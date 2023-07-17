using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CarShopProDB;
using CarShopProDB.Commands;
using CarShopProDB.Tables;

namespace CarShopPro.ViewModel
{
    /// <summary>
    /// Represents a view model for displaying a collection of customers in a table.
    /// </summary>
    public class CustomersTableViewModel : INotifyPropertyChanged
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

        #region Props
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        private string _phone;
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
        }
        #endregion


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
        private ObservableCollection<Customer> _partsTableDisplay;
        private readonly AddToDb _addcommands;
        private readonly RemoveByID _removecommand;

        /// <summary>
        /// Gets or sets the collection of customers to display in the table.
        /// </summary>
        public ObservableCollection<Customer> TableDisplay
        {
            get => _partsTableDisplay;
            set
            {
                _partsTableDisplay = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the CustomersTableViewModel class with the specified CarShopProDBContext.
        /// </summary>
        /// <param name="context">The CarShopProDBContext to use for database operations.</param>
        public CustomersTableViewModel(CarShopProDBContext context)
        {
            _context = context;
            Add = new CommandBlueprint(AddElementToDb);
            Remove = new CommandBlueprint(RemoveFromDb);
            _authcommands = new AuthenticationCommands(_context);
            _addcommands = new AddToDb(_context);
            _removecommand = new RemoveByID(_context);
            UpdateTable();
        }

        /// <summary>
        /// Removes a customer from the database based on its ID.
        /// </summary>
        private void RemoveFromDb()
        {
            if (!int.TryParse(ID, out int parsedID))
            {
                MessageBox.Show("Invalid ID. Please enter a valid integer value.", "Error");
                return;
            }

            if (!_removecommand.RemoveData<Customer>(parsedID))
            {
                MessageBox.Show("Item with given ID wasn't found", "Error");
                return;
            }
            UpdateTable();
            ID = "";
        }

        /// <summary>
        /// Gets the command to add a new customer to the database.
        /// </summary>
        public ICommand Add { get; set; }

        /// <summary>
        /// Gets the command to remove a customer from the database.
        /// </summary>
        public ICommand Remove { get; set; }


        /// <summary>
        /// Adds a new customer to the database.
        /// </summary>
        private void AddElementToDb()
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Phone))
            {
                MessageBox.Show("Please fill in all the required fields.", "Error");
                return; 
            }

            var customer = new Customer
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Phone = Phone
            };

            _addcommands.AddData(customer);
            UpdateTable();
        }


        /// <summary>
        /// Updates the collection of customers to display in the table from the database.
        /// </summary>
        public void UpdateTable()
        {
            var dbtotable = new DbToTableFetch();
            TableDisplay = new ObservableCollection<Customer>(dbtotable.FetchData<Customer>());
        }
    }
}
