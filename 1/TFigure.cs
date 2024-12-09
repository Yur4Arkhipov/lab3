using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal abstract class TFigure
    {
        // общие свойства и поведение примитивов
        // коорлинаты базовой точки примитива, конструктор, методы доступа
        // абстрактные методы прорисовки Show и перемещения MoveTo
        public Point basePoint;

        public TFigure(Point basePoint)
        {
            this.basePoint = basePoint;
            // TODO(): message about create 
            MessageBox.Show($"TFigure создан: базовая точка ({this.basePoint.X}, {this.basePoint.Y})", "Alert");
        }

        public abstract void Show(Graphics g);
        public abstract void MoveTo(int deltaX, int deltaY);
    }
}
