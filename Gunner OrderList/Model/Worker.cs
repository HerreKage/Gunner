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
       


        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        public string Status { get => _status; set => _status = value; }

    }
}
