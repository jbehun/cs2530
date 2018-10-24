﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject
{
    class NFLPlayer : Player
    {
        public Yards Yardage;
        public TDS TouchDowns;
        public string Bye;
        public double Fumbles { get; private set; }

        public NFLPlayer(string n, string p, string t, string b, Yards y, TDS td, double f)
            : base(n, p, t)
        {
            Bye = b;
            Yardage = y;
            TouchDowns = td;
            Fumbles = f;
        }

        public override string ToString()
        {
            return String.Format("{0, -10} {1, -10} {2, -4} {3, -5} {4, -5} {5, -5}"
                , Name, Team, Position, Yardage, TouchDowns, Fumbles);
        }
    }
}