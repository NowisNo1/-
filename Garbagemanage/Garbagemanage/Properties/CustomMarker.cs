using GMap.NET;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using GMap.NET.WindowsForms;

namespace Garbagemanage.Map
{
    class CustomMarker
    {
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

                g.Y = g.Y + (this.length >> 1);                                 // 将像素坐标的 Y 轴坐标增加图片长度的一半，使得图片的中心和目标位置重合

                return gMapControl.FromLocalToLatLng((int)g.X, (int)g.Y);       // 将像素坐标转换为地理坐标

            }catch(Exception e)
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
        public CustomMarker(string path)                                  
        {       
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
                Graphics g = Graphics.FromImage((Image)bitmap);                         // 创建画布

                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.TranslateTransform(Pcenter.X, Pcenter.Y);                             // 将画布 (0, 0) 调整至正方形中心
                g.RotateTransform((int)angle % 360);                                    // 旋转画布
                g.TranslateTransform(-Pcenter.X, -Pcenter.Y);                           // 将画布原点恢复

                g.DrawImage(this.bitmap, (length - this.bitmap.Width) >> 1, (length - this.bitmap.Height) >> 1, this.bitmap.Width, this.bitmap.Height);     // 将目标图片写入正方形区域，保证二者的中心重合
                g.Dispose();

                return bitmap;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return this.bitmap;
            } 
        }

        public Bitmap getBitmap() { return this.bitmap; }

        private Bitmap bitmap;
        private int length;

    }
}
