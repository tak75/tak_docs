using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ListBoxDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Dto> _dtos = new ObservableCollection<Dto>();

        public MainWindow()
        {
            InitializeComponent();

            _dtos.Add(new Dto("Images/A.jpeg", "Shinichi ONO"));
            _dtos.Add(new Dto("Images/B.jpeg", "Jyunta INAMOTO"));
            _dtos.Add(new Dto("Images/C.jpeg", "Naotaro TAKAHARA"));
            MyListBox.ItemsSource = _dtos;
            SingleRadioButton.IsChecked = true;
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (SingleRadioButton.IsChecked.Value)
            {
                MyListBox.SelectionMode = SelectionMode.Single;
            }
            else if (ExtendedRadioButton.IsChecked.Value)
            {
                MyListBox.SelectionMode = SelectionMode.Extended;
            }
            else
            {
                MyListBox.SelectionMode = SelectionMode.Multiple;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    public sealed class Dto
    {
        public Dto(string fileName, string name)
        {
            FileName = fileName;
            Name = name;
        }

        public string FileName { get; set; }
        public string Name { get; set; }
    }
}
