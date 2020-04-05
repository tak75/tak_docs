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
using SQLiteDemo.Objects;
using SQLite;

namespace SQLiteDemo
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
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customer()
            {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
            };

            //string databaseName = "Shop.db";
            //string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //string databasePath = System.IO.Path.Combine(folderPath, databaseName);

            // クラス生成後はメモリの解放が必要なためDisopose()、もしくはClose()を呼び出す必要があります。
            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                // データベースや、Customerテーブルが存在しない場合でもエラーにならず、
                // 空のテーブルを作成してくれます。
                // 存在している場合は何もしないため、このコードを記述しておくことで、
                // 初回もエラーにならずに、テーブルが自動生成されます。
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                // テーブルがないときのためにCreateTableを実行
                connection.CreateTable<Customer>();
                var customers = connection.Table<Customer>().ToList();
            }
        }
    }
}
