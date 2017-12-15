using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Gunner_OrderList.Model;

namespace Gunner_OrderList.Viewmodel
{
    class WorkerAddCommand : ICommand
    {
        private ObservableCollection<Worker> _workersObs;
        private WorkerCatalog _workers;
        private Worker _worker;

        public WorkerAddCommand(Worker worker)
        {
            _worker = worker;
            _workers = WorkerCatalog.Instance;
            _workersObs = _workers.Workers;
        }

        public bool CanExecute(object parameter)
        {
            return _worker != null;
        }

        public void Execute(object parameter)
        {
            _workersObs.Add(_worker);


            _workers.Save(); //SAVE
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }

}
