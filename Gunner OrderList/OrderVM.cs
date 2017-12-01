using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gunner_OrderList
{
    class OrderVM : INotifyPropertyChanged
    {
        // Instance Field starts
        private Order _newOrder;
        private Customer _newcustomer;

        private OrderCatalog _orderCatalog;
        // Instance Field Ends

        // Constructor starts
        public OrderVM()
        {
            _newcustomer = new Customer();
            _newOrder = new Order();

            _orderCatalog = OrderCatalog.Instance;
        }
        // Constructor ends

        // Properties for Data Binding start
        #region ObservableCollections
        public ObservableCollection<Order> CurrentOrders
        {
            get { return _orderCatalog.CurrentOrders; }
        }
        public ObservableCollection<Order> HistoryOrders
        {
            get { return _orderCatalog.HistoryOrders; }
        }
        public ObservableCollection<Order> UnapprovedOrders
        {
            get { return _orderCatalog.UnapprovedOrders; }
        }
        public ObservableCollection<Order> InvoiOrders
        {
            get { return _orderCatalog.InvoiceOrders; }
        }
        #endregion 

        #region Customer
        public string Name
        {
            get { return _newcustomer.Name; }
        }
        public string Email
        {
            get { return _newcustomer.Email; }
        }
        public string PhoneNumber
        {
            get { return _newcustomer.PhoneNumber; }
        }
        public string Address
        {
            get { return _newcustomer.Address; }
        }
        public string CompanyNumber
        {
            get { return _newcustomer.CompanyNumber; }
        }
        #endregion

        #region Order
        public string Description
        {
            get { return _newOrder.Description; }
        }
        #endregion

        // Properties for Data Binding ends



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
