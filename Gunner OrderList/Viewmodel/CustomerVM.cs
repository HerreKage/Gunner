﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunner_OrderList
{
    class CustomerVM
    {
        private ObservableCollection<Customer> _customers;

        public CustomerVM()
        {
            CustomerCatalog customerCatalog = CustomerCatalog.Instance;
            _customers = customerCatalog.Customers;
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
    }
}
