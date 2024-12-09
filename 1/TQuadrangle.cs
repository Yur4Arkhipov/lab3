using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class TQuadrangle : TFigure
    {
        private Point point1;
        private Point point2;
        private Point point3;
        private Point point4;
        private List<Point> points = new List<Point>();
        public Point Point1
        {
            get { return point1; }
            set { point1 = value; }
        }

        public Point Point2
        {
            get { return point2; }
            set { point2 = value; }
        }

        public Point Point3
        {
            get { return point3; }
            set { point3 = value; }
        }

        public Point Point4
        {
            get { return point4; }
            set { point4 = value; }
        }

        public Point Center
        {
            get
            {
                return basePoint;
            }
        }

        public TQuadrangle(Point point1, Point point2, Point point3, Point point4) : base((point1 + point2 + point3 + point4) / 4)
        {
            Point basePoint = (point1 + point2 + point3 + point4) / 4;
            
            this.point1 = point1 - basePoint;
            this.point2 = point2 - basePoint;
            this.point3 = point3 - basePoint;
            this.point4 = point4 - basePoint;

            MessageBox.Show($"TQuadrangle создан: точки ({point1.X}, {point1.Y}), ({point2.X}, {point2.Y}), ({point3.X}, {point3.Y}), ({point4.X}, {point4.Y})", "Alert");
        }

        public override void Show(Graphics g)
        {
            PointF[] points =
            {
                new PointF(point1.X + basePoint.X, point1.Y + basePoint.Y),
                new PointF(point2.X + basePoint.X, point2.Y + basePoint.Y),
                new PointF(point3.X + basePoint.X, point3.Y + basePoint.Y),
                new PointF(point4.X + basePoint.X, point4.Y + basePoint.Y)
            };

            g.DrawPolygon(Pens.Black, points);
        }

        public void Rotate(double angleInDegrees)
        {
            double angleInRadians = Math.PI * angleInDegrees / 180.0;

            Point center = new Point(0, 0);

            Point1 = RotatePoint(Point1, center, angleInRadians);
            Point2 = RotatePoint(Point2, center, angleInRadians);
            Point3 = RotatePoint(Point3, center, angleInRadians);
            Point4 = RotatePoint(Point4, center, angleInRadians);
        }

        public Point RotatePoint(Point point, Point center, double angleInRadians)
        {
            double cosAngle = Math.Cos(angleInRadians);
            double sinAngle = Math.Sin(angleInRadians);

            int dx = point.X - center.X;
            int dy = point.Y - center.Y;

            int newX = center.X + (int)(dx * cosAngle - dy * sinAngle);
            int newY = center.Y + (int)(dx * sinAngle + dy * cosAngle);

            return new Point(newX, newY);
        }

    }
}
