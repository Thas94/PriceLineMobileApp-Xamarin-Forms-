using Priceline.Models;
using Priceline.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Priceline.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BidsPage : ContentPage
	{
        UserService userservice = new UserService();
        APIservices APIservices = new APIservices();

		public BidsPage ()
		{
			InitializeComponent ();
            GetBid();

        }


        public async void GetBid()
        {

            var userId = await userservice.GetClaims();

            var bid = await userservice.GetBids(userId.Id);
                       
            BidListView.ItemsSource = bid;

        }

        private async void BidListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            var bid = e.Item as Bid;

            await DisplayAlert("selected bid " ,"Province : "+ bid.Province
                +"\nCity : " + bid.City
                 +"\nHotel name : " + bid.Hotel_Name
                  +"\nNo. rooms : " + bid.numRooms
                   +"\nRoom price : " + bid.room_Price
                   ,"","Ok");
            

        }
    }
}