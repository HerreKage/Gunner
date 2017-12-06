using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunner_OrderList
{
    class DummyCustomers
    {
        private ObservableCollection<Customer> _dummyInfoCustomer;
        public DummyCustomers()


        {
            #region customer1 - Customer1
            Customer customer1 = new Customer();
            customer1.CompanyNumber = "Apple";
            customer1.Name = "David";
            customer1.Address = "Birkemosvej 8";
            customer1.PhoneNumber = "50652415";
            customer1.CompanyNumber = "21-23-65-23";
            customer1.Email = "apple@gmail.com";

         
            #endregion

            #region Order2 - Customer2
            Customer customer2 = new Customer();
            customer2.Company = "Ro's Kabab";
            customer2.Name = "Greg";
            customer2.Address = "Roskilde 8";
            customer2.PhoneNumber = "80122545";
            customer2.CompanyNumber = "43-98-75-23";
            customer2.Email = "rokabab@gmail.com";

            #endregion

            DummyInfo = new ObservableCollection<Customer>();
            DummyInfo.Add(customer1);
            DummyInfo.Add(customer2);



        }

        internal ObservableCollection<Customer> DummyInfo { get => _dummyInfoCustomer; set => _dummyInfoCustomer = value; }
    }
}
