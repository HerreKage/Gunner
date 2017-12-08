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
        private ObservableCollection<Customer> _dummyInfoCustomer;


        private static CustomerCatalog _instance=null;

        private static int _customerNumber;
        
        private CustomerCatalog()
        {
            _customers = new ObservableCollection<Customer>(); //Should load from database later

            _customerNumber = 2;

            //Customer customer1 = new Customer();
            //customer1.CompanyNumber = "Apple";
            //customer1.Name = "David";
            //customer1.Address = "Birkemosvej 8";
            //customer1.PhoneNumber = "50652415";
            //customer1.CompanyNumber = "21-23-65-23";
            //customer1.Email = "apple@gmail.com";



            //Customer customer2 = new Customer();
            //customer2.Company = "Ro's Kabab";
            //customer2.Name = "Greg";
            //customer2.Address = "Roskilde 8";
            //customer2.PhoneNumber = "80122545";
            //customer2.CompanyNumber = "43-98-75-23";
            //customer2.Email = "rokabab@gmail.com";

            //_customers.Add(customer1);
            //_customers.Add(customer2);
        }

        public static CustomerCatalog Instance
        { 
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomerCatalog();
                }
                return _instance;
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

        internal ObservableCollection<Customer> DummyInfo { get => _dummyInfoCustomer; set => _dummyInfoCustomer = value; }
    }
}
