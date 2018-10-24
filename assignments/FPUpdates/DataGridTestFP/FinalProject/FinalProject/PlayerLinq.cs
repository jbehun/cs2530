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
        public void LinqTest()
        {

            //GroupPlayersByTeam();
            //GroupPlayersByPosition();
            //PlayersWithNamePosition("QB");
            //PlayersWithNameTeam("Den");
            //PlayersNameWithFumbles();
            //PlayersNameWithTouchDowns();
            //PlayersNameWithYards();

        }

        private void GroupPlayersByTeam()
        {
            var GroupByTeam =
                from p in PlayerList
                group p by p.Team into g
                select new { Team = g.Key, Name = g.Select((x => x.Name)) };

           TestGrid.ItemsSource = GroupByTeam;
        }

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

            TestGrid.ItemsSource = pNameWithPos;

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
            var pNameWithFunbles =
                          from p in PlayerList
                          select new
                          {
                              p.Name,
                              p.Fumbles
                          };

            TestGrid.ItemsSource = pNameWithFunbles;
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
            var pNameWithFunbles =
              from p in PlayerList
              select new
              {
                  p.Name,
                  p.Yardage.PassYds,
                  p.Yardage.ReceiveYds,
                  p.Yardage.ReturnYds,
                  p.Yardage.RushYds
              };

            TestGrid.ItemsSource = pNameWithFunbles;
        }


        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            // //... Assign ItemsSource of DataGrid.
            var grid = sender as DataGrid;
            grid.ItemsSource = PlayerList;
        }
    }


}
