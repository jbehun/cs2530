using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject
{
    struct Yards
    {

        public double PassYds { get; set; }
        public double ReceiveYds { get; set; }
        public double RushYds { get;  set; }
        public double ReturnYds { get;  set; }

        public Yards(double p, double rush, double rec, double ret)
            : this()
        {
            PassYds = p;
            ReceiveYds = rec;
            RushYds = rush;
            ReturnYds = ret;
        }

        public override string ToString()
        {
            return String.Format("{0, -6} {1, -6} {2, -6} {3, -6}"
                , PassYds, ReceiveYds, RushYds, ReturnYds);
        }
    }
}
