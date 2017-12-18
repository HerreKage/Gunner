using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gunner_OrderList.Viewmodel
{
    class CustomerEditCommand : ICommand
    {
            private CustomerCatalog _catalog;

            private CustomerVM _customerVM;
            private CustomerVM customerVM;
            private CustomerEditCommand _customereditCommand;

            public CustomerEditCommand(CustomerVM Customer, CustomerCatalog customerCatalog)
            {
                _catalog = customerCatalog;
                _customerVM = Customer;

            }

            public CustomerEditCommand(CustomerVM customerVM, CustomerEditCommand customerEditCommand)
            {
                this.customerVM = customerVM;
                _customereditCommand = customerEditCommand;

            }

            public bool CanExecute(object parameter)
            {
                return _customerVM.SelectedCustomer != null;
            }

            public void Execute(object parameter)
            {
                _customerVM.SelectedCustomer.Company = _customerVM.Company;
                _customerVM.SelectedCustomer.Name = _customerVM.Name;
                _customerVM.SelectedCustomer.Address = _customerVM.Address;
                _customerVM.SelectedCustomer.ZipCode = _customerVM.ZipCode;
                _customerVM.SelectedCustomer.Town = _customerVM.Town;
                _customerVM.SelectedCustomer.PhoneNumber = _customerVM.PhoneNumber;
                _customerVM.SelectedCustomer.Email = _customerVM.Email;
                _customerVM.SelectedCustomer.CompanyNumber = _customerVM.CompanyNumber;
                // _catalog.EditCustomer(_customerVM.SelectedCustomer);
                _customerVM.Refresh();

                _catalog.SaveCustomer();
            }

            public void RaiseCanExecuteChanged()
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }

            public event EventHandler CanExecuteChanged;
    }
    
}
