using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;

namespace Gunner_OrderList
{
    class OrderCatalog
    {

        private ObservableCollection<Order> _currentOrders;
        private ObservableCollection<Order> _unapprovedOrders;
        private ObservableCollection<Order> _historyOrders;
        private ObservableCollection<Order> _invoiceOrders;

        private static OrderCatalog _instance = null;

        private OrderCatalog()
        {
            _currentOrders = new ObservableCollection<Order>();
            _unapprovedOrders = new ObservableCollection<Order>();
            _historyOrders = new ObservableCollection<Order>();
            _invoiceOrders = new ObservableCollection<Order>();
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
    }
}
