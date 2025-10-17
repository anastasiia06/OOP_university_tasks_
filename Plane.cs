using System;

interface IParent
{
    string Info();
    void Metod();
}


class Child1 : IParent, IComparable<Child1>
{
    public double pole1; 
    public double pole2; 
    public double pole3; 

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

    
    public int CompareTo(Child1 other)
    {
        return pole3.CompareTo(other.pole3);
    }
}


class Child2 : IParent, IComparable<Child2>
{
    public double pole1; 
    public double pole2; 
    public double pole3; 

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

   
    public int CompareTo(Child2 other)
    {
        return pole1.CompareTo(other.pole1);
    }
}

class Plane
{
    static void Main()
    {
        Random o = new Random();

        
        Child1[] passengers = new Child1[5];
        for (int i = 0; i < passengers.Length; i++)
        {
            double speed = o.Next(500, 2001);
            double height = o.Next(5000, 20001);
            passengers[i] = new Child1(speed, height);
            passengers[i].Metod();
        }
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Масив пасажирських літаків до сортування:");
        foreach (var p in passengers)
            Console.WriteLine(p.Info());

        Array.Sort(passengers); 

        Console.WriteLine("\nМасив пасажирських літаків після сортування за вартістю:");
        foreach (var p in passengers)
            Console.WriteLine(p.Info());

       
        Child2[] fighters = new Child2[5];
        for (int i = 0; i < fighters.Length; i++)
        {
            double speed = o.Next(500, 2001);
            double height = o.Next(5000, 20001);
            fighters[i] = new Child2(speed, height);
            fighters[i].Metod();
        }

        Console.WriteLine("\nМасив винищувачів до сортування:");
        foreach (var f in fighters)
            Console.WriteLine(f.Info());

        Array.Sort(fighters); 

        Console.WriteLine("\nМасив винищувачів після сортування за швидкістю:");
        foreach (var f in fighters)
            Console.WriteLine(f.Info());

     

        
    }
}

