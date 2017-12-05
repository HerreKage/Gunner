using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gunner_OrderList
{
    class AddComand : ICommand
    {
        private List<Order> _order;

        public event EventHandler CanExecuteChanged;

        public void AddOrder(Order newOrder)
        {
            _order.Add(newOrder);


        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
            
        }

        public void Execute(object parameter)
        {
            //AddOrder();
        }
    }
}
