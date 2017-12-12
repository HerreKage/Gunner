using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gunner_OrderList
{
    class OrderAddComand : ICommand
    {
        private ObservableCollection<Order> _unapprovedOrders;
        private OrderCatalog _orders;
        private Order _order;

        private ObservableCollection<Customer> _customers;

        public OrderAddComand(Order order)
        {
            _order = order;
            _orders = OrderCatalog.Instance;
            _unapprovedOrders = _orders.DummyInfo;             //Currently set to dummy info

            CustomerCatalog customers = CustomerCatalog.Instance;
            _customers = customers.Customers;
        }

        public bool CanExecute(object parameter)
        {
            return _order != null; //should check if minimum information is added
        }

        public void Execute(object parameter)
        {
            _unapprovedOrders.Add(_order);
            _order.OrderNumber = _orders.OrderNumber;   //Order number is only assigned once order added

            _customers.Add(_order.Customer);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }

}
