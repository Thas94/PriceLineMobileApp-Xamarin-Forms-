using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priceline.Helpers;
using Priceline.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Priceline.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserAccount : ContentPage
	{
        UserService userservice = new UserService();

        public UserAccount ()
		{
			InitializeComponent ();
            this.BindingContext = this;
            this.IsBusy = false;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            this.IsBusy = true;

            var details = await userservice.GetBankDetails(Settings.userId);
            if (details.Count <= 0)
            {
                this.IsBusy = false;
                await DisplayAlert("You are new here." + Settings.username, "Please enter your payment details."
              , "OK");
                this.profileView.IsVisible = true;
            }
            else
            {
                this.IsBusy = false;
                this.profileView.IsVisible = true;
            }
        }


        private async void EditProfile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile());
        }

        private async void BankDetails(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BankPage());
        }

        private async void ViewBids(object sender, EventArgs e)
        {
            var bid = await userservice.GetBids(Settings.userId);
            if (bid.Count <= 0)
            {
                await DisplayAlert("No Bids History found.", "Place a bid first."
              , "OK");
            }
            else
            {
                await Navigation.PushAsync(new BidsPage());
            }
            
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Home());
        }

        private async void SignOut(object sender, EventArgs e)
        {
            Settings.accessToken = "";
            Settings.username = "";

            await Navigation.PopAsync();
            await Navigation.PushAsync(new NavigationPage(new Home())); 
        }

    }
}