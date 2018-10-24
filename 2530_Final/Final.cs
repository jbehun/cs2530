using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final
{
    public class Final
    {
        #region Dictionary
        public void PartDictionary()
        {
            Dictionary<string, double> tallestBuildings = new Dictionary<string, double> {
            {"Burj Khalifa", 829.8},
            {"Tokyo Sky Tree", 634}, 
            {"KVLY-TV mast", 628.8}, 
            {"Abraj Al Bait Towers", 601},
            {"Lualualei VLF transmitter", 458},
            {"Ekibastuz GRES-2 Power Station", 419.7 }};

            // 1) add another dictionary entry: "Gateway Arch" and 192 meters
            tallestBuildings.Add("Gateway Arch", 192);

            // 2) delete the entry for the following building: "Ekibastuz GRES-2 Power Station"
            tallestBuildings.Remove("Ekibastuz GRES-2 Power Station");

            // 3) display all of the tallest buildings in two straight columns
            Console.WriteLine("{0,-26} {1,-7}\n", "Building", "Height");
            foreach (KeyValuePair<string, double> el in tallestBuildings)
            {
                Console.WriteLine("{0,-26} {1,-7}", el.Key, el.Value);
            }

        }
        #endregion

        #region Delegate | Lambda
        // fields   . . . why are they declared here? Just to save you some scrolling
        private string title = "General";
        private string name = "Watson";

        // methods
        public void PartDelegateLambda()
        {
            // Take a moment to look at class Greetings. It includes three greeting methods

            // 1) call the method PrintGreeting. Pass the static method FormalWelcome from class Greetings as an argument
            PrintGreeting((title, name) => Greetings.FormalWelcome(title, name));

            // 2) call the method PrintGreeting. Pass the static method FriendGreeting as an argument
            PrintGreeting((title, name) => Greetings.FriendGreeting());

            // 3) call the method PrintGreeting. Pass the static method SpecialOccasionGreeting as an argument
            //    it should print a Birthday greeting
            PrintGreeting((title, name) => Greetings.SpecialOccasionGreeting(SpecialOccasion.birthday, title, name));

        }

        private void PrintGreeting(Func<string, string, string> getGreeting)
        {
            string greeting = getGreeting(title, name);
            DottedLine(greeting.Length + 6);
            Console.WriteLine(".  {0}  .", greeting);
            DottedLine(greeting.Length + 6);
            Console.WriteLine();
        }

        private void DottedLine(int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write('.');
            }
            Console.WriteLine();
        }
        #endregion

        #region Linq
        public void PartLinq()
        {
            // field
            List<RealEstate> houses = new List<RealEstate> {
                new RealEstate(2, 2, 1350, 1992, true),
                new RealEstate(1, 2, 1350, 2009, true),
                new RealEstate(2, 1, 1120, 1996, false),
                new RealEstate(3, 2.5, 2530, 1986, false),
                new RealEstate(2, 2, 1650, 1998, true),
                new RealEstate(1, 2, 1080, 1992, true),
                new RealEstate(3, 3.5, 3150, 2012, false),
                new RealEstate(2, 2, 2100, 2004, false)
            };
            Console.WriteLine("List of houses:");
            Console.WriteLine(string.Join("\n", houses) + "\n");

            // 1)	Write a query that lists all the houses sorted by the year when they
            //      were built (newest houses should be listed first). Then print the result
            IEnumerable<RealEstate> housesByYear =
                (from h in houses
                 select h).OrderByDescending(h => h.Year);
            Console.WriteLine("Sorted by year");
            foreach (RealEstate re in housesByYear)
            {
                Console.WriteLine(re);
            }

            // 2)	Write a query that lists the year, the number of bedrooms
            //     and the number of baths for all houses. Then print the result
            var yearBedsAndBaths =
                from h in houses
                select new { h.Year, h.Beds, h.Baths };
            Console.WriteLine("\nYear Beds Baths");
            foreach (var el in yearBedsAndBaths)
            {
                Console.WriteLine("{0} {1,4} {2,5}", el.Year, el.Beds, el.Baths);
            }

            // 3)	Write a query that lists the size (in square feet) and the year
            //      for all houses that are on sale. It should be ordered by size. 
            //      Print the result
            var sizeYearForSale =
                (from h in houses
                 where h.ForSale
                 select new { h.Sqft, h.Year }).OrderBy(h => h.Sqft);
            Console.WriteLine("\nHouses for Sale\nSize Year");
            foreach (var el in sizeYearForSale)
            {
                Console.WriteLine("{0} {1}", el.Sqft, el.Year);
            }


            // 4)	Group the houses by bedrooms and print the result
            //      the result should be sorted by the number of bedrooms
            var groupByBedrooms =
                (from h in houses
                 group h by h.Beds).OrderBy(g => g.Key);

            Console.WriteLine("\nGrouped by bedrooms");
            foreach (var group in groupByBedrooms)
            {
                Console.WriteLine("{0}", group.Key);
                foreach (RealEstate el in group)
                {
                    Console.WriteLine("     {0}", el);
                }
            }
        }
        #endregion

        #region Iterator
        public void PartIterator()
        {
            Numbers myNumbers =
                new Numbers(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });

            // 1) Go to the file Numbers.cs and implement the three iterators that are described there

            // 2) Here in this method write some code to test all three iterators 
            //    Use single empty lines to make your output clear and easy to read

            Console.WriteLine("Double Elements: ");
            foreach(int i in myNumbers.DoubleElements())
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("\n");

            Console.WriteLine("Reverse Numbers: ");
            foreach (int i in myNumbers.ReversNumbers())
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("\n");

            Console.WriteLine("Third Elements: ");
            foreach (int i in myNumbers.ThirdElemnts())
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("\n");
        }
        #endregion
    }
}
