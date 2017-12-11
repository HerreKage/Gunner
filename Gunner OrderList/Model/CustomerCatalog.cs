using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Gunner_OrderList
{
    class CustomerCatalog
    {
        private ObservableCollection<Customer> _customers;  //List of customers
        //private ObservableCollection<Customer> _dummyInfoCustomer;
        private static CustomerCatalog instance=null;

        private CustomerCatalog()
        {
            _customers = new ObservableCollection<Customer>(); //Should load from database later


            
            DummyCustomers customers = new DummyCustomers();
            foreach (var customer in customers.DummyInfo)
            {
                _customers.Add(customer);
            }
           
        }

        public static CustomerCatalog Instance
        { 
            get
            {
                if (instance == null)
                {
                    instance = new CustomerCatalog();
                }
                return instance;
            }
        }

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value; }

        }

        public void Delete (Customer customer)
        {
            if (_customers.Contains(customer))
            {
                _customers.Remove(customer);
            }
        }

        //public void EditCustomer(Customer customer)
        //{
        //    if (_customers.Contains(customer))
        //    {
        //        _customers.Remove(customer);
        //        _customers.Add(customer);
        //    }
        //}
        //internal ObservableCollection<Customer> DummyInfo { get => _dummyInfoCustomer; set => _dummyInfoCustomer = value; }
    }
}
