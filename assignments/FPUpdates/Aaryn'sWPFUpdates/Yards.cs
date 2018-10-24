using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject
{
    struct Yards
    {

        public double PassYds { get; private set; }
        public double ReceiveYds { get; private set; }
        public double RushYds { get; private set; }
        public double ReturnYds { get; private set; }

        public Yards(double p, double rec, double rush, double ret)
            : this()
        {
            PassYds = p;
            ReceiveYds = rec;
            RushYds = rush;
            ReturnYds = ret;
        }

        public override string ToString()
        {
            return String.Format("{0, -4} {1, -4} {2, -4} {3, -4}"
                , PassYds, ReceiveYds, RushYds, ReturnYds);
        }
    }
}
