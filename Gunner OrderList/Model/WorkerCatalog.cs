using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunner_OrderList.Model
{
    class WorkerCatalog
    {
        private static WorkerCatalog instance = null;
        

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
        

    }
}
