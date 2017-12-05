namespace Gunner_OrderList.Viewmodel
{
    class ChangeCommand
    {
        private Customer _customer;

        private Order _order;

        public ChangeCommand(Customer customer, Order order)
            {
            _customer = customer;
            _order = order;
            }

        public bool CanExecute
        {
        get = c
        }
    }

}
