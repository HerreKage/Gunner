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
            LoadList();
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
                worker1.Name = "jan";
                worker1.Address = "sfdadsf 1";
                worker1.Lastname = "2300";
                worker1.Town = "fasfasd";
                worker1.PhoneNumber = "12345678";
                worker1.Email = "test@test.dk";

                Worker worker2 = new Worker();

            worker2.UserName = "Ejer";
            worker2.Password = "9876";
            worker2.Status = "Employee";
            worker2.Name = "fsda";
            worker2.Address = "sfda";
            worker2.LastName = "sfdaa";
            worker2.Town = "asdfsadfs";
            worker2.PhoneNumber = "asdfdf";
            worker2.Email = "afdsfdafsa";

                _workers.Add(worker1);
                _workers.Add(worker2);
            }
        }

        public void Save()
        {
            allWorker.Save(_workers.ToList());
        }
        #endregion

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

        public ObservableCollection<Worker> GetWorkerCatalog()
        {
            return _workers;
        }

        public string CheckLogin(string Username, string Password)

        {
            string returnstring = "Unknown";

            foreach (var worker in _workers)
            {
                if (worker.UserName == Username && worker.Password == Password)
                {
                    returnstring = worker.Status;
                }
            }

            return returnstring;

        }

        public ObservableCollection<Worker> Workers
        {
            get
            { return _workers; }
            set { _workers = value; }
        }

    }
}