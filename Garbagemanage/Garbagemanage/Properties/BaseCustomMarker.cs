using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Garbagemanage.Map
{
    class BaseCustomMarker : IMarkersService
    {
        /// <summary>
        /// 系数待定
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="gMapControl"></param>
        /// <returns></returns>
        public static int getNextIdx(int idx, GMapControl gMapControl)
        {
            return idx + (int)Math.Pow((int)(gMapControl.MaxZoom - gMapControl.Zoom + offset_bound), 1.1);
        }
        /**
         * @create 2023-03-22
         * @comment 获取偏移后的图片中心经纬度
         * @param gMapControl 地图控件
         * @param src 原始地理坐标
         */
        public PointLatLng get_offset_point(GMapControl gMapControl, PointLatLng src)
        {
            try
            {
                GPoint g = gMapControl.FromLatLngToLocal(src);                  // 将地理坐标转换为像素坐标

                g.Y = g.Y + (length >> 1);                                      // 将像素坐标的 Y 轴坐标增加图片长度的一半，使得图片的中心和目标位置重合

                return gMapControl.FromLocalToLatLng((int)g.X, (int)g.Y);       // 将像素坐标转换为地理坐标

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return new PointLatLng(0, 0);
            }

        }
        /**
         * @create 2023-03-22
         * @comment 根据文件路径获得相应数据
         * @param path 图片路径
         */
        public BaseCustomMarker(string path)
        {
            this.path = path;
            bitmap = (Bitmap)Image.FromFile(path);
            length = (int)Math.Sqrt(bitmap.Width * bitmap.Width + bitmap.Height * bitmap.Height);      // 计算图片旋转时扫过面积的最小外接正方形边长

        }
        /**
         * @create 2023-03-23
         * @comment 旋转图片
         * @param angle 旋转角度（角度制）
         */
        public Bitmap rotate(double angle)
        {
            try
            {
                Bitmap bitmap = new Bitmap(length, length);                             // 创建最小的外接正方形
                PointF Pcenter = new PointF(bitmap.Width / 2, bitmap.Height / 2);       // 定义正方形的中心
                Graphics g = Graphics.FromImage(bitmap);                                // 创建画布

                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.TranslateTransform(Pcenter.X, Pcenter.Y);                             // 将画布 (0, 0) 调整至正方形中心
                g.RotateTransform((float)angle % 360);                                  // 旋转画布
                g.TranslateTransform(-Pcenter.X, -Pcenter.Y);                           // 将画布原点恢复

                g.DrawImage(this.bitmap, (length - this.bitmap.Width) >> 1, (length - this.bitmap.Height) >> 1, this.bitmap.Width, this.bitmap.Height);     // 将目标图片写入正方形区域，保证二者的中心重合
                g.Dispose();

                return bitmap;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return bitmap;
            }
        }
        /**
         * @create 2023-03-23
         * @comment 计算图片的旋转角度
         * @param p1, p2, end -> 起点、终点、导航路径的终点
         * @param f 递归条件
         */
        public double get_slope(GMapControl gMapControl, PointLatLng p1, PointLatLng p2, PointLatLng end, bool f)
        {

            GPoint g1 = gMapControl.FromLatLngToLocal(p1);                          // 坐标转换
            GPoint g2 = gMapControl.FromLatLngToLocal(p2);

            if (g2.X == g1.X)                                         // 满足条件就视作两点所在直线平行于 Y 轴
            {
                if (g2.Y == g1.Y)                                                   // 两个点几乎重合 （可能出现在地图 Zoom 很小的时候）
                {
                    if (f) return get_slope(gMapControl, p1, end, end, !f);         // 递归过程只进行一次，即在 p1 p2 几乎重合时直接计算  p1 -> end 的方向
                    return 0;                                                       // 如果依然重合那么就不进行旋转
                }
                return g2.Y > g1.Y ? 90 : 270;
            }
            double k = (double)(g2.Y - g1.Y) / (g2.X - g1.X);                   // 计算斜率
            return g2.X < g1.X ? (Math.Atan(k) * 180 / Math.PI) + 180 : (Math.Atan(k) * 180 / Math.PI);       // 返回角度制结果

        }
        public Bitmap getBitmap() { return bitmap; }
        public string getPath() { return path; }
        public GMapMarker GetGMapMarker()
        {
            return gMapMarker;
        }
        public GMapMarker GetGMapMarker(PointLatLng src, Bitmap bitmap)
        {
            try
            {
                gMapMarker = new GMarkerGoogle(src, bitmap);

            }
            catch (Exception e)
            {
                throw e;
            }

            return GetGMapMarker();
        }
        public GMapMarker GetGMapMarker(GMapControl gMapControl, PointLatLng p2, PointLatLng end)
        {
            return GetGMapMarker(get_offset_point(gMapControl, start), rotate(get_slope(gMapControl, start, p2, end, true)));
        }
        public int setIndexEnd(int index) { indexEnd = index; return indexEnd; }
        public int getIndexEnd() { return indexEnd; }
        public int setIndexStart(int index) { indexStart = index; return indexStart; }
        public int getIndexStart() { return indexStart; }
        public PointLatLng setStart(PointLatLng start)
        {
            this.start = new PointLatLng(start.Lat, start.Lng);
            return this.start;
        }
        public bool IsEmpty() { return start.IsEmpty; }
        public PointLatLng getStart() { return start; }
        
        public static double offset_bound = 1;                                            // 设定的偏移参数，地图 Zoom 越小，路径点的像素坐标越接近，因此判断方向（get_slope）时的 p1 p2 要是路径（points）上距离较远的点（即下标差距较大
        private string path;
        private Bitmap bitmap;
        private int length;
        private GMapMarker gMapMarker = null;
        protected int indexEnd, indexStart;                                               // 终点 下标 
        protected PointLatLng start;                                                      // 起点

    }
}
