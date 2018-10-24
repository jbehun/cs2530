using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountByN
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 1; i <= 5; i++)
            {
                for (int J = 0; J < i; J++)
                {
                    Console.Write("{0,3}", i * (J + 1) );
                }
                Console.WriteLine();
            }
        }
    }
}
