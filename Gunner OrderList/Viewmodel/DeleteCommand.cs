using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Input;


namespace Gunner_OrderList.Viewmodel
{
    class DeleteCommand :ICommand
    {
        private CustomerCatalog _catalog;

        private Customer _customer;
        private CustomerVM _customerVM;
        private CustomerVM customerVM;
        private DeleteCommand _deleteCommand;

        public DeleteCommand(CustomerVM Customer, CustomerCatalog customerCatalog)
        {
            _catalog = customerCatalog;
            _customerVM = Customer;
            
        }

        public DeleteCommand(CustomerVM customerVM, DeleteCommand deleteCommand)
        {
            this.customerVM = customerVM;
            _deleteCommand = deleteCommand;
        }

        public bool CanExecute(object parameter)
        {
            return _customerVM.SelectedCustomer != null;
        }

        public void Execute(object parameter)
        {
            _catalog.Delete(_customerVM.SelectedCustomer);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}
