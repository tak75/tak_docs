using SQLite;
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

namespace CustomerSettingSamp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    //public partial class MainWindow : Window
    //{
    //    private int customerId = 0;

    //    public MainWindow()
    //    {
    //        InitializeComponent();

    //        using (var connection = new SQLiteConnection(App.DatabasePath))
    //        {
    //            // テーブルがないときのためにCreateTableを実行
    //            connection.CreateTable<Customer>();
    //            var customers = connection.Table<Customer>().ToList();

    //            if(customers.Count > 0)
    //            {
    //                this.customerId = customers.Max(x => x.Id) + 1;
    //            }
    //            else
    //            {
    //                this.customerId = 0;
    //            }
    //        }

    //        UpdateListView();
    //    }

    //    private void AddButton_Click(object sender, RoutedEventArgs e)
    //    {
    //        var saveWindow = new SaveWindow(this.customerId);
    //        saveWindow.ShowDialog();
    //        UpdateListView();
    //    }

    //    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    //    {

    //    }

    //    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    //    {

    //    }

    //    private void UpdateListView()
    //    {
    //        using (var connection = new SQLiteConnection(App.DatabasePath))
    //        {
    //            // テーブルがないときのためにCreateTableを実行
    //            connection.CreateTable<Customer>();
    //            var customers = connection.Table<Customer>().ToList();
    //            CustomerListView.ItemsSource = customers;
    //        }
    //    }
    //}
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReadDatabase();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var f = new SaveWindow(null);
            f.ShowDialog();
            ReadDatabase();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null)
            {
                MessageBox.Show("行を選択してください");
                return;
            }

            var f = new SaveWindow(item);
            f.ShowDialog();
            ReadDatabase();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null)
            {
                MessageBox.Show("行を選択してください");
                return;
            }

            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Customer>();
                connection.Delete(item);
                ReadDatabase();
            }
        }

        private void ReadDatabase()
        {
            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Customer>();
                CustomerListView.ItemsSource = connection.Table<Customer>().ToList();
            }
        }
    }
}
