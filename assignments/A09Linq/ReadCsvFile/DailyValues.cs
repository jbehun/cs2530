/* Project: A08 Linq 
 * File:    DailyValues.cs
 * Name:    Justin Behunin
 * Date:    4/7/2015
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace ReadCsvFile
{
    struct DailyValues
    {
        public DateTime Date { get; private set; }
        public decimal Open { get; private set; }
        public decimal High { get; private set; }
        public decimal Low { get; private set; }
        public decimal Close { get; private set; }
        public decimal Volume { get; private set; }
        public decimal AdjClose { get; private set; }

        public DailyValues(DateTime date, decimal open, decimal high, decimal low,
            decimal close, decimal volume, decimal adjClose)
            : this()
        {
            Date = date;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
            AdjClose = adjClose;
        }

        public override string ToString()
        {
            return string.Format("O:{0} / H:{1} / L:{2} / C:{3} / V:{4} / AC:{5} / {6:d}",
                    Open, High, Low, Close, Volume, AdjClose, Date);
        }

        // reads stock values from csv file into a List
        public static List<DailyValues> GetStockValues(string filePath)
        {
            List<DailyValues> values = new List<DailyValues>();

            DateTime date = new DateTime();
            DateTime dateResult;
            decimal result;
            decimal[] data = new decimal[6];


            // TODO: add the data from the csv file
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    string[] fileValues;
                    line = reader.ReadLine();
                    while ((line = reader.ReadLine()) != null)
                    {
                        fileValues = line.Split(',');

                        //get date
                        if (DateTime.TryParse(fileValues[0], out dateResult))
                        {
                            date = dateResult;
                        }
                        else
                        {
                            Console.WriteLine("Unable to parse {0}", fileValues[0]);
                        }

                        //get the decimal values
                        for (int i = 1; i < fileValues.Length; i++)
                        {
                            if (decimal.TryParse(fileValues[i], out result))
                            {
                                data[i - 1] = result;
                            }
                            else
                            {
                                Console.WriteLine("Unable to parse {0}", fileValues[i + 1]);
                            }
                        }

                        //adds each line of input to the list creating a new DailyValue
                        values.Add(new DailyValues(date, data[0], data[1], data[2], data[3], data[4], data[5]));
                    }//end while loop
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("A problem occured opening " + filePath);
                Console.WriteLine(ex.ToString());
            }

            return values;
        }
    }
}
