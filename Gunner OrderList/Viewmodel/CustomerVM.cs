using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Gunner_OrderList.Viewmodel;

namespace Gunner_OrderList
{
    class CustomerVM
    {
        private ObservableCollection<Customer> _customers;
        private DeleteCommand _deleteCommand;


        public CustomerVM()
        {
            CustomerCatalog customerCatalog = CustomerCatalog.Instance;
            _customers = customerCatalog.Customers;
            _deleteCommand=new DeleteCommand(this, customerCatalog);
        }
        private Customer _selectedCustomer = new Customer();

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
        }

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { _selectedCustomer = value; }
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
    }

   
}
