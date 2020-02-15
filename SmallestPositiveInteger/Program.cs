﻿using System;

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

            Console.WriteLine($"Result: {Solotion(array01)}");
            Console.WriteLine($"Result: {Solotion(array02)}");
            Console.WriteLine($"Result: {Solotion(array03)}");
            Console.WriteLine($"Result: {Solotion(array04)}");

            Console.ReadLine();
        }

        static int Solotion(int[] array)
        {
            var result = 0;

            for (int i = 1; i <= 1000000; i++)
            {
                if (Array.IndexOf(array, i) == -1)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }
    }
}
