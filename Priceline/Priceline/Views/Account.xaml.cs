﻿using Priceline.Helpers;
using Priceline.Models;
using Priceline.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Priceline.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Account : ContentPage
	{
        APIservices apiservice = new APIservices();


		public Account ()
		{
			InitializeComponent ();
            Title = "Account";
            this.BindingContext = this;
            this.IsBusy = false;
            SendEmail();
        }

        private async void LoginAsync(object sender, EventArgs e)
        {
            this.IsBusy = true;
            await DisplayAlert("Login Error", loginUsername.Text + " " + loginPassword.Text, "OK");
        }

        private async void OpenRegisterPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registration() { Title = "Register" });
        }

        private async void OpenProfilePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile() { Title = "Profile" });
        }

        private async void OpenBankPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BankPage() { Title = "BankPage" });
        }

        private async void OpenBidPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BidsPage() { Title = "BidsPage" });
        }

        private async void OpenPaymentPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Payment() { Title = "Payment" });
        }


        UserService us = new UserService();

        async void SignIn(object sender, EventArgs e)
        {
            this.IsBusy = true;
            var access = await us.SigninAsync(loginUsername.Text, loginPassword.Text);
            if (access != null)
            {
                this.IsBusy = false;
                await DisplayAlert("Login", "Login Succesful", "Ok");
                await Navigation.PushAsync(new UserAccount());
                var claims =await us.GetClaims();
                Settings.userId = claims.Id;
                Settings.FirstName = claims.FirstName;
                Settings.LastName = claims.LastName;
                Settings.Email = claims.Email;
            }
            else
            {
                await DisplayAlert("Login", "Login unsuccesful, Incorrect Username or Password", "Ok");
            }
        
        }

        async void SendEmail()
        {

            var email = await apiservice.SendEmail("sduuuuuuuuu", "sduuuuuuuuu", "sduuuuuuuuu", "sduuuuuuuuu", "sduuuuuuuuu", "sduuuuuuuuu", "sduuuuuuuuu", "sduuuuuuuuu", "66sdumo@gmail.com");

        }

    }
}