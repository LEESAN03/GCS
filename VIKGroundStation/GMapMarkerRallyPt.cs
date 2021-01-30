using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace MissionPlanner.Utilities
{
    [Serializable]
    public class GMapMarkerRallyPt : GMapMarker
    {
        public float? Bearing;

        public int Alt { get; set; }

        public GMapMarkerRallyPt(PointLatLng p)
            : base(p)
        {         
           Offset = new Point(-10, -40);
        }

        static readonly Point[] Arrow = new Point[]
        {new Point(-7, 7), new Point(0, -22), new Point(7, 7), new Point(0, 2)};

        public override void OnRender(Graphics g)
        {
#if !Pocketnum          

#else
    //    DrawImageUnscaled(g, Resources.shadow50, LocalPosition.X, LocalPosition.Y);
            DrawImageUnscaled(g, Resources.marker, LocalPosition.X, LocalPosition.Y);
#endif
        }
    }
}