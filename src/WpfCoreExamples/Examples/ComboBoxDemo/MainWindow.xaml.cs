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

namespace ComboBoxDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Customer> _customers = new ObservableCollection<Customer>();

        public MainWindow()
        {
            InitializeComponent();

            MyComboBox.Items.Add("111");
            MyComboBox.Items.Add("222");
            MyComboBox.Items.Add("333");

            _customers.Add(new Customer { Id = 1, Name = "name1", Phone = "Phone1" });
            _customers.Add(new Customer { Id = 2, Name = "name2", Phone = "Phone2" });
            _customers.Add(new Customer { Id = 3, Name = "name3", Phone = "Phone3" });

            AComboBox.ItemsSource = _customers;
            BComboBox.ItemsSource = _customers;
        }
        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine("MyComboBox.SelectedIndex:" + MyComboBox.SelectedIndex);
            sb.AppendLine("MyComboBox.SelectedValue:" + MyComboBox.SelectedValue);
            sb.AppendLine("MyComboBox.Text:" + MyComboBox.Text);
            MessageBox.Show(sb.ToString());
        }
        private void AButton_Click(object sender, RoutedEventArgs e)
        {
            var item = AComboBox.SelectedItem as Customer;
            if (item != null)
            {
                var sb = new StringBuilder();
                sb.AppendLine("AComboBox.SelectedIndex:" + AComboBox.SelectedIndex);
                sb.AppendLine("AComboBox.SelectedValue:" + AComboBox.SelectedValue);
                sb.AppendLine("AComboBox.Text:" + AComboBox.Text);
                sb.AppendLine("-------");
                sb.AppendLine("SelectedItem.Id : " + item.Id);
                sb.AppendLine("SelectedItem.Name : " + item.Name);
                sb.AppendLine("SelectedItem.Phone : " + item.Phone);
                MessageBox.Show(sb.ToString());
            }
        }

        private void BButton_Click(object sender, RoutedEventArgs e)
        {
            var item = BComboBox.SelectedItem as Customer;
            if (item != null)
            {
                var sb = new StringBuilder();
                sb.AppendLine("AComboBox.SelectedIndex:" + BComboBox.SelectedIndex);
                sb.AppendLine("AComboBox.SelectedValue:" + BComboBox.SelectedValue);
                sb.AppendLine("AComboBox.Text:" + BComboBox.Text);
                sb.AppendLine("-------");
                sb.AppendLine("SelectedItem.Id : " + item.Id);
                sb.AppendLine("SelectedItem.Name : " + item.Name);
                sb.AppendLine("SelectedItem.Phone : " + item.Phone);
                MessageBox.Show(sb.ToString());
            }
        }
    }
}
