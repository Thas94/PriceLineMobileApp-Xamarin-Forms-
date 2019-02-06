using Newtonsoft.Json;
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
    public partial class Registration : ContentPage
    {
       


        string[] SelectedRole = { "Customer" };



        APIservices service = new APIservices();


        public Registration()
        {
            InitializeComponent();
            GetRoles();


        }



        public async void GetRoles()
        {
            HttpClient client = new HttpClient();


            var response = await client.GetStringAsync(service.url + "/api/GetAllRoles");

            List<Roles> roles = JsonConvert.DeserializeObject<List<Roles>>(response);


        }






        public async void Register(object sender, EventArgs e)
        {
            RegisterModel regModel = new RegisterModel();

            regModel.UserName = registerUsername.Text;
            regModel.FirstName = registerName.Text;
            regModel.LastName = registerSurname.Text;
            regModel.Email = registerEmail.Text;
            regModel.Password = registerPassword.Text;


            var isSuccess = await service.RegisterUser(regModel, SelectedRole);
            if (isSuccess)
            {

                await App.Current.MainPage.DisplayAlert("Sign up", "Successful", "ok");
                await Navigation.PushAsync(new Home());

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Sign up failed.", "", "ok");
            }
        }





    }
}