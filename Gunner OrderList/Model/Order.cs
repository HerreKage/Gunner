using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunner_OrderList
{
    class Order
    {
        private Customer _customer = new Customer();
        private string _description;
        private int orderNumber;
        private string _product;
        private string _startdate;
        private string _deadline;
        private string _price;
        private string _notes;

        #region Material Boxes
        private bool _malBool;
        private string _malString;

        private bool _suv1;
        private bool _medie1;

        private bool _solBool1;
        private string _solString1;

        private bool _suv2;
        private bool _medie2;

        private bool _solBool2;
        private string _solString2;

        private bool _751CBool1;
        private string _751CString1;

        private bool _751CBool2;
        private string _751CString2;

        private bool _751CBool3;
        private string _751CString3;

        private bool _751CBool4;    //4 and 5 should pop up when first three are full
        private string _751CString4;

        private bool _751CBool5;
        private string _751CString5;
        #endregion

        #region Product Boxes

        private bool _antalBool;
        private string _antalString;

        private bool _iamBool1;
        private string _iamString1;

        private bool _iamBool2;
        private string _iamString2;

        private bool _iamBool3;
        private string _iamString3;

        private bool _3mmALU;
        private bool _10mmPVC;
        private bool _viMonterer;
        private bool _afhentes;

        private bool _blankBool1;
        private string _blankString1;

        private bool _blankBool2;
        private string _blankString2;

        private bool _blankBool3;
        private string _blankString3;

        #endregion

        #region Price Boxes

        private bool _priceBool;
        private string _priceString;

        private bool _dptBool;
        private string _dptString;

        private bool _fragtBool;
        private string _fragtString;

        private bool _optTill_10_Bool;
        private string _optTill_10_String;

        private bool _levAntalBool;
        private string _levAntalString;

        private bool _vedlagteBool;
        private string _vedlagteString;
        #endregion

        public Order()
        {
        }

        public Customer Customer { get => _customer; set => _customer = value; }
        public string Description { get => _description; set => _description = value; }
        public int OrderNumber { get => orderNumber; set => orderNumber = value; }
        public string Product { get => _product; set => _product = value; }
        public string StartDate { get => _startdate; set => _startdate = value; }
        public string Deadline { get => _deadline; set => _deadline = value; }
        public string Price { get => _price; set => _price = value; }
        public string Notes { get => _notes; set => _notes = value; }
        public bool MalBool { get => _malBool; set => _malBool = value; }
        public string MalString { get => _malString; set => _malString = value; }
        public bool Suv1 { get => _suv1; set => _suv1 = value; }
        public bool Medie1 { get => _medie1; set => _medie1 = value; }
        public bool SolBool1 { get => _solBool1; set => _solBool1 = value; }
        public string SolString1 { get => _solString1; set => _solString1 = value; }
        public bool Suv2 { get => _suv2; set => _suv2 = value; }
        public bool Medie2 { get => _medie2; set => _medie2 = value; }
        public bool SolBool2 { get => _solBool2; set => _solBool2 = value; }
        public string SolString2 { get => _solString2; set => _solString2 = value; }
        public bool C751Bool1 { get => _751CBool1; set => _751CBool1 = value; }
        public string C751String1 { get => _751CString1; set => _751CString1 = value; }
        public bool C751Bool2 { get => _751CBool2; set => _751CBool2 = value; }
        public string C751String2 { get => _751CString2; set => _751CString2 = value; }
        public bool C751Bool3 { get => _751CBool3; set => _751CBool3 = value; }
        public string C751String3 { get => _751CString3; set => _751CString3 = value; }
        public bool C751Bool4 { get => _751CBool4; set => _751CBool4 = value; }
        public string C751String4 { get => _751CString4; set => _751CString4 = value; }
        public bool C751Bool5 { get => _751CBool5; set => _751CBool5 = value; }
        public string C751String5 { get => _751CString5; set => _751CString5 = value; }
    }
}
