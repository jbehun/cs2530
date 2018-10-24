// Project: Connect Four
// File   : Program.cs
// Name   : Justin Behunin
// Date   : 3/4/2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A05ConnectFour
{
    class Program
    {
        //runs the game, gets player input, prints game results
        static void Main(string[] args)
        {
            bool gameOver = false;
            Player p1 = new Player(ConsoleColor.Yellow, 1);
            Player p2 = new Player(ConsoleColor.Red, 2);
            ConnectFour game = new ConnectFour(p1, p2);

            while (ConnectFour.count < 42 && !gameOver)
            {
                //Player 1 turn
                ClearText(16);
                Console.SetCursorPosition(7, 16);
                Console.ForegroundColor = p1.Color;
                Console.Write("Player 1 Choose: ");
                Console.ForegroundColor = ConsoleColor.White;
                game.AddPlayerPiece(getColumn(game), p1);
                if (game.CheckWin())
                {
                    p1.WonGame();
                    break;
                }

                //Player2 turn
                ClearText(16);
                Console.SetCursorPosition(7, 16);
                Console.ForegroundColor = p2.Color;
                Console.Write("Player 2 Choose: ");
                Console.ForegroundColor = ConsoleColor.White;
                game.AddPlayerPiece(getColumn(game), p2);
                if (game.CheckWin())
                {
                    p2.WonGame();
                    break;
                }
            }//end while block

            //print end game result
            Console.SetCursorPosition(5, 16);
            if (p1.wonGame)
            {
                Console.ForegroundColor = p1.Color;
                Console.WriteLine("Player 1 won the game");
            }
            else if (p2.wonGame)
            {
                Console.ForegroundColor = p2.Color;
                Console.WriteLine("Player 2 won the game");
            }
            else
            {
                Console.SetCursorPosition(11, 16);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Draw Game");
            }

            Console.ResetColor();
            Console.SetCursorPosition(5, 18);
            Console.Write("Press Enter to Exit ");
            Console.ReadLine();
        }

        //get player input for column number and check to see if column is full
        #region Get Column
        public static int getColumn(ConnectFour game)
        {
            int column = 0;
            do
            {
                int.TryParse(Console.ReadLine(), out column);
                if (column < 1 || column > 7)
                {
                    ClearText(17);
                    Console.SetCursorPosition(7, 17);
                    Console.Write("Choose 1 - 7: ");
                }
                else if(game.ColumnFull(column) == true)
                {
                    ClearText(17);
                    Console.SetCursorPosition(7, 17);
                    Console.WriteLine("Column {0} is full ", column);
                    Console.SetCursorPosition(7, 18);
                    Console.Write("Choose again: ");
                    column = 0;
                }
            } while (column < 1 || column > 7);

            return column;
        }
        #endregion

        //clears text for player input
        public static void ClearText(int line)
        {
            for (int i = 0; i < 3; i++)
            { 
                Console.SetCursorPosition(0, line + i);
            Console.WriteLine("{0,35}", " ");
        }
        }
    }
}
