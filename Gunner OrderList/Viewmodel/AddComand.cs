using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gunner_OrderList
{
    class AddComand : ICommand
    {
        private ObservableCollection<Order> _unapprovedOrders;
        Order _order;

        public AddComand(Order order)
        {
            _order = order;
            OrderCatalog _orders = OrderCatalog.Instance;
            _unapprovedOrders = _orders.DummyInfo;             //Currently set to dummy info
        }


        public bool CanExecute(object parameter)
        {
            return _order != null; //??Need to change equal function for orders  ??
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
