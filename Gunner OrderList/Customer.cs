using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunner_OrderList
{
    class Customer
    {
        private string _name;
        private string _email;
        private string _phoneNumber;
        private string _address;
        private string _blank;

        public Customer()
        {
            
        }

        public string Name { get => _name; set => _name = value; }
        public string Email { get => _email; set => _email = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string Address { get => _address; set => _address = value; }
        public string Blank { get => _blank; set => _blank = value; }
    }
}
