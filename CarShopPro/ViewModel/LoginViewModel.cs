using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CarShopPro.Views;
using CarShopProDB;
using CarShopProDB.Commands;
using CarShopProDB.Tables;
using SQLitePCL;

namespace CarShopPro.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        private string _password;
        private readonly CarShopProDBContext _context;
        private readonly AuthenticationCommands _authcommands;
        public string Password
        {
            get
            {
                return _password;
            }set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
        public LoginViewModel(CarShopProDBContext context)
        {
            _context = context;
            LoginComm = new CommandBlueprint(Login);
            _authcommands = new AuthenticationCommands(_context);
        }

        private void Login()
        {
            if (_authcommands.AuthenticateUser(Username, Password))
            {
                MessageBox.Show("Login Successfull");
                var window = new MainView();
                if (Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.Close();
                }
                Application.Current.MainWindow = window;
                window.Show();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }
        }

        public ICommand LoginComm { get; }
    }
}
