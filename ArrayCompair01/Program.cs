using System;
using System.Text;

namespace ArrayCompair01
{
    class Program
    {
        /*

           input :
              sortedArray01 => [1, 2, 3, 4]
              sortedArray02 => [3, 4, 5, 6]

           output:
              3
              4  

           input 02 :
              sortedArray01 => [1, 2, 3, 4, 7, 11, 25, 95, 124, 411, 1501, 2001]
              sortedArray02 => [3, 7, 9, 11, 15, 19, 20, 95, 202, 401, 411, 1500, 3553 ]

           output 02:
              3
              7
              11
              95
              411
        */

        static string Search01(int[] array01, int[] array02)
        {
            int compairCount = 0;
            var output = new StringBuilder();

            for (int i = 0; i < array01.Length; i++)
            {
                for (int j = 0; j < array02.Length; j++)
                {
                    compairCount++;

                    if (array01[i] == array02[j])
                        output.AppendLine(array01[i].ToString());
                }
            }

            output.AppendLine($"compair count: {compairCount}");

            return output.ToString();
        }

        static string Search02(int[] array01, int[] array02)
        {
            int compairCount = 0;
            var output = new StringBuilder();

            for (int i = 0; i < array01.Length; i++)
            {
                for (int j = 0; j < array02.Length; j++)
                {
                    compairCount++;

                    if (array01[i] == array02[j])
                    {
                        output.AppendLine(array01[i].ToString());
                        break;
                    }
                }
            }

            output.AppendLine($"compair count: {compairCount}");

            return output.ToString();
        }

        static string Search03(int[] array01, int[] array02)
        {
            int compairCount = 0;
            var output = new StringBuilder();

            for (int i = 0; i < array01.Length; i++)
            {
                for (int j = 0; j < array02.Length; j++)
                {
                    compairCount++;

                    if (array01[i] < array02[j])
                        break;

                    if (array01[i] == array02[j])
                    {
                        output.AppendLine(array01[i].ToString());
                        break;
                    }
                }
            }

            output.AppendLine($"compair count: {compairCount}");

            return output.ToString();
        }

        static void Main(string[] args)
        {
            //var array01 = new[] { 1, 2, 3, 4, 7, 11, 25, 95, 124, 411, 1501, 2001 };
            //var array02 = new[] { 3, 7, 9, 11, 15, 19, 20, 95, 202, 401, 411, 1500, 3553 };

            var array01 = new[] { 1, 2, 3, 4 };
            var array02 = new[] { 3, 4, 5, 6 };

            Console.WriteLine("-- Method01 ---------------");
            Console.WriteLine(Search01(array01, array02));

            Console.WriteLine("-- Method02 ---------------");
            Console.WriteLine(Search02(array01, array02));

            Console.WriteLine("-- Method03 ---------------");
            Console.WriteLine(Search03(array01, array02));

            Console.ReadKey();
        }
    }
}
