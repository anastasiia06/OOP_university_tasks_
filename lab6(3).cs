Console.OutputEncoding = System.Text.Encoding.UTF8;

Random o = new Random();
int N = 5;

List<int> list1 = new List<int>();
List<int> list2 = new List<int>();
List<int> list3 = new List<int>();


for (int i = 0; i < N; i++)
{
    list1.Add(o.Next(1, 11));
    list2.Add(o.Next(1, 11));
}


Console.WriteLine("Колекція №1:");
for (int i = 0; i < N; i++)
    Console.Write(list1[i] + " ");

Console.WriteLine("\nКолекція №2:");
for (int i = 0; i < N; i++)
    Console.Write(list2[i] + " ");


for (int i = 0; i < N; i++)
{
    int max = Math.Max(list1[i], list2[i]);
    list3.Add(max);
}


Console.WriteLine("\nКолекція №3:");
for (int i = 0; i < N; i++)
    Console.Write("{0} ", list3[i]);
