// Project: Connect Four Gui
// File   : MainWindow.xaml.cs
// Name   : Justin Behunin
// Date   : 3/11/2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace A06ConnectFourGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private Rectangle[,] squares;
        ConnectFour game;
        Player p1, p2, currentPlayer;
        bool gameOver;
        int timerRowCounter;

        public MainWindow()
        {
            InitializeComponent();

            squares = new Rectangle[6, 7];
            addSquares();

            p1 = new Player(Brushes.Black, 1);
            p2 = new Player(Brushes.Red, 2);
            currentPlayer = p1;

            SetUpTimer();
            timerRowCounter = 0;

            game = new ConnectFour(p1, p2);
            gameOver = false;
        }

        private void SetUpTimer()
        {
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {

            if (timerRowCounter > 0)
            {
                DrawCircle(Brushes.White, 30, (timerRowCounter - 1) * 43 + 7, game.column * 57 + 12);//clear position above current game piece
            }
            DrawCircle(currentPlayer.Color, 30, timerRowCounter * 43 + 7, game.column * 57 + 12);//draw player game piece

            if (timerRowCounter == game.row)
            {
                timer.Stop();

                if(!gameOver && ConnectFour.count != 42)
                ChangePlayer();
            }

            timerRowCounter++;
        }

        private void addSquares()
        {
            for (int i = 0; i < squares.GetLength(0); i++)
            {
                for (int j = 0; j < squares.GetLength(1); j++)
                {
                    DrawSquare(i * 43 + 1, j * 57, 42, 56, Brushes.Blue);
                    DrawCircle(Brushes.White, 30, i * 43 + 7, j * 57 + 12);
                }
            }
        }


        //on button click checks to see if timer is stopped to prevent addtional actions
        //until the currents player piece is placed on the gui.
        private void b1_Click(object sender, RoutedEventArgs e)
        {
            if (!timer.IsEnabled)
            takeTurn(1);
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            if (!timer.IsEnabled)
            takeTurn(2);
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            if (!timer.IsEnabled)
            takeTurn(3);
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            if (!timer.IsEnabled)
            takeTurn(4);
        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            if (!timer.IsEnabled)
            takeTurn(5);
        }

        private void b6_Click(object sender, RoutedEventArgs e)
        {
            if (!timer.IsEnabled)
            takeTurn(6);
        }

        private void b7_Click(object sender, RoutedEventArgs e)
        {
            if (!timer.IsEnabled)
            takeTurn(7);
        }


        private void takeTurn(int col)
        {
            if (game.ColumnFull(col))
            {
                playerLabel.Foreground = currentPlayer.Color;
                playerLabel.Content = String.Format("Column full choose again Player {0}", currentPlayer.Number);
                return;
            }

            game.AddPlayerPiece(col, currentPlayer);//add game piece to the back end of the game;
            timerRowCounter = 0;
            timer.Start();

            gameOver = game.CheckWin();//check for win and end game if win found.
            if (gameOver || ConnectFour.count == 42)
            {
                EndGame();
                return;
            }

        }

        private void ChangePlayer()
        {
            if (currentPlayer.Equals(p1))
            {
                currentPlayer = p2;
                playerLabel.Foreground = p2.Color;
                playerLabel.Content = "Player Two Select Column";
            }
            else
            {
                currentPlayer = p1;
                playerLabel.Foreground = p1.Color;
                playerLabel.Content = "Player One Select Column";
            }
        }

        private void EndGame()
        {
            if (ConnectFour.count == 42 && !gameOver)
            {
                playerLabel.Foreground = Brushes.Blue;
                playerLabel.Content = "Draw Game!";
            }
            else
            {
                playerLabel.Foreground = currentPlayer.Color;
                playerLabel.Content = String.Format("Player {0} Wins!", currentPlayer.Number);
            }

            //hide buttons so pieces can no longer be placed.
            b1.Visibility = System.Windows.Visibility.Hidden;
            b2.Visibility = System.Windows.Visibility.Hidden;
            b3.Visibility = System.Windows.Visibility.Hidden;
            b4.Visibility = System.Windows.Visibility.Hidden;
            b5.Visibility = System.Windows.Visibility.Hidden;
            b6.Visibility = System.Windows.Visibility.Hidden;
            b7.Visibility = System.Windows.Visibility.Hidden;
        }

        private Rectangle DrawSquare(int top, int left, int height, int width, SolidColorBrush color)
        {
            Rectangle rect = new Rectangle();
            rect.Width = width;
            rect.Height = height;
            rect.Fill = color;

            GameCanvas.Children.Add(rect);
            Canvas.SetLeft(rect, left);
            Canvas.SetTop(rect, top);

            return rect;
        }

        private void DrawCircle(Brush color, double size, double positionTop, double positionLeft)
        {
            // create circle
            Ellipse circle = new Ellipse();
            circle.Height = size;
            circle.Width = size;
            circle.Fill = color;

            // set position 
            Canvas.SetLeft(circle, positionLeft);
            Canvas.SetTop(circle, positionTop);

            // add circle to canvas
            GameCanvas.Children.Add(circle);

        }
    }
}
