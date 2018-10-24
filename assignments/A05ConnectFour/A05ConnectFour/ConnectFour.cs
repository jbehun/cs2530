// Project: Connect Four
// File   : ConnectFour.cs
// Name   : Justin Behunin
// Date   : 3/4/2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A05ConnectFour
{
    class ConnectFour
    {
        public int[,] board { get; set; }
        private int row, column; //keep track of where last piece is placed.
        public static int count;//keep track of number of moves
        private int playerNumber;
        private ConnectFourDisplay display;

        public ConnectFour(Player p1, Player p2)
        {
            board = new int[6, 7];
            IntializeBoard();
            row = 0;
            column = 0;
            count = 0;
            playerNumber = 1;
            display = new ConnectFourDisplay(p1, p2, board);
        }

        private void IntializeBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    board[i, j] = 0;
        }


        public void AddPlayerPiece(int column, Player player)
        {
            column += -1;//adjusted to allow player input of 1-7 instead of 0-6
            this.column = column;
            count++;
            playerNumber = player.Number;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, column] == 0)
                {
                    board[i, column] = playerNumber;
                    row = i;//keep track of which row piece ends on
                    if (i > 0)
                        board[i - 1, column] = 0;

                }
                display.PrintBoard(board);
                System.Threading.Thread.Sleep(100);
            }
        }

        //check to see if column is full
        public bool ColumnFull(int c)
        {
            if (board[0, c - 1] != 0)
                return true;
            return false;
        }

        //check the different directions to determine if player won
        public bool CheckWin()
        {
            int counter = 0;
            //check left diagnal
            counter = 0;
            for (int i = -3; i < board.GetLength(0); i++)
            {
                if ((row + i >= 0) && (column + i >= 0) && (row + i < board.GetLength(0)) && column + i < board.GetLength(1))
                {
                    if (board[row + i, column + i] == playerNumber)
                        counter++;
                    else
                        counter = 0;
                    if (counter == 4)
                        return true;
                }
            }

            if (counter == 4)
                return true;

            //check right diagnal
            counter = 0;
            for (int i = -3; i < board.GetLength(0); i++)
            {
                if ((row + i >= 0) && (column - i >= 0) && (row + i < board.GetLength(0)) && column - i < board.GetLength(1))
                {
                    if (board[row + i, column - i] == playerNumber)
                        counter++;
                    else
                        counter = 0;
                    if (counter == 4)
                        return true;
                }
            }

            //check vertical
            counter = 0;
            if (row < 3)
            {
                for (int i = 0; i < 4; i++)
                    if (board[(row + i), (column)] == playerNumber)
                        counter++;
            }

            if (counter == 4)
                return true;

            //check horiztonal
            counter = 0;
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[row, j] == playerNumber)
                    counter++;
                else
                    counter = 0;
                if (counter == 4)
                    return true;
            }

            return false;//returns false if win not found
        }
    }
}
