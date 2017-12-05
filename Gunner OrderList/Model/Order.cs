using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunner_OrderList
{
    class Order 
    {
        private Customer _customer = new Customer();
        private string _description;

        // These varriables need to be added to the order page
        private int orderNumber;
        private string _product;
        private string _startdate;
        private string _deadline;
        private string _price;
        //End

        private bool checkbox1;
        private bool checkbox2;
        private bool checkbox3;
        private bool checkbox4;
        private bool checkbox5;
        private bool checkbox6;
        private bool checkbox7;
        private bool checkbox8;


        public Order()
        {
        }

        public Customer Customer { get => _customer; set => _customer = value; }
        public string Description { get => _description; set => _description = value; }
        public int OrderNumber { get => orderNumber; set => orderNumber = value; }
        public string Product { get => _product; set => _product = value; }
        public string Deadline { get => _deadline; set => _deadline = value; }
        public string Price { get => _price; set => _price = value; }

        //public bool Checkbox1 { get => checkbox1; set => checkbox1 = value; }
        //public bool Checkbox2 { get => checkbox2; set => checkbox2 = value; }
        //public bool Checkbox3 { get => checkbox3; set => checkbox3 = value; }
        //public bool Checkbox4 { get => checkbox4; set => checkbox4 = value; }
        //public bool Checkbox5 { get => checkbox5; set => checkbox5 = value; }
        //public bool Checkbox6 { get => checkbox6; set => checkbox6 = value; }
        //public bool Checkbox7 { get => checkbox7; set => checkbox7 = value; }
        //public bool Checkbox8 { get => checkbox8; set => checkbox8 = value; }

    }
}
