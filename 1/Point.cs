public class Point
{
    int x, y;

    public int X
    {
        get { return x; }
    }

    public int Y
    {
        get { return y; }
    }

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static Point operator+(Point a, Point b)
    {
        return new Point(a.X + b.X, a.Y + b.Y);
    }

    public static Point operator -(Point a, Point b)
    {
        return new Point(a.X - b.X, a.Y - b.Y);
    }

    public static Point operator /(Point a, int b)
    {
        return new Point(a.X / b, a.Y / b);
    }
}
