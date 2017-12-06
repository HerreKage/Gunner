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
        ObservableCollection<Customer> _customers;  //List of customers

        private static CustomerCatalog instance=null;

        private CustomerCatalog()
        {
            _customers = new ObservableCollection<Customer>(); //Should load from database later
            
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
    }
}
