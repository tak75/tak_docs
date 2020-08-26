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
using ControlTemplateDemo;

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
                new Example(typeof(ButtonDemo.MainWindow), null, "画像付ボタン、図形付ボタン、丸型ボタン（シンプル）、LayoutTransform（表示倍率）"),
                new Example(typeof(VariousButtonsDemo.MainWindow), null, "楕円形ボタン、リピートボタン、トグルボタン、ControlTemplate、TemplateBinding"),
                new Example(typeof(CheckBoxDemo.MainWindow), null, "CheckBoxの簡易デモ"),
                new Example(typeof(RadioButtonDemo.MainWindow), null, "RadioButtonの簡易デモ"),
                new Example(typeof(ExpanderDemo.MainWindow), null, "Expanderの簡易デモ"),
                new Example(typeof(GroupBoxDemo.MainWindow), null, "GroupBoxの簡易デモ"),
                new Example(typeof(ListViewDemo.MainWindow), null, "ListViewの簡易デモ、ItemTemplate、DataTemplate"),
                new Example(typeof(ListBoxDemo.MainWindow), null, "ListBoxの簡易デモ、ItemTemplate、DataTemplate、SelectionMode"),
                new Example(typeof(ProgressBarDemo.MainWindow), null, "ProgressBarの簡易デモ"),
                new Example(typeof(SliderDemo.MainWindow), null, "Sliderの簡易デモ"),
                new Example(typeof(SQLiteDemo.MainWindow), null, "SQLiteの簡易デモ"),
                new Example(typeof(CustomerSettingSamp.MainWindow), null, "SQLiteを用いたカスタマー設定サンプル、ItemTemplate、DataTemplate"),
                new Example(typeof(ComboBoxDemo.MainWindow), null, "ComboBoxの簡易デモ、ItemTemplate、DataTemplate"),
                new Example(typeof(TabControlDemo.MainWindow), null, "TabControlの簡易デモ"),
                new Example(typeof(TreeViewDemo.MainWindow), null, "TreeViewの簡易デモ"),
                new Example(typeof(TextBlock_TextBoxDemo.MainWindow), null, "TextBlock、およびTextBoxDemoの簡易デモ"),
                new Example(typeof(MenuDemo.MainWindow), null, "Menuの簡易デモ"),
                new Example(typeof(ToolBarDemo.MainWindow), null, "ToolBarの簡易デモ"),
                new Example(typeof(StatusBarDemo.MainWindow), null, "StatusBarの簡易デモ"),
                new Example(typeof(WrapPanelDemo.MainWindow), null, "WrapPanelの簡易デモ"),
                new Example(typeof(DockPanelDemo.MainWindow), null, "DockPanelの簡易デモ"),
                new Example(typeof(CanvasDemo.MainWindow), null, "Canvasの簡易デモ"),
                new Example(typeof(TriggerDemo.MainWindow), null, "Triggerの簡易デモ"),
                new Example(typeof(ControlTemplateDemo.MainWindow), null, "ControlTemplateの簡易デモ"),
                new Example(typeof(DataTemplateDemo.MainWindow), null, ""),
            };
            this.ExamplesComplex = new List<Example>
            {
                new Example(typeof(CustomButtonDemo.MainWindow), null, "カスタムボタン"),
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
