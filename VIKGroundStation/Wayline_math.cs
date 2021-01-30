using System;
using System.Collections.Generic;
using System.Linq;

namespace VIKGroundStation
{
    class Wayline_math
    {
        private Wayline_math() { }
        static Wayline_math instance = new Wayline_math();
        public static Wayline_math getInstance()
        {
            return instance;
        }
        
        class lents
        {
            public int steps;
            public double lats;
            public lents(int steps, double lats)
            {
                this.steps = steps;
                this.lats = lats;
            }
        }
        private Points transform(double x, double y, double tx, double ty, double deg, double sx, double sy)
        {
            deg = deg * Math.PI / 180;
            if (0 != sy)
                sy = 1;
            if (0 != sx)
                sx = 1;
            return new Points(sx * ((x - tx) * Math.Cos(deg) - (y - ty) * Math.Sin(deg)) + tx, sy * ((x - tx) * Math.Sin(deg) + (y - ty) * Math.Cos(deg)) + ty);
        }

        private Points calcPointssInLineWithY(Points p1, Points p2, double y)
        {
            double s = p1.y - p2.y;
            double x;
            if (s == 0)
            {
                x = (y - p1.y) * (p1.x - p2.x) / s + p1.x;
            }
            else
            {
                return null;
            }

            /**判断x是否在p1,p2在x轴的投影里，不是的话返回false*/
            if (x > p1.x && x > p2.x)
            {
                return null;
            }
            if (x < p1.x && x < p2.x)
            {
                return null;
            }
            return new Points(x, y);
        }


        /**@method 创建多边形外接矩形
         * @param {Array} latlngs - 格式为[{lat,lng}]的经纬度数组，多边形的顶点集合
         * @return {Array} .rect - 返回外接矩形四顶点
         * @return {Object} .center - 返回外接矩形的中心的
         */
        private List<Points> createPolygonBounds(List<Points> latlngs)
        {
            List<Double> lats = new List<Double>();
            List<Double> lngs = new List<Double>();
            List<Points> Pointsss = new List<Points>();
            for (int i = 0; i < latlngs.Count; i++)
            {
                lats.Add(latlngs[i].x);
                lngs.Add(latlngs[i].y);
            }
            double maxLat = lats.Max();
            double maxLng = lngs.Max();
            double minLat = lats.Min();
            double minLng = lngs.Min();
            
            Pointsss.Add(new Points((maxLat + minLat) / 2.0, (maxLng + minLng) / 2.0));
            Pointsss.Add(new Points(maxLat, minLng));//西北
            Pointsss.Add(new Points(maxLat, maxLng));//东北
            Pointsss.Add(new Points(minLat, maxLng));//东南
            Pointsss.Add(new Points(minLat, minLng));//西南
            return Pointsss;
        }

        private List<Points> createRotatePolygon(List<Points> latlngs, List<Points> bounds, double rotate)
        {
            List<Points> res = new List<Points>();
            Points a, b;
            Points c = bounds[0];
            for (int i = 0; i < latlngs.Count; i++)
            {
                a = latlngs[i];
                b = transform(a.x, a.y, c.x, c.y, rotate, 1, 1);
                res.Add(b);
            }
            return res;
        }

        private lents createLats(List<Points> bounds, double space)
        {
            Points nw = bounds[1];
            //Log.e("guo","nw："+bounds.get(1).x+" nw"+bounds.get(1).y);
            Points sw = bounds[4];
            //Log.e("guo","sw："+bounds.get(4).x+" sw"+bounds.get(4).y);
            double distance = distances(nw, sw);

            int steps = (int)(distance / space);
            double lats = (nw.x - sw.x) / steps;
            return new lents(steps, lats);
        }

        private double distances(Points p1, Points p2)
        {
            return Math.Sqrt(Math.Pow((p1.x - p2.x), 2) + Math.Pow((p1.y - p2.y), 2));
        }

        private Points createInlinePointss(Points p1, Points p2, double y)
        {
            double s = p1.y - p2.y;
            double x;
            if (s != 0)
            {
                x = (y - p1.y) * (p1.x - p2.x) / s + p1.x;
            }
            else
            {
                return null;
            }
            if (x > p1.x && x > p2.x)
            {
                return null;
            }
            if (x < p1.x && x < p2.x)
            {
                return null;
            }
            return new Points(x, y);
        }


        //public List<Pointss> getLine()

        public List<Points> setPointsss(List<Points> polygon, double rotate, double space)
        {
            List<Points> PointsssList = new List<Points>();
            List<Points> bounds = createPolygonBounds(polygon);
            List<Points> rPolygon = createRotatePolygon(polygon, bounds, -rotate);
            List<Points> rBounds = createPolygonBounds(rPolygon);

            lents latline = createLats(rBounds, space);

            List<Points> line = new List<Points>();
            List<Points> polyline = new List<Points>();
            Points check = null;

            for (int i = 0; i < latline.steps; i++)
            {
                line.Clear();
                for (int j = 0; j < rPolygon.Count; j++)
                {
                    int nt = si(j + 1, rPolygon.Count);
                    check = createInlinePointss(new Points(rPolygon[j].y, rPolygon[j].x), new Points(rPolygon[nt].y, rPolygon[nt].x), rBounds[1].x - i * latline.lats);
                    if (check != null)
                    {
                        line.Add(check);
                    }
                }
                if (line.Count < 2)
                {
                    continue;
                }
                if (line[0].x == line[1].x)
                {
                    continue;
                }
                if (i % 2 == 0)
                {
                    polyline.Add(new Points(line[0].y, max(line[0].x, line[1].x)));
                    polyline.Add(new Points(line[0].y, min(line[0].x, line[1].x)));
                }
                else
                {
                    polyline.Add(new Points(line[0].y, min(line[0].x, line[1].x)));
                    polyline.Add(new Points(line[0].y, max(line[0].x, line[1].x)));
                }
            }

            //0730
            return createRotatePolygon(polyline, bounds, rotate);
        }
        private double max(double x, double y)
        {
            if (x > y)
                return x;
            else return y;
        }
        private double min(double x, double y)
        {
            if (x > y)
                return y;
            else return x;
        }
        private int si(int i, int l)
        {
            if (i > l - 1)
            {
                return i - l;
            }
            if (i < 0)
            {
                return l + i;
            }
            return i;
        }
    }
}
