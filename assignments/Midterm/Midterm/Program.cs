using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Program
    {
        static void Main(string[] args)
        {
            Pyramid[] p = new Pyramid[6];
            for(int i = 0; i < 6; i++)
            {
                p[i] = new Pyramid(i);
            }

            foreach(Pyramid el in p)
            {
                Console.WriteLine(el.ToString());
                el.Print();
            }

            using(StreamWriter writer = new StreamWriter("Pyramid.txt"))
            {
                foreach(Pyramid el in p)
                {
                    writer.WriteLine("{0}", el.ToString());
                    WritePyramid(writer, el);
                }
            }
        }

        public static void WritePyramid(StreamWriter w, Pyramid p)
        {
            for (int i = 0; i < p.Size; i++)
            {
                for (int j = (p.Size - 1) - i; j > 0; j--)
                {
                    w.Write(' ');
                }

                for (int j = 0; j < (i * 2) + 1; j++)
                {

                    w.Write("X");
                }
                w.WriteLine();
            }
            w.WriteLine();
        }
    }
}
