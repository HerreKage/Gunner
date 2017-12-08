using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunner_OrderList.Model
{
    class WorkerPassWord
    {
        private Worker _worker = new Worker();

        private string _password;

        public WorkerPassWord()
        {
        }

        public WorkerPassWord PassWord { set => _password = value; }

        public static implicit operator string(WorkerPassWord v)
        {
            throw new NotImplementedException();
        }
    }
}
