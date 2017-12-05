using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gunner_OrderList
{
    class ViewModelOrder : INotifyPropertyChanged
    {
        // Instance Field starts

        private Order _newOrder;
        private Customer _newcustomer;

        // Instance Field Ends

        // Constructor starts
        public ViewModelOrder(Customer c, Order o)
        {
            _newcustomer = c;
            _newOrder= o;
        }

        // Constructor ends

        // Properties for Data Binding start
        public string Name
        {
            get { return _newcustomer.Name; }
        }
        public string Email
        {
            get { return _newcustomer.Email; }
        }
        public string PhoneNumber
        {
            get { return _newcustomer.PhoneNumber; }
        }
        public string Address
        {
            get { return _newcustomer.Address; }
        }
        public string CompanyNumber
        {
            get { return _newcustomer.CompanyNumber; }
        }
        public string Description
        {
            get { return _newOrder.Description; }
        }
        // Properties for Data Binding ends

        // OnPropertyChange start
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        // OnPropertyChange ends
    }
}
