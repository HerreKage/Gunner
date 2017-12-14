using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Gunner_OrderList.Model;
using Gunner_OrderList.View;
using Microsoft.Xaml.Interactions.Core;

namespace Gunner_OrderList.Viewmodel
{
    public class LoginCommandVM
    {

       

        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginCommandVM()
        {
            UserName = "";
            Password = "";

            LoginCmd = new LoginCommand(UserName,Password);    
        }

        public LoginCommand LoginCmd { get; }


    }
}
