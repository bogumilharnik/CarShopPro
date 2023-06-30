using CarShopProDB.Commands;
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
using CarShopProDB.Tables;

namespace CarShopPro.ViewModel
{
    public class MainViewViewModel : INotifyPropertyChanged
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

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string _description;
        public string Desc
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Desc));
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

        private string _quantity;
        public string Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        private string _partid;
        public string PartID
        {
            get
            {
                return _partid;
            }
            set
            {
                if (_partid != value)
                {
                    _partid = value;
                    OnPropertyChanged(nameof(PartID));
                }
            }
        }


        private readonly CarShopProDBContext _context;
        private readonly AuthenticationCommands _authcommands;
        private ObservableCollection<Part> _partsTableDisplay;
        private readonly AddToDb _addcommands;
        private readonly RemoveByID _removecommand;

        public ObservableCollection<Part> PartsTableDisplay
        {
            get => _partsTableDisplay;
            set
            {
                _partsTableDisplay = value;
                OnPropertyChanged();
            }
        }

        public MainViewViewModel(CarShopProDBContext context)
        {
            _context = context;
            #region Tables
            UsersTable = new CommandBlueprint(UsersTableShow);
            CarsTable = new CommandBlueprint(CarsTableShow);
            CustomersTable = new CommandBlueprint(CustomersTableShow);
            #endregion

            AddPart = new CommandBlueprint(AddPartToDb);
            Remove = new CommandBlueprint(RemovePartFromDb);
            _authcommands = new AuthenticationCommands(_context);
            _addcommands = new AddToDb(_context);
            _removecommand = new RemoveByID(_context);
            UpdatePartsTable();
        }

        private void RemovePartFromDb()
        {
            if (!int.TryParse(PartID, out int partId))
            {
                MessageBox.Show("Invalid Part ID. Please enter a valid integer value.", "Error");
                return;
            }

            if (!_removecommand.RemoveData<Part>(partId))
            {
                MessageBox.Show("Item with given ID wasn't found", "Error");
                return;
            }
            UpdatePartsTable();
            PartID = "";
        }

        public ICommand AddPart { get; set; }
        public ICommand Remove { get; set; }

        private void AddPartToDb()
        {
            if (string.IsNullOrWhiteSpace(Desc) || string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(Price) || string.IsNullOrWhiteSpace(Quantity))
            {
                MessageBox.Show("Please fill in all the required fields.", "Error");
                return; 
            }

            decimal price;
            if (!decimal.TryParse(Price, out price))
            {
                MessageBox.Show("Please enter a valid price.", "Error");
                return; 
            }

            int quantity;
            if (!int.TryParse(Quantity, out quantity))
            {
                MessageBox.Show("Please enter a valid quantity.", "Error");
                return; 
            }
            Part part = new Part()
            {
                Description = Desc,
                Name = Name,
                Price = Convert.ToDecimal(Price),
                Quantity = Convert.ToInt32(Quantity)
            };

            _addcommands.AddPartToDb(part);
            UpdatePartsTable();
        }

        #region RedirectButtons
        private void UsersTableShow()
        {
            var window = new UsersTable();
            Application.Current.MainWindow = window;
            window.Show();
        }

        private void CarsTableShow()
        {
            var window = new CarsTable();
            Application.Current.MainWindow = window;
            window.Show();
        }

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

        public void UpdatePartsTable()
        {
            var dbtotable = new DbToTableFetch();
            PartsTableDisplay = new ObservableCollection<Part>(dbtotable.FetchData<Part>());
        }
    }
}
