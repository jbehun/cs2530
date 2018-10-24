/* Project: A08 Linq 
 * File:    Program.cs
 * Name:    Justin Behunin
 * Date:    4/7/2015
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ReadCsvFile
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DailyValues> stockValues = DailyValues.GetStockValues("Toyota.csv");

            Console.WriteLine("\n= = =   Q u e s t i o n   a   = = = \n");
            questionA(stockValues);

            Console.WriteLine("\n= = =   Q u e s t i o n   b   = = = \n");
            questionB(stockValues);

            Console.WriteLine("\n= = =   Q u e s t i o n   c   = = = \n");
            questionC(stockValues);

            Console.WriteLine("\n= = =   Q u e s t i o n   d   = = = \n");
            questionD(stockValues);

            Console.WriteLine("\n= = =   Q u e s t i o n   e   = = = \n");
            questionE(stockValues);
        }

        #region question A - E
        // Find the highest and the lowest amount the stock ever traded for
        // and display the values together with the corresponding dates
        private static void questionA(List<DailyValues> stockValues)
        {
            decimal highest = stockValues.Max(x => x.High);
            decimal lowest = stockValues.Min(x => x.Low);

            var highestAmountandDate =
                (from sv in stockValues
                 where sv.High == highest
                 select new { sv.High, sv.Date }).Max();

            var lowestAmountandDate =
                (from sv in stockValues
                 where sv.Low == lowest
                 select new { sv.Low, sv.Date }).Min();


            Console.WriteLine("Highest price traded: {0} on {1:yyyy/MM/dd}",
                highestAmountandDate.High, highestAmountandDate.Date);

            Console.WriteLine("Lowest price traded : {0} on {1:yyyy/MM/dd}",
                lowestAmountandDate.Low, lowestAmountandDate.Date);
        }

        // Calculate the average volume traded per day
        private static void questionB(List<DailyValues> stockValues)
        {
            Console.WriteLine("Avg Volume traded per day: {0:0.#}",
                GetAverageVolume(stockValues));
        }

        private static decimal GetAverageVolume(List<DailyValues> stockValues)
        {
            decimal averageVolume = (from sv in stockValues
                                     select sv.Volume).Average();
            return averageVolume;
        }

        // How many times was the trading volume higher than the average? How many times was it lower? 
        private static void questionC(List<DailyValues> stockValues)
        {
            decimal averageVolume = GetAverageVolume(stockValues);

            int higherThanAverage =
                (from sv in stockValues
                 where sv.Volume > averageVolume
                 select sv.Volume).Count();
            int lowerThanAverage =
                (from sv in stockValues
                 where sv.Volume < averageVolume
                 select sv.Volume).Count();

            Console.WriteLine("Volume > Average: {0} times", higherThanAverage);
            Console.WriteLine("Volume < Average: {0} times", lowerThanAverage);

        }

        // In descending order list the 10 highest ‘open values’ with the corresponding dates  
        private static void questionD(List<DailyValues> stockValues)
        {
            var tenHighestOpen =
                stockValues.Select((sv) => new { sv.Open, sv.Date }).OrderByDescending(sv => sv.Open).Take(10);

            Console.WriteLine("10 heighest opening values:");
            foreach (var el in tenHighestOpen)
            {
                Console.WriteLine("{0:0.00} {1:yyyy/MM/dd}", el.Open, el.Date);
            }

        }

        // Calculate the average volume traded for each of the calendar years
        private static void questionE(List<DailyValues> stockValues)
        {
            var allYears =
                (from sv in stockValues
                group sv by sv.Date.Year into g
                select new { Year = g.Key, Volume = g }).OrderBy(g => g.Year);

            Console.WriteLine("Average volume per calender year:");
            foreach(var group in allYears)
            {
                Console.WriteLine("{0} vol: {1:0.#}", group.Year, group.Volume.Average(sv => sv.Volume));
            }
        }
        #endregion
    }
}