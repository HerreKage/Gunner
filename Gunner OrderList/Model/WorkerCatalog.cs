using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gunner_OrderList.Model
{
    class WorkerCatalog
    {
        private static WorkerCatalog instance = null;
        private ICommand _workerCatalog;

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

        public ICommand GetWorkerCatalog()
        {
            return _workerCatalog;
        }
    }
}
