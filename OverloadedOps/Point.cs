using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadedOps
{

    class Point :IComparable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }
      

        public Point(int xPos, int yPos) { X = xPos; Y = yPos; }


        /// Override Object.ToString().
        public override string ToString() => $"[{this.X}, {this.Y}]";

        // Overloaded operator +.
        public static Point operator + (Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y+p2.Y);
        //When you are overloading a binary operator, you are not required to pass in two parameters of the same
        //type.If it makes sense to do so, one of the arguments can differ
        public static Point operator +(int change, Point p1) => new Point(p1.X + change, p1.Y + change);
        
        // Overloaded operator -.
        public static Point operator -(Point p1, Point p2) => new Point(p1.X - p2.X, p1.Y - p2.Y);

        // Add 1 to the X/Y values for the incoming Point.
        public static Point operator ++(Point p1) => new Point(p1.X + 1, p1.Y + 1);

        // Subtract 1 from the X/Y values for the incoming Point.
        public static Point operator --(Point p1) => new Point(p1.X - 1, p1.Y - 1);

        public override bool Equals(object o) => o.ToString() == this.ToString();

        public override int GetHashCode() => this.ToString().GetHashCode();
        // Now let's overload the == and != operators.
        public static bool operator ==(Point p1, Point p2) => p1.Equals(p2);
        public static bool operator !=(Point p1, Point p2) => !p1.Equals(p2);


        public int CompareTo(Point other)
        {
            if (this.X > other.X && this.Y > other.Y) return 1;
            if (this.X < other.X && this.Y < other.Y) return -1;
            else return 0;
        }

        public static bool operator <(Point p1, Point p2) => p1.CompareTo(p2) < 0;
        public static bool operator >(Point p1, Point p2) => p1.CompareTo(p2) > 0;
        public static bool operator <=(Point p1, Point p2) => p1.CompareTo(p2) <= 0;
        public static bool operator >=(Point p1, Point p2) => p1.CompareTo(p2) >= 0;
    }
}
