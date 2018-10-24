// Project: Connect Four GUI
// File   : Player.cs
// Name   : Justin Behunin
// Date   : 3/11/2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace A06ConnectFourGUI
{
    //used to store player color and if player won
    struct Player
    {
        public SolidColorBrush Color { get; private set; }
        public int Number { get; private set; }
        public bool wonGame { get; private set; }


        public Player(SolidColorBrush c, int n)
            : this()
        {
            this.Color = c;
            this.Number = n;
            wonGame = false;
        }

        public void WonGame()
        {
            wonGame = true;
        }

        public override string ToString()
        {
            return String.Format("Player {0}", Number);
        }

    }
}
