using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Завдання №1
//Створіть інтерфейс ICalc. У ньому мають бути два методи:
//■ int Less(int valueToCompare) — повертає кількість менших значень, ніж valueToCompare;
//■ int Greater(intvalueToCompare) — повертає кількість більших значень, ніж valueToCompare.
//Клас, створений раніше у практичному завданні Array, має імплементувати інтерфейс ICalc.
//Метод Less — повертає кількість елементів масиву менших, ніж valueToCompare.
//Метод Greater — повертає кількість елементів масиву більших, ніж valueToCompare.
//Напишіть код для тестування отриманої функціональності.
//Завдання №2
//Створіть інтерфейс IOutput2. У ньому мають бути два методи:
//■ void ShowEven() — відображає парні значення контейнера з даними;
//■ void ShowOdd() — відображає непарні значення контейнера з даними.
//Клас, створений раніше у практичному завданні Array, має імплементувати інтерфейс IOutput2.
//Метод ShowEven — відображає парні значення з масиву.
//Метод ShowOdd — відображає непарні значення масиву.
//Напишіть код для тестування отриманої функціональності.
//Завдання 3
//Створіть інтерфейс ICalc2. У ньому мають бути два методи:
//■ int CountDistinct() — повертає кількість унікальних значень у контейнері даних;
//■ int EqualToValue(int valueToCompare) — повертає кількість значень, рівних valueToCompare.
//Клас, створений раніше у практичному завданні Array, має імплементувати інтерфейс ICalc2.
//Метод CountDistinct — повертає кількість унікальних значень в масив.
//Метод EqualToValue — повертає кількість елементів масиву, рівних valueToCompare.
//Напишіть код для тестування отриманої функціональності.

namespace InterfaceICalc
{
    public class Array : ICalc, IFillRandom, IOutput2, ICalc2
    {
        private int[] _array;
        private int _size;

        private void CreateArray()
        {
            _array = new int[_size];
        }

        public int Size
        {
            get { return _size; }
            set
            {
                if (_size > 0 && value != _size)
                {
                    _size = value;
                    CreateArray();
                }
            }
        }

        public Array(int size)
        {
            if (size > 0)
            {
                _size = size;
                CreateArray();
            }
        }

        public Array()
        {
            _size = 10;
            CreateArray();
        }

        public int this[int index] //индексатор - отдельная конструкция языка
        {
            get
            {
                if (index >= 0 && index < _size)
                {
                    return _array[index];
                }
                throw new Exception("Некорректный индекс");
            }
            set
            {
                if (index >= 0 && index < _size)
                {
                    _array[index] = value;
                }
            }
        }


        // --------------------------------------  реализация интерфейсов -------------------------------
        public int Greater(int valueToCompare) //— повертає кількість більших значень, ніж valueToCompare.
        {
            int count = 0;
            foreach (var element in _array)
            {
                if (element > valueToCompare)
                    count++;
            }
            return count;
        }

        public int Less(int valueToCompare) // — повертає кількість менших значень, ніж valueToCompare;
        {
            int count = 0;
            foreach (var element in _array)
            {
                if (element < valueToCompare)
                    count++;
            }
            return count;
        }

        public void FillRandom(int min, int max) // заполнение случайными числами
        {
            Random random = new Random();
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = random.Next(min, max);
                Console.Write($"{_array[i]}\t");
            }
        }

        public void ShowEven() // — відображає парні значення контейнера з даними;
        {
            Console.WriteLine("Even elements: ");
            foreach (var element in _array)
            {
                if (element % 2 == 0)
                    Console.Write($"{element}\t");
            }
            Console.WriteLine();
        }

        public void ShowOdd() // — відображає непарні значення контейнера з даними.
        {
            Console.WriteLine("Odd elements: ");
            foreach (var element in _array)
            {
                if (element % 2 != 0)
                    Console.Write($"{element}\t");
            }
            Console.WriteLine();
        }

        public int CountDistinct()// — повертає кількість унікальних значень у контейнері даних;
        {
            HashSet<int> distinctValues = new HashSet<int>();
            foreach (var element in _array)
            {
                distinctValues.Add(element);
            }
            return distinctValues.Count;
        }

        public int EqualToValue(int valueToCompare)// — повертає кількість значень, рівних valueToCompare.
        {
            int count = 0;
            foreach (var element in _array)
            {
                if (element == valueToCompare)
                    count++;
            }
            return count;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            IFillRandom filledArray;
            filledArray = new Array(12); // создание объекта через ссылку на интерфейс
            filledArray.FillRandom(0, 20);
            Console.WriteLine("\n__________________________________________________________________");
            Console.WriteLine("\nLess then 10: " + ((ICalc)filledArray).Less(10)); // вызов метода класса, с помощью приведения типа к интерфейсу ICalc
            Console.WriteLine("Greate then 10: " + ((ICalc)filledArray).Greater(10));
            Console.WriteLine("\n__________________________________________________________________");
            ((IOutput2)filledArray).ShowEven();// вызов метода класса, с помощью приведения типа к интерфейсу IOutput2
            Console.WriteLine("\n__________________________________________________________________");
            ((IOutput2)filledArray).ShowOdd();
            Console.WriteLine("\n__________________________________________________________________");
            Console.WriteLine("distinctValues: " + ((ICalc2)filledArray).CountDistinct()); // вызов метода класса, с помощью приведения типа к интерфейсу ICalc2
            Console.WriteLine("\n__________________________________________________________________");
            Console.WriteLine("Are equivalent to 10: " + ((ICalc2)filledArray).EqualToValue(10));

        }
    }
}
