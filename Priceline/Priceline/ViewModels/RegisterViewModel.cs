using Priceline.Services;
using Priceline.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Priceline.ViewModels
{
    public class RegisterViewModel
    {
        APIservices services = new APIservices();

        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] Roles { get; set; }

        //public ICommand RegisterCommand
        //{
        //    get
        //    {
                 
        //        return new Command(async () =>
        //        {
        //            //await Application.Current.MainPage.Navigation.PushAsync(new Login());
        //            var isSuccess= await services.RegisterUser(UserName, FirstName, LastName, Email, Password, Roles);
        //              if (isSuccess)
        //              {
        //                  Debug.WriteLine(Roles + "+++++++++++++++++++++++++++++++++++++");
        //                  await App.Current.MainPage.DisplayAlert("You have successfully registered.", "", "ok");
        //                  //await Application.Current.MainPage.Navigation.PushAsync(new HomePage());
        //              }
        //              else
        //              {
        //                  await App.Current.MainPage.DisplayAlert("Registration failed.", "", "ok");
        //              }
        //        });
        //    }
        //}
    }
}
