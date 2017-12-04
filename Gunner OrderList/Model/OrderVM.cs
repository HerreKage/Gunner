using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store.Preview.InstallControl;
using Windows.UI.Xaml;

namespace Gunner_OrderList
{
    class OrderVM : INotifyPropertyChanged
    {
        private Order _selectedOrder;
        private OrderCatalog _orderCatalog;

        private ObservableCollection<Order> _displayedOrders;

        public OrderVM()
        {
            _orderCatalog = OrderCatalog.Instance;

        
            _displayedOrders = _orderCatalog.DummyInfo;
        }

        public ObservableCollection<Order> DisplayedOrders
        {
            get { return _displayedOrders; }
        }
        
        #region Customer
        public string Name
        {
            get { return _selectedOrder.Customer.Name; }
        }
        public string Email
        {
            get { return _selectedOrder.Customer.Email; }
        }
        public string PhoneNumber
        {
            get { return _selectedOrder.Customer.PhoneNumber; }
        }
        public string Address
        {
            get { return _selectedOrder.Customer.Address; }
        }
        public string CompanyNumber
        {
            get { return _selectedOrder.Customer.CompanyNumber; }
        }
        #endregion

        #region Order

        public string Product
        {
            get { return _selectedOrder.Product; }
        }

        public string Deadline
        {
            get { return _selectedOrder.Deadline; }
        }

        public string Description
        {
            get { return _selectedOrder.Description; }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
