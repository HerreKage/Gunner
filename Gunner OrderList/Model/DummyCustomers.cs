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
            #region Customer1
            Customer customer1 = new Customer();
            customer1.Company = "Apple";
            customer1.Name = "Greg Hancock";
            customer1.Address = "Birkemosvej 8";
            customer1.ZipCode = "2720";
            customer1.Town = "Vanløse";
            customer1.PhoneNumber = "50652415";
            customer1.CompanyNumber = "12345678";
            customer1.Email = "apple@gmail.com";

         
            #endregion

            #region Customer2
            Customer customer2 = new Customer();
            customer2.Company = "Ro's Kabab";
            customer2.Name = "Søren Olsen";
            customer2.Address = "Roskilde 8";
            customer2.ZipCode = "4000";
            customer2.Town = "Roskilde";
            customer2.PhoneNumber = "80122545";
            customer2.CompanyNumber = "91234567";
            customer2.Email = "rokabab@gmail.com";
            #endregion

            #region Customer3
            Customer customer3 = new Customer();
            customer3.Company = "Hotel Comwell";
            customer3.Name = "Peter William Sørensen";
            customer3.Address = "Vestre Kirkevej 8";
            customer3.ZipCode = "4000";
            customer3.Town = "Roskilde";
            customer3.PhoneNumber = "46162545";
            customer3.CompanyNumber = "81234567";
            customer3.Email = "peter@comwell.com";
            #endregion

            #region Customer4
            Customer customer4 = new Customer();
            customer4.Company = "Ringsted Auto";
            customer4.Name = "Peter Andersen";
            customer4.Address = "Hovedgaden 125";
            customer4.ZipCode = "4100";
            customer4.Town = "Ringsted";
            customer4.PhoneNumber = "45251478";
            customer4.CompanyNumber = "25148552";
            customer4.Email = "peter@rauto.dk";
            #endregion

            #region Customer5
            Customer customer5 = new Customer();
            customer5.Company = "Vordinborg Kirke";
            customer5.Name = "Palle Gram";
            customer5.Address = "Kirkestræde 5";
            customer5.ZipCode = "4500";
            customer5.Town = "Vordingborg";
            customer5.PhoneNumber = "57552255";
            customer5.CompanyNumber = "88521475";
            customer5.Email = "peter@vkirke.dk";
            #endregion
            DummyInfo = new ObservableCollection<Customer>();
            DummyInfo.Add(customer1);
            DummyInfo.Add(customer2);
            DummyInfo.Add(customer3);
            DummyInfo.Add(customer4);
            DummyInfo.Add(customer5);



        }

        public ObservableCollection<Customer> DummyInfo { get => _dummyInfoCustomer; set => _dummyInfoCustomer = value; }
    }
}
