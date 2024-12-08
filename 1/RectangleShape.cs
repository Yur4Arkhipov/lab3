public class RectangleShape
{
    public Point TopLeft { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }

    public RectangleShape(Point topLeft, int width, int height)
    {
        TopLeft = topLeft;
        Width = width > 0 ? width : throw new ArgumentException("Width must be positive.");
        Height = height > 0 ? height : throw new ArgumentException("Height must be positive.");
    }

    public void MoveTo(int deltaX, int deltaY)
    {
        TopLeft = new Point(TopLeft.X + deltaX, TopLeft.Y + deltaY);
    }

    public void Resize(int newWidth, int newHeight)
    {
        if (newWidth > 0)
            Width = newWidth;
        if (newHeight > 0)
            Height = newHeight;
    }

    public void Show(Graphics g)
    {
        g.DrawRectangle(Pens.Black, TopLeft.X, TopLeft.Y, Width, Height);
    }
}
