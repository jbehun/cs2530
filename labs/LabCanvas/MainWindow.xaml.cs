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
using System.Windows.Threading;

namespace LabCanvas
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        #region DrawCircle
        private void DrawCircle(Brush color, double size, double positionLeft, double positionTop)
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
            BackgroundCanvas.Children.Add(circle);
        }
        #endregion

        private void ConcentricCirclesdButton_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < 10; i++)
            {
                Brush color = (i % 2 == 0) ? Brushes.White : Brushes.Black;
                DrawCircle(color, 400 - (i * 40), 50 + (i * 20), 50 + (i * 20));
            }

        }

        private void OverlappingCircles_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Brush color = (i % 2 != 0) ? Brushes.White : Brushes.Black;
                DrawCircle(color, 400 - (i * 40), 50 + (i * 20), 50 + (i * 40));
            }
        }
    }
}
