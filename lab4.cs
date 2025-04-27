class Coordinate
{
    private double x1;
    private double y1;

    public Coordinate(double x1, double y1)
    {
        this.x1 = x1;
        this.y1 = y1;
    }

    public string information()
    {
        return $"Координати: x = {x1}, y = {y1}";
    }

    public double Distance()
    {
        return Math.Sqrt(x1 * x1 + y1 * y1);
    }
}

class Circle : Coordinate
{
    private double r;

    public Circle(double x1, double y1, double r) : base(x1, y1)
    {
        this.r = r;
    }


    public string IsInsideCircle()
    {
        if (Distance() <= r)
            return "Точка знаходиться всередині кола.";
        else
            return "Точка знаходиться за межами кола.";
    }


    public string Information()
    {
        return $"{information()}, Радіус кола = {r}";
    }
}

class Program
{
   
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            
            Console.Write("Введіть координату x: ");
            double x = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть координату y: ");
            double y = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть радіус кола: ");
            double r = Convert.ToDouble(Console.ReadLine());

            Circle circle = new Circle(x, y, r);

            Console.WriteLine(circle.Information());
            Console.WriteLine($"Відстань до початку координат: {circle.Distance()}");

            Console.WriteLine(circle.IsInsideCircle());

    }
}



