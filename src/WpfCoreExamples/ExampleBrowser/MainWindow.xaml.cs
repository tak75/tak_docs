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
using ButtonDemo;

namespace ExampleBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.ExamplesSimple = new List<Example>
            {
                new Example(typeof(HelloWorld.MainWindow), null, "HelloWorld"),
                new Example(typeof(GridDemo.MainWindow), null, "Gridの簡易デモ"),
                new Example(typeof(ButtonDemo.MainWindow), null, "画像付ボタン、図形付ボタン、丸型ボタン（シンプル）"),
                new Example(typeof(VariousButtonsDemo.MainWindow), null, "楕円形ボタン、リピートボタン、トグルボタン、TemplateBinding"),
                new Example(typeof(CheckBoxDemo.MainWindow), null, "CheckBoxの簡易デモ"),
                new Example(typeof(RadioButtonDemo.MainWindow), null, "RadioButtonの簡易デモ"),
                new Example(typeof(ExpanderDemo.MainWindow), null, "Expanderの簡易デモ"),
                new Example(typeof(GroupBoxDemo.MainWindow), null, "GroupBoxの簡易デモ"),
                new Example(typeof(ListViewDemo.MainWindow), null, "ListViewの簡易デモ、ItemTemplate"),
                new Example(typeof(ProgressBarDemo.MainWindow), null, "ProgressBarの簡易デモ"),
                new Example(typeof(SliderDemo.MainWindow), null, "Sliderの簡易デモ"),
                new Example(typeof(SQLiteDemo.MainWindow), null, "SQLiteの簡易デモ"),
                new Example(typeof(CustomerSettingSamp.MainWindow), null, "SQLiteを用いたカスタマー設定サンプル"),
                new Example(typeof(ComboBoxDemo.MainWindow), null, "ComboBoxの簡易デモ"),
                new Example(typeof(DataTemplateDemo.MainWindow), null, ""),
            };
            this.ExamplesComplex = new List<Example>
            {
                new Example(typeof(AnimatedButton.MainWindow), null, "アニメーションボタン、ControlTemplate"),
            };
        }
        public IList<Example> ExamplesSimple { get; private set; }
        public IList<Example> ExamplesComplex { get; private set; }
        private void ListBoxMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var lb = (ListBox)sender;
            var example = lb.SelectedItem as Example;
            if (example != null)
            {
                var window = example.Create();
                window.Show();
            }
        }
    }
}
