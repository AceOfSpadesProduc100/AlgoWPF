using ScottPlot.Drawing.Colormaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AlgoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class Comparer : IComparer<double>
    {
        public int Compare(double x, double y)
        {
            Thread.Sleep(1);
            return x < y ? -1 : x > y ? 1 : 0;
        }
    }
    public partial class MainWindow : Window
    {
        Random random = new();
        double[] arr = new double[256];
        double[] arr2 = new double[256];
        DispatcherTimer timer = new();
        
        
        public MainWindow()
        {
            InitializeComponent();
            
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(0, 250);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                arr2[i] = i;
            }
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Start();
            Display.Plot.AddScatter(arr2, arr);
            Display.Plot.AxisScaleLock(false);
            Display.Refresh();
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Display.Render();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Display.Refresh();
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            Comparer cmp = new();
            Array.Sort(arr, comparer: cmp);
        }
    }
}
