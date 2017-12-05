using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunner_OrderList
{
    class DummyOrder
    {
        private ObservableCollection<Order> _dummyInfo;
        public DummyOrder()
        {
            #region Order1 - Customer1
            Customer customer1 = new Customer();
            customer1.Company = "Apple";
            customer1.Name = "David";
            customer1.Address = "Birkemosvej 8";
            customer1.PhoneNumber = "50652415";
            customer1.CompanyNumber = "21-23-65-23";
            customer1.Email = "apple@gmail.com";
            
            Order order1 = new Order();
            order1.Customer = customer1;
            order1.Deadline = "16/12/17";
            order1.Description = "Needs outdoor signs that will be in a windy area so will need to use strong plastic.";
            order1.Product = "Advertisment Sign";
            order1.OrderNumber = 1;
            order1.Price = "86 dk";
            #endregion

            #region Order2 - Customer2
            Customer customer2 = new Customer();
            customer2.Company = "Ro's Kabab";
            customer2.Name = "Greg";
            customer2.Address = "Roskilde 8";
            customer2.PhoneNumber = "80122545";
            customer2.CompanyNumber = "43-98-75-23";
            customer2.Email = "rokabab@gmail.com";

            Order order2 = new Order();
            order2.Customer = customer2;
            order2.Deadline = "19/12/17";
            order2.Description = "Needs vibrant sign that will attact customers.";
            order2.Product = "Advertisment Sign";
            order2.OrderNumber = 2;
            order2.Price = "130 dk";
            #endregion


            DummyInfo = new ObservableCollection<Order>();
            DummyInfo.Add(order1);
            DummyInfo.Add(order2);


        }

        internal ObservableCollection<Order> DummyInfo { get => _dummyInfo; set => _dummyInfo = value; }
    }
}
