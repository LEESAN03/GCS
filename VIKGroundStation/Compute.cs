using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace VIKGroundStation
{
    public class Compute
    {
        public const double LONLAT_TO_M = 0.01113195f;
        public const double LONLAT_TO_CM = 1.113195f;
        public const double DEG_TO_RAD = 0.017453292519943295769236907684886;
        public const double RAD_TO_DEG = 57.295779513082320876798154814105;
        public const double E_7 = 10000000;

        private static Compute m_Compute = new Compute();
        public static Compute getInstance()
        {
            if (m_Compute == null)
                m_Compute = new Compute();
            return m_Compute;
        }
        private Compute()
        {
        }
        public static double math_min(double argInput1, double argInput2)
        {
            double returnValue;

            if (argInput1 >= argInput2)
                returnValue = argInput2;
            else
                returnValue = argInput1;
            return returnValue;
        }

        public static double math_max(double argInput1, double argInput2)
        {
            double returnValue;

            if (argInput1 >= argInput2)
                returnValue = argInput1;
            else
                returnValue = argInput2;
            return returnValue;
        }
        public static double dis_math(double lon, double lon1, double lat, double lat1)
        {
            double mLat = (lat - lat1) * 111319.54;
            double mLon = (lon - lon1) * Math.Cos(((lat + lat1) / 2) * 0.0174532925) * 111319.54;
            double temp1 = Math.Sqrt(mLat * mLat + mLon * mLon);
            return temp1;
        }

        public static int Math_Constrain(int argInput, int argMin, int argMax)
        {
            int tempValue = 0;

            if (argInput < argMin)
                tempValue = argMin;
            else if (argInput > argMax)
                tempValue = argMax;
            else
                tempValue = argInput;

            return tempValue;
        }

        public static double Math_Constrain_float(double argInput, double argMin, double argMax)
        {
            double tempValue = 0;

            if (argInput < argMin)
                tempValue = argMin;
            else if (argInput > argMax)
                tempValue = argMax;
            else
                tempValue = argInput;

            return tempValue;
        }

        public static byte[] StructToBytes(object structObj)
        {
            int size = Marshal.SizeOf(structObj);
            byte[] bytes = new byte[size];

            IntPtr structPtr = Marshal.AllocHGlobal(size);

            //将结构体拷到分配好的内存空间
            Marshal.StructureToPtr(structObj, structPtr, false);

            //从内存空间拷贝到byte 数组
            Marshal.Copy(structPtr, bytes, 0, size);

            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            return bytes;
        }

        public static object ByteToStruct(byte[] bytes, UInt16 startIndex, Type type)
        {
            int size = Marshal.SizeOf(type);

            if (size + startIndex > bytes.Length)
            {
                return null;
            }

            //分配结构体内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);

            //将byte数组拷贝到分配好的内存空间

            Marshal.Copy(bytes, startIndex, structPtr, size);

            //将内存空间转换为目标结构体

            object obj = Marshal.PtrToStructure(structPtr, type);

            //释放内存空间

            Marshal.FreeHGlobal(structPtr);

            return obj;
        }

        static double earth_lngscale = 0.0f;
        private static double earth_longitude_scale(int lat)
        {
            earth_lngscale = Math.Cos(Math.Abs((lat / 10000000.0f) * DEG_TO_RAD)); // 1角度 = PI/180 = 0.0174532925弧度

            return earth_lngscale;
        }

        public static int point_to_point_distance(int lon1, int lat1, int lon2, int lat2)
        {
            int dist = 0;
            double cmLat = 0.0f;
            double cmLon = 0.0f;

            earth_longitude_scale(lat2);
            cmLat = (double)(lat2 - lat1);
            cmLon = (double)(lon2 - lon1) * earth_lngscale;

            dist = (int)(Math.Sqrt(cmLat * cmLat + cmLon * cmLon) * LONLAT_TO_CM); // cm

            return dist;
        }

        public static double point_to_point_bearing(int lon1, int lat1, int lon2, int lat2)
        {
            double bear = 0.0f;
            double dLat = 0.0f;
            double dLon = 0.0f;

            earth_longitude_scale(lat2);
            dLat = lat2 - lat1;
            dLon = (lon2 - lon1) * earth_lngscale;

            // Convert the output redians to deg
            bear = Math.Atan2(dLon, dLat) * RAD_TO_DEG;
            return bear;
        }

        public static double wrap_180(double ang)
        {
            if (ang > 180)
                ang -= 180;
            else if (ang <= -180)
                ang += 180;
            return ang;
        }

        public static double wrap_360(double ang)
        {
            if (ang >= 360)
                ang -= 360;
            else if (ang < 0)
                ang += 360;
            return ang;
        }

        public static double wrap_3600(double ang)
        {
            if (ang >= 3600)
                ang -= 3600;
            else if (ang < 0)
                ang += 3600;
            return ang;
        }

        public static double wrap_1800(double ang)
        {
            if (ang > 1800)
                ang -= 3600;
            else if (ang <= -1800)
                ang += 3600;
            return ang;
        }

        public static double calcpolygonarea(List<BOUND_PT> polygon)
        {
            if (polygon.Count < 3)
            {
                return 0;
            }

            // close the polygon
            if (polygon[0] != polygon[polygon.Count - 1])
                polygon.Add(polygon[0]); // make a full loop

            CoordinateTransformationFactory ctfac = new CoordinateTransformationFactory();

            GeographicCoordinateSystem wgs84 = GeographicCoordinateSystem.WGS84;

            int utmzone = (int)((polygon[0].lon - -186.0) / 6.0);

            IProjectedCoordinateSystem utm = ProjectedCoordinateSystem.WGS84_UTM(utmzone, polygon[0].lat < 0 ? false : true);
            ICoordinateTransformation trans = ctfac.CreateFromCoordinateSystems(wgs84, utm);

            double prod1 = 0;
            double prod2 = 0;

            for (int a = 0; a < (polygon.Count - 1); a++)
            {
                double[] pll1 = { polygon[a].lon, polygon[a].lat };
                double[] pll2 = { polygon[a + 1].lon, polygon[a + 1].lat };

                double[] p1 = trans.MathTransform.Transform(pll1);
                double[] p2 = trans.MathTransform.Transform(pll2);

                prod1 += p1[0] * p2[1];
                prod2 += p1[1] * p2[0];
            }

            double answer = (prod1 - prod2) / 2;

            if (polygon[0] == polygon[polygon.Count - 1])
                polygon.RemoveAt(polygon.Count - 1); // unmake a full loop

            return Math.Abs(answer);
        }


        // UTC时间转换为本地时间函数
        // 用时 1-2us
        /*void UTCToLocalTime(int timezone)
        {
            int year, month, day, hour;
            int lastday = 0;     // 月的最后一天的日期
            int lastlastday = 0; // 上月的最后一天的日期

            year = raw_gps._gps_year;            //已知的UTC时间
            month = raw_gps._gps_month;          //已知的UTC时间
            day = raw_gps._gps_day;              //已知的UTC时间
            hour = raw_gps._gps_hour + timezone; //已知的UTC时间

            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                lastday = 31;
                lastlastday = 30;
                if (month == 3)
                {
                    if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0)) //判断是否为闰年，年号能被400整除或年号能被4整除，而不能被100整除为闰年
                        lastlastday = 29;                                        // 闰年的2月为29天，平年为28天
                    else
                        lastlastday = 28;
                }
                if (month == 8)
                    lastlastday = 31;
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                lastday = 30;
                lastlastday = 31;
            }
            else
            {
                lastlastday = 31;
                if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0)) // 闰年的2月为29天，平年为28天
                    lastday = 29;
                else
                    lastday = 28;
            }

            if (hour >= 24)
            { // 当算出的区时大于或等于24:00时，应减去24:00，日期加一天
                hour -= 24;
                day += 1;

                if (day > lastday)
                { // 当算出的日期大于该月最后一天时，应减去该月最后一天的日期，月份加上一个月
                    day -= lastday;
                    month += 1;

                    if (month > 12)
                    { // 当算出的月份大于12时，应减去12，年份加上一年
                        month -= 12;
                        year += 1;
                    }
                }
            }
            if (hour < 0)
            { // 当算出的区时为负数时，应加上24:00，日期减一天
                hour += 24;
                day -= 1;
                if (day < 1)
                { // 当算出的日期为0时，日期变为上一月的最后一天，月份减去一个月
                    day = lastlastday;
                    month -= 1;
                    if (month < 1)
                    { // 当算出的月份为0时，月份变为12月，年份减去一年
                        month = 12;
                        year -= 1;
                    }
                }
            }
            //得到转换后的本地时间
            ins.local_year = year;
            ins.local_
        
            ins.local_month = month;
            ins.local_day = day;
            ins.local_hour = hour;
        }*/
    }
}
