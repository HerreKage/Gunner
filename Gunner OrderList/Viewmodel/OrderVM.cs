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
        private ObservableCollection<Order> _displayedOrders2;

        private Order _selectedOrder1;
        private Order _selectedOrder2;
        private Order _selectedOrder;
        private Customer _selectedOrderCustomer;

        private Order _newOrder;

        private string _topText = "Til færdiggørelse:";
        private string _bottomText = "Til godkendelse:";

        private OrderAddComand _addCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _editCommand;
        private RelayCommand _changeListHistoryCommand;
        private RelayCommand _changeListCurrentCommand;


        private RelayCommand _moveOrderToHistoryCommand;
        private RelayCommand _moveOrderToCurrentCommand;
        private RelayCommand _moveOrderToUnapprovedCommand;
        private RelayCommand _moveOrderToInvoiceCommand;

        private bool _editMode = false;

        public OrderVM()
        {
            _newOrder = new Order();
            _orderCatalog = OrderCatalog.Instance;

            _displayedOrders = _orderCatalog.CurrentOrders;
            _displayedOrders2 = _orderCatalog.UnapprovedOrders;

            _deleteCommand = new RelayCommand(Delete, OrderIsSelected);
            _editCommand = new RelayCommand(Edit, OrderIsSelected);

            _changeListHistoryCommand = new RelayCommand(ChangeListHistory, AlwaysTrue);
            _changeListCurrentCommand = new RelayCommand(ChangeListCurrent, AlwaysTrue);

            _moveOrderToHistoryCommand = new RelayCommand(MoveOrderToHistory, AlwaysTrue);
            _moveOrderToCurrentCommand = new RelayCommand(MoveOrderToCurrent, AlwaysTrue);
            _moveOrderToUnapprovedCommand = new RelayCommand(MoveOrderToUnapproved, AlwaysTrue);
            _moveOrderToInvoiceCommand = new RelayCommand(MoveOrderToInvoice, AlwaysTrue);

        }

        #region Properties
        public ObservableCollection<Order> DisplayedOrders
        {
            get
            {   //Needs to be placed better
                _changeListHistoryCommand.RaiseCanExecuteChanged();
                _changeListCurrentCommand.RaiseCanExecuteChanged();
                return _displayedOrders;
            }
        }

        public ObservableCollection<Order> DisplayedOrders2
        {
            get
            {
                _changeListHistoryCommand.RaiseCanExecuteChanged();
                _changeListCurrentCommand.RaiseCanExecuteChanged();
                return _displayedOrders2;
            }
        }

        public Order NewOrder
        {
            get
            {
                _moveOrderToHistoryCommand.RaiseCanExecuteChanged();
                _moveOrderToCurrentCommand.RaiseCanExecuteChanged();
                _moveOrderToInvoiceCommand.RaiseCanExecuteChanged();
                _moveOrderToUnapprovedCommand.RaiseCanExecuteChanged();

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

        public string PriceString
        {
            get { return _newOrder.PriceString; }
            set
            {
                NewOrder.PriceString = value;
                OnPropertyChanged("TotalPrice");
                OnPropertyChanged();
            }
        }
        public string DptString
        {
            get { return _newOrder.DptString; }
            set
            {
                NewOrder.DptString = value;
                OnPropertyChanged("TotalPrice");
                OnPropertyChanged();
            }
        }
        public string FragtString
        {
            get { return _newOrder.FragtString; }
            set
            {
                NewOrder.FragtString = value;
                OnPropertyChanged("TotalPrice");
                OnPropertyChanged();
            }
        }
        public string TotalPrice
        {
            get { return _newOrder.TotalPrice; }
            set
            {
                NewOrder.TotalPrice = value;
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

        public string TopText
        {
            get { return _topText; }
            set { _topText = value; }
        }

        public string BottomText
        {
            get { return _bottomText; }
            set { _bottomText = value; }
        }

        #region Selected

        public Order SelectedOrder1
        {
            get { return _selectedOrder1; }
            set
            { 
                _selectedOrder1 = value;
                _selectedOrder2 = null;
                SelectedOrder = _selectedOrder1;
                OnPropertyChanged("SelectedOrder2");
            }
        }

        public Order SelectedOrder2
        {
            get { return _selectedOrder2; }
            set
            {
                _selectedOrder2 = value;
                _selectedOrder1 = null;
                SelectedOrder = _selectedOrder2;
                OnPropertyChanged("SelectedOrder1");
            }
        }

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
                else
                {
                    _selectedOrderCustomer = null;
                }
                
                OnPropertyChanged("SelectedOrderCustomer");
                OnPropertyChanged();

                _deleteCommand.RaiseCanExecuteChanged();
                _editCommand.RaiseCanExecuteChanged();
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
        public bool OrderIsSelected() 
        {
            return SelectedOrder != null;
        }

        public ICommand DeleteCommand 
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
                _orderCatalog.SaveAll();
            }
            if (_displayedOrders2.Contains(_selectedOrder))
            {
                _displayedOrders2.Remove(_selectedOrder);
                _selectedOrder = null;
                _selectedOrderCustomer = null;
                _orderCatalog.SaveAll();
            }
        }
        #endregion

        #region EditCommand
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

        public ICommand ChangeListCommandHistory 
        {
            get { return _changeListHistoryCommand; }
        }

        public void ChangeListHistory()
        {
            _displayedOrders = _orderCatalog.HistoryOrders;
            _displayedOrders2 = _orderCatalog.InvoiceOrders;

            _topText = "IN ORDERVM CHANGELISTCOMMAND";
            _bottomText = "SAME PLACE";

            OnPropertyChanged("DisplayedOrders");
            OnPropertyChanged("DisplayedOrders2");

            OnPropertyChanged("TopText");
            OnPropertyChanged("BottomText");
        }

        public bool AlwaysTrue()
        {
            return true;
        }

        public ICommand ChangeListCommandCurrent 
        {
            get { return _changeListCurrentCommand; }
        }

        public void ChangeListCurrent()
        {
            _displayedOrders = _orderCatalog.CurrentOrders;
            _displayedOrders2 = _orderCatalog.UnapprovedOrders;

            _topText = "Til færdiggørelse:";
            _bottomText = "Til godkendelse:";

            OnPropertyChanged("DisplayedOrders");
            OnPropertyChanged("DisplayedOrders2");

            OnPropertyChanged("TopText");
            OnPropertyChanged("BottomText");
        }

        #endregion

        #region MoveList

        public ICommand MoveOrderToHistoryCommand 
        {
            get { return _moveOrderToHistoryCommand; }
        }

        public void MoveOrderToHistory()
        {
            _orderCatalog.HistoryOrders.Add(_newOrder);
            _newOrder.CurrentList = "history";
            RemoveFromOrders("history");
        }

        public ICommand MoveOrderToCurrentCommand
        {
            get { return _moveOrderToCurrentCommand; }
        }

        public void MoveOrderToCurrent()
        {
            _orderCatalog.CurrentOrders.Add(_newOrder);
            _newOrder.CurrentList = "current";
            RemoveFromOrders("current");
        }

        public ICommand MoveOrderToUnapprovedCommand 
        {
            get { return _moveOrderToUnapprovedCommand; }
        }

        public void MoveOrderToUnapproved()
        {
            _orderCatalog.UnapprovedOrders.Add(_newOrder);
            _newOrder.CurrentList = "unapproved";
            RemoveFromOrders("unapproved");
        }

        public ICommand MoveOrderToInvoiceCommand
        {
            get { return _moveOrderToInvoiceCommand; }
        }

        public void MoveOrderToInvoice()
        {
            _orderCatalog.InvoiceOrders.Add(_newOrder);
            _newOrder.CurrentList = "invoice";
            RemoveFromOrders("invoice");
        }

        public void RemoveFromOrders(string current)
        {
            if (_orderCatalog.CurrentOrders.Contains(_newOrder) && current != "current")
            {
                _orderCatalog.CurrentOrders.Remove(_newOrder);
            }

            if (_orderCatalog.UnapprovedOrders.Contains(_newOrder) && current != "unapproved")
            {
                _orderCatalog.UnapprovedOrders.Remove(_newOrder);
            }

            if (_orderCatalog.HistoryOrders.Contains(_newOrder) && current != "history")
            {
                _orderCatalog.HistoryOrders.Remove(_newOrder);
            }

            if (_orderCatalog.InvoiceOrders.Contains(_newOrder) && current != "invoice")
            {
                _orderCatalog.InvoiceOrders.Remove(_newOrder);
            }
            _orderCatalog.SaveAll(); //SAVE
        }

        #endregion

        #region AutoFill - Not in use

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
