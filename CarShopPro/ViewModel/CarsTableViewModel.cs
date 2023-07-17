using CarShopProDB.Commands;
using CarShopProDB.Tables;
using CarShopProDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using CarShopPro.Views;

namespace CarShopPro.ViewModel
{
    /// <summary>
    /// Represents a view model for displaying a collection of cars in a table.
    /// </summary>
    public class CarsTableViewModel : INotifyPropertyChanged
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
        private string _brand;
        public string Brand
        {
            get
            {
                return _brand;
            }
            set
            {
                if (_brand != value)
                {
                    _brand = value;
                    OnPropertyChanged(nameof(Brand));
                }
            }
        }

        private string _model;
        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                if (_model != value)
                {
                    _model = value;
                    OnPropertyChanged(nameof(Model));
                }
            }
        }

        private string _year;
        public string Year
        {
            get
            {
                return _year;
            }
            set
            {
                if (_year != value)
                {
                    _year = value;
                    OnPropertyChanged(nameof(Year));
                }
            }
        }

        private string _color;
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged(nameof(Color));
                }
            }
        }

        private string _price;
        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
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
        private ObservableCollection<Car> _partsTableDisplay;
        private readonly AddToDb _addcommands;
        private readonly RemoveByID _removecommand;

        public ObservableCollection<Car> TableDisplay
        {
            get => _partsTableDisplay;
            set
            {
                _partsTableDisplay = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the CarsTableViewModel class with the specified CarShopProDBContext.
        /// </summary>
        /// <param name="context">The CarShopProDBContext to use for database operations.</param>
        public CarsTableViewModel(CarShopProDBContext context)
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
        /// Removes a car from the database based on its ID.
        /// </summary>
        private void RemoveFromDb()
        {
            if (!int.TryParse(ID, out int parsedID))
            {
                MessageBox.Show("Invalid ID. Please enter a valid integer value.", "Error");
                return;
            }

            if (!_removecommand.RemoveData<Car>(parsedID))
            {
                MessageBox.Show("Item with given ID wasn't found", "Error");
                return;
            }
            UpdateTable();
            ID = "";
        }

        public ICommand Add { get; set; }
        public ICommand Remove { get; set; }

        /// <summary>
        /// Adds a new car to the database.
        /// </summary>
        private void AddElementToDb()
        {
            if (string.IsNullOrWhiteSpace(Brand) || string.IsNullOrWhiteSpace(Model) || string.IsNullOrWhiteSpace(Year) || string.IsNullOrWhiteSpace(Color) || string.IsNullOrWhiteSpace(Price))
            {
                MessageBox.Show("Please fill in all the required fields.", "Error");
                return; 
            }

            int parsedYear;
            if (!int.TryParse(Year, out parsedYear))
            {
                MessageBox.Show("Invalid year value.", "Error");
                return;
            }

            decimal parsedPrice;
            if (!decimal.TryParse(Price, out parsedPrice))
            {
                MessageBox.Show("Invalid price value.", "Error");
                return;
            }

            var car = new Car
            {
                Brand = Brand,
                Model = Model,
                Year = int.Parse(Year),
                Color = Color,
                Price = decimal.Parse(Price)
            };

            _addcommands.AddData(car);
            UpdateTable();
        }

        /// <summary>
        /// Updates the collection of cars to display in the table from the database.
        /// </summary>
        public void UpdateTable()
        {
            var dbtotable = new DbToTableFetch();
            TableDisplay = new ObservableCollection<Car>(dbtotable.FetchData<Car>());
        }
    }
}
