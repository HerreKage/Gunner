using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Gunner_OrderList.Viewmodel;
using FilePersistency.Implementation;
using Persistency.Interfaces;

namespace Gunner_OrderList.Model
{
    class WorkerCatalog
    {
        private static WorkerCatalog instance = null;
        private ObservableCollection<Worker> _workers;

        private FileSource<Worker> allWorker;
        private WorkerCatalog()
        {
            _workers = new ObservableCollection<Worker>();


            allWorker = new FileSource<Worker>(new FileStringPersistence(), new JSONConverter<Worker>(), "allWorker.json");
            //List<Worker> ll = new List<Worker>();  //(for if workers gets messed up)
            //allWorker.Save(ll);
            LoadList();

            Worker worker1 = new Worker();
        }

        #region Load/Save
        private async void LoadList()
        {
            List<Worker> ll = await allWorker.Load();
            ConvertListToObs(ll);
        }

        public void ConvertListToObs(List<Worker> list)
        {
            if (list.Count != 0)
            {
                foreach (Worker worker in list)
                {
                    _workers.Add(worker);
                }
            }
            else
            {
                Worker worker1 = new Worker();

                worker1.UserName = "Jan";
                worker1.Password = "1234";
                worker1.Status = "Owner";
                worker1.Name = "Built in";
                worker1.LastName = "Owner";

                Worker worker2 = new Worker();

                worker2.UserName = "Ejer";
                worker2.Password = "9876";
                worker2.Status = "Employee";
                worker2.Name = "Built in";
                worker2.LastName = "Employee";

                _workers.Add(worker1);
                _workers.Add(worker2);
            }
        }

        public void Save()
        {
            allWorker.Save(_workers.ToList());
        }
        #endregion

        #region Singleton
        public static WorkerCatalog Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WorkerCatalog();
                }
                return instance;
            }
        }
        #endregion

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

        public ObservableCollection<Worker> Workers
        {
            get
            {return _workers; }
            set { _workers = value; }
        }

    }
}
