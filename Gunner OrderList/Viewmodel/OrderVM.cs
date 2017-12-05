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
        private OrderCatalog _orderCatalog;
        private ObservableCollection<Order> _displayedOrders;
        private Order _selectedOrder = null;
        private Customer _selectedOrderCustomer = null;
        private AddComand _addComand;

        public OrderVM()
        {
            _orderCatalog = OrderCatalog.Instance;
            _displayedOrders = _orderCatalog.DummyInfo;  //For now just display dummyinfo
         
            _addComand = new AddComand();
        }

        public ObservableCollection<Order> DisplayedOrders
        {
            get { return _displayedOrders; }
        }



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

        #region Order
        //public string Product
        //{
        //    get { return _selectedOrder.Product; }
        //    set { _selectedOrder.Product = value; }
        //}

        //public string Deadline
        //{
        //    get { return _selectedOrder.Deadline; }
        //    set { _selectedOrder.Deadline = value; }
        //}

        //public string Description
        //{
        //    get { return _selectedOrder.Description; }
        //    set { _selectedOrder.Description = value; }
        //}

        //public string Price
        //{
        //    get { return _selectedOrder.Price; }
        //    set { _selectedOrder.Price = value; }
        //}

        //public int OrderNumber
        //{
        //    get { return _selectedOrder.OrderNumber; }
        //}
    #endregion

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
        #region Customer
        //public string Name
        //{
        //    get { return _selectedOrder.Customer.Name; }
        //}
        //public string Email
        //{
        //    get { return _selectedOrder.Customer.Email; }
        //}
        //public string PhoneNumber
        //{
        //    get { return _selectedOrder.Customer.PhoneNumber; }
        //}
        //public string Address
        //{
        //    get { return _selectedOrder.Customer.Address; }
        //}
        //public string CompanyNumber
        //{
        //    get { return _selectedOrder.Customer.CompanyNumber; }
        //}
        #endregion


    public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
