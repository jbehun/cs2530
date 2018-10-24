using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This file should not be changed
namespace _2530_Final
{
    public class RealEstate
    {
        public int Beds { get; set; }       // number of bedrooms
        public double Baths { get; set; }   // number of bathrooms
        public int Sqft { get; set; }       // square feet
        public int Year { get; set; }       // the year the house was built
        public bool ForSale { get; set; }

        public RealEstate(int beds, double baths, int sqft, int year, bool forSale)
        {
            Beds = beds;
            Baths = baths;
            Sqft = sqft;
            Year = year;
            ForSale = forSale;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} beds {2,-3} baths {3} sqft {4}",
                ForSale ? '*' : ' ', Beds, Baths, Sqft, Year);
        }
    }
}
