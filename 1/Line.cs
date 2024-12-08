public class Line
{
    public Point Start { get; private set; }
    public Point End { get; private set; }

    public Line(Point start, Point end)
    {
        Start = start;
        End = end;
    }

    public void MoveTo(int deltaX, int deltaY)
    {
        Start = new Point(Start.X + deltaX, Start.Y + deltaY);
        End = new Point(End.X + deltaX, End.Y + deltaY);
    }

    public void Show(Graphics g)
    {
        g.DrawLine(Pens.Black, Start.X, Start.Y, End.X, End.Y);
    }
}
