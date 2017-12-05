using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.ViewManagement;

namespace Gunner_OrderList
{
    class OrderCatalog
    {
        private static OrderCatalog _instance = null;
        private ObservableCollection<Order> _selectedOrder;
        private ObservableCollection<Order> _currentOrders;
        private ObservableCollection<Order> _unapprovedOrders;
        private ObservableCollection<Order> _historyOrders;
        private ObservableCollection<Order> _invoiceOrders;
        private List<Order> _order;

        private ObservableCollection<Order> _dummyInfo;  //Testing info
        private static int _orderNumber;  //This will be the ordernumber that is assigned to each order when added (will be updated)
        private OrderCatalog()
        {
            _currentOrders = new ObservableCollection<Order>();  //Load in from stored data later
            _unapprovedOrders = new ObservableCollection<Order>();
            _historyOrders = new ObservableCollection<Order>();
            _invoiceOrders = new ObservableCollection<Order>();
            
            DummyOrder _dummyOrders = new DummyOrder();  //Testing Info
            DummyInfo = _dummyOrders.DummyInfo;         //Testing Info
            _orderNumber = 2; //This number needs to be stored
        }
        public void AddOrder(Order newOrder)
        {
            _order.Add(newOrder);

        }
        public static OrderCatalog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OrderCatalog();
                }
                return _instance;
            }
        }

        public ObservableCollection<Order> CurrentOrders
        { 
            get { return _currentOrders; }
            set { _currentOrders = value; }
        }

        public ObservableCollection<Order> UnapprovedOrders
        {
            get { return _unapprovedOrders; }
            set { _unapprovedOrders = value; }
        }

        public ObservableCollection<Order> HistoryOrders
        {
            get { return _historyOrders; }
            set { _historyOrders = value; }
        }

        public ObservableCollection<Order> InvoiceOrders
        {
            get { return _invoiceOrders; }
            set { _invoiceOrders = value; }
        }

        internal ObservableCollection<Order> DummyInfo { get => _dummyInfo; set => _dummyInfo = value; } //Testing Info
    }
}
