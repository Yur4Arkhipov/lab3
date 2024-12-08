using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class TCircle : TFigure
    {
        private int radius;

        public int Radius
        {
            get { return radius; }
            set
            {
                if (value > 0)
                    radius = value;
                else
                    throw new ArgumentException("Радиус должен быть больше нуля.");
            }
        }

        // base point is a center
        public TCircle(Point center, int radius) : base(center)
        {
            Radius = radius;
            MessageBox.Show($"TCircle создан: центр ({center.X}, {center.Y}), радиус {Radius}", "Alert");
        }

        public override void Show(Graphics g)
        {
            g.DrawEllipse(Pens.Black, basePoint.X - radius, basePoint.Y - radius, radius * 2, radius * 2);
        }

        public void ChangeRadius(int newRadius)
        {
            Radius = newRadius;
        }
    }
}
