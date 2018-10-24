using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject
{
    public partial class MainWindow
    {
        public void LinqTest()
        {
            Player p = new NFLPlayer("Fred", "QB", "Patriots", "6", new Yards(10, 5, 6, 10), new TDS(10 , 5, 6, 10), 2);
            PlayerList.Add(p);
            TestDisplay.Text = PlayerList[0].ToString();
        }
    }
}
