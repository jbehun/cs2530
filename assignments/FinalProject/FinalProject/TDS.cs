using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject
{
    struct TDS
    {
        public double PassTds { get; set; }
        public double ReceiveTds { get; set; }
        public double RushTds { get;  set; }
        public double ReturnTds { get;  set; }

        public TDS(double p, double rush, double rec, double ret)
            : this()
        {
            PassTds = p;
            ReceiveTds = rec;
            RushTds = rush;
            ReturnTds = ret;
        }

        public override string ToString()
        {
            return String.Format("{0, -4} {1, -4} {2, -4} {3, -4}"
                , PassTds, ReceiveTds, RushTds, ReturnTds);
        }
    }
}
