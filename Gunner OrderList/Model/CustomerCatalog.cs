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

            //Customer customer1 = new Customer();
            //customer1.Company = "Apple";
            //customer1.Name = "David";
            //customer1.Address = "Birkemosvej 8";
            //customer1.ZipCode = "2720";
            //customer1.Town = "Vanløse";
            //customer1.PhoneNumber = "50652415";
            //customer1.CompanyNumber = "21-23-65-23";
            //customer1.Email = "apple@gmail.com";

            //Customer customer2 = new Customer();
            //customer2.Company = "Ro's Kabab";
            //customer2.Name = "Greg";
            //customer2.Address = "Roskilde 8";
            //customer2.ZipCode = "4000";
            //customer2.Town = "Roskilde";
            //customer2.PhoneNumber = "80122545";
            //customer2.CompanyNumber = "43-98-75-23";
            //customer2.Email = "rokabab@gmail.com";
            
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
        //internal ObservableCollection<Customer> DummyInfo { get => _dummyInfoCustomer; set => _dummyInfoCustomer = value; }
    }
}
