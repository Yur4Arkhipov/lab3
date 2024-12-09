using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class TRhombus : TQuadrangle
    {
        public TRhombus(Point center, int distance1, int distance2) : base(
            new Point(center.X - distance1, center.Y),  // left
            new Point(center.X, center.Y - distance2),   // bottom
            new Point(center.X + distance1, center.Y),  // right
            new Point(center.X, center.Y + distance2)  // top
        )
        {
            MessageBox.Show($"TRhombus создан: центр ({center.X}, {center.Y})", "Alert");
        }

        public override void Show(Graphics g)
        {
            //PointF[] points =
            //{
            //    new PointF(Point1.X + basePoint.X, Point1.Y + basePoint.Y),
            //    new PointF(Point2.X + basePoint.X, Point2.Y + basePoint.Y),
            //    new PointF(Point3.X + basePoint.X, Point3.Y + basePoint.Y),
            //    new PointF(Point4.X + basePoint.X, Point4.Y + basePoint.Y)
            //};
            //PointF[] points =
            //{
            //    new PointF(Point1.X + deltaX, Point2.Y + deltaY),
            //    new PointF(Point2.X + deltaX, Point2.Y + deltaY),
            //    new PointF(Point3.X + deltaX, Point3.Y + deltaY),
            //    new PointF(Point4.X + deltaX, Point4.Y + deltaY)
            //};
            //g.DrawPolygon(Pens.Black, points);
            base.Show(g);
        }
    }
}
