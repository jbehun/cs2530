using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegate
{
    class Program
    {
        static List<int> data = new List<int> { 3, 5, 7 };

        static void Main(string[] args)
        {
            DrawAll(ConsoleDrawing.Triangle);

            // TODO
            // 1
            DrawAll(ConsoleDrawing.Square);
            // 2
            DrawAll( i => ConsoleDrawing.Frame(i,i*2));
            // 3
            DrawAll( i => ConsoleDrawing.Line(i,'~'));
            //4
            DrawAll( i => ConsoleDrawing.Diamond5x5());

        }

        private static void DrawAll(Action<int> drawMethod)
        {
            foreach (int number in data)
            {
                drawMethod(number);
                Console.WriteLine();
            }
        }
    }
}
