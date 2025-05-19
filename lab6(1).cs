Random o = new Random();
int N = 8;
List<int> numbers = new List<int>();


for (int i = 0; i < N; i++)
{
    numbers.Add(o.Next(1, 91));
}



for (int i = 0; i < numbers.Count; i++)
{
    Console.Write("{0} ", numbers[i]);
}

for (int i = numbers.Count - 1; i >= 0; i--)
{
    if (numbers[i] % 3 == 0 || numbers[i] % 10 == 5)
    {
        numbers.RemoveAt(i);
    }
}


Console.WriteLine("\nПісля видалення (кратні 3 і закінчуються на 5):");
for (int i = 0; i < numbers.Count; i++)
{
    Console.Write("{0} ", numbers[i]);
}

