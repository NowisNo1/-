using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Garbagemanage.Map
{
    class CustomMakersManager
    {
        public CustomMakersManager()
        {
            routePoints = new List<PointLatLng>();
            activeCustomMarkers = new List<ActiveCustomMarker>();
            staticCustomMarkers = new List<StaticCustomMarker>(); 
        }
        public CustomMakersManager(List<ActiveCustomMarker> activeCustomMarkers)
        {
            routePoints = new List<PointLatLng>();
            staticCustomMarkers = new List<StaticCustomMarker>();
            this.activeCustomMarkers = new List<ActiveCustomMarker>();
            foreach (var item in activeCustomMarkers) this.activeCustomMarkers.Add(new ActiveCustomMarker(item.getPath()));
        }
        public CustomMakersManager(List<PointLatLng> routePoints)
        {
            this.routePoints = new List<PointLatLng>();
            activeCustomMarkers = new List<ActiveCustomMarker>();
            staticCustomMarkers = new List<StaticCustomMarker>();
            foreach (var item in routePoints) this.routePoints.Add(new PointLatLng(item.Lat, item.Lng));
        }
        public CustomMakersManager(List<StaticCustomMarker> staticCustomMarkers)
        {
            this.staticCustomMarkers = new List<StaticCustomMarker>();
            routePoints = new List<PointLatLng>();
            activeCustomMarkers = new List<ActiveCustomMarker>();
            foreach (var item in staticCustomMarkers) this.staticCustomMarkers.Add(new StaticCustomMarker(item.getPath()));
        }
        public CustomMakersManager(List<ActiveCustomMarker> activeCustomMarkers, List<StaticCustomMarker> staticCustomMarkers, List<PointLatLng> routePoints)
        {
            this.activeCustomMarkers = new List<ActiveCustomMarker>();
            this.staticCustomMarkers = new List<StaticCustomMarker>();
            this.routePoints = new List<PointLatLng>();
            foreach (var item in activeCustomMarkers) this.activeCustomMarkers.Add(new ActiveCustomMarker(item.getPath()));
            foreach (var item in staticCustomMarkers) this.staticCustomMarkers.Add(new StaticCustomMarker(item.getPath()));
            foreach (var item in routePoints) this.routePoints.Add(new PointLatLng(item.Lat, item.Lng));
        }
        public ActiveCustomMarker Add(ActiveCustomMarker activeCustomMarker) { activeCustomMarkers.Add(activeCustomMarker); return activeCustomMarker; }

        public StaticCustomMarker Add(StaticCustomMarker staticCustomMarker) { staticCustomMarkers.Add(staticCustomMarker); return staticCustomMarker; }

        public void refresh_active_markers(GMapOverlay gMapOverlay, GMapControl gMapControl, int interval)
        {
            try
            {
                if (interval > 0)
                {
                    foreach (var marker in activeCustomMarkers)
                {
                    int tick_now = marker.TimeUp(interval);
                    int index = marker.getIndexEnd();
                    if (marker.getIndexEnd() < marker.getIndexStart())
                    {
                        Console.WriteLine("出现错误");
                    }
                    if (index == 0 || index >= routePoints.Count) marker.setPosition(routePoints[0], gMapControl, routePoints.Count); // 重置
                    index = marker.getIndexEnd();

                    if (tick_now == 0)
                    {
                        marker.resetSegment(gMapControl, routePoints[index]);
                        gMapOverlay.Markers.Add(marker.nextPos(routePoints[index], gMapControl, routePoints.Count));
                    }
                    else
                    {
                        gMapOverlay.Markers.Add(marker.GetGMapMarker());
                    }
                }
                }else
                {
               
                    foreach (var marker in activeCustomMarkers)
                    {
                        if (marker.getIndexEnd() < marker.getIndexStart())
                        {
                            Console.WriteLine("出现错误");
                        }
                        if (marker.IsEmpty())
                        {
                            marker.setPosition(routePoints[0], gMapControl, routePoints.Count);
                        }
                        int targetIndex = marker.getTargetIndexEnd(gMapControl);
                        
                        if (targetIndex == 0 || targetIndex >= routePoints.Count) targetIndex = routePoints.Count - 1;
                        marker.setIndexEnd(gMapControl, routePoints[targetIndex]);
                        int index = marker.getIndexEnd();
                        if (index == 0 || index >= routePoints.Count) marker.setPosition(routePoints[0], gMapControl, routePoints.Count); // 重置
                        index = marker.getIndexEnd();
                        marker.resetSegment(gMapControl, routePoints[index]);
                        gMapOverlay.Markers.Add(marker.GetGMapMarker(gMapControl, routePoints[index], routePoints[routePoints.Count - 1]));
                    }
                }  
            }
            catch (OverflowException e)
            {
                throw e;
            }
        }
        public void refresh_static_markers(GMapOverlay gMapOverlay, GMapControl gMapControl)
        {
            foreach (var marker in staticCustomMarkers)
            {
                try
                {
                    marker.setIndex(gMapControl, routePoints.Count);
                    gMapOverlay.Markers.Add(marker.GetGMapMarker(gMapControl, routePoints[marker.getIndexEnd()], routePoints[routePoints.Count - 1]));
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public GMapOverlay refresh_markers(GMapOverlay gMapOverlay, GMapControl gMapControl, int interval)
        {
            _mutexLock.WaitOne();
            try
            {
                if (routePoints.Count <= 1) return gMapOverlay;
                //refresh_static_markers(gMapOverlay, gMapControl);
                refresh_active_markers(gMapOverlay, gMapControl, interval);
                
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                _mutexLock.ReleaseMutex();
            }
           
            return gMapOverlay;
        }
        
        private List<PointLatLng> routePoints;
        private List<ActiveCustomMarker> activeCustomMarkers;
        private List<StaticCustomMarker> staticCustomMarkers;
        protected readonly Mutex _mutexLock = new Mutex();
    }
}
