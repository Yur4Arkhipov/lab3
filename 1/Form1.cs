using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace _1
{
    public partial class Form1 : Form
    {
        private List<Circle> circles = new List<Circle>();
        private List<Line> lines = new List<Line>();
        private List<RectangleShape> rectangles = new List<RectangleShape>();
        private List<Ring> rings = new List<Ring>();
        private Random random = new Random();

        private List<TCircle> tcircles = new List<TCircle>();
        private List<TEllipse> tellipses = new List<TEllipse>();
        private List<TRectangle> trectangles = new List<TRectangle>();
        private List<TTrapezoid> ttrapezoids = new List<TTrapezoid>();
        private List<TRhombus> trhombuses = new List<TRhombus>();
        List<TQuadrangle> tquadrangles = new List<TQuadrangle>();
        List<TFigure> tfigures = new List<TFigure>();

        public Form1()
        {
            this.Text = "Графические Примитивы";
            this.Size = new Size(800, 800);

            var createMenu = new ToolStripMenuItem("Создать");
            createMenu.DropDownItems.Add("Окружность", null, (s, e) => CreateCircle());
            createMenu.DropDownItems.Add("Окружность (TCircle)", null, (s, e) => CreateTCircle());
            createMenu.DropDownItems.Add("Эллипс (TEllipse)", null, (s, e) => CreateTEllipse());
            createMenu.DropDownItems.Add("Отрезок", null, (s, e) => CreateLine());
            createMenu.DropDownItems.Add("Прямоугольник", null, (s, e) => CreateRectangle());
            createMenu.DropDownItems.Add("Прямоугольник (TRectangle)", null, (s, e) => CreateTRectangle());
            createMenu.DropDownItems.Add("Трапеция (TTrapezoid)", null, (s, e) => CreateTTrapezoid());
            createMenu.DropDownItems.Add("Ромб (TRhombus)", null, (s, e) => CreateTRhombus());
            createMenu.DropDownItems.Add("Кольцо", null, (s, e) => CreateRing());


            var moveMenu = new ToolStripMenuItem("Переместить");
            moveMenu.DropDownItems.Add("Все окружности", null, (s, e) => MoveAllCircles());
            moveMenu.DropDownItems.Add("Все отрезки", null, (s, e) => MoveAllLines());
            moveMenu.DropDownItems.Add("Все прямоугольники", null, (s, e) => MoveAllRectangles());
            moveMenu.DropDownItems.Add("Все кольца", null, (s, e) => MoveAllRings());
            moveMenu.DropDownItems.Add("Все фигуры (TFigures)", null, (s, e) => MoveAllFigures());

            var modifyMenu = new ToolStripMenuItem("Изменить");
            modifyMenu.DropDownItems.Add("Размер всех окружностей", null, (s, e) => ChangeAllCirclesRadius());
            modifyMenu.DropDownItems.Add("Размер всех окружностей (TCircles)", null, (s, e) => ChangeAllTCirclesRadius());
            modifyMenu.DropDownItems.Add("Повернуть эллипсы на 90 градусов (TEllipse)", null, (s, e) => RotateAllEllipses());
            modifyMenu.DropDownItems.Add("Повернуть четырехугольники на n градусов (TQuadrangles)", null, (s, e) => RotateAllQuadrangles());
            modifyMenu.DropDownItems.Add("Размер всех прямоугольников", null, (s, e) => ChangeAllRectanglesSize());
            modifyMenu.DropDownItems.Add("Размер всех колец", null, (s, e) => ChangeAllRingsRadius());

            var arrayMenu = new ToolStripMenuItem("Массивы");
            arrayMenu.DropDownItems.Add("Создать массив окружностей", null, (s, e) => CreateCirclesArray());
            arrayMenu.DropDownItems.Add("Создать массив отрезков", null, (s, e) => CreateLinesArray());
            arrayMenu.DropDownItems.Add("Создать массив прямоугольников", null, (s, e) => CreateRectanglesArray());
            arrayMenu.DropDownItems.Add("Создать массив колец", null, (s, e) => CreateRingsArray());
            arrayMenu.DropDownItems.Add("Удалить все массивы", null, (s, e) => ClearAllArrays());

            var menuStrip = new MenuStrip();
            menuStrip.Items.Add(createMenu);
            menuStrip.Items.Add(moveMenu);
            menuStrip.Items.Add(modifyMenu);
            menuStrip.Items.Add(arrayMenu);
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
            this.Paint += MainForm_Paint;
        }

        private void CreateCircle()
        {
            Point point = new Point(random.Next(100, 400), random.Next(100, 400));
            MessageBox.Show("|| Точка-центр для окружности создана", "Alert");
            circles.Add(new Circle(point, random.Next(20, 80)));
            this.Invalidate();
        }

        private void CreateTCircle()
        {
            Point point = new Point(random.Next(100, 400), random.Next(100, 400));
            var tcircle = new TCircle(point, random.Next(20, 80));
            tcircles.Add(tcircle);
            tfigures.Add(tcircle);
            this.Invalidate();
        }

        private void CreateTEllipse()
        {
            Point p = new Point(random.Next(100, 400), random.Next(100, 400));
            var tellipse = new TEllipse(p, random.Next(20, 80), random.Next(20, 80));
            tellipses.Add(tellipse);
            tfigures.Add(tellipse);
            this.Invalidate();
        }


        private void CreateLine()
        {
            Point point1 = new Point(random.Next(100, 400), random.Next(100, 400));
            Point point2 = new Point(random.Next(100, 400), random.Next(100, 400));
            MessageBox.Show("|| Точки для создания линии созданы", "Alert");
            lines.Add(new Line(point1, point2));
            this.Invalidate();
        }


        private void CreateRectangle()
        {
            Point point = new Point(random.Next(100, 400), random.Next(100, 400));
            int width = random.Next(50, 150);
            int height = random.Next(30, 100);
            MessageBox.Show("|| Прямоугольник создан", "Alert");
            rectangles.Add(new RectangleShape(point, width, height));
            this.Invalidate();
        }

        private void CreateTRectangle()
        {
            Point point = new Point(random.Next(100, 400), random.Next(100, 400));
            int width = random.Next(50, 150);
            int height = random.Next(30, 100);
            var trectangle = new TRectangle(point, width, height);
            trectangles.Add(trectangle);
            tquadrangles.Add(trectangle);
            tfigures.Add(trectangle);
            this.Invalidate();
        }

        private void CreateTTrapezoid()
        {
            int x1 = random.Next(100, 300);
            int y1 = random.Next(100, 200);
            int x2 = random.Next(x1 + 50, 400);
            int y2 = y1;
     
            int x3 = random.Next(100, 300);
            int y3 = random.Next(300, 500); 
            int x4 = random.Next(x3 + 50, 400);
            int y4 = y3;

            //if (x2 - x1 < x4 - x3)
            //{
            //    int tempX1 = x1, tempX2 = x2;
            //    x1 = x3;
            //    x2 = x4;
            //    x3 = tempX1;
            //    x4 = tempX2;
            //}

            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Point point3 = new Point(x3, y3);
            Point point4 = new Point(x4, y4);

            var ttrapezoid = new TTrapezoid(point1, point2, point4, point3);
            ttrapezoids.Add(ttrapezoid);
            tquadrangles.Add(ttrapezoid);
            tfigures.Add(ttrapezoid);
            this.Invalidate();
        }

        private void CreateTRhombus()
        {
            int centerX = random.Next(100, 400);
            int centerY = random.Next(100, 400);

            int distance1 = random.Next(50, 150);
            int distance2 = random.Next(50, 150);
            var trhombus = new TRhombus(new Point(centerX, centerY), distance1, distance2);

            trhombuses.Add(trhombus);
            tquadrangles.Add(trhombus);
            tfigures.Add(trhombus);
            this.Invalidate();
        }


        private void CreateRing()
        {
            Point center = new Point(random.Next(100, 400), random.Next(100, 400));
            int outerRadius = random.Next(50, 150);
            int innerRadius = random.Next(10, outerRadius);
            MessageBox.Show("|| Кольцо создано", "Alert");
            rings.Add(new Ring(center, innerRadius, outerRadius));
            this.Invalidate();
        }


        private void MoveAllCircles()
        {
            int menuHeight = this.MainMenuStrip != null ? this.MainMenuStrip.Height : 0;

            foreach (var circle in circles)
            {
                int deltaX = random.Next(-50, 50);
                int deltaY = random.Next(-50, 50);

                int newX = circle.Center.X + deltaX;
                int newY = circle.Center.Y + deltaY;

                bool isOutOfBoundsX = newX - circle.Radius < 0 || newX + circle.Radius > this.ClientRectangle.Width;
                bool isOutOfBoundsY = newY - circle.Radius < menuHeight || newY + circle.Radius > this.ClientRectangle.Height;

                if (isOutOfBoundsX || isOutOfBoundsY)
                {
                    continue;
                }

                circle.MoveTo(deltaX, deltaY);
            }
            this.Invalidate();
        }

        private void MoveAllRings()
        {
            int menuHeight = this.MainMenuStrip != null ? this.MainMenuStrip.Height : 0;

            foreach (var ring in rings)
            {
                int deltaX = random.Next(-50, 50);
                int deltaY = random.Next(-50, 50);

                int newX = ring.Center.X + deltaX;
                int newY = ring.Center.Y + deltaY;

                bool isOutOfBoundsX = newX - ring.OuterCircle.Radius < 0 || newX + ring.OuterCircle.Radius > this.ClientRectangle.Width;
                bool isOutOfBoundsY = newY - ring.OuterCircle.Radius < menuHeight || newY + ring.OuterCircle.Radius > this.ClientRectangle.Height;

                if (isOutOfBoundsX || isOutOfBoundsY)
                {
                    continue;
                }

                ring.MoveTo(deltaX, deltaY);
            }

            this.Invalidate();
        }



        private void MoveAllLines()
        {
            int menuHeight = this.MainMenuStrip != null ? this.MainMenuStrip.Height : 0;

            foreach (var line in lines)
            {
                int deltaX = random.Next(-50, 50);
                int deltaY = random.Next(-50, 50);

                int newStartX = line.Start.X + deltaX;
                int newStartY = line.Start.Y + deltaY;
                int newEndX = line.End.X + deltaX;
                int newEndY = line.End.Y + deltaY;

                bool isOutOfBoundsStart = newStartX < 0 || newStartX > this.ClientSize.Width ||
                                          newStartY < menuHeight || newStartY > this.ClientSize.Height;
                bool isOutOfBoundsEnd = newEndX < 0 || newEndX > this.ClientSize.Width ||
                                        newEndY < menuHeight || newEndY > this.ClientSize.Height;

                if (isOutOfBoundsStart || isOutOfBoundsEnd)
                {
                    continue;
                }

                line.MoveTo(deltaX, deltaY);
            }

            this.Invalidate();
        }


        private void MoveAllRectangles()
        {
            int menuHeight = this.MainMenuStrip != null ? this.MainMenuStrip.Height : 0;

            foreach (var rectangle in rectangles)
            {
                int deltaX = random.Next(-50, 50);
                int deltaY = random.Next(-50, 50);

                int newX = rectangle.TopLeft.X + deltaX;
                int newY = rectangle.TopLeft.Y + deltaY;

                bool isOutOfBounds = newX < 0 || newX + rectangle.Width > this.ClientSize.Width ||
                                     newY < menuHeight || newY + rectangle.Height > this.ClientSize.Height;

                if (isOutOfBounds)
                {
                    continue;
                }

                rectangle.MoveTo(deltaX, deltaY);
            }

            this.Invalidate();
        }


        private void MoveAllFigures()
        {
            int deltaX = random.Next(-50, 50),
                deltaY = random.Next(-50, 50);
            

            foreach (var tfigure in tfigures)
            {
                //int newX = tfigure.basePoint.X + deltaX;
                //int newY = tfigure.basePoint.Y + deltaY;

                tfigure.MoveTo(deltaX, deltaY);
            }
            this.Invalidate();
        }

        private void ChangeAllCirclesRadius()
        {
            int menuHeight = this.MainMenuStrip != null ? this.MainMenuStrip.Height : 0;
            foreach (var circle in circles)
            {
                int oldRadius = circle.Radius;
                int newRadius = random.Next(10, 100);

                bool isOutOfBounds = circle.Center.X - newRadius < 0 || circle.Center.X + newRadius > this.ClientSize.Width ||
                                     circle.Center.Y - newRadius < menuHeight || circle.Center.Y + newRadius > this.ClientSize.Height;

                if (isOutOfBounds)
                {
                    continue;
                }

                circle.Radius = newRadius;
            }

            this.Invalidate();
        }

        private void ChangeAllTCirclesRadius()
        {
            int menuHeight = this.MainMenuStrip != null ? this.MainMenuStrip.Height : 0;
            foreach (var tcircle in tcircles)
            {
                //int oldRadius = tcircle.Radius;
                int newRadius = random.Next(10, 100);
                tcircle.ChangeRadius(newRadius);
               

                bool isOutOfBounds = tcircle.basePoint.X - newRadius < 0 || tcircle.basePoint.X + newRadius > this.ClientSize.Width ||
                                     tcircle.basePoint.Y - newRadius < menuHeight || tcircle.basePoint.Y + newRadius > this.ClientSize.Height;

                if (isOutOfBounds)
                {
                    continue;
                }

                tcircle.Radius = newRadius;
            }

            this.Invalidate();
        }

        private void RotateAllEllipses()
        {
            int menuHeight = this.MainMenuStrip != null ? this.MainMenuStrip.Height : 0;

            foreach (var tellipse in tellipses)
            {
                int newSemiMajorAxis = tellipse.SemiMinorAxis;
                int newSemiMinorAxis = tellipse.SemiMajorAxis;

                bool isOutOfBounds = tellipse.basePoint.X - newSemiMajorAxis < 0 || tellipse.basePoint.X + newSemiMajorAxis > this.ClientSize.Width ||
                                     tellipse.basePoint.Y - newSemiMinorAxis < menuHeight || tellipse.basePoint.Y + newSemiMinorAxis > this.ClientSize.Height;

                if (isOutOfBounds)
                {
                    continue;
                }

                tellipse.Rotate90Degrees();
            }

            this.Invalidate();
        }

        private void RotateAllQuadrangles()
        {
            int menuHeight = this.MainMenuStrip != null ? this.MainMenuStrip.Height : 0;
            int angle = random.Next(10, 90);
            //foreach (var trectangle in trectangles) { tquadrangles.Add(trectangle); }

            foreach (var tquadrangle in tquadrangles)
            {
                //Point rotatedPoint1 = tquadrangle.RotatePoint(tquadrangle.Point1, tquadrangle.Center, angle);
                //Point rotatedPoint2 = tquadrangle.RotatePoint(tquadrangle.Point2, tquadrangle.Center, angle);
                //Point rotatedPoint3 = tquadrangle.RotatePoint(tquadrangle.Point3, tquadrangle.Center, angle);
                //Point rotatedPoint4 = tquadrangle.RotatePoint(tquadrangle.Point4, tquadrangle.Center, angle);

                //bool isOutOfBounds = rotatedPoint1.X < 0 || rotatedPoint1.X > this.ClientSize.Width ||
                //                     rotatedPoint1.Y < menuHeight || rotatedPoint1.Y > this.ClientSize.Height ||
                //                     rotatedPoint2.X < 0 || rotatedPoint2.X > this.ClientSize.Width ||
                //                     rotatedPoint2.Y < menuHeight || rotatedPoint2.Y > this.ClientSize.Height ||
                //                     rotatedPoint3.X < 0 || rotatedPoint3.X > this.ClientSize.Width ||
                //                     rotatedPoint3.Y < menuHeight || rotatedPoint3.Y > this.ClientSize.Height ||
                //                     rotatedPoint4.X < 0 || rotatedPoint4.X > this.ClientSize.Width ||
                //                     rotatedPoint4.Y < menuHeight || rotatedPoint4.Y > this.ClientSize.Height;

                //if (isOutOfBounds)
                //{
                //    continue;
                //}

                tquadrangle.Rotate(angle);
            }

            this.Invalidate();
        }

        private void ChangeAllRingsRadius()
        {
            int menuHeight = this.MainMenuStrip != null ? this.MainMenuStrip.Height : 0;
            foreach (var ring in rings)
            {
                int oldOuterRadius = ring.OuterCircle.Radius;
                int oldInnerRadius = ring.InnerCircle.Radius;
                int newOuterRadius = random.Next(10, 100);
                int newInnerRadius = random.Next(10, newOuterRadius);

                bool isOutOfBounds = ring.InnerCircle.Center.X - newOuterRadius < 0 || ring.Center.X + newOuterRadius > this.ClientSize.Width ||
                                     ring.InnerCircle.Center.Y - newOuterRadius < menuHeight || ring.Center.Y + newOuterRadius > this.ClientSize.Height;

                if (isOutOfBounds)
                {
                    continue;
                }

                ring.OuterCircle.Radius = newOuterRadius;
                ring.InnerCircle.Radius = newInnerRadius;
            }

            this.Invalidate();
        }



        private void ChangeAllRectanglesSize()
        {
            int menuHeight = this.MainMenuStrip != null ? this.MainMenuStrip.Height : 0;

            foreach (var rectangle in rectangles)
            {
                int newWidth = random.Next(50, 200);
                int newHeight = random.Next(30, 150);

                bool isOutOfBounds = rectangle.TopLeft.X + newWidth > this.ClientSize.Width ||
                                     rectangle.TopLeft.Y + newHeight > this.ClientSize.Height ||
                                     rectangle.TopLeft.Y < menuHeight;

                if (isOutOfBounds)
                {
                    continue;
                }

                rectangle.Resize(newWidth, newHeight);
            }

            this.Invalidate();
        }



        private void CreateCirclesArray()
        {
            circles.Clear();
            for (int i = 0; i < 5; i++)
            {
                int radius;
                Point position;
                do
                {
                    position = new Point(random.Next(100, 400), random.Next(100, 400));
                    radius = random.Next(20, 80);
                } while (position.X - radius < 0 || position.X + radius > this.ClientSize.Width ||
                         position.Y - radius < 0 || position.Y + radius > this.ClientSize.Height);

                circles.Add(new Circle(position, radius));
            }
            this.Invalidate();
        }

        private void CreateRingsArray()
        {
            circles.Clear();
            for (int i = 0; i < 5; i++)
            {
                int innerRadius, outerRadius;
                Point position;
                do
                {
                    position = new Point(random.Next(100, 400), random.Next(100, 400));
                    outerRadius = random.Next(20, 80);
                    innerRadius = random.Next(20, outerRadius);
                } while (position.X - outerRadius < 0 || position.X + outerRadius > this.ClientSize.Width ||
                         position.Y - outerRadius < 0 || position.Y + outerRadius > this.ClientSize.Height);

                rings.Add(new Ring(position, innerRadius, outerRadius));
            }
            this.Invalidate();
        }

        private void CreateLinesArray()
        {
            lines.Clear();
            for (int i = 0; i < 5; i++)
            {
                int x1, y1, x2, y2;
                do
                {
                    x1 = random.Next(100, 400);
                    y1 = random.Next(100, 400);
                    x2 = random.Next(400, 700);
                    y2 = random.Next(100, 400);
                } while (x1 < 0 || x1 > this.ClientSize.Width || y1 < 0 || y1 > this.ClientSize.Height ||
                         x2 < 0 || x2 > this.ClientSize.Width || y2 < 0 || y2 > this.ClientSize.Height);
                Point startPoint = new Point(x1, y1);
                Point endPoint = new Point(x2, y2);
                lines.Add(new Line(startPoint, endPoint));
            }
            this.Invalidate();
        }

        private void CreateRectanglesArray()
        {
            rectangles.Clear();
            for (int i = 0; i < 5; i++)
            {
                Point topLeft;
                int width, height;

                do
                {
                    topLeft = new Point(random.Next(100, 400), random.Next(100, 400));
                    width = random.Next(50, 150);
                    height = random.Next(30, 100);
                } while (topLeft.X < 0 || topLeft.X + width > this.ClientSize.Width ||
                         topLeft.Y < 0 || topLeft.Y + height > this.ClientSize.Height);

                rectangles.Add(new RectangleShape(topLeft, width, height));
            }

            this.Invalidate();
        }

        private void ClearAllArrays()
        {
            circles.Clear();
            lines.Clear();
            rectangles.Clear();
            this.Invalidate();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (var circle in circles)
            {
                circle.Show(e.Graphics);
            }
            foreach (var line in lines)
            {
                line.Show(e.Graphics);
            }
            foreach (var rectangle in rectangles)
            {
                rectangle.Show(e.Graphics);
            }
            foreach (var ring in rings)
            {
                ring.Show(e.Graphics);
            }

            //foreach (var tcircle in tcircles)
            //{
            //    tcircle.Show(e.Graphics);
            //}

            //foreach (var tellipse in tellipses)
            //{
            //    tellipse.Show(e.Graphics);
            //}

            //foreach (var tquadrangle in tquadrangles)
            //{
            //    tquadrangle.Show(e.Graphics);
            //}

            foreach (var tfigure in tfigures)
            {
                tfigure.Show(e.Graphics);
            }
        }

        public static void start()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}
