using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunner_OrderList
{
    public class Catalog

    {
        private ObservableCollection<Catalog> _catalog;

        private static Catalog _instance = null;

        private Catalog() { }

        public static Catalog Instance

        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Catalog();
                }
                return _instance;
            }



        }

        public ObservableCollection<Catalog> CatalogInformation

        {

          get {  return _catalog; } 


          set {_catalog = value; }

        }

        
         




    }


}
