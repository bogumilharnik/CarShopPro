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
using System.Windows.Shapes;
using CarShopPro.ViewModel;
using CarShopProDB;

namespace CarShopPro.Views
{
    /// <summary>
    /// Interaction logic for CarsTable.xaml
    /// </summary>
    public partial class CarsTable : Window
    {
        public CarsTable()
        {
            InitializeComponent();
            DataContext = new CarsTableViewModel(new CarShopProDBContext());
        }
    }
}
