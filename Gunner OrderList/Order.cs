using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunner_OrderList
{
    class Order
    {
        private string _name;
        private string _description;

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

        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public bool Checkbox1 { get => checkbox1; set => checkbox1 = value; }
        public bool Checkbox2 { get => checkbox2; set => checkbox2 = value; }
        public bool Checkbox3 { get => checkbox3; set => checkbox3 = value; }
        public bool Checkbox4 { get => checkbox4; set => checkbox4 = value; }
        public bool Checkbox5 { get => checkbox5; set => checkbox5 = value; }
        public bool Checkbox6 { get => checkbox6; set => checkbox6 = value; }
        public bool Checkbox7 { get => checkbox7; set => checkbox7 = value; }
        public bool Checkbox8 { get => checkbox8; set => checkbox8 = value; }
    }
}
