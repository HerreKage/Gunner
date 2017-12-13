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

        private static int _orderNumber;  //This will be the ordernumber that is assigned to each order when added (will be updated)

        private Order _editOrder;


        private FileSource<Order> historyOrder;
        //private FileSource<Order> unapprovedOrder;
        //private FileSource<Order> currentOrder;
        //private FileSource<Order> invoiceOrder;

        private OrderCatalog()
        {
            _orderNumber = 5;           //This needs to load from stored data later

            _currentOrders = new ObservableCollection<Order>();  //Load in from stored data later
            _unapprovedOrders = new ObservableCollection<Order>();
            _invoiceOrders = new ObservableCollection<Order>();
            _historyOrders = new ObservableCollection<Order>();


            DummyOrder _dummyOrders = new DummyOrder();  //Testing Info
            _dummyInfo = _dummyOrders.DummyInfo;         //Testing Info

            FileSource<Order> currentOrder = new FileSource<Order>(new FileStringPersistence(), new JSONConverter<Order>(), "Current.json");
            FileSource<Order> unapprovedOrder = new FileSource<Order>(new FileStringPersistence(), new JSONConverter<Order>(), "Unapproved.json");
            historyOrder = new FileSource<Order>(new FileStringPersistence(), new JSONConverter<Order>(), "History.json");
            FileSource<Order> invoiceOrder = new FileSource<Order>(new FileStringPersistence(), new JSONConverter<Order>(), "Invoice.json");

            ConvertListToObs(historyOrder.Load().Result, _historyOrders);
            //ConvertListToObs(unapprovedOrder.Load().Result, _unapprovedOrders);
            //ConvertListToObs(invoiceOrder.Load().Result, _invoiceOrders);
            //ConvertListToObs(currentOrder.Load().Result, _currentOrders);

        }

        public void SaveAll()
        {
            historyOrder.Save(_historyOrders.ToList());
            //unapprovedOrder.Save(_unapprovedOrders.ToList());
            //currentOrder.Save(_currentOrders.ToList());
            //invoiceOrder.Save(_invoiceOrders.ToList());
        }


        public void ConvertListToObs(List<Order> list, ObservableCollection<Order> obs)
        {
            if (list == null || list == new List<Order>())
            {
                obs = new ObservableCollection<Order>();
            }
            else
            {
                foreach (Order order in list)
                {
                    obs.Add(order);
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
                return _orderNumber;
                _orderNumber++;
            }
        }
        #endregion


        internal Order EditOrder { get => _editOrder; set => _editOrder = value; }
    }
}
