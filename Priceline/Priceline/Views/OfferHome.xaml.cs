using System;
using Priceline.Helpers;
using Priceline.Models;
using Priceline.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Priceline.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OfferHome : ContentPage
    {

        APIservices service = new APIservices();
        BidService bidService = new BidService();
        List<Hotels> hotelDestinations;
        List<Rooms> allRooms;
        List<Rooms> RoomsByID;
        List<Rooms> RoomsAboveZero;
        List<Rooms> RoomsByPrice;
        List<Rooms> filterRooms;
        Rooms roomLeft;
        string outDate, inDate;

        public OfferHome()
        {
            InitializeComponent();
            this.BindingContext = this;
            this.IsBusy = false;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //Set minumum dates for date pickers
            checkInDate.MinimumDate = DateTime.Today;
            checkOutDate.MinimumDate = DateTime.Today;

            allRooms = await service.GetAllRooms();
        }


        private void CheckInDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            string date = e.NewDate.ToString("yyyy-MM-dd");
            inDate = date;
            Settings.inDate = inDate;
        }

        private void CheckOutDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            string date = e.NewDate.ToString("yyyy-MM-dd");
            outDate = date;
            Settings.outDate = outDate;
        }

        private async void StartBid(object sender, EventArgs e)
        {
            this.IsBusy = true;
            int diffDays = bidService.daysToStay(inDate, outDate);
            Settings.diffDays = diffDays.ToString();

            hotelDestinations = await service.GetDestination(destination.Text, city.Text, Convert.ToInt32(rating.Text));

            if (hotelDestinations.Count >= 1)
            {
                this.IsBusy = false;
                int index = bidService.randomizeHotel(hotelDestinations);
                var chosenHotel = hotelDestinations[index];
                Settings.chosenHotel = chosenHotel;
                RoomsByID = await service.GetAllRoomsByID(chosenHotel.hotelMan_id);

                RoomsAboveZero = bidService.roomsAboveZero(RoomsByID);

                RoomsByPrice = bidService.returnRoomsByPrice(RoomsAboveZero, Convert.ToDouble(bidAmount.Text));

                filterRooms = bidService.filterRooms(RoomsByPrice, inDate, outDate, Convert.ToInt32(RoomPicker.Text));

                if (filterRooms.Count <= 0)
                {
                    await DisplayAlert("Rooms", "are not available for your search", "Ok");
                }
                else
                {
                    int index2 = bidService.randomizeRoom(filterRooms);
                    var chosenRoom = filterRooms[index2];
                    Settings.chosenRoom = chosenRoom;

                    Settings.destination = destination.Text;
                    Settings.city = city.Text;
                    Settings.rate = rating.Text;
                    Settings.Bidmount = bidAmount.Text;
                    Settings.roomSelected = RoomPicker.Text;
                
                    await Navigation.PushAsync(new BidReview());
                }
            }
            else
            {
                this.IsBusy = false;
                await DisplayAlert("No results found for your destination", destination.Text, "Ok");
            }
        }
    }
}