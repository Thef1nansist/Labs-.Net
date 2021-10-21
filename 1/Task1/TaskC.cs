using System;

namespace Task1
{
    public static class TaskC
    {
        public static void SumArr()
        {
            Console.WriteLine("Enter array size: ");

            var countOfArray = int.Parse(Console.ReadLine());

            if (countOfArray < 2)
            {
                Console.WriteLine("Array size can't be < 2");
                return;
            }

            var arr = new int[countOfArray];
            var max = int.MinValue;
            var min = int.MaxValue;
            var minId = 0;
            var maxId = 0;
            var sum = 0;

            Console.WriteLine("Fill the array with elements: ");

            for (var i = 0; i < countOfArray; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    minId = i;
                }
                else if (arr[i] >= max)
                {
                    max = arr[i];
                    maxId = i;
                }
            }

            var rez = Math.Abs(maxId - minId);
            var startIndex = maxId > minId ? minId : maxId;

            for (var i = startIndex; i <= startIndex + rez; i++)
            {
                sum += arr[i];
            }

            for (var i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.Write("\n Sum:" + sum);
        }
    }
}
