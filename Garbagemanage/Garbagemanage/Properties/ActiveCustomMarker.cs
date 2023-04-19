using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbagemanage.Map
{
    class ActiveCustomMarker : BaseCustomMarker
    {
        public ActiveCustomMarker(string path): base(path)
        {
            hold_on = 0;
            timeout = 0;
            tick_now = 0;
            interval = 0;
            slope = 0;
            newSegment = true;
            segmentSlope = 0;
            speed = minimalSpeed;
            indexStart = 0;
            Console.WriteLine("动态 marker 从 " + path + "获取图片资源");
        }
        
        public PointLatLng setPosition(PointLatLng point, GMapControl gMapControl, int length)
        {
            indexStart = 0;
            indexEnd = getNextIdx(0, gMapControl);
            start = new PointLatLng(point.Lat, point.Lng);
            segmentStart = new PointLatLng(point.Lat, point.Lng);
            return start;
        }
        
        public GMapMarker setGMapMarker(GMapControl gMapControl, PointLatLng p2)
        {
            return GetGMapMarker(get_offset_point(gMapControl, start), rotate(get_slope(gMapControl, start, p2, p2, false)));
        }

        public GMapMarker nextPos(PointLatLng end, GMapControl gMapControl, int length)
        {
            GPoint START = gMapControl.FromLatLngToLocal(start);
            GPoint END = gMapControl.FromLatLngToLocal(end);
            
            int dy = (int)(END.Y - START.Y);
            int dx = (int)(END.X - START.X);

            double distance = Math.Sqrt(dx * dx + dy * dy);

            speed *= (1 + coefficient);
            speed = speed >= 20 ? 20 : speed;

            if(Math.Abs(speed - distance) <= 0.0001 || speed > distance)                  // 一帧可以走完
            {
                
                newSegment = true;
                segmentSlope = 0;
                slope = get_slope(gMapControl, segmentStart, end, end, false);
                
                indexStart = indexEnd;
                indexEnd += getNextIdx(0, gMapControl);


                PointLatLng point = get_offset_point(gMapControl, end);
                if (point.Lng == 0 && point.Lng == 0)
                {
                    Console.WriteLine("未获取到偏移后的地理位置");
                    return GetGMapMarker();
                }
                Bitmap bitmap = rotate(slope);
                start = end;
                return GetGMapMarker(point, bitmap);
                
            }
            else
            {
                if (newSegment)
                {
                    segmentStart = new PointLatLng(start.Lat, start.Lng);
                    segmentSlope = get_slope(gMapControl, start, end, end, false);
                    slope = segmentSlope;
                    newSegment = false;

                }else
                {
                    slope = 0.8 * get_slope(gMapControl, start, end, end, false) + 0.2 * segmentSlope;
                }
                
                double nx = START.X + adjust(Math.Cos(slope / 180 * Math.PI), speed);
                double ny = START.Y + adjust(Math.Sin(slope / 180 * Math.PI), speed);
 
                PointLatLng res = gMapControl.FromLocalToLatLng((int)nx, (int)ny);
                start = new PointLatLng(res.Lat, res.Lng);
                
                PointLatLng point = get_offset_point(gMapControl, start);
                if (point.Lng == 0 && point.Lng == 0)
                {
                    Console.WriteLine("未获取到偏移后的地理位置");
                    return GetGMapMarker();
                }
                return GetGMapMarker(point, rotate(slope));
            }
        }
        protected static double adjust(double value, double speed)
        {
            double res = speed * value;
            
            if (Math.Abs(res) <= 0.001)
            {
                return 0;
            }else
            {
                if(res > 0)
                {
                    return Math.Ceiling(res);
                }
                return Math.Floor(res);
            }
        }

        public int SetTimeout(int timeout)
        {
            this.timeout = timeout;
            return this.timeout;
        }
        public int SetInterval(int interval)
        {
            this.interval = interval <= minimalInterval ? minimalInterval : interval;
            return this.interval;
        }
        public int TimeUp(int interval)
        {
            tick_now += interval;
            int ret;
            if (tick_now < timeout)
            {
                return -1;
            }
            else
            {
                timeout = 0;
                tick_now = interval;
                ret = 0;
            }
            tick_now = tick_now >= this.interval ? 0 : tick_now;
            return ret;
        }
        public void resetSegment(GMapControl gMapControl, PointLatLng end) {

            segmentSlope = get_slope(gMapControl, start, end, end, false);
        }

        public int getTargetIndexEnd(GMapControl gMapControl)
        {
            return getNextIdx(indexStart, gMapControl);
        }
        public int setIndexEnd(GMapControl gMapControl, PointLatLng targetIndex)
        {
            
            GPoint tarIndex = gMapControl.FromLatLngToLocal(targetIndex);
            GPoint start = gMapControl.FromLatLngToLocal(this.start);
            GPoint segmentStart = gMapControl.FromLatLngToLocal(this.segmentStart);

            Point vector_target2segment = new Point((int)(segmentStart.X - tarIndex.X), (int)(segmentStart.Y - tarIndex.Y));
            Point vector_target2start = new Point((int)(start.X - tarIndex.X), (int)(start.Y - tarIndex.Y));

            int dot = vector_target2segment.X * vector_target2start.X + vector_target2segment.Y * vector_target2start.Y;
           
            if (dot >= 0)
            {
                indexEnd = getNextIdx(indexStart, gMapControl);
            }
            
            return indexEnd;

        }

        
        private bool newSegment;
        private PointLatLng segmentStart;                           // 斜率改变
        private double segmentSlope;
        private double slope;
        private static double minimalSpeed = 4;                     // 一次位移 10 px
        private static double coefficient = 0;                      // 加速度
        private static int minimalInterval = 20;                    // 一次位移 / ms
        private double speed;                                       // px  / 一次位移
        private int interval;                                       // 移动间隔（ms）
        private int tick_now;                                       // 已经静止时长 (ms)
        private int hold_on;                                        // 已经停止时长 (ms)
        private int timeout;                                        // 需要停止的时长
    }
}
