using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    public struct Pyramid
    {
        public int Size { get; private set; }

        public Pyramid (int size) : this()
        {
            Size = size;
        }

        public void Print()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < Size; i++)
            {
                if (Size > 0)
                {
                    Console.CursorLeft = (Size - 1) - i;
                }

                for (int j = 0; j < (i * 2) + 1; j++)
                {
                    
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.ResetColor();
            Console.WriteLine();
            
        }

        public override string ToString()
        {
 	        return String.Format("Pyramid of size {0}", Size);
        }
    }
}
