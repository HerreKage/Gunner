using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gunner_OrderList.Viewmodel
{
    class ChangeCommand: OrderVM, ICommand
    {

        private Order _order;
        private OrderVM _orderCatalog;


        public ChangeCommand(Order Order, OrderVM catalog)

        {
            _order = Order;
            _orderCatalog = catalog;
        }


        public bool CanExecute(object parameter)
        {
            return _orderCatalog.SelectedOrder !=null;
            
        }

        public void Execute(object parameter)
        {
            _orderCatalog.Edit();
           
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}
