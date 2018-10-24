﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabTPL
{
    public partial class MainWindow : Window
    {
        private const int pixelWidth = 15000;
        private const int pixelHeight = 8500;
        private const double dpiX = 96.0;
        private const double dpiY = 96.0;
        private WriteableBitmap graphBitmap = new WriteableBitmap(pixelWidth, pixelHeight, dpiX, dpiY, PixelFormats.Gray8, null);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlotButton_Click(object sender, RoutedEventArgs e)
        {
            int stride = pixelWidth; // pixelWidth * bytesPerPixel, but bytesPerPixel == 1
            int dataSize = stride * pixelHeight;
            byte[] data = new byte[dataSize];

            Stopwatch stopwatch = Stopwatch.StartNew();
            int a = (int)Math.Pow(pixelWidth, 2) / 4;
            Task t1 = Task.Factory.StartNew(() => GenerateGraphData(data, 0, a / 2));
            Task t2 = Task.Factory.StartNew(() => GenerateGraphData(data, a / 2, a));
            Task.WaitAll(t1, t2);
            //GenerateGraphData(data);
            durationLabel.Content = "duration: " + stopwatch.ElapsedMilliseconds + " ms";
            graphBitmap.WritePixels(new Int32Rect(0, 0, pixelWidth, pixelHeight), data, stride, 0);
            graphImage.Source = graphBitmap;
        }

        private void GenerateGraphData(byte[] data , int fromInclusive, int toExclusive)
        {
            int a = (int)Math.Pow(pixelWidth, 2) / 4;
            int upperBound = pixelWidth / 2;

            //for (int x = 0; x < upperBound; x++)
            //Parallel.For( 0, upperBound, x =>
            for (int x = fromInclusive; x < toExclusive; x++)
            {
                int s = x * x;
                double p = Math.Sqrt(a - s);
                for (double i = -p; i < p; i += 3)
                {
                    double r = 2 * Math.Sqrt(s + i * i) / pixelWidth;
                    double q = (r - 1) * Math.Sin(15 * r);
                    double y = i / 3 + (q * pixelHeight / 4);


                    PlotXY(data, (int)(-x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2)));
                    PlotXY(data, (int)(x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2)));

                    //Parallel.Invoke(
                    //() => PlotXY(data, (int)(-x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2))),
                    //() => PlotXY(data, (int)(x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2))));
                }
            }//);
        }

        private void PlotXY(byte[] data, int x, int y)
        {
            data[x + y * pixelWidth] = 0xFF;
        }
    }
}
