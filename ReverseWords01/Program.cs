using System;
using System.Text;

namespace ReverseWords01
{
    // input : Bill Gates is the richest man on Earth
    // output : Earth on man richest the is Gates Bill

    class Program
    {
        static string ReverseWordsMethod01(string input)
        {
            var space = ' ';
            var words = input.Split(space);

            Array.Reverse(words);

            return string.Join(space, words);
        }

        static string ReverseWordsMethod02(string input)
        {
            var space = ' ';
            var words = input.Split(space);
            var output = new StringBuilder();

            for (int i = words.Length - 1; i >= 0; i--)
                if (i == 0)
                    output.Append($"{words[i]}");
                else
                    output.Append($"{words[i]}{space}");

            return output.ToString();
        }

        static string ReverseWordsMethod03(string input)
        {
            var space = ' ';
            var word = new StringBuilder();
            var output = new StringBuilder();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                var chr = input[i];
                
                if (chr != space)
                    word = word.Insert(0, chr);               
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

            Console.WriteLine($"{ReverseWordsMethod01(input)} => Method01");
            Console.WriteLine($"{ReverseWordsMethod02(input)} => Method02");
            Console.WriteLine($"{ReverseWordsMethod03(input)} => Method03");

            Console.ReadKey();
        }
    }
}
