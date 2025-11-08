using System;
using System.Threading;

class Program
{
    static int[] numbers = new int[10];
    static int sum = 0;
    static long product = 1; 

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Random rand = new Random();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Масив із 10 чисел (0..25):");
        Console.ResetColor();
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = rand.Next(0, 26);
            Console.Write(numbers[i] + " ");
        }
        Console.WriteLine("\n");

     
        Thread t0 = new Thread(SumElements);
        Thread t1 = new Thread(ProductElements);

        
        t0.Start();//Метод Start запускає потік
        t1.Start();

       
        t0.Join();// блокує виконання потоку, що викликав його доти, поки не завершиться потік, для якого був викликаний даний метод
        t1.Join();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nСума всіх елементів: {sum}");
        Console.WriteLine($"Добуток всіх елементів: {product}");
        Console.ResetColor();
    }

    
    static void SumElements()
    {
        sum = 0;
        foreach (int num in numbers)
            sum += num;
        Console.WriteLine("(Потік T0) Сума.");
    }

    static void ProductElements()
    {
        product = 1;
        foreach (int num in numbers)
            product *= num;
        Console.WriteLine("(Потік T1) Добуток.");
    }
}
