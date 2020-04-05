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

namespace RadioButtonDemo
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

        // ARadioButtonとBRadioButtonはそれぞれのCheckedイベントにチェック状態になると通知されるが、
        // CRadioButtonとDRadioButtonは同一のCRadioButton_Checkedに通知されるため、
        // イベントの中で、どちらの通知かを判断して処理をすることができる。
        private void ARadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("A clicked");
        }

        private void BRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("B clicked");
        }

        private void CRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton == CRadioButton)
            {
                Debug.WriteLine("C clicked");
            }
            else if (radioButton == DRadioButton)
            {
                Debug.WriteLine("D clicked");
            }
        }
    }
}
