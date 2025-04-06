
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
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введіть координату x: ");
        double x = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть координату y: ");
        double y = Convert.ToDouble(Console.ReadLine());
        Coordinate coordinate = new Coordinate(x, y);
        Console.WriteLine(coordinate.information());
        Console.WriteLine($"Відстань до початку координат: {coordinate.Distance():F2}");
    }
}

