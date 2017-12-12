using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Store.Preview.InstallControl;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Gunner_OrderList.Viewmodel;

namespace Gunner_OrderList
{
    class OrderVM : INotifyPropertyChanged
    {
        private OrderCatalog _orderCatalog;
        private ObservableCollection<Order> _displayedOrders;

        private Order _selectedOrder;
        private Customer _selectedOrderCustomer;

        private Order _newOrder;

        private OrderAddComand _addCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _editCommand;
        private RelayCommand _changeListCommand;
        private RelayCommand _moveListCommand;

        private bool _editMode = false;

        public OrderVM()
        {
            _orderCatalog = OrderCatalog.Instance;
            _displayedOrders = _orderCatalog.DummyInfo;   //For now just display dummyinfo       
            _newOrder = new Order();

            _deleteCommand = new RelayCommand(DoDeleteRelay, OrderIsSelected);
            _editCommand = new RelayCommand(DoEditRelay, OrderIsSelected);
            _changeListCommand = new RelayCommand(DoChangeListRelay, AlwaysTrue);
            _moveListCommand = new RelayCommand(DoMoveListRelay, OrderIsSelected);
        }

        #region Properties
        public ObservableCollection<Order> DisplayedOrders
        {
            get
            {
                _changeListCommand.RaiseCanExecuteChanged();
                return _displayedOrders;
            }
        }

        public Order NewOrder
        {
            get
            {
                if (_orderCatalog.EditOrder != null)
                {
                    _newOrder = _orderCatalog.EditOrder;
                    _editMode = true;
                    _orderCatalog.EditOrder = null;
                }
                
                return _newOrder;
            }
            set
            {
                _newOrder = value;
                OnPropertyChanged();
            }
        }

        public Boolean EditModeShow
        {
            get { return !_editMode; }
        }

        public Boolean EditModeHide
        {
            get { return _editMode; }
        }

        #region Selected
        public Order SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                if (_selectedOrder != null)
                {
                    _selectedOrderCustomer = _selectedOrder.Customer;
                }
                OnPropertyChanged("SelectedOrderCustomer");
                OnPropertyChanged();

                _deleteCommand.RaiseCanExecuteChanged();
                _editCommand.RaiseCanExecuteChanged();
                _moveListCommand.RaiseCanExecuteChanged();
            }
        }

        public Customer SelectedOrderCustomer
        {
            get
            {
                return _selectedOrderCustomer;
            }
            set
            {
                _selectedOrderCustomer = value;
                OnPropertyChanged();
            }
        }
        #endregion
        

        #endregion

        #region AddCommand
        public ICommand AddCommand
        {
            get
            {
                _addCommand = new OrderAddComand(_newOrder);
                return _addCommand;
            }
        }
        #endregion

        #region DeleteCommand

        public void DoDeleteRelay() // Added
        {
            Delete();
        }

        public bool OrderIsSelected() // Added
        {
            return SelectedOrder != null;
        }

        public ICommand DeleteCommand // Added
        {
            get { return _deleteCommand; }
        }

        public void Delete()
        {
            if (_displayedOrders.Contains(_selectedOrder))
            {
                _displayedOrders.Remove(_selectedOrder);
                _selectedOrder = null;
                _selectedOrderCustomer = null;
            }
        }
        #endregion

        #region EditCommand
        public void DoEditRelay() // Added
        {
            Edit();
        }

        public ICommand EditCommand // Added
        {
            get { return _editCommand; }
        }

        public void Edit()
        {
            _orderCatalog.EditOrder = _selectedOrder;
        }
        #endregion

        #region ChangeListCommand

        public void DoChangeListRelay() // Added
        {
            ChangeList();
        }

        public ICommand ChangeListCommand // Added
        {
            get { return _changeListCommand; }
        }

        public void ChangeList()
        {
            _displayedOrders = _orderCatalog.HistoryOrders;
            OnPropertyChanged("DisplayedOrders");
        }

        public bool AlwaysTrue()
        {
            return true;
        }

        #endregion

        #region MoveList

        public void DoMoveListRelay() // Added
        {
            MoveList();
        }

        public ICommand MoveListCommand // Added
        {
            get { return _moveListCommand; }
        }

        public void MoveList()
        {
            if (_displayedOrders.Contains(_selectedOrder))
            {
                _orderCatalog.HistoryOrders.Add(_selectedOrder);
                _displayedOrders.Remove(_selectedOrder);
                _selectedOrder = null;
                _selectedOrderCustomer = null;
            }
        }

        #endregion

        #region AutoFill

        //public void SortDisplayedList()
        //{
        //    ObservableCollection<Customer> _newDisplayedList = new ObservableCollection<Customer>();
        //    foreach (Customer customer in _customers)
        //    {
        //        string customerCompany = customer.Company.ToLower();
        //        string searchedCustomerList = _searchCustomer.ToLower();

        //        if (customerCompany.Substring(0, searchedCustomerList.Length) == searchedCustomerList)
        //        {
        //            _newDisplayedList.Add(customer);
        //        }
        //    }
        //    _displayedCustomerList = _newDisplayedList;
        //}


        //public void ChangeDisplayedList()   //Makes sure that the list displayed if correct
        //{
        //    SortDisplayedList();

        //    foreach (Customer customer in _displayedCustomerList)
        //    {
        //        _displayedCustomerListString.Add(customer.Company);
        //    }
        //}


        //public ObservableCollection<string> DisplayedCustomerList   //List that is used to display
        //{
        //    get
        //    {
        //        if (_displayedCustomerListString == null)
        //        {
        //            foreach (Customer customer in _customers)
        //            {
        //                _displayedCustomerListString = new ObservableCollection<string>();
        //                _displayedCustomerListString.Add(customer.Company);
        //            }
        //        }
        //        ChangeDisplayedList();
        //        return _displayedCustomerListString;
        //    }
        //    set
        //    {
        //        _displayedCustomerListString = value;
        //    }
        //}

        //public string SearchCustomer   //String the user types in
        //{
        //    get { return _searchCustomer; }
        //    set
        //    {
        //        _searchCustomer = value;

        //        ChangeDisplayedList();
        //        OnPropertyChanged("DisplayedCustomerList");
        //        OnPropertyChanged();
        //    }
        //}

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
