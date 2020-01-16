using System;
using System.Text;

namespace ReverseWords02
{
    // input : Bill Gates is the richest man on Earth
    // output : lliB setaG si eht tsehcir nam no htraE

    class Program
    {
        static string ReverseWords(string input)
        {
            var space = ' ';            
            var word = new StringBuilder();
            var output = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                var chr = input[i];

                if (chr != space)
                    word.Insert(0, chr);
                else
                {
                    output.Append(word);
                    output.Append(space);

                    word.Clear();
                }
            }

            output.Append(word); // the end word

            return output.ToString();
        }

        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Console.WriteLine(ReverseWords(input));

            Console.ReadKey();
        }
    }
}
