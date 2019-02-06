using Priceline.Helpers;
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
	public partial class BidReview : ContentPage
	{
        UserService userservice = new UserService();
        public BidReview ()
		{
			InitializeComponent ();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            destination.Text = "Destination :" + Settings.destination;
            inDate.Text = "Check-In-Date :" + Settings.inDate;
            outDate.Text = "Check-Out-Date :" + Settings.outDate;
            city.Text = "City :" + Settings.city;
            numRooms.Text = "Number of Rooms :" + Settings.roomSelected;
            price.Text = "Bid Amount R:" + Settings.Bidmount;
            numNights.Text = "Number of Nights :" + Settings.diffDays;
        }


        private async void MakePayment(object sender, EventArgs e)
        {
            var details = await userservice.GetBankDetails(Settings.userId);
            if (details.Count <= 0)
            {
                await DisplayAlert("No Banking details found.", "Please sign in first and enter your banking details in the account page."
              , "OK");
            }
            else
            {
                await Navigation.PushAsync(new Payment());
            }
           
        }
    }
}