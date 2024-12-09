using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class TEllipse : TCircle
    {
        private int semiMajorAxis;
        private int semiMinorAxis;
        public int SemiMajorAxis
        {
            get { return semiMajorAxis; }
            set { semiMajorAxis = value; }
        }

        public int SemiMinorAxis
        {
            get { return semiMinorAxis; }
            set { semiMinorAxis = value; }
        }

        public TEllipse(Point center, int semiMinor, int semiMajor) : base(center, semiMinor)
        {
            semiMajorAxis = semiMajor;
            semiMinorAxis = semiMinor;
            MessageBox.Show($"TEllipse создан: центр ({center.X}, {center.Y}), полуоси ({semiMajorAxis}, {semiMinorAxis})", "Alert");
        }

        public override void Show(Graphics g)
        {
            g.DrawEllipse(Pens.Black, basePoint.X - semiMajorAxis, basePoint.Y - semiMinorAxis, semiMajorAxis * 2, semiMinorAxis * 2);
            //g.DrawString($"Ellips:\n R({semiMajorAxis}, {semiMinorAxis})",
                         //new Font("Arial", 6), Brushes.Black, basePoint.X - semiMinorAxis, basePoint.Y - semiMinorAxis);
        }

        public void Rotate90Degrees()
        {
            int temp = semiMajorAxis;
            semiMajorAxis = semiMinorAxis;
            semiMinorAxis = temp;
        }
    }
}
