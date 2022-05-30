using System;
using System.Collections.Generic;

namespace SmallestPositiveInteger
{
    /*
      Task description
      This is a demo task.

      Write a function:

      class Solution { public int solution(int[] A); }

      that, given an array A of N integers, returns the smallest positive integer (greater than 0) that does not occur in A.

      For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.

      Given A = [1, 2, 3], the function should return 4.

      Given A = [−1, −3], the function should return 1.

      Write an efficient algorithm for the following assumptions:

      N is an integer within the range [1..100,000];
      each element of array A is an integer within the range [−1,000,000..1,000,000].
      Copyright 2009–2020 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited.

     */

    class Program
    {
        static void Main(string[] args)
        {
            var array01 = new[] { 1, 3, 6, 4, 1, 2 }; // 5
            var array02 = new[] { 1, 2, 3 }; // 4
            var array03 = new[] { -1, -3 }; // 1
            var array04 = new[] { 1 }; // 2

            Console.WriteLine("< ---------- Solotion01 ----------");

            Console.WriteLine($"Result: {Solotion01(array01)}");
            Console.WriteLine($"Result: {Solotion01(array02)}");
            Console.WriteLine($"Result: {Solotion01(array03)}");
            Console.WriteLine($"Result: {Solotion01(array04)}");

            Console.WriteLine("< ---------- Solotion01 Best Performance ----------");

            Console.WriteLine($"Result: {Solotion02(array01)}");
            Console.WriteLine($"Result: {Solotion02(array02)}");
            Console.WriteLine($"Result: {Solotion02(array03)}");
            Console.WriteLine($"Result: {Solotion02(array04)}");

            Console.ReadLine();
        }

        static int Solotion01(int[] array)
        {
            var result = 1;

            for (int i = 1; i <= 100001; i++)
            {
                if(Array.IndexOf(array, i) == -1)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        static int Solotion02(int[] array)
        {
            var result = 1;

            Array.Sort(array);

            for (int i = 1; i <= 100001; i++)
            {
                if (Array.BinarySearch(array, i) < 0)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        static int Solution03(int[] array)
        {
            var dic = new Dictionary<int, int>(array.Length);

            foreach (var item in array)
            {
                if (item > 0)
                {
                    if (!dic.ContainsKey(item))
                    {
                        dic.Add(item, item);
                    }
                }
            }

            int i;
            
            for (i = 0; i < dic.Count; i++)
            {
                if (!dic.ContainsKey(i + 1))
                {
                    return i + 1;
                }
            }

            if (i != 0)
            {
                return i + 1;
            }

            return 1;
        }
    }
}
