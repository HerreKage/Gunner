using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Gunner_OrderList
{
    public class CustomerCatalog
    {
        ObservableCollection<Customer> _customers;

        private static CustomerCatalog instance=null;

        private CustomerCatalog() { _customers= new ObservableCollection<Customer> }

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



    }
}
