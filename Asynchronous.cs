using System;
using System.Threading.Tasks;

class Asynchronous
{
    static async Task Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Введіть рядки. Для виходу введіть 'exit'.");

        while (true)
        {
         
            string input = Console.ReadLine();

            if (input?.ToLower() == "exit")
                break;

            // Запускаю обчислення асинхронно, не блокуючи консоль
            _ = ProcessLineAsync(input);
        }

        Console.WriteLine("Програма завершена. Натисніть будь-яку клавішу...");
        Console.ReadKey();
    }

    // Асинхронний метод обробки рядка
    static async Task ProcessLineAsync(string line)
    {
        try
        {
            Console.WriteLine($"[Старт] Обробка: {line}");

            
            await Task.Delay(2000);

            // довжина рядка
            int length = line.Length;

            Console.WriteLine($"[Готово] Рядок: '{line}', довжина: {length}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при обробці рядка '{line}': {ex.Message}");
        }
    }
}

