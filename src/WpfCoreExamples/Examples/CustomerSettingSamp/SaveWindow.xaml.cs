using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CustomerSettingSamp
{
    /// <summary>
    /// SaveWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SaveWindow : Window
    {
        //private int customerId;

        //public SaveWindow()
        //{
        //    InitializeComponent();
        //}
        //public SaveWindow(int id)
        //{
        //    InitializeComponent();
        //    this.customerId = id;
        //}

        //private void SaveButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var customer = new Customer()
        //    {
        //        Id = this.customerId,
        //        Name = NameTextBox.Text
        //    };

        //    //string databaseName = "Shop.db";
        //    //string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //    //string databasePath = System.IO.Path.Combine(folderPath, databaseName);

        //    // クラス生成後はメモリの解放が必要なためDisopose()、もしくはClose()を呼び出す必要があります。
        //    using (var connection = new SQLiteConnection(App.DatabasePath))
        //    {
        //        // データベースや、Customerテーブルが存在しない場合でもエラーにならず、
        //        // 空のテーブルを作成してくれます。
        //        // 存在している場合は何もしないため、このコードを記述しておくことで、
        //        // 初回もエラーにならずに、テーブルが自動生成されます。
        //        connection.CreateTable<Customer>();
        //        connection.Insert(customer);
        //    }

        //    Close();
        //}
        private Customer _customer;
        public SaveWindow(Customer customer)
        {
            InitializeComponent();

            _customer = customer;

            if (customer != null)
            {
                this.NameTextBox.Text = customer.Name;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text.Trim().Length < 1)
            {
                MessageBox.Show("名前を入力してください");
                return;
            }

            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Customer>();
                if (_customer == null)
                {
                    connection.Insert(new Customer(NameTextBox.Text));
                }
                else
                {
                    connection.Update(new Customer(_customer.Id, NameTextBox.Text));
                }

                Close();
            }
        }
    }
}
