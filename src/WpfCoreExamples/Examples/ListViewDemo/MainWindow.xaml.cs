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

namespace ListViewDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private List<Customer> _customers = new List<Customer>();

        // List<T>だと、Addボタンをクリックしてデータを追加しても変更通知が行われず、画面が変化しない。
        // ObservableCollectionを使用することで、データの変更通知が行われ、画面が変更される。
        private ObservableCollection<Customer> _customers = new ObservableCollection<Customer>();
        private int _index = 0;

        public MainWindow()
        {
            InitializeComponent();

            //_customers.Add(new Customer { Id = 1, Name = "name1", Phone = "phone1" });
            //_customers.Add(new Customer { Id = 2, Name = "name2", Phone = "phone2" });
            //_customers.Add(new Customer { Id = 3, Name = "name3", Phone = "phone3" });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            CustomerListView.ItemsSource = _customers;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            //CustomerListView.ItemsSource = _customers;
        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filterList =
                _customers.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = filterList;
        }
    }
}
