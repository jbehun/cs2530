//Project: Game of Life
//Date   : 1/30/2015
//Name   : Justin Behunin

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_Life
{
    class GameOfLife
    {
        private int [,] lifeGrid;
        private int [,] neighborGrid;

        public GameOfLife()
        {

            Console.SetWindowSize(60, 45);
            lifeGrid = new int[25, 40];
            neighborGrid = new int[lifeGrid.GetLength(0), lifeGrid.GetLength(1)];
            IntializeGameOfLife();
        }//end constructor

        public void Start()
        {
            
            PrintIntialGame();
            Console.ReadLine();//pause till enter is pressed
            ChangeUserMessage();

            while (!Console.KeyAvailable)
            {
                CountNeighbors();
                CopyNextGenerationToLifeGrid();
                PrintGameOfLife();
            }
            Console.SetCursorPosition(0, 40);
            Console.WriteLine("\n");    
        }//end start

        private void CountNeighbors()
        {
            int count = 0;

            //totals the number of squares that are alive around each square
            for (int i = 0; i < lifeGrid.GetLength(0); i++)
            {
                for (int j = 0; j < lifeGrid.GetLength(1); j++)
                {
                    count = 0;
                    for (int m = i - 1; m < i + 2; m++)
                    {
                        for (int n = j - 1; n < j + 2; n++)
                        {
                            if ((m > -1) && (m < lifeGrid.GetLength(0)) && (n > -1) && (n < lifeGrid.GetLength(1)))
                            {
                                if (lifeGrid[m, n] == 1)
                                    count += 1;
                            }//end if 
                        }//end n
                    }//end m

                    //deducts 1 if the tested sqaure was alive and counted
                    if (lifeGrid[i, j] == 1)
                    {
                        count -= 1;
                    }
                    neighborGrid[i, j] = count;
                }//end j
            }//end i
        }

        private void CopyNextGenerationToLifeGrid()
        {
            for (int i = 0; i < lifeGrid.GetLength(0); i++)
            {
                for (int j = 0; j < lifeGrid.GetLength(1); j++)
                {
                    if ((neighborGrid[i, j] < 2) || (neighborGrid[i, j] > 3))
                    {
                        lifeGrid[i, j] = 0;
                    }
                    if (neighborGrid[i, j] == 3)
                    {
                        lifeGrid[i, j] = 1;
                    }
                }
            }
        }

        private void PrintIntialGame()
        {
            //print game header
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            
            for(int i = 1; i <= 3; i++)
            {
                Console.SetCursorPosition(10, i + 5);
                for (int j = 0; j < lifeGrid.GetLength(1); j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.SetCursorPosition(24, 7);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Game Of Life");
            Console.ResetColor();

            //print game
            PrintGameOfLife();

            

            //print intial user message
            Console.CursorVisible = false;
            Console.SetCursorPosition(19,38);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Press Enter to Start");
            Console.ResetColor();
        }//end PrintIntialGame

        private void PrintGameOfLife()
        {
            //print game area
            for (int i = 0; i < lifeGrid.GetLength(0); i++)
            {
                Console.SetCursorPosition(10, i + 10);
                for (int j = 0; j < lifeGrid.GetLength(1); j++)
                {
                    if (lifeGrid[i, j] == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.ResetColor();

        }

        private void ChangeUserMessage()
        {
            //update user message
            Console.SetCursorPosition(19, 38);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Press Any Key to Stop");
            Console.ResetColor();
        }

        private void IntializeGameOfLife()
        {
            //set up areas with all dead cells
            for(int i = 0; i < lifeGrid.GetLength(0); i++)
            {
                for(int j = 0; j < lifeGrid.GetLongLength(1); j++)
                {
                    lifeGrid[i, j] = 0;
                    neighborGrid[i, j] = 0;
                }
            }

            //set up intial configuration
            for (int j = 14; j <= 26; j++)
            {
                lifeGrid[13, j] = 1;
            }

            for (int i = 8; i <= 10; i++)
            {
                lifeGrid[i, 12] = 1;
            }

            for (int i = 8; i <= 10; i++)
            {
                lifeGrid[i, 20] = 1;
            }

            for (int i = 8; i <= 10; i++)
            {
                lifeGrid[i, 28] = 1;
            }
        }//end intialize
    }
}
