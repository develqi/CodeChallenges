using System;
using System.Linq;
using System.Collections.Generic;

namespace SortDates
{
    class Program
    {
        /*
            Each date is in the dd mmm yyyy where

                 dd => [0-31]
                 mmm => ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
                 yyyy => is four digits
                 
                 Costrants : 2 <= |Dates| <= 30

            input =>  ["01 Mar 2017", "03 Feb 2017", "15 Jan 1988"]
            output => ["15 Jan 1988", "03 Feb 2017", "01 Mar 2017"]
        */

        public static string[] SortDates(string[] dates)
        {
            var months = new [] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            return dates
                .Select(date => new
                 {
                     day = date.Substring(0, 2),
                     month = date.Substring(3, 3),
                     year = date.Substring(7, 4)
                 })
                .OrderBy(date => date.day)
                .OrderBy(date => Array.IndexOf(months, date.month))
                .OrderBy(date => date.year)
                .Select(date => $"{date.day} {date.month} {date.year}")
                .ToArray();
        }

        static void Main(string[] args)
        {
            var dates = new[]
            {
                "01 Mar 2017",
                "03 Feb 2017",
                "15 Jan 1988"
            };

            SortDates(dates).ToList().ForEach(date => Console.WriteLine(date));

            Console.ReadLine();
        }
    }
}
