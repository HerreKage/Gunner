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
        private DeleteCommand _deleteCommand;
        private Customer _selectedCustomer = null;

        private ObservableCollection<Customer> _displayCustomers;
        private CustomerCatalog _customerCatalog;

        public CustomerVM()
        {
            _customerCatalog = CustomerCatalog.Instance;
            _deleteCommand= new DeleteCommand(this, _customerCatalog);
            _displayCustomers = _customerCatalog.Customers;
        }

        public ObservableCollection<Customer> DisplayCustomers
        {
            get { return _displayCustomers; }
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
