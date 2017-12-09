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
        private OrderDeleteCommand _deleteCommand;
        private OrderEditCommand _editCommand;

        private CustomerCatalog customerCatalog;
        private ObservableCollection<Customer> _customers;
        private ObservableCollection<Customer> _displayedCustomerList;

        private ObservableCollection<string> _displayedCustomerListString;
        private string _searchCustomer;
        private Customer _selectedCustomer;

        public OrderVM()
        {
            _orderCatalog = OrderCatalog.Instance;
            _displayedOrders = _orderCatalog.DummyInfo;   //For now just display dummyinfo       
            _newOrder = new Order();

            _deleteCommand = new OrderDeleteCommand(DoDeleteRelay, OrderIsSelected);
            _editCommand = new OrderEditCommand(DoEditRelay, OrderIsSelected);

            customerCatalog = CustomerCatalog.Instance;
            _customers = customerCatalog.Customers;
            _displayedCustomerList = _customers;
        }

        public ObservableCollection<Order> DisplayedOrders
        {
            get
            {
                return _displayedOrders;
            }
        }

        public Order NewOrder
        {
            get { return _newOrder; }
            set
            {
                _newOrder = value;
                OnPropertyChanged();
            }
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
            NewOrder = _selectedOrder;
            OnPropertyChanged("NewOrder");
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
