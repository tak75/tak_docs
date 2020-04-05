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

namespace CheckBoxDemo
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
        private void MyCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("MyCheckBox_Checked:" + MyCheckBox.IsChecked);
        }

        private void MyCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("MyCheckBox_Unchecked:" + MyCheckBox.IsChecked);
        }

        private void MyCheckBox_Indeterminate(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("MyCheckBox_Indeterminate:" + MyCheckBox.IsChecked);
        }
    }
}
