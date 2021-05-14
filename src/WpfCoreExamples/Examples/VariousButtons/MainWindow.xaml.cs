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

namespace VariousButtonsDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NormalButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Normal button click!!");
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "RepeatButton");
        }

        private void MyToggleBtton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("toggle button click:" + MyToggleBtton.IsChecked);
        }
    }
}
