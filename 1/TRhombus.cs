using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class TRhombus : TQuadrangle
    {
        public TRhombus(Point center, int distance1, int distance2) : base(
            new Point(center.X - distance1, center.Y),  // top
            new Point(center.X, center.Y - distance2),   // rigth
            new Point(center.X + distance1, center.Y),  // under
            new Point(center.X, center.Y + distance2)  // left
        )
        {
            MessageBox.Show($"TRhombus создан: центр ({center.X}, {center.Y})", "Alert");
        }

        public override void Show(Graphics g)
        {
            PointF[] points =
            {
                new PointF(Point1.X, Point1.Y),
                new PointF(Point2.X, Point2.Y),
                new PointF(Point3.X, Point3.Y),
                new PointF(Point4.X, Point4.Y)
            };
            g.DrawPolygon(Pens.Black, points);
        }
    }
}
