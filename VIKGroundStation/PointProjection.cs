using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIKGroundStation
{
    public class GlobeParamter
    {
        public static double BJ54Major = 6378245.0;
        public static double BJ54Minor = 6356863.0187730473;
        public static double XA80Major = 6378140.0;
        public static double XA80Minor = 6356755.2881575283;
        public static double WGS84Major = 6378137.0;
        public static double WGS84Minor = 6356752.3142451793;
    }
    public class GaussProjection
    {
        // Fields
        private double m_central_meridian;
        private double m_e;
        private double m_e0;
        private double m_e1;
        private double m_e2;
        private double m_e3;
        private double m_es;
        private double m_esp;
        private double m_lat_origin = 0.0;
        private double m_ml0;
        private double m_offset_east;
        private double m_offset_north = 0.0;
        private double m_scale_factor = 1.0;
        private double m_semi_major = 6378137.0;
        private double m_semi_minor = 6356752.3142;
        private int m_zone_wide = 6;

        // Methods
        private double adjust_lon(double x)
        {
            long num = 0L;
            double num2 = 2147483647.0;
            double num3 = 4.61168601E+18;
            do
            {
                if (Math.Abs(x) <= 3.1415926535897931)
                {
                    return x;
                }
                if (((int)Math.Abs((double)(x / 3.1415926535897931))) < 2)
                {
                    x -= (((x < 0.0) ? ((double)(-1)) : ((double)1)) * 3.1415926535897931) * 2.0;
                }
                else if (((int)Math.Abs((double)((x / 3.1415926535897931) * 2.0))) < num2)
                {
                    x -= (((int)((x / 3.1415926535897931) * 2.0)) * 3.1415926535897931) * 2.0;
                }
                else if (((int)Math.Abs((double)(x / ((num2 * 3.1415926535897931) * 2.0)))) < num2)
                {
                    x -= ((int)(x / ((num2 * 3.1415926535897931) * 2.0))) * (6.2831853071795862 * num2);
                }
                else if (((int)Math.Abs((double)(x / ((num3 * 3.1415926535897931) * 2.0)))) < num2)
                {
                    x -= ((int)(x / ((num3 * 3.1415926535897931) * 2.0))) * (6.2831853071795862 * num3);
                }
                else
                {
                    x -= (((x < 0.0) ? ((double)(-1)) : ((double)1)) * 3.1415926535897931) * 2.0;
                }
                num += 1L;
            }
            while (num <= 4L);
            return x;
        }

        private double degree_to_radian(double deg)
        {
            return ((deg * 3.1415926535897931) / 180.0);
        }

        public bool gauss_projection_caculate(double longitude, double latitude, out double coord_x, out double coord_y)
        {
            coord_x = 0.0;
            coord_y = 0.0;
            double num = this.degree_to_radian(longitude);
            double a = this.degree_to_radian(latitude);
            double num3 = 0.0;
            this.m_es = 1.0 - Math.Pow(this.m_semi_minor / this.m_semi_major, 2.0);
            this.m_e = Math.Sqrt(this.m_es);
            this.m_e0 = 1.0 - ((0.25 * this.m_es) * (1.0 + ((this.m_es / 16.0) * (3.0 + (1.25 * this.m_es)))));
            this.m_e1 = (0.375 * this.m_es) * (1.0 + ((0.25 * this.m_es) * (1.0 + (0.46875 * this.m_es))));
            this.m_e2 = ((0.05859375 * this.m_es) * this.m_es) * (1.0 + (0.75 * this.m_es));
            this.m_e3 = ((this.m_es * this.m_es) * this.m_es) * 0.011393229166666666;
            this.m_ml0 = this.m_semi_major * ((((this.m_e0 * this.m_lat_origin) - (this.m_e1 * Math.Sin(2.0 * this.m_lat_origin))) + (this.m_e2 * Math.Sin(4.0 * this.m_lat_origin))) - (this.m_e3 * Math.Sin(6.0 * this.m_lat_origin)));
            this.m_esp = this.m_es / (1.0 - this.m_es);
            int num14 = 0;
            if (this.m_zone_wide == 6)
            {
                num14 = ((int)(longitude / ((double)this.m_zone_wide))) + 1;
                this.m_central_meridian = this.degree_to_radian((double)((num14 * this.m_zone_wide) - (this.m_zone_wide >> 1)));
            }
            else
            {
                num14 = ((int)((longitude - 1.5) / ((double)this.m_zone_wide))) + 1;
                this.m_central_meridian = this.degree_to_radian((double)(num14 * this.m_zone_wide));
            }
            this.m_offset_east = (0xf4240L * num14) + 0x7a120L;
            num3 = this.adjust_lon(num - this.m_central_meridian);
            double x = Math.Sin(a);
            double num5 = Math.Cos(a);
            double num6 = num5 * num3;
            double num7 = Math.Pow(num6, 2.0);
            double num8 = this.m_esp * Math.Pow(num5, 2.0);
            double num10 = Math.Tan(a);
            double num9 = Math.Pow(num10, 2.0);
            double d = 1.0 - (this.m_es * Math.Pow(x, 2.0));
            double num12 = this.m_semi_major / Math.Sqrt(d);
            double num13 = this.m_semi_major * ((((this.m_e0 * a) - (this.m_e1 * Math.Sin(2.0 * a))) + (this.m_e2 * Math.Sin(4.0 * a))) - (this.m_e3 * Math.Sin(6.0 * a)));
            coord_x = (((this.m_scale_factor * num12) * num6) * (1.0 + ((num7 / 6.0) * (((1.0 - num9) + num8) + ((num7 / 20.0) * ((((5.0 - (18.0 * num9)) + Math.Pow(num9, 2.0)) + (72.0 * num8)) - (58.0 * this.m_esp))))))) + this.m_offset_east;
            coord_y = (this.m_scale_factor * ((num13 - this.m_ml0) + ((num12 * num10) * (num7 * (0.5 + ((num7 / 24.0) * ((((5.0 - num9) + (9.0 * num8)) + (4.0 * Math.Pow(num8, 2.0))) + ((num7 / 30.0) * ((((61.0 - (58.0 * num9)) + Math.Pow(num9, 2.0)) + (600.0 * num8)) - (330.0 * this.m_esp)))))))))) + this.m_offset_north;
            return true;
        }

        public bool gauss_projection_inverse_caculate(double coord_x, double coord_y, out double longitude, out double latitude)
        {
            longitude = 0.0;
            latitude = 0.0;
            this.m_es = 1.0 - Math.Pow(this.m_semi_minor / this.m_semi_major, 2.0);
            this.m_e = Math.Sqrt(this.m_es);
            this.m_e0 = 1.0 - ((0.25 * this.m_es) * (1.0 + ((this.m_es / 16.0) * (3.0 + (1.25 * this.m_es)))));
            this.m_e1 = (0.375 * this.m_es) * (1.0 + ((0.25 * this.m_es) * (1.0 + (0.46875 * this.m_es))));
            this.m_e2 = ((0.05859375 * this.m_es) * this.m_es) * (1.0 + (0.75 * this.m_es));
            this.m_e3 = ((this.m_es * this.m_es) * this.m_es) * 0.011393229166666666;
            this.m_ml0 = this.m_semi_major * ((((this.m_e0 * this.m_lat_origin) - (this.m_e1 * Math.Sin(2.0 * this.m_lat_origin))) + (this.m_e2 * Math.Sin(4.0 * this.m_lat_origin))) - (this.m_e3 * Math.Sin(6.0 * this.m_lat_origin)));
            this.m_esp = this.m_es / (1.0 - this.m_es);
            int num16 = (int)(coord_x / 1000000.0);
            if (this.m_zone_wide == 6)
            {
                this.m_central_meridian = this.degree_to_radian((double)((num16 * this.m_zone_wide) - (this.m_zone_wide / 2)));
            }
            else
            {
                this.m_central_meridian = this.degree_to_radian((double)(num16 * this.m_zone_wide));
            }
            this.m_offset_east = (0xf4240L * num16) + 0x7a120L;
            double num17 = coord_x - this.m_offset_east;
            double num18 = coord_y - this.m_offset_north;
            double d = (this.m_ml0 + (num18 / this.m_scale_factor)) / this.m_semi_major;
            double num2 = d;
            long num4 = 0L;
            while (true)
            {
                double num3 = ((((d + (this.m_e1 * Math.Sin(2.0 * num2))) - (this.m_e2 * Math.Sin(4.0 * num2))) + (this.m_e3 * Math.Sin(6.0 * num2))) / this.m_e0) - num2;
                num2 += num3;
                if (Math.Abs(num3) <= 1E-10)
                {
                    break;
                }
                num4 += 1L;
            }
            if (Math.Abs(num2) < 1.5707963267948966)
            {
                double x = Math.Sin(num2);
                double num6 = Math.Cos(num2);
                double num7 = Math.Tan(num2);
                double num8 = this.m_esp * Math.Pow(num6, 2.0);
                double num9 = Math.Pow(num8, 2.0);
                double num10 = Math.Pow(num7, 2.0);
                double num11 = Math.Pow(num10, 2.0);
                d = 1.0 - (this.m_es * Math.Pow(x, 2.0));
                double num12 = this.m_semi_major / Math.Sqrt(d);
                double num13 = (num12 * (1.0 - this.m_es)) / d;
                double num14 = num17 / (num12 * this.m_scale_factor);
                double num15 = Math.Pow(num14, 2.0);
                double rad = num2 - ((((num12 * num7) * num15) / num13) * (0.5 - ((num15 / 24.0) * (((((5.0 + (3.0 * num10)) + (10.0 * num8)) - (4.0 * num9)) - (9.0 * this.m_esp)) - ((num15 / 30.0) * (((((61.0 + (90.0 * num10)) + (298.0 * num8)) + (45.0 * num11)) - (252.0 * this.m_esp)) - (3.0 * num9)))))));
                double num20 = this.adjust_lon(this.m_central_meridian + ((num14 * (1.0 - ((num15 / 6.0) * (((1.0 + (2.0 * num10)) + num8) - ((num15 / 20.0) * (((((5.0 - (2.0 * num8)) + (28.0 * num10)) - (3.0 * num9)) + (8.0 * this.m_esp)) + (24.0 * num11))))))) / num6));
                longitude = this.radian_to_degree(num20);
                latitude = this.radian_to_degree(rad);
            }
            else
            {
                longitude = this.radian_to_degree((3.1415926535897931 * ((num18 < 0.0) ? ((double)(-1)) : ((double)1))) / 2.0);
                latitude = this.radian_to_degree(this.m_central_meridian);
            }
            return true;
        }

        private double radian_to_degree(double rad)
        {
            return ((rad * 180.0) / 3.1415926535897931);
        }
        public bool setGlobeParamXA80()
        {
            return set_semi(GlobeParamter.XA80Major, GlobeParamter.XA80Minor);
        }
        public bool setGlobeParamBJ54()
        {
            return set_semi(GlobeParamter.BJ54Major, GlobeParamter.BJ54Minor);
        }
        public bool setGlobeParamWGS84()
        {
            return set_semi(GlobeParamter.WGS84Major, GlobeParamter.WGS84Minor);
        }
        public bool set_semi(double major, double minor)
        {
            if ((major <= 0.0) || (minor <= 0.0))
            {
                return false;
            }
            this.m_semi_major = major;
            this.m_semi_minor = minor;
            return true;
        }

        public bool set_zone_wide(int wide)
        {
            this.m_zone_wide = wide;
            return true;
        }
    }
    public class MercatorProjection
    {
        // Fields
        private double m_central_meridian = 0.0;
        private int m_interative_times = 10;
        private double m_interative_value = 0.0;
        private double m_referance_lat = 0.0;
        private double m_semi_major = 6378137.0;
        private double m_semi_minor = 6356752.3142;

        // Methods
        private double degree_to_radian(double deg)
        {
            return ((deg * 3.1415926535897931) / 180.0);
        }

        public bool mercator_projection_caculate(double longitude, double latitude, out double coord_x, out double coord_y)
        {
            coord_x = 0.0;
            coord_y = 0.0;
            longitude = this.degree_to_radian(longitude);
            latitude = this.degree_to_radian(latitude);
            if (((longitude < -3.1415926535897931) || (longitude > 3.1415926535897931)) || ((latitude < -1.5707963267948966) || (latitude > 1.5707963267948966)))
            {
                return false;
            }
            if ((this.m_semi_major <= 0.0) || (this.m_semi_minor <= 0.0))
            {
                return false;
            }
            double num1 = (this.m_semi_major - this.m_semi_minor) / this.m_semi_major;
            double d = 1.0 - ((this.m_semi_minor / this.m_semi_major) * (this.m_semi_minor / this.m_semi_major));
            if (d < 0.0)
            {
                return false;
            }
            double num = Math.Sqrt(d);
            d = ((this.m_semi_major / this.m_semi_minor) * (this.m_semi_major / this.m_semi_minor)) - 1.0;
            if (d < 0.0)
            {
                return false;
            }
            double num2 = Math.Sqrt(d);
            double num3 = ((this.m_semi_major * this.m_semi_major) / this.m_semi_minor) / Math.Sqrt(1.0 + (((num2 * num2) * Math.Cos(this.m_referance_lat)) * Math.Cos(this.m_referance_lat)));
            double num4 = num3 * Math.Cos(this.m_referance_lat);
            coord_x = num4 * (longitude - this.m_central_meridian);
            coord_y = num4 * Math.Log(Math.Tan(0.78539816339744828 + (latitude / 2.0)) * Math.Pow((1.0 - (num * Math.Sin(latitude))) / (1.0 + (num * Math.Sin(latitude))), num / 2.0));
            return true;
        }

        public bool mercator_projection_inverse_caculate(double coord_x, double coord_y, out double longitude, out double latitude)
        {
            longitude = 0.0;
            latitude = 0.0;
            if ((this.m_semi_major <= 0.0) || (this.m_semi_minor <= 0.0))
            {
                return false;
            }
            double num1 = (this.m_semi_major - this.m_semi_minor) / this.m_semi_major;
            double d = 1.0 - ((this.m_semi_minor / this.m_semi_major) * (this.m_semi_minor / this.m_semi_major));
            if (d < 0.0)
            {
                return false;
            }
            double num = Math.Sqrt(d);
            d = ((this.m_semi_major / this.m_semi_minor) * (this.m_semi_major / this.m_semi_minor)) - 1.0;
            if (d < 0.0)
            {
                return false;
            }
            double num2 = Math.Sqrt(d);
            double num3 = ((this.m_semi_major * this.m_semi_major) / this.m_semi_minor) / Math.Sqrt(1.0 + (((num2 * num2) * Math.Cos(this.m_referance_lat)) * Math.Cos(this.m_referance_lat)));
            double num4 = num3 * Math.Cos(this.m_referance_lat);
            double rad = (coord_x / num4) + this.m_central_meridian;
            double a = this.m_interative_value;
            for (int i = 0; i < this.m_interative_times; i++)
            {
                a = 1.5707963267948966 - (2.0 * Math.Atan(Math.Exp(-coord_y / num4) * Math.Exp((num / 2.0) * Math.Log((1.0 - (num * Math.Sin(a))) / (1.0 + (num * Math.Sin(a)))))));
            }
            longitude = this.radian_to_degree(rad);
            latitude = this.radian_to_degree(a);
            return true;
        }

        private double radian_to_degree(double rad)
        {
            return ((rad * 180.0) / 3.1415926535897931);
        }

        public bool set_central(double central_meridian, double ref_lat)
        {
            if (((central_meridian < -180.0) || (central_meridian > 180.0)) || ((ref_lat < -90.0) || (ref_lat > 90.0)))
            {
                return false;
            }
            this.m_central_meridian = this.degree_to_radian(central_meridian);
            this.m_referance_lat = this.degree_to_radian(ref_lat);
            return true;
        }
        public bool setGlobeParamXA80()
        {
            return set_semi(GlobeParamter.XA80Major, GlobeParamter.XA80Minor);
        }
        public bool setGlobeParamBJ54()
        {
            return set_semi(GlobeParamter.BJ54Major, GlobeParamter.BJ54Minor);
        }
        public bool setGlobeParamWGS84()
        {
            return set_semi(GlobeParamter.WGS84Major, GlobeParamter.WGS84Minor);
        }
        public bool set_semi(double major, double minor)
        {
            if ((major <= 0.0) || (minor <= 0.0))
            {
                return false;
            }
            this.m_semi_major = major;
            this.m_semi_minor = minor;
            return true;
        }
    }
    public class UTMProjection
    {
        // Fields
        private double m_central_meridian;
        private double m_e;
        private double m_e1;
        private double m_es;
        private double m_esp;
        private double m_offset_east = 500000.0;
        private double m_offset_north = 0.0;
        private double m_scale_factor = 0.9996;
        private double m_semi_major = 6378137.0;
        private double m_semi_minor = 6356752.3142;

        // Methods
        private double degree_to_radian(double deg)
        {
            return ((deg * 3.1415926535897931) / 180.0);
        }

        private double radian_to_degree(double rad)
        {
            return ((rad * 180.0) / 3.1415926535897931);
        }
        public bool setGlobeParamXA80()
        {
            return set_semi(GlobeParamter.XA80Major, GlobeParamter.XA80Minor);
        }

        public bool setGlobeParamBJ54()
        {
            return set_semi(GlobeParamter.BJ54Major, GlobeParamter.BJ54Minor);
        }

        public bool setGlobeParamWGS84()
        {
            return set_semi(GlobeParamter.WGS84Major, GlobeParamter.WGS84Minor);
        }
        public bool set_semi(double major, double minor)
        {
            if ((major <= 0.0) || (minor <= 0.0))
            {
                return false;
            }
            this.m_semi_major = major;
            this.m_semi_minor = minor;
            this.m_es = 1.0 - Math.Pow(this.m_semi_minor / this.m_semi_major, 2.0);
            this.m_e = Math.Sqrt(this.m_es);
            this.m_esp = this.m_es / (1.0 - this.m_es);
            this.m_e1 = (1.0 - (this.m_semi_minor / this.m_semi_major)) / (1.0 + (this.m_semi_minor / this.m_semi_major));
            return true;
        }
        /// <summary>
        /// 经纬度转换为平面坐标
        /// </summary>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <param name="coord_x">平面的经度</param>
        /// <param name="coord_y">平面的纬度</param>
        /// <returns></returns>
        public bool utm_projection_caculate(double longitude, double latitude, out double coord_x, out double coord_y)
        {
            coord_x = 0.0;
            coord_y = 0.0;
            int num = ((int)((longitude + 180.0) / 6.0)) + 1;
            this.m_central_meridian = this.degree_to_radian((double)(((num - 30) * 6) - 3));
            this.m_offset_east = (0xf4240L * num) + 0x7a120L;
            if (latitude < 0.0)
            {
                this.m_offset_north = 10000000.0;
            }
            double num2 = this.degree_to_radian(longitude);
            double a = this.degree_to_radian(latitude);
            double num4 = 1.0 - ((0.25 * this.m_es) * (1.0 + ((this.m_es / 16.0) * (3.0 + (1.25 * this.m_es)))));
            double num5 = (0.375 * this.m_es) * (1.0 + ((0.25 * this.m_es) * (1.0 + (0.46875 * this.m_es))));
            double num6 = ((0.05859375 * this.m_es) * this.m_es) * (1.0 + (0.75 * this.m_es));
            double num7 = ((this.m_es * this.m_es) * this.m_es) * 0.011393229166666666;
            double num8 = Math.Tan(a) * Math.Tan(a);
            double num9 = (this.m_esp * Math.Cos(a)) * Math.Cos(a);
            double num10 = (num2 - this.m_central_meridian) * Math.Cos(a);
            double num11 = this.m_semi_major * ((((num4 * a) - (num5 * Math.Sin(2.0 * a))) + (num6 * Math.Sin(4.0 * a))) - (num7 * Math.Sin(6.0 * a)));
            double num12 = this.m_semi_major / Math.Sqrt(1.0 - ((this.m_es * Math.Sin(a)) * Math.Sin(a)));
            double num13 = num10 * num10;
            double num14 = num10 * num13;
            double num15 = num13 * num13;
            double num16 = num13 * num14;
            double num17 = num14 * num14;
            coord_x = this.m_offset_east + ((this.m_scale_factor * num12) * ((num10 + ((((1.0 - num8) + num9) * num14) / 6.0)) + ((((((5.0 - (18.0 * num8)) + (num8 * num8)) + (72.0 * num9)) - (58.0 * this.m_esp)) * num16) / 120.0)));
            coord_y = this.m_offset_north + (this.m_scale_factor * (num11 + ((num12 * Math.Tan(a)) * (((num13 / 2.0) + (((((5.0 - num8) + (9.0 * num9)) + ((4.0 * num9) * num9)) * num15) / 24.0)) + ((((((61.0 - (58.0 * num8)) + (num8 * num8)) + (600.0 * num9)) - (330.0 * this.m_esp)) * num17) / 720.0)))));
            return true;
        }
        /// <summary>
        /// 平面坐标变换为经纬度
        /// </summary>
        /// <param name="coord_x"></param>
        /// <param name="coord_y"></param>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public bool utm_projection_inverse_caculate(double coord_x, double coord_y, out double longitude, out double latitude)
        {
            longitude = 0.0;
            latitude = 0.0;
            int num = (int)(coord_x / 1000000.0);
            this.m_central_meridian = this.degree_to_radian((double)(((num - 30) * 6) - 3));
            if (coord_y > 10000000.0)
            {
                this.m_offset_north = 10000000.0;
            }
            this.m_offset_east = (0xf4240L * num) + 0x7a120L;
            double num2 = coord_x - this.m_offset_east;
            double num3 = coord_y - this.m_offset_north;
            double num4 = this.m_e1 * this.m_e1;
            double num5 = 1.0 - ((0.25 * this.m_es) * (1.0 + ((this.m_es / 16.0) * (3.0 + (1.25 * this.m_es)))));
            double num6 = (1.5 * this.m_e1) * (1.0 - (0.5625 * num4));
            double num7 = ((42.0 - (55.0 * num4)) * num4) / 32.0;
            double num8 = ((151.0 * num4) * this.m_e1) / 96.0;
            double num9 = ((1097.0 * num4) * num4) / 512.0;
            double num15 = num3 / this.m_scale_factor;
            double num16 = num15 / (this.m_semi_major * num5);
            double a = (((num16 + (num6 * Math.Sin(2.0 * num16))) + (num7 * Math.Sin(4.0 * num16))) + (num8 * Math.Sin(6.0 * num16))) + (num9 * Math.Sin(8.0 * num16));
            double num18 = Math.Tan(a);
            double num19 = Math.Sin(a);
            double num20 = Math.Cos(a);
            double num10 = num18 * num18;
            double num11 = (this.m_esp * num20) * num20;
            double num12 = (this.m_semi_major * (1.0 - this.m_es)) / Math.Pow(1.0 - ((this.m_es * num19) * num19), 1.5);
            double num13 = this.m_semi_major / Math.Sqrt(1.0 - ((this.m_es * num19) * num19));
            double num14 = num2 / (num13 * this.m_scale_factor);
            double num21 = num14 * num14;
            double num22 = num14 * num21;
            double num23 = num21 * num21;
            double num24 = num21 * num22;
            double num25 = num22 * num22;
            double rad = (((num14 - ((((1.0 + (2.0 * num10)) + num11) * num22) / 6.0)) + (((((((5.0 - (2.0 * num11)) + (28.0 * num10)) - ((3.0 * num11) * num11)) + (8.0 * this.m_esp)) + ((24.0 * num10) * num10)) * num24) / 120.0)) / num20) + this.m_central_meridian;
            double num27 = a - (((num13 * num18) * (((num21 * 0.5) - ((((((5.0 + (3.0 * num10)) + (10.0 * num11)) - ((4.0 * num11) * num11)) - (9.0 * this.m_esp)) * num23) / 24.0)) + (((((((61.0 + (90.0 * num10)) + (298.0 * num11)) + ((45.0 * num10) * num10)) - ((3.0 * num11) * num11)) - (252.0 * this.m_esp)) * num25) / 720.0))) / num12);
            longitude = this.radian_to_degree(rad);
            latitude = this.radian_to_degree(num27);
            return true;
        }
    }
}
