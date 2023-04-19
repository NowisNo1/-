using GMap.NET;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Garbagemanage.Map
{
    class StaticCustomMarker : BaseCustomMarker
    {
        public StaticCustomMarker(string path): base(path)
        {
            Console.WriteLine("静态 marker 从 " + path + "获取图片资源");
        }
        public int setIndex(GMapControl gMapControl, int length)
        {
            indexEnd = getNextIdx(0, gMapControl);
            indexEnd = indexEnd < length ? indexEnd : length - 1;
            
            return indexEnd;
        }
        

    }
}
