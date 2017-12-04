using System;
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
        private string _name;
        private string _email;
        private string _phoneNumber;
        private string _address;
        private string _companyNumber;

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
        }


    }
}
