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
        private ObservableCollection<string> _displayedCustomerList = new ObservableCollection<string>();
        private string _searchCustomerList;
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
        }

        public ObservableCollection<Order> DisplayedOrders
        {
            get
            {
                foreach (Customer customer in _customers)
                {
                    
                }
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

        public void SortDisplayedList()
        {
            ObservableCollection<Customer> _newDisplayedList = new ObservableCollection<Customer>();
            foreach (Customer customer in _customers)
            {
                string customerCompany = customer.Company.ToLower();
                string searchedCustomerList = _searchCustomerList.ToLower();

                if (  customerCompany.Substring(0, searchedCustomerList.Length) == searchedCustomerList )
                {
                    _newDisplayedList.Add(customer);
                }
            }
            //_displayedCustomerList = _newDisplayedList;
        }


        public void ChangeDisplayedList()   //Makes sure that the list displayed if correct
        {
            //if (_searchCustomerList != null)
            //{
            //    _displayedCustomerList = _customers;
            //}
            //else
            //_displayedCustomerList = null;

            //SortDisplayedList();

            foreach (Customer customer in _customers)
            {
                _displayedCustomerList.Add(customer.Company);
            }
        }

        public ObservableCollection<string> DisplayedCustomerList   //List that is used to display
        {
            get
            {
                ChangeDisplayedList();
                return _displayedCustomerList;
            }
            set
            {
                _displayedCustomerList = value;
            }
        }

        public string SearchCustomerList   //String the user types in
        {
            get { return _searchCustomerList; }
            set
            {
                _searchCustomerList = value;
                ChangeDisplayedList();
                OnPropertyChanged("DisplayedCustomerList");
                OnPropertyChanged();
            }
        }

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
