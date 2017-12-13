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
            customer1.Name = "Anders Andersen";
            customer1.Address = "Birkemosvej 8";
            customer1.PhoneNumber = "50652415";
            customer1.CompanyNumber = "12345678";
            customer1.Email = "apple@gmail.com";
            
            Order order1 = new Order();
            order1.Customer = customer1;
            order1.StartDate = "14/12";
            order1.Deadline = "16/12";
            order1.Description = "Needs outdoor signs that will be in a windy area so will need to use strong plastic.";
            order1.Product = "Advertisment Sign";
            order1.OrderNumber = 1325;
            order1.Price = "86 dk";
            order1.Notes = "Ja";

            #endregion

            #region Order2 - Customer2
            Customer customer2 = new Customer();
            customer2.Company = "Ro's Kabab";
            customer2.Name = "Bent Byskov";
            customer2.Address = "Roskilde 8";
            customer2.PhoneNumber = "80122545";
            customer2.CompanyNumber = "91234567";
            customer2.Email = "rokabab@gmail.com";

            Order order2 = new Order();
            order2.Customer = customer2;
            order2.StartDate = "01/12";
            order2.Deadline = "19/12";
            order2.Description = "Needs vibrant sign that will attact customers.";
            order2.Product = "Sign";
            order2.OrderNumber = 1326;
            order2.Price = "130 dk";
            order2.Notes = "Nej";
            #endregion

            #region Order3 - Customer1

            Order order3 = new Order();
            order3.Customer = customer1;
            order3.StartDate = "08/12";
            order3.Deadline = "10/12";
            order3.Description = "Need to getadvertisement on ther company cars";
            order3.Product = "4 biler";
            order3.OrderNumber = 1327;
            order3.Price = "86 dk";
            order3.Notes = "Nej";

            #endregion

            #region Order4 - Customer2
            Order order4 = new Order();
            order4.Customer = customer2;
            order4.StartDate = "07/12";
            order4.Deadline = "12/12";
            order4.Description = "Needs outdoor signs that will be in a windy area so will need to use strong plastic.";
            order4.Product = "Stickers";
            order4.OrderNumber = 1328;
            order4.Price = "86 dk";
            order4.Notes = "Nej";


            #endregion

            #region Order5 - Customer2

            Order order5 = new Order();
            order5.Customer = customer1;
            order5.StartDate = "02/12";
            order5.Deadline = "02/12";
            order5.Description = "Needs outdoor signs that will be in a windy area so will need to use strong plastic.";
            order5.Product = "Pop-up medie";
            order5.OrderNumber = 1329;
            order5.Price = "86 dk";
            order5.Notes = "Ja";

            #endregion

            #region Order6 - Customer1

            Order order6 = new Order();
            order6.Customer = customer1;
            order6.StartDate = "02/12";
            order6.Deadline = "10/12";
            order6.Description = "Needs outdoor signs that will be in a windy area so will need to use strong plastic.";
            order6.Product = "Gulv reklame";
            order6.OrderNumber = 1330;
            order6.Price = "86 dk";
            order6.Notes = "Nej";

            #endregion

            DummyInfo = new ObservableCollection<Order>();
            DummyInfo.Add(order1);
            DummyInfo.Add(order2);
            DummyInfo.Add(order3);
            DummyInfo.Add(order4);
            DummyInfo.Add(order5);
            DummyInfo.Add(order6);
        }


        internal ObservableCollection<Order> DummyInfo { get => _dummyInfo; set => _dummyInfo = value; }
    }
}
