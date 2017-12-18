﻿using System;
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
        private ObservableCollection<Worker> _displayWorkers;
        private RelayCommand _deleteCommand;
        private RelayCommand _addCommand;
        //private WorkerEditCommand _workerEditCommand;
        private Worker _selectedWorker = new Worker();
        private Worker _newWorker;

        public WorkerVM()
        {
            _workerCatalog = WorkerCatalog.Instance;
            _workers = _workerCatalog.Workers;
            _displayWorkers = _workerCatalog.Workers;
            _deleteCommand = new RelayCommand(Delete, OrderIsSelected);
            //_workerEditCommand = new WorkerEditCommand(this, _workerCatalog);
        }
        public ObservableCollection<Worker> DisplayWorkers
        {
            get
            {
                ObservableCollection<Worker> newList = new ObservableCollection<Worker>();
                foreach (var c in _workerCatalog.Workers)
                {
                    newList.Add(c);
                }
                return newList;

            }
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
                //_addCommand = new WorkerAddCommand(_newWorker);

                return _addCommand;
            }
        }

        #endregion

        #region EditCommand
        //Needs to put in

        //public ICommand EditWorkerCommand
        //{
            //get { return _workerEditCommand; }
        //}

        public void Refresh()
        {
            OnPropertyChanged(nameof(DisplayWorkers));
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostNumber { get; set; }
        public string Town { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        //public bool Owner { get => _owner; set => _owner = value; }
        #endregion




        public Worker SelectedWorker
        {
            get { return _selectedWorker; }
            set
            {
                _selectedWorker = value;


                if (_selectedWorker != null)
                {
                    UserName = _selectedWorker.UserName;
                    Name = _selectedWorker.Name;
                    LastName = _selectedWorker.LastName;
                    Address = _selectedWorker.Address;
                    //PostNumber = _selectedWorker.PostNumber;
                    Town = _selectedWorker.Town;
                    PhoneNumber = _selectedWorker.PhoneNumber;
                    Email = _selectedWorker.Email;
                    Password = _selectedWorker.Password;
                    //         Status = _selectedWorker.Status;

                    // Owner = _selectedWorker.Owner;

                    OnPropertyChanged(nameof(UserName));
                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(LastName));
                    OnPropertyChanged(nameof(Address));
                    OnPropertyChanged(nameof(PostNumber));
                    OnPropertyChanged(nameof(Town));
                    OnPropertyChanged(nameof(PhoneNumber));
                    OnPropertyChanged(nameof(Email));
                    OnPropertyChanged(nameof(Password));
                    //OnPropertyChanged(nameof(Owner));
                    //OnPropertyChanged(nameof(Status));
                }
                _deleteCommand.RaiseCanExecuteChanged();
                //_workerEditCommand.RaiseCanExecuteChanged();
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}