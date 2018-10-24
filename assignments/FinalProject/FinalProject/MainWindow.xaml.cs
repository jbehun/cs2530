using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IList<NFLPlayer> PlayerList;
        public MainWindow()
        {
            InitializeComponent();

            PlayerList = GetPlayerList("EditedFootbalStats.csv");

            //foreach (Player p in PlayerList)
            //{
            //    TestDisplay.Text += p.ToString() + "\n";
            //}


        }

        private void PositionBtn_Checked(object sender, RoutedEventArgs e)
        {
            PlayersWithNamePosition("QB");
        }

        private void TeamBtn_Checked(object sender, RoutedEventArgs e)
        {
            //PlayersWithNameTeam("Den");
            PlayersNameWithFumbles();
            //GroupPlayersByTeam();
        }

        #region read data and create list
        #endregion

        #region linq searches
        #endregion

    }
}

