using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This file should not be changed
namespace _2530_Final
{
    public class Program
    {
        static void Main(string[] args)
        {
            Final myFinal = new Final();

            Console.WriteLine("\n\n- - - - - - Part Dictionary: - - - - - - \n");
            myFinal.PartDictionary();

            Console.WriteLine("\n\n- - - - - - Part Delegate: - - - - - - \n");
            myFinal.PartDelegateLambda();

            Console.WriteLine("\n\n- - - - - - Part Linq - - - - - - \n");
            myFinal.PartLinq();

            Console.WriteLine("\n\n- - - - - - Part Iterator : - - - - - - \n");
            myFinal.PartIterator();

        }

    }
}
