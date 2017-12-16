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
        private string _status = "Employee";
        private string _name;
        private string _address;
        private string _postNumber;
        private string _town;
        private string _phoneNumber;
        private string _email;
        private bool _ownerAccess;

        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        public string Status { get => _status; set => _status = value; }
        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public string PostNumber { get => _postNumber; set => _postNumber = value; }
        public string Town { get => _town; set => _town = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string Email { get => _email; set => _email = value; }
        public bool OwnerAccess { get => _ownerAccess; set => _ownerAccess = value; }
    }
}
