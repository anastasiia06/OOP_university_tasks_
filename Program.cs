using System;

namespace WinFormsApp9
{
    class Triangle<T> where T : struct, IConvertible
    {
        private T a, b, c;

        public Triangle()
        {
            a = b = c = default;
        }

        public Triangle(T a, T b, T c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public Triangle(Triangle<T> t)
        {
            a = t.a;
            b = t.b;
            c = t.c;
        }

        private double ToDouble(T value) => Convert.ToDouble(value);

        public void Input()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть сторону a: ");
            a = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

            Console.Write("Введіть сторону b: ");
            b = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

            Console.Write("Введіть сторону c: ");
            c = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
        }

        public void Output()
        {
            Console.WriteLine($"Сторони трикутника: a={a}, b={b}, c={c}");
        }

        public double Per()
        {
            return ToDouble(a) + ToDouble(b) + ToDouble(c);
        }

        public double Area()
        {
            double aa = ToDouble(a), bb = ToDouble(b), cc = ToDouble(c);
            double p = (aa + bb + cc) / 2;
            return Math.Sqrt(p * (p - aa) * (p - bb) * (p - cc));
        }

        public bool IsEqual(Triangle<T> t)
        {
            return Math.Abs(this.Area() - t.Area()) < 1e-6;
        }

        public static Triangle<double> operator +(Triangle<T> t1, Triangle<T> t2)
        {
            return new Triangle<double>(
                Convert.ToDouble(t1.a) + Convert.ToDouble(t2.a),
                Convert.ToDouble(t1.b) + Convert.ToDouble(t2.b),
                Convert.ToDouble(t1.c) + Convert.ToDouble(t2.c)
            );
        }

        public static Triangle<double> operator -(Triangle<T> t1, Triangle<T> t2)
        {
            return new Triangle<double>(
                Convert.ToDouble(t1.a) - Convert.ToDouble(t2.a),
                Convert.ToDouble(t1.b) - Convert.ToDouble(t2.b),
                Convert.ToDouble(t1.c) - Convert.ToDouble(t2.c)
            );
        }

        public static Triangle<double> operator *(Triangle<T> t, double k)
        {
            return new Triangle<double>(
                Convert.ToDouble(t.a) * k,
                Convert.ToDouble(t.b) * k,
                Convert.ToDouble(t.c) * k
            );
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.Write("\nВведіть множник: ");
            double k = Convert.ToDouble(Console.ReadLine());

            Triangle<int> t1 = new Triangle<int>();
            Console.WriteLine("Введіть дані для першого трикутника:");
            t1.Input();

            Triangle<int> t2 = new Triangle<int>();
            Console.WriteLine("\nВведіть дані для другого трикутника:");
            t2.Input();

            Console.WriteLine("\nТрикутник 1:");
            t1.Output();
            Console.WriteLine($"Периметр: {t1.Per()}");
            Console.WriteLine($"Площа: {t1.Area():F2}");

            Console.WriteLine("\nТрикутник 2:");
            t2.Output();

            var t3 = t1 + t2;
            Console.WriteLine("\nПісля додавання (t1+t2):");
            t3.Output();

            var t4 = t1 - t2;
            Console.WriteLine("\nПісля віднімання (t1-t2):");
            t4.Output();

            var t5 = t1 * k;
            Console.WriteLine("\nПісля множення t1:");
            t5.Output();

            Console.WriteLine("\nПорівняння t1 і t2 за площею:");
            Console.WriteLine(t1.IsEqual(t2) ? "Трикутники рівні за площею" : "Трикутники не рівні за площею");
        }
    }
}
