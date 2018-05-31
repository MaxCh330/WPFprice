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

        //關閉視窗事件
        private void Window_Closed(object sender, EventArgs e)
        {

            // 新增一個串列裝每個項目轉成的文字
            List<string> datas = new List<string>();

            // 轉換每一個項目
            foreach (item item in toDoList.Children)
            {
                //設置一個空的字串
                string data = "";

                //每一種資料以"|"區隔加入data字串
                data += item.day.Text + "|" + item.itemName.Text + "|" + item.itemPrice.Text;
                
                //加入Datas的陣列
                datas.Add(data);
            }

            System.IO.File.WriteAllLines(@"C:\temp\data.txt", datas);
        }

        //按鍵事件
        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            //建立一個空的數字
            int CtotalPrice = 0;
            
            //在按ENTER的時候會計算總支出
            if (e.Key == Key.Return)
            {
                // 計算每一個項目
                foreach (item item in toDoList.Children)
                {
                    //將價格相加
                    CtotalPrice += item.itemPriceValue;
                }

                //顯示價格
                totalPrice.Text = CtotalPrice.ToString();
            }
            
        }

        //打開視窗事件
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 開檔
            string[] lines = System.IO.File.ReadAllLines(@"C:\temp\data.txt");
            
            // 分析每一行
            foreach (string line in lines)
            {
                // 用 | 符號拆開
                string[] parts = line.Split('|');
                
                // 建立 TodoItem
                item item = new item();
                
                //分別讀取不同部份
                item.day.Text = parts[0];
                item.itemName.Text = parts[1];
                item.itemPrice.Text = parts[2];
                
                // 放到清單中
                toDoList.Children.Add(item);
            }
        }

        //增加項目
        private void addItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 產生項目
            item item = new item();

            //放到清單中
            toDoList.Children.Add(item);
        }
    }
}
