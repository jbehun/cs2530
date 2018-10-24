using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject
{
    class Player
    {
        public string Name { get; private set; }
        public string Position { get; private set; }
        public string Team { get; private set; }

        public Player(string n, string p, string t)
        {
            Name = n;
            Position = p;
            Team = t;
        }
        public override string ToString()
        {
            return string.Format("{0, -10}, {1, -10}. {2,-10}", Name, Position, Team);
        }
    }
}
