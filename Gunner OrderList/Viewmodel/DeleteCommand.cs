using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Gunner_OrderList.Viewmodel
{
    class DeleteCommand :ICommand
    {
        private Catalog _catalog;

        private Customer _customer;



        public DeleteCommand(Catalog catalog, Customer customer);


        {
            _catalog = catalog;
            _customer = customer;
        }







    public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;
    }
}
