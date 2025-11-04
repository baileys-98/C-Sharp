using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT8
{
    class Box<T>
    {
        private T item;
        private bool hasItem = false;

        public void Put(T item)
        {
            this.item = item;
            hasItem = true;
        }

        public T Get()
        {
            if (!hasItem)
                throw new InvalidOperationException("Коробка пуста");
            return item;
        }

        public bool IsEmpty => !hasItem;
    }

    static class Utils
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public static void DisplayInfo<T>(T value)
        {
            Console.WriteLine($"Значение: {value}, Тип: {typeof(T).Name}");
        }
    }

    class Pair<T1, T2>
    {
        public T1 First { get; }
        public T2 Second { get; }

        public Pair(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }

        public override string ToString()
        {
            return $"({First}, {Second})";
        }
    }

    class Program
    {
        static void Main()
        {

            Box<int> intBox = new Box<int>();
            intBox.Put(42);
            Console.WriteLine($"Число в коробке: {intBox.Get()}");
            Console.WriteLine($"Коробка пуста: {intBox.IsEmpty}");

            Box<string> strBox = new Box<string>();
            strBox.Put("Hello");
            Console.WriteLine($"Строка в коробке: {strBox.Get()}");

            int a = 5, b = 10;
            Console.WriteLine($"\nДо Swap: {a}, {b}");
            Utils.Swap(ref a, ref b);
            Console.WriteLine($"После Swap: {a}, {b}");

            string s1 = "Hello", s2 = "World";
            Console.WriteLine($"До Swap: {s1}, {s2}");
            Utils.Swap(ref s1, ref s2);
            Console.WriteLine($"После Swap: {s1}, {s2}");

            Pair<int, string> pair = new Pair<int, string>(5, "Hello");
            Console.WriteLine($"\nПара: {pair}");
            Console.WriteLine($"Первое значение: {pair.First}, Второе значение: {pair.Second}");

            Utils.DisplayInfo(123);
            Utils.DisplayInfo("Test String");

            Pair<double, bool> anotherPair = new Pair<double, bool>(3.14, true);
            Console.WriteLine($"\nДругая пара: {anotherPair}");
        }
    }
}