using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT10_parameter_method
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Демонстрация параметров методов ===");

            int a = 10;
            Console.WriteLine($"До ModifyValue: {a}");
            ModifyValue(a);
            Console.WriteLine($"После ModifyValue: {a}\n");

            int b = 20;
            Console.WriteLine($"До ModifyRef: {b}");
            ModifyRef(ref b);
            Console.WriteLine($"После ModifyRef: {b}\n");

            if (GetRandomNumber(out int random))
            {
                Console.WriteLine($"Случайное число: {random}");
            }

            if (TryDivide(10, 2, out double result))
            {
                Console.WriteLine($"Результат деления: {result}");
            }

            if (TryDivide(10, 0, out double errorResult))
            {
                Console.WriteLine($"Результат деления: {errorResult}");
            }
            else
            {
                Console.WriteLine("Деление на ноль невозможно!\n");
            }

            SumAndPrint(1, 2, 3, 4, 5);
            SumAndPrint(10, 20);
            SumAndPrint();

            string[] names = { "Анна", "Борис", "Виктор" };
            PrintNames("Список имен:", names);
        }

        static void ModifyValue(int x)
        {
            Console.WriteLine($"В ModifyValue до изменения: {x}");
            x = 999;
            Console.WriteLine($"В ModifyValue после изменения: {x}");
        }

        static void ModifyRef(ref int x)
        {
            Console.WriteLine($"В ModifyRef до изменения: {x}");
            x++;
            Console.WriteLine($"В ModifyRef после изменения: {x}");
        }

        static bool GetRandomNumber(out int number)
        {
            number = new Random().Next(1, 101);
            return true;
        }

        static bool TryDivide(double dividend, double divisor, out double quotient)
        {
            if (divisor != 0)
            {
                quotient = dividend / divisor;
                return true;
            }
            else
            {
                quotient = 0;
                return false;
            }
        }

        static void SumAndPrint(params int[] values)
        {
            if (values.Length == 0)
            {
                Console.WriteLine("Массив пуст, сумма: 0");
                return;
            }

            int sum = 0;
            Console.Write($"Суммируем числа: ");
            foreach (int v in values)
            {
                Console.Write($"{v} ");
                sum += v;
            }
            Console.WriteLine($"\nСумма {values.Length} чисел: {sum}\n");
        }

        static void PrintNames(string message, params string[] names)
        {
            Console.WriteLine(message);
            foreach (string name in names)
            {
                Console.WriteLine($" - {name}");
            }
            Console.WriteLine();
        }
    }
}