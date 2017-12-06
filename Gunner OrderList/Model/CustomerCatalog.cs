using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Gunner_OrderList
{
    class CustomerCatalog
    {
        private ObservableCollection<Customer> _customers;  //List of customers
        
        private static CustomerCatalog instance=null;

        private ObservableCollection<Customer> _dummyInfoCustomer;
        private static int _customerNumber;
        private List<Customer> _customer;

        private CustomerCatalog()
        {
            DummyCustomers _customerorders=new DummyCustomers(); //Should load from database later
            DummyInfo = _customerorders.DummyInfo;
            _customerNumber = 2;
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

        internal ObservableCollection<Customer> DummyInfo { get => _dummyInfoCustomer ; set => _dummyInfoCustomer = value; }
    }
}
