using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject
{
    struct TDS
    {
        public double PassTds { get; private set; }
        public double ReceiveTds { get; private set; }
        public double RushTds { get; private set; }
        public double ReturnTds { get; private set; }

        public TDS(double p, double rec, double rush, double ret)
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
