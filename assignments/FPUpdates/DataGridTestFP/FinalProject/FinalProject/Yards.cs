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
            return String.Format("{0, -5} {1, -5} {2, -5} {3, -5}"
                , PassYds, ReceiveYds, RushYds, ReturnYds);
        }
    }
}
