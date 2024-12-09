using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    internal class TTrapezoid : TQuadrangle
    {
        public TTrapezoid(Point basePoint, Point point2, Point point3, Point point4)
            : base(basePoint, point2, point3, point4)
        {
            if (!IsTrapezoid())
            {
                throw new ArgumentException("Указанные точки не образуют трапецию.");
            }

            MessageBox.Show($"TTrapezoid создан: точки ({Point1.X}, {Point1.Y}), ({Point2.X}, {Point2.Y}), ({Point3.X}, {Point3.Y}), ({Point4.X}, {Point4.Y})", "Alert");
        }
        private bool IsTrapezoid()
        {
            return AreLinesParallel(Point1, Point2, Point3, Point4) ||
                   AreLinesParallel(Point2, Point3, Point4, Point1);
        }

        private bool AreLinesParallel(Point a1, Point a2, Point b1, Point b2)
        {
            double slope1 = a2.X == a1.X ? double.PositiveInfinity : (double)(a2.Y - a1.Y) / (a2.X - a1.X);
            double slope2 = b2.X == b1.X ? double.PositiveInfinity : (double)(b2.Y - b1.Y) / (b2.X - b1.X);

            return Math.Abs(slope1 - slope2) < 1e-6;
        }

        public override void Show(Graphics g)
        {
            base.Show(g);
            //g.DrawString($"Rect: W({width}), H({height})",
            //             new Font("Arial", 6), Brushes.Black, basePoint.X, basePoint.Y);
        }
    }
}
