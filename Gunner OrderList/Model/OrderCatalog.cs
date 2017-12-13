using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.ViewManagement;
using FilePersistency.Implementation;
using Persistency.Interfaces;

namespace Gunner_OrderList
{
    class OrderCatalog
    {
        private static OrderCatalog _instance = null;

        private ObservableCollection<Order> _currentOrders;
        private ObservableCollection<Order> _unapprovedOrders;
        private ObservableCollection<Order> _historyOrders;
        private ObservableCollection<Order> _invoiceOrders;

        private ObservableCollection<Order> _dummyInfo;  //Testing info

        private static int _orderNumber = 0; 

        private Order _editOrder;


        private FileSource<Order> allOrder;


        private OrderCatalog()
        {
            _currentOrders = new ObservableCollection<Order>();
            _unapprovedOrders = new ObservableCollection<Order>();
            _invoiceOrders = new ObservableCollection<Order>();
            _historyOrders = new ObservableCollection<Order>();

            DummyOrder _dummyOrders = new DummyOrder();  //Testing Info
            _dummyInfo = _dummyOrders.DummyInfo;         //Testing Info

            allOrder = new FileSource<Order>(new FileStringPersistence(), new JSONConverter<Order>(), "allOrder.json");

            ConvertListToObs(allOrder.Load().Result);
        }

        public void SaveAll()
        {
            List<Order> allOrders = new List<Order>();

            foreach (Order order in _currentOrders)
            {
                allOrders.Add(order);
            }
            foreach (Order order in _unapprovedOrders)
            {
                allOrders.Add(order);
            }
            foreach (Order order in _historyOrders)
            {
                allOrders.Add(order);
            }
            foreach (Order order in _invoiceOrders)
            {
                allOrders.Add(order);
            }

            allOrder.Save( allOrders );
        }

        public void ConvertListToObs(List<Order> list)
        {
            if (list != null)
            {
                foreach (Order order in list)
                {
                    if (order.CurrentList == "current")
                    {
                        _currentOrders.Add(order);

                    }
                    if (order.CurrentList == "unapproved")
                    {
                        _unapprovedOrders.Add(order);
                    }
                    if (order.CurrentList == "history")
                    {
                        _historyOrders.Add(order);
                    }
                    if (order.CurrentList == "invoice")
                    {
                        _invoiceOrders.Add(order);
                    }
                    if (order.OrderNumber > _orderNumber)
                    {
                        _orderNumber = order.OrderNumber;
                    }
                }
            }
        }

        #region Singlton
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
        #endregion

        #region ObservableCollections
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

        public ObservableCollection<Order> DummyInfo
        {
            get { return _dummyInfo; }
            set { _dummyInfo = value; }
        }
        #endregion

        #region OrderNumber
        public int OrderNumber
        {
            get
            {
                ++_orderNumber;
                return _orderNumber;
            }
        }
        #endregion


        internal Order EditOrder { get => _editOrder; set => _editOrder = value; }
    }
}
