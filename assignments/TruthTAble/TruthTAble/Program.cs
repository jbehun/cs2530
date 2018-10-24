using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TruthTAble
{
    class Program
    {
        static void Main(string[] args)
        {
            bool p = true;
            bool q = true;
            Console.WriteLine(p ^ !q);
            p = true;
            q = false;
            Console.WriteLine(p ^ !q);
            p = false;
            q = true;
            Console.WriteLine(p ^ !q);
            p = false;
            q = false;
            Console.WriteLine(p ^ !q);
        }
    }
}
