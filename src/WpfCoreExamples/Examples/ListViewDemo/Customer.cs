using System;
using System.Collections.Generic;
using System.Text;

namespace ListViewDemo
{
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        
        // オーバライドすることでListViewに所定の文字列を表示させることができる
        //public override string ToString()
        //{
        //    return $"{Id} - {Name} - {Phone}";
        //}
    }
}
