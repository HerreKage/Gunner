using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunner_OrderList
{
    class AddComand
    {
        private List<OrderCatalog> _orderCatalogs;
        public void AddOrder(OrderCatalog newOrder)
        {
            _orderCatalogs.Add(newOrder);


        }
    }
}
