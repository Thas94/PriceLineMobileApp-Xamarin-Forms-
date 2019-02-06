using Priceline.Helpers;
using Priceline.Models;
using Priceline.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Priceline.Views
{
 

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Profile : ContentPage
	{

        UserService us = new UserService();

        public Profile()
		{

          
			InitializeComponent();
            GetUser();
		}

        async void GetUser()
        {
            User userObj = new User();

           User user =  await us.GetClaims();

            userObj.Id = user.Id;
            userObj.UserName = user.UserName;
            userObj.FirstName = user.FirstName;
            userObj.LastName = user.LastName;
            userObj.Email = user.Email;
            userObj.Password = user.Password;
            userObj.PasswordHash = user.PasswordHash;
            userObj.SecurityStamp = user.SecurityStamp;

            BindingContext = userObj;
        }


        async void UpdateProfile(Object sender , EventArgs e)
        {
            User userObj = new User();

            userObj.Id = Id.Text;
            userObj.UserName = username.Text;
            userObj.FirstName = FirstName.Text;
            userObj.LastName =LastName.Text;
            userObj.Email = Email.Text;
            userObj.Password = Password.Text;
            userObj.PasswordHash = PasswordHash.Text;
            userObj.SecurityStamp =SecurityStamp.Text;


            var isSuccess = await us.UpdateUser(userObj, Id.Text);
            if(isSuccess)
            { 

                await App.Current.MainPage.DisplayAlert("Update", "Successful", "ok");
                await Navigation.PushAsync(new Home());

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Update failed.", "", "ok");
            }
        }
	}
}