using System;
using System.Collections.Generic;
using System.Linq;

using System.Text.RegularExpressions;

namespace NewTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var text = "I'm a very good programmer. Even though I am just 12 years old.";
            //var text2 = "a b c xxx yyy zzz _";

            //var analyze = new DocumentProcessor().Analyze(text2);

            var array = new int[] { 3, 5, 6, 3, 3, 5 };

            var count = 0;
            for (int i = 0; i < array.Length; i++)
            {

                if (Array.IndexOf(array, array[i]) > i && Array.Exists(array, x => x == array[i]))
                    count++;
            }

            Console.ReadLine();
        }
    }

    public interface IDocumentProcessor
    {
        /// <summary>
        /// Analyzes the document and returns statistics.
        /// </summary>
        /// <exception cref="ArgumentNullException">document is null</exception>
        Stats Analyze(string document);
    }

    public class DocumentProcessor : IDocumentProcessor
    {
        /// <summary>
        /// Analyzes the document and returns statistics.
        /// </summary>
        /// <exception cref="ArgumentNullException">document is null</exception>
        public Stats Analyze(string document)
        {
            var digits = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var spcialCharacters = new[] { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "+", "=", "/", @"\" };

            var doc = document.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var regex = new Regex("^[0-9]+$");

            var wordLength = doc.Select(word => new { Word = word, CharLength = word.Length });

            var digitWords = doc.Where(word => regex.IsMatch(word));
            var noDigitWords = doc.Where(word => !regex.IsMatch(word));

            return new Stats
            {
                NumberOfAllWords = doc.Length,
                NumberOfWordsThatContainOnlyDigits = digitWords.Count(),
                NumberOfWordsStartingWithSmallLetter = noDigitWords.Count(word => !spcialCharacters.Contains(word[0].ToString()) && word[0] == word.ToLower()[0]),
                NumberOfWordsStartingWithCapitalLetter = noDigitWords.Count(word => !spcialCharacters.Contains(word[0].ToString()) && word[0] == word.ToUpper()[0]),
                TheLongestWord = wordLength.OrderByDescending(word => word.CharLength).FirstOrDefault().Word,
                TheShortestWord = wordLength.OrderBy(word => word.CharLength).FirstOrDefault().Word
            };
        }
    }

    public class Stats
    {
        // Total number of all words in the document
        public int NumberOfAllWords { get; set; }

        // Returns number of words that consist only from digits e.g. 13455, 98374
        public int NumberOfWordsThatContainOnlyDigits { get; set; }

        // Returns number of words that start with a lower letter e.g. a, d, z
        public int NumberOfWordsStartingWithSmallLetter { get; set; }

        // Returns number of words that start with a capital letter e.g. A, D, Z
        public int NumberOfWordsStartingWithCapitalLetter { get; set; }

        // Returns the first longest word in the document
        public string TheLongestWord { get; set; }

        // Returns the first shortest word in the document
        public string TheShortestWord { get; set; }
    }
}
