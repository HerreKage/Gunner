using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.ViewManagement;
using FilePersistency.Implementation;
using Persistency.Interfaces;

namespace Gunner_OrderList
{
    class CustomerCatalog
    {
        private static CustomerCatalog instance = null;

        private ObservableCollection<Customer> _customers;
        private FileSource<Customer> allCustomer;

        private CustomerCatalog()
        {
            _customers = new ObservableCollection<Customer>();
            allCustomer = new FileSource<Customer>(new FileStringPersistence(), new JSONConverter<Customer>(), "Customer.json");
            LoadList();
        }

        private async void LoadList()
        {
            List<Customer> ll = await allCustomer.Load();
            ConvertListToObs(ll);
        }

        public void ConvertListToObs( List<Customer> list )
        {
            if (list != null)
            {
                foreach (Customer customer in list)
                {
                    _customers.Add(customer);
                }
            }
        }


        public void SaveCustomer()
        {
            allCustomer.Save( _customers.ToList() );
        }

        #region Singleton
        public static CustomerCatalog Instance
        { 
            get
            {
                if (instance == null)
                {
                    instance = new CustomerCatalog();
                }
                return instance;
            }
        }
        #endregion


        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value; }

        }

        public void Delete (Customer customer)
        {
            if (_customers.Contains(customer))
            {
                _customers.Remove(customer);
            }
        }
    }
}
