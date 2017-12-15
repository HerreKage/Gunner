using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Store.Preview.InstallControl;
using Gunner_OrderList.Annotations;
using Gunner_OrderList.Model;

namespace Gunner_OrderList.Viewmodel
{
    class WorkerVM : INotifyPropertyChanged
    {
        private WorkerCatalog _workerCatalog;   //Singleton
        private ObservableCollection<Worker> _workers;
        private RelayCommand _deleteCommand;
        private WorkerAddCommand _addCommand;

        private Worker _selectedWorker = new Worker();
        private Worker _newWorker;

        public WorkerVM()
        {
            _workerCatalog = WorkerCatalog.Instance;
            _workers = _workerCatalog.Workers;

            _deleteCommand = new RelayCommand(Delete,OrderIsSelected);

        }



        #region DeleteCommand
        public bool OrderIsSelected()
        {
            return SelectedWorker != null;
        }

        public ICommand DeleteCommand
        {
            get { return _deleteCommand; }
        }

        public void Delete()
        {
            if (_workers.Contains(_selectedWorker))
            {
                _workers.Remove(_selectedWorker);
                _selectedWorker = null;
            }
        }
        #endregion

        #region AddCommand

        public ICommand AddCommand
        {
            get
            {
                _addCommand = new WorkerAddCommand(_newWorker);
                return _addCommand;
            }
        }

        #endregion

        #region EditCommand
        //Needs to put in

        #endregion


        public Worker SelectedWorker
        {
            get { return _selectedWorker; }
            set { _selectedWorker = value; }
        }

        public ObservableCollection<Worker> Workers
        {
            get { return _workers; }
            set { _workers = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
