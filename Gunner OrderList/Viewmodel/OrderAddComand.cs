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
        Order _order;

        public OrderAddComand(Order order)
        {
            _order = order;
            OrderCatalog _orders = OrderCatalog.Instance;
            _unapprovedOrders = _orders.DummyInfo;             //Currently set to dummy info
        }


        public bool CanExecute(object parameter)
        {
            return _order != null; //should check if minimum information is added
        }

        public void Execute(object parameter)
        {
            _unapprovedOrders.Add(_order);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }

}
