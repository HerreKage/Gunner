using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Gunner_OrderList.Annotations;
using Gunner_OrderList.Viewmodel;

namespace Gunner_OrderList
{
    class CustomerVM : INotifyPropertyChanged
    {
        private CustomerCatalog _customerCatalog;
        private ObservableCollection<Customer> _customers;
        private DeleteCommand _deleteCommand;
        private Customer _selectedCustomer = null;
        private ObservableCollection<Customer> _displayedCustomers;

        public CustomerVM()
        {
            _customerCatalog = CustomerCatalog.Instance;
           _deleteCommand=new DeleteCommand(this, _customerCatalog);
            
            _displayedCustomers = _customerCatalog.Customers;
        }

        public ObservableCollection<Customer> DisplayedCustomers
        {
            get { return _displayedCustomers; }
        }

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
        }

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value; 
                _deleteCommand.RaiseCanExecuteChanged();
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _selectedCustomer.Name; }
            set { _selectedCustomer.Name = value; }
        }
        public string Email
        {
            get { return _selectedCustomer.Email; }
            set { _selectedCustomer.Email = value; }
        }
        public string PhoneNumber
        {
            get { return _selectedCustomer.PhoneNumber; }
            set { _selectedCustomer.PhoneNumber = value; }
        }
        public string Address
        {
            get { return _selectedCustomer.Address; }
            set { _selectedCustomer.Address = value; }
        }
        public string CompanyNumber
        {
            get { return _selectedCustomer.CompanyNumber; }
            set { _selectedCustomer.CompanyNumber = value; }
        }

        public ICommand DeletionCommand

        {
            get { return _deleteCommand; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

   
}
