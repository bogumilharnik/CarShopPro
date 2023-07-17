using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CarShopPro.Views;
using CarShopProDB;
using CarShopProDB.Commands;
using CarShopProDB.Tables;

namespace CarShopPro.ViewModel
{
    /// <summary>
    /// Represents a view model for handling the UserTable view.
    /// </summary>
    public class UserTableViewModel : INotifyPropertyChanged
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
            }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        private string _role;
        public string Role
        {
            get
            {
                return _role;
            }
            set
            {
                if (_role != value)
                {
                    _role = value;
                    OnPropertyChanged(nameof(Role));
                }
            }
        }

        private string _id;
        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(ID));
                }
            }
        }

        private readonly CarShopProDBContext _context;
        private readonly AuthenticationCommands _authcommands;
        private ObservableCollection<User> _partsTableDisplay;
        private readonly AddToDb _addcommands;
        private readonly RemoveByID _removecommand;


        /// <summary>
        /// Gets or sets the collection of users to display in the table.
        /// </summary>
        public ObservableCollection<User> TableDisplay
        {
            get => _partsTableDisplay;
            set
            {
                _partsTableDisplay = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the UserTableViewModel class with the specified CarShopProDBContext.
        /// </summary>
        /// <param name="context">The CarShopProDBContext to use for database operations.</param>
        public UserTableViewModel(CarShopProDBContext context)
        {
            _context = context;
            #region Tables
            UsersTable = new CommandBlueprint(UsersTableShow);
            CarsTable = new CommandBlueprint(CarsTableShow);
            CustomersTable = new CommandBlueprint(CustomersTableShow);
            #endregion

            Add = new CommandBlueprint(AddElementToDb);
            Remove = new CommandBlueprint(RemoveFromDb);
            _authcommands = new AuthenticationCommands(_context);
            _addcommands = new AddToDb(_context);
            _removecommand = new RemoveByID(_context);
            UpdateTable();
        }

        /// <summary>
        /// Removes a user from the database based on their ID.
        /// </summary>
        private void RemoveFromDb()
        {
            if (!int.TryParse(ID, out int partId))
            {
                MessageBox.Show("Invalid ID. Please enter a valid integer value.", "Error");
                return;
            }

            if (!_removecommand.RemoveData<User>(partId))
            {
                MessageBox.Show("Item with given ID wasn't found", "Error");
                return;
            }
            UpdateTable();
            ID = "";
        }

        /// <summary>
        /// Gets the command to add a new user to the database.
        /// </summary>
        public ICommand Add { get; set; }

        /// <summary>
        /// Gets the command to remove a user from the database.
        /// </summary>
        public ICommand Remove { get; set; }


        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        private void AddElementToDb()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(Role))
            {
                MessageBox.Show("Please fill in all the required fields.", "Error");
                return; 
            }

            User user = new User()
            {
                Username = Username,
                Password = Password,
                Role = Role
            };

            _addcommands.AddData(user);
            UpdateTable();
        }

        #region RedirectButtons

        /// <summary>
        /// Shows the UsersTable view.
        /// </summary>
        private void UsersTableShow()
        {
            var window = new UsersTable();
            Application.Current.MainWindow = window;
            window.Show();
        }


        /// <summary>
        /// Shows the CarsTable view.
        /// </summary>
        private void CarsTableShow()
        {
            var window = new CarsTable();
            Application.Current.MainWindow = window;
            window.Show();
        }

        /// <summary>
        /// Shows the CustomersTable view.
        /// </summary>
        private void CustomersTableShow()
        {
            var window = new CustomersTable();
            Application.Current.MainWindow = window;
            window.Show();
        }
        public ICommand UsersTable { get; }
        public ICommand CarsTable { get; }
        public ICommand CustomersTable { get;}

        #endregion

        /// <summary>
        /// Updates the collection of users to display in the table from the database.
        /// </summary>
        public void UpdateTable()
        {
            var dbtotable = new DbToTableFetch();
            TableDisplay = new ObservableCollection<User>(dbtotable.FetchData<User>());
        }
    }

}
