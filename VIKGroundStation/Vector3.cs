using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET;
using MissionPlanner.Utilities;

namespace MissionPlanner.HIL
{
    public class Vector3
    {
        public double x;
        public double y;
        public double z;

        public Vector3(double x = 0, double y = 0, double z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(Vector3 copyme)
        {
            this.x = copyme.x;
            this.y = copyme.y;
            this.z = copyme.z;
        }

        public new string ToString()
        {
            return String.Format("Vector3({0}, {1}, {2})", x,
                y,
                z);
        }

        public static implicit operator Vector3(PointLatLngAlt a)
        {
            return new Vector3(a.Lat, a.Lng, a.Alt);
        }

        public static implicit operator Vector3(PointLatLng a)
        {
            return new Vector3(a.Lat, a.Lng, 0);
        }

        public static implicit operator PointLatLng(Vector3 a)
        {
            return new PointLatLng(a.x, a.y);
        }

        public static Vector3 operator +(Vector3 self, Vector3 v)
        {
            return new Vector3(self.x + v.x,
                self.y + v.y,
                self.z + v.z);
        }


        public static Vector3 operator -(Vector3 self, Vector3 v)
        {
            return new Vector3(self.x - v.x,
                self.y - v.y,
                self.z - v.z);
        }

        public static Vector3 operator -(Vector3 self)
        {
            return new Vector3(-self.x, -self.y, -self.z);
        }


        public static Vector3 operator *(Vector3 self, Vector3 v)
        {
            //  '''dot product'''
            return new Vector3(self.x*v.x + self.y*v.y + self.z*v.z);
        }

        public static Vector3 operator *(Vector3 self, double v)
        {
            return new Vector3(self.x*v,
                self.y*v,
                self.z*v);
        }

        public static Vector3 operator *(double v, Vector3 self)
        {
            return (self*v);
        }

        public static Vector3 operator /(Vector3 self, double v)
        {
            return new Vector3(self.x/v,
                self.y/v,
                self.z/v);
        }

        public static Vector3 operator %(Vector3 self, Vector3 v)
        {
            //  '''cross product'''
            return new Vector3(self.y*v.z - self.z*v.y,
                self.z*v.x - self.x*v.z,
                self.x*v.y - self.y*v.x);
        }

        public Vector3 copy()
        {
            return new Vector3(x, y, z);
        }


        public double length()
        {
            return Math.Sqrt(x*x + y*y + z*z);
        }

        public void zero()
        {
            x = y = z = 0;
        }

        //public double angle (Vector3 self, Vector3 v) {
        //   '''return the angle between this vector and another vector'''
        //  return Math.Acos(self * v) / (self.length() * v.length());
        //}

        public Vector3 normalized()
        {
            return this/length();
        }

        public void normalize()
        {
            Vector3 v = normalized();
            x = v.x;
            y = v.y;
            z = v.z;
        }

        const double HALF_SQRT_2 = 0.70710678118654757;


    }
}