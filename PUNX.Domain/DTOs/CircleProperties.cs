

namespace PUNX.Domain.DTOs
{
    public class CircleProperties
    {
        public CircleProperties(double radius, double area, double circumference, double diameter)
        {
            Radius = radius;
            Area = area;
            Circumference = circumference;
            Diameter = diameter;
        }
        public double Radius { get; set; }
        public double Area { get; set; }
        public double Circumference { get; set; }
        public double Diameter { get; set; }
    }
}
