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
        List<Player> PlayerList;
        public MainWindow()
        {     
            InitializeComponent();

            PlayerList = GetPlayerList(@"\\smb\student$\E_G\agoodwil\My Documents\Visual Studio 2013\CS2530\Final Project\FinalProject\EditedFootbalStats.csv");

            foreach (Player p in PlayerList)
            {
                TestDisplay.Text += p.ToString() + "\n";
            }
            
            
        }

        #region read data and create list
        #endregion

        #region linq searches
        #endregion

    }
}
