using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunner_OrderList.Model
{
    class Worker
    {
        private string _userName;
        private string _name;
        private string _address;
        private string _zipCode;
        private string _town;
        private string _phoneNumber;
        private string _eMail;

        public Worker()
            {
            }

        public string UserName { get => _userName; set => _userName = value; }
        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public string ZipCode { get => _zipCode; set => _zipCode = value; }
        public string Town { get => _town; set => _town = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string EMail { get => _eMail; set => _eMail = value; }
    }
}
