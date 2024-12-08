public class Circle
{
    private Point center;
    private int radius;

    public Point Center
    {
        get { return center; }
    }

    public int Radius
    {
        get { return radius; }
        set
        {
            if (value > 0)
                radius = value;
        }
    }

    public Circle(Point center, int radius)
    {
        this.center = center;
        this.radius = radius > 0 ? radius : throw new ArgumentException("Радиус должен быть больше нуля.");
    }

    public void MoveTo(int deltaX, int deltaY)
    {
        center = new Point(center.X + deltaX, center.Y + deltaY);
    }

    public void Show(Graphics g)
    {
        g.DrawEllipse(Pens.Black, center.X - radius, center.Y - radius, radius * 2, radius * 2);
    }
}
