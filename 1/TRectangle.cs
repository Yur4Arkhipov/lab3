using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class TRectangle : TQuadrangle
    {
        private int width;
        private int height;

        public TRectangle(Point topLeft, int width, int height)
            : base(topLeft,
                  new Point(topLeft.X + width, topLeft.Y),
                  new Point(topLeft.X + width, topLeft.Y + height),
                  new Point(topLeft.X, topLeft.Y + height))
        {
            this.width = width;
            this.height = height;
            MessageBox.Show($"TRectangle создан: верхний левый угол ({topLeft.X}, {topLeft.Y}), ширина {width}, высота {height}", "Alert");
        }

        //public void Resize(int newWidth, int newHeight)
        //{
        //    width = newWidth;
        //    height = newHeight;

        //    Point2 = new Point(basePoint.X + width, basePoint.Y);
        //    Point3 = new Point(basePoint.X + width, basePoint.Y + height);
        //    Point4 = new Point(basePoint.X, basePoint.Y + height);
        //}

        public override void Show(Graphics g)
        {
            base.Show(g);
            //g.DrawString($"Rect: W({width}), H({height})",
            //             new Font("Arial", 6), Brushes.Black, basePoint.X, basePoint.Y);
        }
    }
}
