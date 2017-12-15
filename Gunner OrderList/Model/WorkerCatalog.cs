using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Gunner_OrderList.Viewmodel;

namespace Gunner_OrderList.Model
{
    class WorkerCatalog
    {
        private static WorkerCatalog instance = null;
        private ObservableCollection<Worker> _workers;
       

        private WorkerCatalog()
        {
            _workers = new ObservableCollection<Worker>();


            Worker worker1=new Worker();

            worker1.UserName = "Jan";
            worker1.Password = "1234";
            worker1.Status = "Owner";

            Worker worker2 = new Worker();

            worker2.UserName = "Ejer";
            worker2.Password = "9876";
            worker2.Status = "Employee";


            _workers.Add(worker1);
            _workers.Add(worker2);

        }

        public static WorkerCatalog Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new WorkerCatalog();
                }
                return instance;
            }
        }

        public ObservableCollection<Worker> GetWorkerCatalog()
        {
            return _workers;
        }

        public string CheckLogin(string Username, string Password)

        {
            string returnstring = "Unknown";

            foreach (var worker in _workers)
            {
                if (worker.UserName==Username && worker.Password==Password)
                {
                    returnstring = worker.Status;
                }
            }

            return returnstring;

        }

    }
}
