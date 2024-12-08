public class Ring
{
    private Circle innerCircle;
    private Circle outerCircle;

    public Circle InnerCircle
    {
        get { return innerCircle; }
        set
        {
            if (value.Radius > 0 && value.Radius < OuterCircle.Radius)
                innerCircle = value;
            else
                throw new ArgumentException("Радиус внутреннего круга должен быть больше 0 и меньше радиуса внешнего круга.");
        }
    }

    public Circle OuterCircle
    {
        get { return outerCircle; }
        set
        {
            if (value.Radius > InnerCircle.Radius)
                outerCircle = value;
            else
                throw new ArgumentException("Радиус внешнего круга должен быть больше радиуса внутреннего круга.");
        }
    }

    public Point Center
    {
        get { return outerCircle.Center; }
    }

    public Ring(Point center, int innerRadius, int outerRadius)
    {
        if (innerRadius <= 0 || outerRadius <= 0)
            throw new ArgumentException("Радиусы должны быть больше нуля.");
        if (innerRadius >= outerRadius)
            throw new ArgumentException("Внешний радиус должен быть больше внутреннего.");

        innerCircle = new Circle(center, innerRadius);
        outerCircle = new Circle(center, outerRadius);
    }

    public void MoveTo(int deltaX, int deltaY)
    {
        innerCircle.MoveTo(deltaX, deltaY);
        outerCircle.MoveTo(deltaX, deltaY);
    }

    public void Show(Graphics g)
    {
        innerCircle.Show(g);
        outerCircle.Show(g);
    }
}
