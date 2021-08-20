using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace TabControlDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MyTabControl.SelectedIndex = 1;

            MyTabControl.SizeChanged += (sender, args) =>
            {
                double sumWidth = 0;
                foreach (var item in MyTabControl.Items)
                {
                    var tabItem = item as TabItem;
                    if (tabItem.Tag as string != "spacer")
                    {
                        sumWidth += tabItem.ActualWidth;
                    }
                }
                var width = MyTabControl.ActualWidth - sumWidth - 5;
                if (width < 0) return;
                HiddenTab.Width = width;

                //Dispatcher.BeginInvoke(new Action(() =>
                //{
                //    var width = MyTabControl.ActualWidth - TabA.ActualWidth - TabB.ActualWidth - TabC.ActualWidth - TabD.ActualWidth - TabZ.ActualWidth - 5;
                //    if (width < 0) return;
                //    HiddenTab.Width = width;
                //}),
                //DispatcherPriority.Loaded);
            };
        }
    }
}
