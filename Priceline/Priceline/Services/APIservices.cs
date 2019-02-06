using Newtonsoft.Json;
using Priceline.Helpers;
using Priceline.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Priceline.Services
{
    public class APIservices
    {
        public string url = "https://f4556698.ngrok.io";

        internal async Task<bool> RegisterUser(RegisterModel model,String[] role)
        {
            var client = new HttpClient();


            RegisterModel RegModel = new RegisterModel();


            RegModel.UserName = model.UserName;
            RegModel.LastName = model.LastName;
            RegModel.FirstName = model.FirstName;
            RegModel.Email = model.Email;
            RegModel.Password = model.Password;
            RegModel.Roles = role;

            

            var json = JsonConvert.SerializeObject(RegModel);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(url + "/api/User/Register", content);

            if (response.IsSuccessStatusCode)
            {
                //This function needs to get the userID 
                //HttpResponseMessage userData = await client.GetAsync("/api/User/Register");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
               
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<List<Hotels>> GetDestination(string des, string city, int rate)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", "bearer " + Settings.accessToken);
            var response = await client.GetStringAsync(url + "/api/Hotels?prov=" + des + "&city=" + city + "&rate=" + rate);
            var claims = JsonConvert.DeserializeObject<List<Hotels>>(response);
            Debug.WriteLine("claims", claims);
            return claims;
        }

        public async Task<List<Rooms>> GetAllRooms()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", "bearer " + Settings.accessToken);
            var response = await client.GetStringAsync(url + "/api/Rooms");
            var claims = JsonConvert.DeserializeObject<List<Rooms>>(response);
            Debug.WriteLine("claims", claims);
            return claims;
        }

        public async Task<List<Rooms>> GetAllRoomsByID(string id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", "bearer " + Settings.accessToken);
            var response = await client.GetStringAsync(url + "/api/Rooms?id=" + id);
            var claims = JsonConvert.DeserializeObject<List<Rooms>>(response);
            Debug.WriteLine("claims", claims);
            return claims;
        }

        public async Task<bool> UpdateRooms(int id, Rooms rooms)
        {
            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(rooms);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            var response = await client.PutAsync(url + "/api/Rooms/" + id, content);

            return response.IsSuccessStatusCode;
        }

        internal async Task<bool> PlaceBid(Bid model)
        {
            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(url + "/api/Bids", content);

            return response.IsSuccessStatusCode;
        }


        public async Task<string> SendEmail(String id,string numRooms, string accomodations, string price,string checkin,string checkout, string fname, string lname,string email)
        {
            HttpClient client = new HttpClient();


            var response = await client.GetStringAsync(url + "/api/Email/" + id + "?numRooms=" + numRooms + "&accomodations=" + accomodations + "&price=" + price + "&checkin=" + checkin + "&checkout=" + checkout + "&fname=" + fname + "&lname=" + lname + "&email=" + email);


            return response;

        }


        public async Task<bool> updateBankDetails(int id, BankDetail details)
        {
            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(details);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(url + "/api/BankDetails/" + id, content);

            return response.IsSuccessStatusCode;
        }





    }
}
