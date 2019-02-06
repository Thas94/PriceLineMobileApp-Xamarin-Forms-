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
    public partial class Payment : ContentPage
    {
        APIservices service = new APIservices();
        BidService bidService = new BidService();
        Rooms roomLeft, chosenRoom;
        Hotels chosenHotel;
        UserService userservice = new UserService();

        public Payment()
        {
            InitializeComponent();
            GetBankDetails();

            chosenRoom = Settings.chosenRoom;
            chosenHotel = Settings.chosenHotel;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            roomLeft = bidService.roomsLeft(chosenRoom, Convert.ToInt32(Settings.roomSelected));

            var updateRooms = service.UpdateRooms(roomLeft.room_id, roomLeft);

            var bid = new Bid
            {
                user_id = Settings.userId,
                startDate = chosenRoom.startDate,
                endDate = chosenRoom.endDate,
                numRooms = Convert.ToInt32(Settings.roomSelected),
                room_Price = chosenRoom.room_Price,
                room_Type = chosenRoom.room_Type,
                Country = chosenHotel.Country,
                City = chosenHotel.City,
                Hotel_Name = chosenHotel.Hotel_Name,
                Province = chosenHotel.Province,
                phone_no = chosenHotel.phone_no,
                street_Address = chosenHotel.street_Address,
                zip_code = chosenHotel.zip_code,
                website = chosenHotel.website
            };

            var placeBid = service.PlaceBid(bid);

            var email = service.SendEmail(Settings.userId, chosenRoom.numRooms, chosenHotel.Hotel_Name, chosenRoom.room_Price.ToString(), Settings.inDate, Settings.outDate, Settings.FirstName, Settings.LastName, Settings.Email);

            await Navigation.PushAsync(new FinalPage());
        }

        public async void GetBankDetails()
        {
            BankDetail bankDetails = new BankDetail();

            var UserId = Settings.userId;


            var details = await userservice.GetBankDetails(UserId);

            bankDetails.user_id = details[0].user_id;
            bankDetails.acc_holder = details[0].acc_holder;
            bankDetails.phone_no = details[0].phone_no;
            bankDetails.acc_no = details[0].acc_no;
            bankDetails.card_no = Convert.ToInt32(details[0].card_no);
            bankDetails.acc_Type = details[0].acc_Type;
            bankDetails.branch_no = details[0].branch_no;
            bankDetails.cvv = details[0].cvv;
            bankDetails.exp_Date = details[0].exp_Date;
            bankDetails.bank_Name = details[0].bank_Name;

            BindingContext = bankDetails;

        }
    }
}