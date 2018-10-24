using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject
{
    class Player
    {
        public string Name;
        public string Position;
        public string Team;

        public Player(string n, string p, string t)
        {
            Name = n;
            Position = p;
            Team = t;
        }
        public override string ToString()
        {
            return string.Format("{0, -10}, {0, -10}. {2,-10}", Name, Position, Team);
        }
    }
}
