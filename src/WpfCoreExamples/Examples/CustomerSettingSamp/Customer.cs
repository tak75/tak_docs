using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerSettingSamp
{
    //class Customer
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    public class Customer
    {
        public Customer()
        {

        }

        public Customer(string name)
        {
            Name = name;
        }

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
