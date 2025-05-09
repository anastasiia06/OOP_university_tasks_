using System;

interface IParent
{
    string Info();
    void Metod();


}

class Child1 : IParent
{
    double pole1;
    double pole2;
    double pole3;

    public Child1(double speed, double height)
    {
        pole1 = speed;
        pole2 = height;
    }

    public void Metod()
    {
        pole3 = pole1 * 1000 + pole2 * 100;
    }

    public string Info()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        return $"Пасажирський літак: швидкість = {pole1}, висота = {pole2}, вартість = {pole3}";
    }
}

class Child2 : IParent
{
    double pole1;
    double pole2;
    double pole3;

    public Child2(double speed, double height)
    {
        pole1 = speed;
        pole2 = height;
    }

    public void Metod()
    {
        pole3 = pole1 * 3000 + pole2 * 200;
    }

    public string Info()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        return $"Винищувач: швидкість = {pole1}, висота = {pole2}, вартість = {pole3}";
    }
}

class Child3 : IParent
{
    double pole1;
    double pole2;
    double pole3;
    double pole4;

    public Child3(double speed, double height, double bombs)
    {
        pole1 = speed;
        pole2 = height;
        pole4 = bombs;
    }

    public void Metod()
    {
        pole3 = pole1 * 1500 + pole2 * 150 + pole4 * 50;
    }

    public string Info()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        return $"Бомбардувальник: швидкість = {pole1}, висота = {pole2}, вартість = {pole3},бомби = {pole4} ";
    }
}

class Program
{
    static void Main()
    {
        Random o = new Random();
        IParent obj;

        for (int i = 0; i < 5; i++)
        {
            int type = o.Next(3);
            double speed = o.Next(500, 2001);
            double height = o.Next(5000, 20001);

            if (type == 0)
            {
                obj = new Child1(speed, height);
            }
            else if (type == 1)
            {
                obj = new Child2(speed, height);
            }
            else
            {
                double bombs = o.Next(1, 11);
                obj = new Child3(speed, height, bombs);
            }

            obj.Metod();
            Console.WriteLine(obj.Info());
            Console.WriteLine();
        }
    }
}
