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
    public partial class BankPage : ContentPage
    {


        UserService user = new UserService();
        APIservices service = new APIservices();
        User userObj = new User();
        bool bankAvail = false;
        List<BankDetail> bank;

        public BankPage()
        {
            InitializeComponent();
            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            GetUser();

             bank = await user.GetBankDetails(Settings.userId);
             if (bank.Count <= 0)
             {
                 //post
                 bankAvail = false;
             }
             else
             {
                 //update
                 bankAvail = true;

                
                 acc_holder.Text = bank[0].acc_holder;
                 phone_no.Text = "0" + Convert.ToString(bank[0].phone_no);
                 acc_no.Text = Convert.ToString(bank[0].acc_no);
                 card_no.Text = Convert.ToString(bank[0].card_no);
                 acc_Type.Text = bank[0].acc_Type;
                 branch_no.Text = Convert.ToString(bank[0].branch_no);
                 cvv.Text = Convert.ToString(bank[0].cvv);
                 exp_Date.Text = bank[0].exp_Date;
                 bank_Name.Text = bank[0].bank_Name;

                
             }
        }

        async void GetUser()
        {


            User model = await user.GetClaims();

            userObj.Id = model.Id;
            userObj.UserName = model.UserName;
            userObj.FirstName = model.FirstName;
            userObj.LastName = model.LastName;
            userObj.Email = model.Email;
            userObj.Password = model.Password;
            userObj.PasswordHash = model.PasswordHash;
            userObj.SecurityStamp = model.SecurityStamp;


            //Store user id of the current logged in 
            Settings.userId = model.Id;

        }


        async void postBank(object sender, EventArgs e)
        {
            if (bankAvail == false)
            {
                //post

                BankDetail details = new BankDetail();


                var userId = Settings.userId;

                details.user_id = userId;

                details.bank_Name = bank_Name.Text;
                details.branch_no = Convert.ToInt32(branch_no.Text);
                details.acc_no = Convert.ToInt32(acc_no.Text);
                details.acc_Type = acc_Type.Text;
                details.acc_holder = acc_holder.Text;
                details.card_no = Convert.ToInt32(card_no.Text);
                details.cvv = Convert.ToInt32(cvv.Text);
                details.exp_Date = exp_Date.Text;
                details.phone_no = Convert.ToInt32(phone_no.Text);

                var isSuccess = await user.PostBank(details);
                if (isSuccess)
                {

                    await App.Current.MainPage.DisplayAlert("Payment", "Details Added", "ok");
                    await Navigation.PushAsync(new UserAccount());

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Failed to add details", "", "ok");
                }
            }
            else
            {
                //Update
                var body = new BankDetail
                {
                    bank_id = bank[0].bank_id,
                    user_id = Settings.userId,
                    acc_holder = acc_holder.Text,
                    acc_no = Convert.ToInt32(acc_no.Text),
                    phone_no = Convert.ToInt32(phone_no.Text),
                    acc_Type = acc_Type.Text,
                    card_no = Convert.ToInt32(card_no.Text),
                    branch_no = Convert.ToInt32(branch_no.Text),
                    cvv = Convert.ToInt32(cvv.Text),
                    exp_Date = exp_Date.Text,
                    bank_Name = bank_Name.Text
                };

                var update = await service.updateBankDetails(bank[0].bank_id,body);
                if (!update)
                {
                    await App.Current.MainPage.DisplayAlert("Failed to update bank details", "", "ok");

                }
                else
                {
                    await Navigation.PushAsync(new UserAccount());
                }

            }


        }

       



    }
}