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
        private Customer _newCustomer = new Customer();

        private static CustomerCatalog instance=null;

        private CustomerCatalog()
        {
            _customers = new ObservableCollection<Customer>();
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
    }
}
