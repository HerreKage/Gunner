using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Gunner_OrderList.Model;

namespace Gunner_OrderList.Viewmodel
{
    class WorkerEditCommand : ICommand
    {
        private WorkerCatalog _workerCatalog;

        private Worker _worker;
        private WorkerVM _workerVM;
        private WorkerVM workerVM;
        private WorkerEditCommand _workereditCommand;

        public WorkerEditCommand(WorkerVM Worker, WorkerCatalog workerCatalog)
        {
            _workerCatalog = workerCatalog;
            _workerVM = Worker;

        }

        public WorkerEditCommand(WorkerVM workerVM, WorkerEditCommand workerEditCommand)
        {
            this.workerVM = workerVM;
            _workereditCommand = workerEditCommand;

        }

        public bool CanExecute(object parameter)
        {
            return _workerVM.SelectedWorker != null;
        }

        public void Execute(object parameter)
        {
            _workerVM.SelectedWorker.UserName = _workerVM.UserName;
            _workerVM.SelectedWorker.Name = _workerVM.Name;
            _workerVM.SelectedWorker.LastName = _workerVM.LastName;
            _workerVM.SelectedWorker.Address = _workerVM.Address;
            _workerVM.SelectedWorker.Town = _workerVM.Town;
            _workerVM.SelectedWorker.PhoneNumber = _workerVM.PhoneNumber;
            _workerVM.SelectedWorker.Email = _workerVM.Email;
            _workerVM.SelectedWorker.Password = _workerVM.Password;
            _workerVM.SelectedWorker.Owner = _workerVM.Owner;

            // _catalog.EditCustomer(_customerVM.SelectedCustomer);
            _workerVM.Refresh();

            _workerCatalog.Save();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}