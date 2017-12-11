using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Store.Preview.InstallControl;
using Gunner_OrderList.Annotations;
using Gunner_OrderList.Viewmodel;

namespace Gunner_OrderList
{
    class CustomerVM : INotifyPropertyChanged
    {
        private  ObservableCollection<Customer> _customers;
        private DeleteCommand _deleteCommand;
        private Customer _selectedCustomer = null;
        private  ObservableCollection<Customer> _displayCustomers;
        private  CustomerCatalog _customerCatalog;
        private CustomerEditCommand _customerEditCommand;
        public CustomerVM()
        {
            _customerCatalog = CustomerCatalog.Instance;
            _customers = _customerCatalog.Customers;
            _deleteCommand= new DeleteCommand(this, _customerCatalog);
            _displayCustomers = _customerCatalog.Customers;
            _customerEditCommand = new CustomerEditCommand(this, _customerCatalog);
        }

        public ObservableCollection<Customer> DisplayCustomers
        {
            get
            {
                ObservableCollection<Customer> newList = new ObservableCollection<Customer>();
                foreach (var c in _customerCatalog.Customers)
                {
                    newList.Add(c);
                }
                return newList; 
                
            }
        }

        //public ObservableCollection<Customer> Customers
        //{
        //    get { return _customers; }
        //}

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;

                if (_selectedCustomer != null)
                {
                    Company = _selectedCustomer.Company;
                    Name = _selectedCustomer.Name;
                    Address = _selectedCustomer.Address;
                    ZipCode = _selectedCustomer.ZipCode;
                    Town = _selectedCustomer.Town;
                    PhoneNumber = _selectedCustomer.PhoneNumber;
                    Email = _selectedCustomer.Email;
                    CompanyNumber = _selectedCustomer.CompanyNumber;

                    OnPropertyChanged(nameof(Name));
                }

                _deleteCommand.RaiseCanExecuteChanged();
                _customerEditCommand.RaiseCanExecuteChanged();
                OnPropertyChanged();
            }
        }
        public string Company { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    
        public string ZipCode { get; set; }

        public string Town { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string CompanyNumber { get; set; }

        public ICommand DeletionCommand

        {
            get { return _deleteCommand; }
        }
        
        public ICommand EditCustomerCommand
        {
            get { return _customerEditCommand; }
        }

        public void Refresh()
        {
            OnPropertyChanged(nameof(DisplayCustomers));
        }
       
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

   
}
