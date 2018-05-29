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

namespace WPFprice
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            item item = new item();

            toDoList.Children.Add(item);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            string data = "";

            foreach (item item in toDoList.Children)
            {

                data += item.day + "|" + item.itemName + "|" + item.itemPrice + "\r\n";
            }

            System.IO.File.WriteAllText(@"D:\SaveDataTest", data);
        }

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            int CtotalPrice = 0;
            if (e.Key == Key.Return)
            {
                foreach (item item in toDoList.Children)
                {
                    CtotalPrice += item.itemPriceValue;
                }
                totalPrice.Text = CtotalPrice.ToString();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 開檔
            string[] lines = System.IO.File.ReadAllLines(@"C:\temp\data.txt");
​
           // 分析每一行
        foreach (string line in lines)
            {
                // 用 | 符號拆開
                string[] parts = line.Split('|');
​
        // 建立 TodoItem
        item item = new item();
        item.day.Text = parts[1];
                
​​
        // 放到清單中
        TotoItemList.Children.Add(item);
            }
        }
    }
}
