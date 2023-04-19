using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbagemanage.Map
{
    interface IMarkersService
    {
        GMapMarker GetGMapMarker();
        GMapMarker GetGMapMarker(PointLatLng src, Bitmap bitmap);
        PointLatLng get_offset_point(GMapControl gMapControl, PointLatLng src);
        Bitmap rotate(double angle);
        Bitmap getBitmap();

        
    }
}
