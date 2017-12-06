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

        private Order _newOrder = new Order();
        private OrderAddComand _addCommand;
        private OrderDeleteCommand _deleteCommand;

        public OrderVM()
        {
            _orderCatalog = OrderCatalog.Instance;
            _displayedOrders = _orderCatalog.DummyInfo;   //For now just display dummyinfo       

            _deleteCommand = new OrderDeleteCommand(DoDeleteRelay, OrderIsSelected);
        }

        public ObservableCollection<Order> DisplayedOrders
        {
            get { return _displayedOrders; }
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
