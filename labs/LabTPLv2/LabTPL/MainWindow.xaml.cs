using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace LabTPL
{
    public partial class MainWindow : Window
    {
        private const int pixelWidth = 15000;
        private const int pixelHeight = 7500;
        private const double dpiX = 96.0;
        private const double dpiY = 96.0;
        private WriteableBitmap graphBitmap =
        new WriteableBitmap(pixelWidth, pixelHeight, dpiX, dpiY, PixelFormats.Gray8, null);
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
            int a = pixelWidth / 2;
            Task t1 = Task.Factory.StartNew(() => GenerateGraphData(data, 0, a / 4));
            Task t2 = Task.Factory.StartNew(() => GenerateGraphData(data, a / 4, a / 2));
            Task t3 = Task.Factory.StartNew(() => GenerateGraphData(data, a /2, a /(3/ 2)));
            Task t4 = Task.Factory.StartNew(() => GenerateGraphData(data, a /(3 / 2), a));
            Task.WaitAll(t1, t2, t3, t4);
            //generateGraphData(data);
            durationLabel.Content = "duration: " + stopwatch.ElapsedMilliseconds + " ms";
            graphBitmap.WritePixels(new Int32Rect(0, 0, pixelWidth, pixelHeight), data, stride, 0);
            graphImage.Source = graphBitmap;
        }
        private void GenerateGraphData(byte[] data, int fromInclusive, int toExclusive)
        {
            int a = pixelWidth / 2;
            int b = a * a;
            int c = pixelHeight / 2;
            for (int x = fromInclusive; x < toExclusive; x++)
            //for (int x = 0; x < a; x++)
            {
                int s = x * x;
                double p = 0.65 * Math.Sqrt(b - s);
                for (double i = -p; i < p; i += 2)
                {
                    double r = Math.Sqrt(1.5 * s + i * i) / a;
                    double q = (r - 1) * Math.Cos(25 * r + 25);
                    double y = i / 4 + (q * c);
                    drawXY(data, (-x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2)));
                    drawXY(data, (x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2)));

                    //try
                    //{
                    //    Parallel.Invoke(() => drawXY(data, (-x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2))),
                    //    () => drawXY(data, (x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2))));
                    //}
                    //catch(Exception ex)
                    //{
                    //    durationLabel.Content = ex.ToString();
                    //}
                }
            }
        }
        private void drawXY(byte[] data, int x, int y)
        {
            data[x + y * pixelWidth] = 0xFF;
        }
    }
}