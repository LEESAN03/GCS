using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIKGroundStation
{
    class Points
    {
        public double x=0.0;
        public double y=0.0;
        public double z=0;
        public Points(){}
        public Points(double x, double y){
            this.x=x;
            this.y=y;
        }
    public Points(double x, double y, double z){
        this.x=x;
        this.y=y;
        this.z=z;
    }

    public  Boolean Equals(Points obj)
    {
            Points p = (Points)obj;
            return x == p.x &&y == p.y;

    }



    public static Points  add(Points a, Points b)
    {
        Points p=new Points();
        p.x=a.x+b.x;
        p.y=a.y+b.y;
        return p;
    }
    public static Points del(Points a, Points b)
    {
        Points p=new Points();
        p.x=a.x-b.x;
        p.y=a.y-b.y;
        return p;
    }
    public static double cheng(Points a, Points b)
    {
        double p=a.x*b.x+a.y*b.y;
        return p;
    }
    public static Points  cheng(Points a, double value)
    {
        Points p=new Points();
        p.x=a.x*value;
        p.y=a.y*value;
        return p;
    }
    public static  double xlJi(Points a, Points b)
    {
        double p=((a.x)*(b.y))-((a.y)*(b.x));
        return p;
    }
    }
}
