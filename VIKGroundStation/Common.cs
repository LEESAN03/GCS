using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AGaugeApp;
using System.IO.Ports;
using System.Threading;

using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Net.Sockets;
using System.Xml; // config file
using System.Runtime.InteropServices; // dll imports
using log4net;

using MissionPlanner;
using System.Reflection;

using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
//using System.Windows;

namespace VIKGroundStation
{
    public class Common
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public enum distances
        {
            Meters,
            Feet
        }

        public enum speeds
        {
            meters_per_second,
            fps,
            kph,
            mph,
            knots
        }
        /// <summary>
        /// from libraries\AP_Math\rotations.h
        /// </summary>
        public enum Rotation
        {
            ROTATION_NONE = 0,
            ROTATION_YAW_45,
            ROTATION_YAW_90,
            ROTATION_YAW_135,
            ROTATION_YAW_180,
            ROTATION_YAW_225,
            ROTATION_YAW_270,
            ROTATION_YAW_315,
            ROTATION_ROLL_180,
            ROTATION_ROLL_180_YAW_45,
            ROTATION_ROLL_180_YAW_90,
            ROTATION_ROLL_180_YAW_135,
            ROTATION_PITCH_180,
            ROTATION_ROLL_180_YAW_225,
            ROTATION_ROLL_180_YAW_270,
            ROTATION_ROLL_180_YAW_315,
            ROTATION_ROLL_90,
            ROTATION_ROLL_90_YAW_45,
            ROTATION_ROLL_90_YAW_90,
            ROTATION_ROLL_90_YAW_135,
            ROTATION_ROLL_270,
            ROTATION_ROLL_270_YAW_45,
            ROTATION_ROLL_270_YAW_90,
            ROTATION_ROLL_270_YAW_135,
            ROTATION_PITCH_90,
            ROTATION_PITCH_270,
            ROTATION_MAX
        }
        
        public static bool getFilefromNet(string url, string saveto)
        {
            try
            {
                // this is for mono to a ssl server
                //ServicePointManager.CertificatePolicy = new NoCheckCertificatePolicy(); 

                ServicePointManager.ServerCertificateValidationCallback =
                    new System.Net.Security.RemoteCertificateValidationCallback(
                        (sender, certificate, chain, policyErrors) => { return true; });

                log.Info(url);
                // Create a request using a URL that can receive a post. 
                WebRequest request = WebRequest.Create(url);
                request.Timeout = 10000;
                // Set the Method property of the request to POST.
                request.Method = "GET";
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                log.Info(((HttpWebResponse)response).StatusDescription);
                if (((HttpWebResponse)response).StatusCode != HttpStatusCode.OK)
                    return false;

                if (File.Exists(saveto))
                {
                    DateTime lastfilewrite = new FileInfo(saveto).LastWriteTime;
                    DateTime lasthttpmod = ((HttpWebResponse)response).LastModified;

                    if (lasthttpmod < lastfilewrite)
                    {
                        if (((HttpWebResponse)response).ContentLength == new FileInfo(saveto).Length)
                        {
                            log.Info("got LastModified " + saveto + " " + ((HttpWebResponse)response).LastModified +
                                     " vs " + new FileInfo(saveto).LastWriteTime);
                            response.Close();
                            return true;
                        }
                    }
                }

                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();

                long bytes = response.ContentLength;
                long contlen = bytes;

                byte[] buf1 = new byte[1024];

                if (!Directory.Exists(Path.GetDirectoryName(saveto)))
                    Directory.CreateDirectory(Path.GetDirectoryName(saveto));

                FileStream fs = new FileStream(saveto + ".new", FileMode.Create);

                DateTime dt = DateTime.Now;

                while (dataStream.CanRead && bytes > 0)
                {
                    Application.DoEvents();
                    log.Debug(saveto + " " + bytes);
                    int len = dataStream.Read(buf1, 0, buf1.Length);
                    bytes -= len;
                    fs.Write(buf1, 0, len);
                }

                fs.Close();
                dataStream.Close();
                response.Close();

                File.Delete(saveto);
                File.Move(saveto + ".new", saveto);

                return true;
            }
            catch (Exception ex)
            {
                log.Info("getFilefromNet(): " + ex.ToString());
                return false;
            }
        }

        //from px4firmwareplugin.cc
        enum PX4_CUSTOM_MAIN_MODE
        {
            PX4_CUSTOM_MAIN_MODE_MANUAL = 1,
            PX4_CUSTOM_MAIN_MODE_ALTCTL,
            PX4_CUSTOM_MAIN_MODE_POSCTL,
            PX4_CUSTOM_MAIN_MODE_AUTO,
            PX4_CUSTOM_MAIN_MODE_ACRO,
            PX4_CUSTOM_MAIN_MODE_OFFBOARD,
            PX4_CUSTOM_MAIN_MODE_STABILIZED,
            PX4_CUSTOM_MAIN_MODE_RATTITUDE
        }

        enum PX4_CUSTOM_SUB_MODE_AUTO
        {
            PX4_CUSTOM_SUB_MODE_AUTO_READY = 1,
            PX4_CUSTOM_SUB_MODE_AUTO_TAKEOFF,
            PX4_CUSTOM_SUB_MODE_AUTO_LOITER,
            PX4_CUSTOM_SUB_MODE_AUTO_MISSION,
            PX4_CUSTOM_SUB_MODE_AUTO_RTL,
            PX4_CUSTOM_SUB_MODE_AUTO_LAND,
            PX4_CUSTOM_SUB_MODE_AUTO_RTGS
        }        
    }

    /// <summary>
    /// used to override the drawing of the waypoint box bounding
    /// </summary>
    [Serializable]
    public class GMapMarkerRect : GMapMarker
    {
        public Pen Pen = new Pen(Brushes.White, 2);

        public Color Color
        {
            get { return Pen.Color; }
            set
            {
                if (!initcolor.HasValue) initcolor = value;
                Pen.Color = value;
            }
        }

        Color? initcolor = null;

        public GMapMarker InnerMarker;

        public int wprad = 0;

        public void ResetColor()
        {
            if (initcolor.HasValue)
                Color = initcolor.Value;
            else
                Color = Color.White;
        }

        public GMapMarkerRect(PointLatLng p)
            : base(p)
        {
            Pen.DashStyle = DashStyle.Dash;

            // do not forget set Size of the marker
            // if so, you shall have no event on it ;}
            Size = new System.Drawing.Size(50, 50);
            Offset = new System.Drawing.Point(-Size.Width/2, -Size.Height/2 - 20);
        }

        public override void OnRender(Graphics g)
        {
            base.OnRender(g);

            if (wprad == 0 || Overlay.Control == null)
                return;

            // if we have drawn it, then keep that color
            if (!initcolor.HasValue)
                Color = Color.White;

            // undo autochange in mouse over
            //if (Pen.Color == Color.Blue)
            //  Pen.Color = Color.White;

            double width =
                (Overlay.Control.MapProvider.Projection.GetDistance(Overlay.Control.FromLocalToLatLng(0, 0),
                    Overlay.Control.FromLocalToLatLng(Overlay.Control.Width, 0))*1000.0);
            double height =
                (Overlay.Control.MapProvider.Projection.GetDistance(Overlay.Control.FromLocalToLatLng(0, 0),
                    Overlay.Control.FromLocalToLatLng(Overlay.Control.Height, 0))*1000.0);
            double m2pixelwidth = Overlay.Control.Width/width;
            double m2pixelheight = Overlay.Control.Height/height;

            GPoint loc = new GPoint((int) (LocalPosition.X - (m2pixelwidth*wprad*2)), LocalPosition.Y);
                // MainMap.FromLatLngToLocal(wpradposition);

            if (m2pixelheight > 0.5)
                g.DrawArc(Pen,
                    new System.Drawing.Rectangle(
                        LocalPosition.X - Offset.X - (int) (Math.Abs(loc.X - LocalPosition.X)/2),
                        LocalPosition.Y - Offset.Y - (int) Math.Abs(loc.X - LocalPosition.X)/2,
                        (int) Math.Abs(loc.X - LocalPosition.X), (int) Math.Abs(loc.X - LocalPosition.X)), 0, 360);
        }
    }

    [Serializable]
    public class GMapMarkerADSBPlane : GMapMarker
    {
        const float rad2deg = (float) (180/Math.PI);
        const float deg2rad = (float) (1.0/rad2deg);

       // private readonly Bitmap icon = global::MissionPlanner.Properties.Resources.FW_icons_2013_logos_01;

        float heading = 0;

        public GMapMarkerADSBPlane(PointLatLng p, float heading)
            : base(p)
        {
            //icon = new Bitmap(icon, new Size(40, 40));
            //this.heading = heading;
            //Size = icon.Size;
        }

        public override void OnRender(Graphics g)
        {
            Matrix temp = g.Transform;
            g.TranslateTransform(LocalPosition.X, LocalPosition.Y);

            g.RotateTransform(-Overlay.Control.Bearing);

            try
            {
                g.RotateTransform(heading);
            }
            catch
            {
            }
            //g.DrawImageUnscaled(icon, icon.Width/-2, icon.Height/-2);

            g.Transform = temp;
        }
    }

    [Serializable]
    public class GMapMarkerWP : GMarkerGoogle
    {
        string wpno = "";
        public bool selected = false;
        SizeF txtsize = SizeF.Empty;
        static Dictionary<string, Bitmap> fontBitmaps = new Dictionary<string, Bitmap>();
        static Font font;

        public GMapMarkerWP(PointLatLng p, string wpno, GMarkerGoogleType type, int num)
            : base(p, type)
        {
            this.wpno = wpno;
            if (font == null)
            {
                /*
                if(num == 1)
                    font = new Font("宋", 12);
                else if(num == 2 || num == 3)*/
                    font = new Font("宋", 8);
            }

            Bitmap temp = new Bitmap(100, 40, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(temp))
            {
                txtsize = g.MeasureString(wpno, font);
                //if (num == 1)
                {
                    g.DrawString(wpno, font, Brushes.White, new PointF(0, 0));
                }
                /*else if(num == 2)
                {
                    g.DrawString(wpno, font, Brushes.Orange, new PointF(0, 0));
                }                
                else if (num == 3)
                {
                    g.DrawString(wpno, font, Brushes.Blue, new PointF(0, 0));
                }*/
            }
            fontBitmaps[wpno] = temp;
        }
        public GMapMarkerWP(PointLatLng p, GMarkerGoogleType type, int num)
            : base(p, type)
        {            
            if (font == null)
                font = new Font("宋", 14);

            // if (!fontBitmaps.ContainsKey(wpno))
            {
                Bitmap temp = new Bitmap(100, 40, PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(temp))
                {
                    txtsize = g.MeasureString(wpno, font);
                    if (num == 1)
                        g.DrawString(wpno, font, Brushes.Red, new PointF(0, 0));
                    else
                    {
                        g.DrawString(wpno, font, Brushes.Black, new PointF(0, 0));
                    }
                }
                fontBitmaps[wpno] = temp;
            }
        }
        public override void OnRender(Graphics g)
        {
            if (selected)
            {
                g.FillEllipse(Brushes.Red, new Rectangle(this.LocalPosition, this.Size));
                g.DrawArc(Pens.Red, new Rectangle(this.LocalPosition, this.Size), 0, 360);
            }

            base.OnRender(g);

            var midw = LocalPosition.X + 10;
            var midh = LocalPosition.Y + 3;

            if (txtsize.Width > 15)
                midw -= 4;

            // if (IsMouseOver)
            g.DrawImageUnscaled(fontBitmaps[wpno], midw, midh);
        }
    }

    [Serializable]
    public class GMapMarkerRover : GMapMarker
    {
        const float rad2deg = (float) (180/Math.PI);
        const float deg2rad = (float) (1.0/rad2deg);

        //static readonly System.Drawing.Size SizeSt =
        //    new System.Drawing.Size(global::MissionPlanner.Properties.Resources.rover.Width,
        //        global::MissionPlanner.Properties.Resources.rover.Height);

        float heading = 0;
        float cog = -1;
        float target = -1;
        float nav_bearing = -1;

        public GMapMarkerRover(PointLatLng p, float heading, float cog, float nav_bearing, float target)
            : base(p)
        {
            this.heading = heading;
            this.cog = cog;
            this.target = target;
            this.nav_bearing = nav_bearing;
           // Size = SizeSt;
        }

        public override void OnRender(Graphics g)
        {
            Matrix temp = g.Transform;
            g.TranslateTransform(LocalPosition.X, LocalPosition.Y);

            g.RotateTransform(-Overlay.Control.Bearing);

            int length = 500;
            // anti NaN
            try
            {
                g.DrawLine(new Pen(Color.Red, 2), 0.0f, 0.0f, (float) Math.Cos((heading - 90)*deg2rad)*length,
                    (float) Math.Sin((heading - 90)*deg2rad)*length);
            }
            catch
            {
            }
            g.DrawLine(new Pen(Color.Green, 2), 0.0f, 0.0f, (float) Math.Cos((nav_bearing - 90)*deg2rad)*length,
                (float) Math.Sin((nav_bearing - 90)*deg2rad)*length);
            g.DrawLine(new Pen(Color.Black, 2), 0.0f, 0.0f, (float) Math.Cos((cog - 90)*deg2rad)*length,
                (float) Math.Sin((cog - 90)*deg2rad)*length);
            g.DrawLine(new Pen(Color.Orange, 2), 0.0f, 0.0f, (float) Math.Cos((target - 90)*deg2rad)*length,
                (float) Math.Sin((target - 90)*deg2rad)*length);
            // anti NaN

            try
            {
                g.RotateTransform(heading);
            }
            catch
            {
            }
            //g.DrawImageUnscaled(global::MissionPlanner.Properties.Resources.rover,
            //    global::MissionPlanner.Properties.Resources.rover.Width/-2,
            //    global::MissionPlanner.Properties.Resources.rover.Height/-2);

            g.Transform = temp;
        }
    }

    [Serializable]
    public class GMapMarkerPlane : GMapMarker
    {
        const float rad2deg = (float) (180/Math.PI);
        const float deg2rad = (float) (1.0/rad2deg);
        public  Bitmap icon = Properties.Resources.planetracker_lost;// new Bitmap(Directory.GetCurrentDirectory()+"/Images/planetracker.png");

        float heading = 0;
        float cog = -1;
        float target = -1;
        float nav_bearing = -1;
        float radius = 0;
        //int num = 0;
        public GMapMarkerPlane(PointLatLng p, float heading, float cog, float nav_bearing, float target, float radius)
            : base(p)
        {
            this.heading = heading;
            this.cog = cog;
            this.target = target;
            this.nav_bearing = nav_bearing;
            this.radius = radius;
            
            Size = icon.Size;            
        }

        public override void OnRender(Graphics g)
        {
            Matrix temp = g.Transform;

            g.TranslateTransform(LocalPosition.X, LocalPosition.Y);
            g.RotateTransform(-Overlay.Control.Bearing);

            int length = 5;
            // anti NaN
            try
            {
                g.DrawLine(new Pen(Color.Red, 2), 0.0f, 0.0f, (float) Math.Cos((heading - 90)*deg2rad)*length,
                    (float) Math.Sin((heading - 90)*deg2rad)*length);
            }
            catch
            {
            }
            try
            {
                g.DrawLine(new Pen(Color.Green, 2), 0.0f, 0.0f, (float)Math.Cos((nav_bearing - 90) * deg2rad) * length,
                    (float)Math.Sin((nav_bearing - 90) * deg2rad) * length);
                g.DrawLine(new Pen(Color.Black, 2), 0.0f, 0.0f, (float)Math.Cos((cog - 90) * deg2rad) * length,
                    (float)Math.Sin((cog - 90) * deg2rad) * length);
                g.DrawLine(new Pen(Color.Orange, 2), 0.0f, 0.0f, (float)Math.Cos((target - 90) * deg2rad) * length,
                    (float)Math.Sin((target - 90) * deg2rad) * length);
            }
            catch { }
                // anti NaN
            try
            {
                float desired_lead_dist = 100;

                double width =
                    (Overlay.Control.MapProvider.Projection.GetDistance(Overlay.Control.FromLocalToLatLng(0, 0),
                        Overlay.Control.FromLocalToLatLng(Overlay.Control.Width, 0))*1000.0);
                double m2pixelwidth = Overlay.Control.Width/width;

                float alpha = ((desired_lead_dist * (float)m2pixelwidth) / radius) * rad2deg;

                if (radius < -1)
                {
                    // fixme 

                    float p1 = (float)Math.Cos((cog) * deg2rad) * radius + radius;

                    float p2 = (float)Math.Sin((cog) * deg2rad) * radius + radius;

                    g.DrawArc(new Pen(Color.HotPink, 2), p1, p2, Math.Abs(radius) * 2, Math.Abs(radius) * 2, cog, alpha);
                }

                else if (radius > 1)
                {
                    // correct

                    float p1 = (float)Math.Cos((cog - 180) * deg2rad) * radius + radius;

                    float p2 = (float)Math.Sin((cog - 180) * deg2rad) * radius + radius;

                    g.DrawArc(new Pen(Color.HotPink, 2), -p1, -p2, radius * 2, radius * 2, cog - 180, alpha);
                }
            }
            catch
            {
            }

            try
            {
                g.RotateTransform(heading);
            }
            catch
            {
            }

            g.DrawImageUnscaled(icon, -35, -35);
            g.Transform = temp;
        }
    }

    [Serializable]
    public class GMapMarkerQuad : GMapMarker
    {
        const float rad2deg = (float) (180/Math.PI);
        const float deg2rad = (float) (1.0/rad2deg);

        //private readonly Bitmap icon = global::MissionPlanner.Properties.Resources.quadicon;

        float heading = 0;
        float cog = -1;
        float target = -1;
        private int sysid = -1;

        public GMapMarkerQuad(PointLatLng p, float heading, float cog, float target, int sysid)
            : base(p)
        {
            this.heading = heading;
            this.cog = cog;
            this.target = target;
            this.sysid = sysid;
          //  Size = icon.Size;
        }

        public override void OnRender(Graphics g)
        {
            Matrix temp = g.Transform;
            g.TranslateTransform(LocalPosition.X, LocalPosition.Y);

            int length = 500;
            // anti NaN
            try
            {
                g.DrawLine(new Pen(Color.Red, 2), 0.0f, 0.0f, (float) Math.Cos((heading - 90)*deg2rad)*length,
                    (float) Math.Sin((heading - 90)*deg2rad)*length);
            }
            catch
            {
            }
            //g.DrawLine(new Pen(Color.GreenRed, 2), 0.0f, 0.0f, (float)Math.Cos((nav_bearing - 90) * deg2rad) * length, (float)Math.Sin((nav_bearing - 90) * deg2rad) * length);
            g.DrawLine(new Pen(Color.Black, 2), 0.0f, 0.0f, (float) Math.Cos((cog - 90)*deg2rad)*length,
                (float) Math.Sin((cog - 90)*deg2rad)*length);
            g.DrawLine(new Pen(Color.Orange, 2), 0.0f, 0.0f, (float) Math.Cos((target - 90)*deg2rad)*length,
                (float) Math.Sin((target - 90)*deg2rad)*length);
            // anti NaN
            try
            {
                g.RotateTransform(heading);
            }
            catch
            {
            }

           // g.DrawImageUnscaled(icon, icon.Width/-2 + 2, icon.Height/-2);

            g.DrawString(sysid.ToString(), new Font(FontFamily.GenericMonospace, 15, FontStyle.Bold), Brushes.Red, -8,
                -8);

            g.Transform = temp;
        }
    }

    [Serializable]
    public class GMapMarkerHeli : GMapMarker
    {
        const float rad2deg = (float) (180/Math.PI);
        const float deg2rad = (float) (1.0/rad2deg);

       // private readonly Bitmap icon = global::MissionPlanner.Properties.Resources.heli;

        float heading = 0;
        float cog = -1;
        float target = -1;

        public GMapMarkerHeli(PointLatLng p, float heading, float cog, float target)
            : base(p)
        {
            this.heading = heading;
            this.cog = cog;
            this.target = target;
           // Size = icon.Size;
        }

        public override void OnRender(Graphics g)
        {
            Matrix temp = g.Transform;
            g.TranslateTransform(LocalPosition.X, LocalPosition.Y);

            int length = 500;
            // anti NaN
            try
            {
                g.DrawLine(new Pen(Color.Red, 2), 0.0f, 0.0f, (float) Math.Cos((heading - 90)*deg2rad)*length,
                    (float) Math.Sin((heading - 90)*deg2rad)*length);
            }
            catch
            {
            }
            //g.DrawLine(new Pen(Color.GreenRed, 2), 0.0f, 0.0f, (float)Math.Cos((nav_bearing - 90) * deg2rad) * length, (float)Math.Sin((nav_bearing - 90) * deg2rad) * length);
            g.DrawLine(new Pen(Color.Black, 2), 0.0f, 0.0f, (float) Math.Cos((cog - 90)*deg2rad)*length,
                (float) Math.Sin((cog - 90)*deg2rad)*length);
            g.DrawLine(new Pen(Color.Orange, 2), 0.0f, 0.0f, (float) Math.Cos((target - 90)*deg2rad)*length,
                (float) Math.Sin((target - 90)*deg2rad)*length);
            // anti NaN
            try
            {
                g.RotateTransform(heading);
            }
            catch
            {
            }
           // g.DrawImageUnscaled(icon, icon.Width/-2 + 2, icon.Height/-2);

            g.Transform = temp;
        }
    }

    [Serializable]
    public class GMapMarkerAntennaTracker : GMapMarker
    {
        const float rad2deg = (float) (180/Math.PI);
        const float deg2rad = (float) (1.0/rad2deg);

        //private readonly Bitmap icon = global::MissionPlanner.Properties.Resources.Antenna_Tracker_01;

        float heading = 0;
        private float target = 0;

        public GMapMarkerAntennaTracker(PointLatLng p, float heading, float target)
            : base(p)
        {
           // Size = icon.Size;
            this.heading = heading;
            this.target = target;
        }

        public override void OnRender(Graphics g)
        {
            Matrix temp = g.Transform;
            g.TranslateTransform(LocalPosition.X, LocalPosition.Y);

            int length = 500;

            try
            {
                // heading
                g.DrawLine(new Pen(Color.Red, 2), 0.0f, 0.0f, (float) Math.Cos((heading - 90)*deg2rad)*length,
                    (float) Math.Sin((heading - 90)*deg2rad)*length);

                // target
                g.DrawLine(new Pen(Color.Orange, 2), 0.0f, 0.0f, (float) Math.Cos((target - 90)*deg2rad)*length,
                    (float) Math.Sin((target - 90)*deg2rad)*length);
            }
            catch
            {
            }

            g.Transform = temp;
        }
    }


    class NoCheckCertificatePolicy : ICertificatePolicy
    {
        public bool CheckValidationResult(ServicePoint srvPoint, X509Certificate certificate, WebRequest request,
            int certificateProblem)
        {
            return true;
        }
    }
}