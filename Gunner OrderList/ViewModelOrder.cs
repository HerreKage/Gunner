using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunner_OrderList
{
    class ViewModelOrder : 
    {
        // Instance Field starts

        private Order _newOrder;

        // Instance Field Ends

        // Constructor starts
        public ViewModelOrder(Order o)
        {
            _newOrder= o;
        }

        // Constructor ends

        public string Description
        {
            get
            {
                return _newOrder.Description;_}
        }
    }
}
