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

        private Order _selectedOrder = null;
        private Customer _selectedOrderCustomer = null;

        private Order _newOrder = new Order();
        private AddComand _addCommand;

        public OrderVM()
        {
            _orderCatalog = OrderCatalog.Instance;
            _displayedOrders = _orderCatalog.DummyInfo;   //For now just display dummyinfo           
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
                _selectedOrderCustomer = _selectedOrder.Customer;
                OnPropertyChanged("SelectedOrderCustomer");
                OnPropertyChanged();
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


        public ICommand AddCommand
        {
            get
            {
                _addCommand = new AddComand(_newOrder);
                return _addCommand;
            }
        }



    public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
