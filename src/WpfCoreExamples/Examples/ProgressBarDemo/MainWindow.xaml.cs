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

namespace ProgressBarDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ATextBlock.Text = AProgressBar.Value.ToString() + "%";
            BTextBlock.Text = BProgressBar.Value.ToString() + "%";
        }
        private void AProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ATextBlock.Text = AProgressBar.Value.ToString() + "%";
        }

        private void AButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    System.Threading.Thread.Sleep(500);

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        AProgressBar.Value += 10;
                    });
                }
            });
        }

        private void BProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            BTextBlock.Text = BProgressBar.Value.ToString() + "%";
        }

        private void BButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    System.Threading.Thread.Sleep(500);

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        BProgressBar.Value += 10;
                    });
                }
            });
        }

        private void CButton_Click(object sender, RoutedEventArgs e)
        {
            CProgressBar.IsIndeterminate = true;
            CTextBlock.Text = "検索しています...";
        }
    }
}
