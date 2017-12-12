using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunner_OrderList
{
    class Customer
    {
        private string _company;
        private string _name;
        private string _email;
        private string _phoneNumber;
        private string _address;
        private string _companyNumber;
        private string _zipCode;
        private string _town;

        public Customer()
        {    
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Email { get => _email; set => _email = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string Address { get => _address; set => _address = value; }
        public string CompanyNumber { get => _companyNumber; set => _companyNumber = value; }
        public string Company { get => _company; set => _company = value; }
        public string ZipCode { get => _zipCode; set => _zipCode = value; }
        public string Town { get => _town; set => _town = value; }
    }
}
