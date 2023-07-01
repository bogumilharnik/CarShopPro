using CarShopPro.ViewModel;
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
using System.Windows.Shapes;
using CarShopProDB;

namespace CarShopPro.Views
{
    /// <summary>
    /// Interaction logic for UsersTable.xaml
    /// </summary>
    public partial class UsersTable : Window
    {
        public UsersTable()
        {
            InitializeComponent();
            DataContext = new UserTableViewModel(new CarShopProDBContext());
        }
    }
}
