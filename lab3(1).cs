class Ball
{
    private double r; //radius
    private double t; //thickness


    public Ball(double r, double t)
    {
        this.r = r;
        this.t = t;
    }

    public double Area() //площа
    {
        return 4 * Math.PI * Math.Pow(r, 2);
    }

    public double Volume() // об'єм
    {
        return (4.0 / 3) * Math.PI * Math.Pow(r, 3);
    }

    public double Mass() // маса
    {
        return Volume() * t;
    }

    public double CrossSection() // обчислення площі перерізу
    {
        return Math.PI * Math.Pow(r, 2);
    }

    public void Information()
    {
        Console.WriteLine("Характеристики кулі:");
        Console.WriteLine($"Радіус: {r}");
        Console.WriteLine($"Щільність: {t}");
        Console.WriteLine($"Площа поверхні: {Area():F2}");
        Console.WriteLine($"Об'єм: {Volume():F2}");
        Console.WriteLine($"Маса: {Mass():F2}");
        Console.WriteLine($"Площа центрального перерізу: {CrossSection():F2}");
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введіть радіус кулі: ");
        double r = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть щільність кулі: ");
        double t = Convert.ToDouble(Console.ReadLine());


        Ball ball = new Ball(r, t);


        ball.Information();
    }
}

