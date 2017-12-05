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

        public DeleteCommand(CustomerVM Customer, CustomerCatalog customerCatalog)


        {
            _catalog = customerCatalog;
            _customerVM = Customer;
        }


        public bool CanExecute(object parameter)
        {
            return _customerVM.SelectedCustomer !=null;
        }

        public void Execute(object parameter)
        {
            _catalog.Delete(_customerVM.SelectedCustomer);



        }

        public event EventHandler CanExecuteChanged;
    }
}
