using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace FinalProject
{
    public partial class MainWindow
    {
        IList<NFLPlayer> MyPicks = new List<NFLPlayer>();//list to store picks

        //groups players by team
        private void GroupPlayersByTeam()
        {
            var GroupByTeam =
                from p in PlayerList
                group p by p.Team into g
                select new { Team = g.Key, Names = g };

            Dictionary<string, string> teamGroup = new Dictionary<string, string>();
            foreach (var group in GroupByTeam)
            {
                teamGroup.Add(group.Team, string.Join(",", group.Names));
            }

            TestGrid.ItemsSource = GroupByTeam;
        }

        //groups players by position
        private void GroupPlayersByPosition()
        {
            var GroupByPosition =
                from p in PlayerList
                group p by p.Position into g
                select new { Team = g.Key, Names = g.Select(x => x.Name) };

            TestGrid.ItemsSource = GroupByPosition;

        }

        private void PlayersWithNamePosition(string pos)
        {

            var pNameWithPos =
                          from p in PlayerList
                          where p.Position == pos
                          select new
                          {
                              p.Name,
                              p.Position,
                              p.Team,
                              p.Yardage.PassYds,
                              p.Yardage.ReceiveYds,
                              p.Yardage.RushYds,
                              p.Yardage.ReturnYds,
                              p.TouchDowns.PassTds,
                              p.TouchDowns.ReceiveTds,
                              p.TouchDowns.RushTds,
                              p.TouchDowns.ReturnTds,
                              p.Fumbles
                          };
            pNameWithPos.OrderBy(x => x.PassYds);

            TestGrid.ItemsSource = pNameWithPos;

        }

        //list players by given position
        private void PlayersWithNamePosition(string pos, int sb, char order)
        {

            var pNameWithPos =
                          from p in PlayerList

                          where p.Position == pos
                          select new
                          {
                              p.Name,
                              p.Position,
                              p.Team,
                              p.Bye,
                              p.Yardage.PassYds,
                              p.Yardage.ReceiveYds,
                              p.Yardage.RushYds,
                              p.Yardage.ReturnYds,
                              p.TouchDowns.PassTds,
                              p.TouchDowns.ReceiveTds,
                              p.TouchDowns.RushTds,
                              p.TouchDowns.ReturnTds,
                              p.Fumbles
                          };

            if (order == 'A')
            {
                switch (sb)
                {
                    case 0: TestGrid.ItemsSource = pNameWithPos.OrderBy(x => x.ReceiveYds); break;
                    case 1: TestGrid.ItemsSource = pNameWithPos.OrderBy(x => x.RushYds); break;
                    case 2: TestGrid.ItemsSource = pNameWithPos.OrderBy(x => x.PassYds); break;
                    case 3: TestGrid.ItemsSource = pNameWithPos.OrderBy(x => x.ReturnYds); break;
                }
            }
            else
            {
                switch (sb)
                {
                    case 0: TestGrid.ItemsSource = pNameWithPos.OrderByDescending(x => x.ReceiveYds); break;
                    case 1: TestGrid.ItemsSource = pNameWithPos.OrderByDescending(x => x.RushYds); break;
                    case 2: TestGrid.ItemsSource = pNameWithPos.OrderByDescending(x => x.PassYds); break;
                    case 3: TestGrid.ItemsSource = pNameWithPos.OrderByDescending(x => x.ReturnYds); break;
                }
            }
        }

        private void UpdateGrid()
        {
            char pos = PositionCbx.Text[0];
            char order = OrderCbx.Text[0];
            int sb = Yards.SelectedIndex;

            switch (pos)
            {
                case 'A': AllPlayers(PlayerList, sb, order); break;
                case 'Q': PlayersWithNamePosition("QB", sb, order); break;
                case 'W': PlayersWithNamePosition("WR", sb, order); break;
                case 'R': PlayersWithNamePosition("RB", sb, order); break;
                case 'T': PlayersWithNamePosition("TE", sb, order); break;
                default: break;
            }
        }

        private void AllPlayers(IList<NFLPlayer> pList, int sb, char order)
        {
            var allPlayersWithStats =
                          from p in pList
                          select new
                          {
                              p.Name,
                              p.Position,
                              p.Team,
                              p.Bye,
                              p.Yardage.PassYds,
                              p.Yardage.ReceiveYds,
                              p.Yardage.RushYds,
                              p.Yardage.ReturnYds,
                              p.TouchDowns.PassTds,
                              p.TouchDowns.ReceiveTds,
                              p.TouchDowns.RushTds,
                              p.TouchDowns.ReturnTds,
                              p.Fumbles
                          };

            if (order == 'A')
            {
                switch (sb)
                {
                    case 0: TestGrid.ItemsSource = allPlayersWithStats.OrderBy(x => x.ReceiveYds); break;
                    case 1: TestGrid.ItemsSource = allPlayersWithStats.OrderBy(x => x.RushYds); break;
                    case 2: TestGrid.ItemsSource = allPlayersWithStats.OrderBy(x => x.PassYds); break;
                    case 3: TestGrid.ItemsSource = allPlayersWithStats.OrderBy(x => x.ReturnYds); break;
                }
            }
            else
            {
                switch (sb)
                {
                    case 0: TestGrid.ItemsSource = allPlayersWithStats.OrderByDescending(x => x.ReceiveYds); break;
                    case 1: TestGrid.ItemsSource = allPlayersWithStats.OrderByDescending(x => x.RushYds); break;
                    case 2: TestGrid.ItemsSource = allPlayersWithStats.OrderByDescending(x => x.PassYds); break;
                    case 3: TestGrid.ItemsSource = allPlayersWithStats.OrderByDescending(x => x.ReturnYds); break;
                }
            }
        }

        private NFLPlayer GetPlayerFromGrid()
        {
            NFLPlayer player;

            if (TestGrid.SelectedIndex < 0)
            {
                return null;
            }

            string[] temp = TestGrid.SelectedItem.ToString().Split(',', '='); ;
            string[] pData = new string[13];
            double[] yData = new double[4];
            double[] tdData = new double[4];
            double fumbles;

            for (int i = 0; i < pData.Length; i++)
            {
                pData[i] = temp[(i * 2) + 1];//gets the data from selected player
                pData[i] = pData[i].Substring(1);//removes extra char that was at the start.
            }

            pData[12] = pData[12].TrimEnd('}');//remove } from the end of the string.

            //parse yards data
            for (int i = 0; i < yData.Length; i++)
            {
                double yds;
                if (double.TryParse(pData[i + 4], out yds))
                {
                    yData[i] = yds;
                }
                else
                {
                    yData[i] = 0;
                }
            }

            //parse touch down data
            for (int i = 0; i < tdData.Length; i++)
            {
                double tds;
                if (double.TryParse(pData[i + 8], out tds))
                {
                    tdData[i] = tds;
                }
                else
                {
                    tdData[i] = 0;
                }
            }

            double getFunmbles;
            if (double.TryParse(pData[12], out getFunmbles))
            {
                fumbles = getFunmbles;
            }
            else
            {
                fumbles = 0;
            }

            player = new NFLPlayer(pData[0], pData[1], pData[2], pData[3]
                                    , new Yards(yData[0], yData[2], yData[1], yData[3])
                                    , new TDS(tdData[0], tdData[2], tdData[1], tdData[3]), fumbles);
            return player;
        }

        private void DeletePlayer(IList<NFLPlayer> pList, NFLPlayer player)
        {

            for (int i = 0; i < pList.Count; i++)
            {
                if (player.Name == pList[i].Name)
                {
                    pList.RemoveAt(i);
                }
            }
        }

        private void FilterButton(object sender, RoutedEventArgs e)
        {
            UpdateGrid();
            AddPlayer.Content = "";
        }

        private void AddPlayerButton(object sender, RoutedEventArgs e)
        {
            NFLPlayer player = GetPlayerFromGrid();
            if (player != null)
            {
                MyPicks.Add(player);
                DeletePlayer(PlayerList, player);
                UpdateGrid();
                AddPlayer.Content = "Player Added";
            }
            else
            {
                AddPlayer.Content = "Please select a player to add";
            }
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateGrid();
        }


        private void PlayersWithNameTeam(string team)
        {
            var pNameWithTeam =
                          from p in PlayerList
                          where p.Team == team
                          select new
                          {
                              p.Name,
                              p.Team,
                              p.Position,
                              p.Yardage.PassYds,
                              p.Yardage.ReceiveYds,
                              p.Yardage.ReturnYds,
                              p.Yardage.RushYds,
                              p.TouchDowns.PassTds,
                              p.TouchDowns.ReceiveTds,
                              p.TouchDowns.ReturnTds,
                              p.TouchDowns.RushTds,
                              p.Fumbles
                          };

            TestGrid.ItemsSource = pNameWithTeam;
        }
        private void PlayersNameWithFumbles()
        {
            var pNameWithFumbles =
                          from p in PlayerList
                          select p;
            //select new
            //{
            //    p.Name,
            //    p.Fumbles
            //};

            TestGrid.ItemsSource = pNameWithFumbles;
        }
        private void PlayersNameWithTouchDowns()
        {
            var pNameWithTouchDowns =
              from p in PlayerList
              select new
              {
                  p.Name,
                  p.TouchDowns.PassTds,
                  p.TouchDowns.ReceiveTds,
                  p.TouchDowns.ReturnTds,
                  p.TouchDowns.RushTds
              };

            TestGrid.ItemsSource = pNameWithTouchDowns;
        }
        private void PlayersNameWithYards()
        {
            var pNameWithYards =
              from p in PlayerList
              select new
              {
                  p.Name,
                  p.Yardage.PassYds,
                  p.Yardage.ReceiveYds,
                  p.Yardage.ReturnYds,
                  p.Yardage.RushYds
              };

            TestGrid.ItemsSource = pNameWithYards;
        }
    }//end class
}//end namepace
