using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunner_OrderList.Model
{
    public class Worker
    {
        private ObservableCollection<WorkerCatalog> _workcatalog;

        private string _userName;
        private string _password;
        private string _status;
        private string _name;
        private string _lastName;
        private string _address;
        private string _lastname;
        private string _town;
        private string _phoneNumber;
        private string _email;
        private bool _owner;

        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        public string Status { get => _status; set => _status = value; }
        public string Name { get => _name; set => _name = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Address { get => _address; set => _address = value; }
        public string Town { get => _town; set => _town = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string Email { get => _email; set => _email = value; }
        public bool Owner { get => _owner; set => _owner = value; }
    }
}