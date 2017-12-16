using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Gunner_OrderList.Model;
using Gunner_OrderList.View;

namespace Gunner_OrderList.Viewmodel
{
    public class LoginCommand : ICommand
    {
        private string _userName;
        private string _password;
        private Worker _worker;

        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }

        public LoginCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var catalog = WorkerCatalog.Instance;

            var login = catalog.CheckLogin(UserName, Password);
            if (login=="Unknown")
            {
                return;
            }
            var frame = (Frame )Window.Current.Content;
            if (login == "Employee")
            {
                frame.Navigate(typeof(EmployeeMainPage));
            }
            else
            {
                frame.Navigate(typeof(MainPage));
            }
             
       
            
        }

        public event EventHandler CanExecuteChanged;
    }
}
