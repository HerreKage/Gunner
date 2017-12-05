using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Gunner_OrderList.Viewmodel;

namespace Gunner_OrderList
{
    class CustomerCatalog
    {
        ObservableCollection<Customer> _customers;  //List of customers
        private Customer _selectedCustomer = new Customer();

        private static CustomerCatalog instance=null;
        private CustomerCatalog _catalog;
        private DeleteCommand _deletecommand;
        

        private CustomerCatalog()
        {
            _customers = new ObservableCollection<Customer>();
            _catalog=new CustomerCatalog();
            _deletecommand= new DeleteCommand(_catalog, this );
        }

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

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value; }
        }




        public ICommand DeletionCommand
        {
            get { return _deletecommand; }
        }


        public void delete()
        {
            _customers.Remove(_selectedCustomer);
        }


    }
}
