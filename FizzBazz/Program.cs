using System;
using System.Collections.Generic;

namespace FizzBazz
{
    class Program
    {        
        /*
         input: 15
         output: 
          1
          2
          Fizz
          4
          Bazz
          Fizz
          7
          8
          Fizz
          Bazz
          11
          Fizz
          13
          14
          FizzBazz
         */

        public static List<string> FizzBazz(int number)
        {
            var output = new List<string>();

            for (int i = 1; i <= number; i++)
            {
                var isFizz = i % 3 == 0;
                var isBazz = i % 5 == 0;

                if (isFizz && isBazz)
                    output.Add("FizzBazz");

                else if (isFizz)
                    output.Add("Fizz");

                else if (isBazz)
                    output.Add("Bazz");

                else
                    output.Add(i.ToString());
            }

            return output;
        }

        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            FizzBazz(number).ForEach(number => Console.WriteLine(number));

            Console.ReadKey();
        }
    }
}
