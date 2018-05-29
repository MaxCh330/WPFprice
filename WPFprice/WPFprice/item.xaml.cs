﻿using System;
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
    /// item.xaml 的互動邏輯
    /// </summary>
    public partial class item : UserControl
    {
        public item()
        {
            InitializeComponent();
        }

       public int itemPriceValue
       {
            get
            {
                try
                {
                    return int.Parse(itemPrice.Text);
                }
                catch
                {
                    MessageBox.Show("Plese enter the number");
                    return 0;
                }
            }
            set
            {
                itemPrice.Text = value.ToString();
            }
       }

        private void itemPrice_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
