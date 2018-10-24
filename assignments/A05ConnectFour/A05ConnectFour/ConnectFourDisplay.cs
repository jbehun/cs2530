// Project: Connect Four
// File   : ConnectFourDisplay.cs
// Name   : Justin Behunin
// Date   : 3/4/2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A05ConnectFour
{
    //prints out the game display
    class ConnectFourDisplay
    {
        private Player player1;
        private Player player2;

        public ConnectFourDisplay(Player p1, Player p2, int[,] board)
        {
            player1 = p1;
            player2 = p2;
            PrintBoard(board);
        }

        public void PrintBoard(int [,] board)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(5, 3 + i);
                for (int j = 0; j < 10; j++)
                    Console.Write("{0} ",' ');
                Console.WriteLine();
            }

            Console.SetCursorPosition(9 , 4);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Connect Four");

            Console.ResetColor();

            Console.SetCursorPosition(6, 7);
            Console.WriteLine("1  2  3  4  5  6  7\n");
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.SetCursorPosition(5, 8 + i);
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 1)
                        Console.BackgroundColor = player1.Color;
                    else if (board[i, j] == 2)
                        Console.BackgroundColor = player2.Color;
                    else
                        Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("{0}", "|_|");
                }
                    
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
