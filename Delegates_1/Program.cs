using System;

namespace Delegates_1
{
    delegate void OpStroke(ref int[] arr);

    public class ArrOperation
    {
        public static void WriteArray(ref int[] arr)
        {
            Console.WriteLine("Исходный массив: ");
            foreach (int i in arr)
                Console.Write("{0}\t", i);
            Console.WriteLine();
        }

        // Сортировка массива
        public static void IncSort(ref int[] arr)
        {
            int j, k;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                j = 0;
                do
                {
                    if (arr[j] > arr[j + 1])
                    {
                        k = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = k;
                    }
                    j++;
                }
                while (j < arr.Length - 1);
            }

            Console.WriteLine("Отсортированный массив в большую сторону: ");
            foreach (int i in arr)
                Console.Write("{0}\t", i);
            Console.WriteLine();
        }

        public static void DecSort(ref int[] arr)
        {
            int j, k;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                j = 0;
                do
                {
                    if (arr[j] < arr[j + 1])
                    {
                        k = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = k;
                    }
                    j++;
                }
                while (j < arr.Length - 1);
            }

            Console.WriteLine("Отсортированный массив в меньшую сторону: ");
            foreach (int i in arr)
                Console.Write("{0}\t", i);
            Console.WriteLine();
        }

        // Заменяем нечетные числа четными и наоборот
        public static void ChetArr(ref int[] arr)
        {
            Console.WriteLine("Четный массив: ");
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] % 2 != 0)
                    arr[i] += 1;

            foreach (int i in arr)
                Console.Write("{0}\t", i);
            Console.WriteLine();
        }

        public static void NeChetArr(ref int[] arr)
        {
            Console.WriteLine("Нечетный массив: ");
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] % 2 == 0)
                    arr[i] += 1;

            foreach (int i in arr)
                Console.Write("{0}\t", i);
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            int[] myArr = new int[6] { 2, -4, 10, 5, -6, 9 };

            // Структуируем делегаты
            OpStroke Del;
            OpStroke Wr = ArrOperation.WriteArray;
            OpStroke OnSortArr = ArrOperation.IncSort;
            OpStroke OffSortArr = ArrOperation.DecSort;
            OpStroke ChArr = ArrOperation.ChetArr;
            OpStroke NeChArr = ArrOperation.NeChetArr;

            // Групповая адресация
            Del = Wr;
            Del += OnSortArr;
            Del += ChArr;
            Del += OffSortArr;
            Del += NeChArr;

            // Выполняем делегат
            Del(ref myArr);

            Console.ReadLine();
        }
    }
}