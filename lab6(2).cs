Console.OutputEncoding = System.Text.Encoding.UTF8;

Random o = new Random();
int N = 10;
List<int> numbers = new List<int>();


for (int i = 0; i < N; i++)
    numbers.Add(o.Next(5, 51));


for (int i = 0; i < numbers.Count; i++)
    Console.Write(numbers[i] + " ");


for (int i = 0; i < numbers.Count; i++)
{
    int lastElement = numbers[i] % 10;
    if (lastElement != 0 && numbers[i] % lastElement == 0)
    {
        numbers.Insert(i, -1);
        break;
    }
}

Console.WriteLine("\nРезультат:");
for (int i = 0; i < numbers.Count; i++)
    Console.Write(numbers[i] + " ");
