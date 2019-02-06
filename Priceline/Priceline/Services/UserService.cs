using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Priceline.Helpers;
using Priceline.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Priceline.Services
{
    class UserService
    {

         HttpClient client;
       
        APIservices APIservices = new APIservices();

     



          public UserService()
          {

              client = new HttpClient();
              client.MaxResponseContentBufferSize = 256000;
              client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

          }
      

        public async Task<string> SigninAsync(string username, string password)
        {

            var keyValues = new List<KeyValuePair<string, string>>
            {

            new KeyValuePair<string, string>("Username",username),
            new KeyValuePair<string, string>("Password",password),
            new KeyValuePair<string, string>("grant_type","password")


            };

            var request = new HttpRequestMessage(
                HttpMethod.Post, APIservices.url + "/token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);


            var content = await response.Content.ReadAsStringAsync();

            var result = JObject.Parse(content);

            var UserRole = result.Value<string>("role");

          

            var token = result.Value<string>("access_token");
            Settings.accessToken = token;


            return token;

        }

        public async Task<User> GetClaims()
        {
            var client = new HttpClient();

            var token = Settings.accessToken;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", token);

            var json = await client.GetStringAsync(APIservices.url + "/api/GetUserClaims");

             User currentUser = JsonConvert.DeserializeObject<User>(json);


            return currentUser;

          
        }


        public async Task<bool>UpdateUser(User user , string id)
        {
            User userObj = new User();

            userObj.Id = user.Id;
            userObj.UserName = user.UserName;
            userObj.FirstName = user.FirstName;
            userObj.LastName = user.LastName;
            userObj.Email = user.Email;
            userObj.Password = user.Password;
            userObj.PasswordHash = user.PasswordHash;
            userObj.SecurityStamp = user.SecurityStamp;

            var json = JsonConvert.SerializeObject(userObj);

            var content = new StringContent(json, Encoding.UTF8, "application/json");


            HttpClient client = new HttpClient();

            var token = Settings.accessToken;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
               "Bearer", token);

            var result = await client.PutAsync(string.Concat(APIservices.url + "/api/Profile/", user.Id), content);

            return result.IsSuccessStatusCode;


        }

        public async Task<bool> PostBank(BankDetail model)
        {
            HttpClient client = new HttpClient();

            BankDetail details = new BankDetail();

            details.user_id = model.user_id;
            details.bank_Name = model.bank_Name;
            details.branch_no = model.branch_no;
            details.acc_no = model.acc_no;
            details.acc_Type = model.acc_Type;
            details.acc_holder = model.acc_holder;
            details.card_no = model.card_no;
            details.cvv = model.cvv;
            details.exp_Date = model.exp_Date;
            details.phone_no = model.phone_no;




            var json = JsonConvert.SerializeObject(details);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var token = Settings.accessToken;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
               "Bearer", token);

            var response = await client.PostAsync(APIservices.url + "/api/BankDetails", content);


            return response.IsSuccessStatusCode;

        }

        public async Task<List<Bid>> GetBids(string Id)
        {
            var client = new HttpClient();

            var token = Settings.accessToken;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", token);

            var json = await client.GetStringAsync(APIservices.url + "/api/Bids/"+Id);

          

            var UserBIds = JsonConvert.DeserializeObject<List<Bid>>(json);


            return UserBIds;


        }


        public async Task<List<BankDetail>> GetBankDetails(string Id)
        {
            var client = new HttpClient();

            var token = Settings.accessToken;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", token);

            var json = await client.GetStringAsync(APIservices.url + "/api/BankDetails/" + Id);


            var bankdetails = JsonConvert.DeserializeObject<List<BankDetail>>(json);

            return bankdetails;


        }

        public async Task<bool> UpdatePayment(BankDetail bankModel, int id)
        {
            BankDetail bankObj = new BankDetail();       

            bankObj.bank_id = bankModel.bank_id;
            bankObj.user_id = bankModel.user_id;
            bankObj.acc_holder = bankModel.acc_holder;
            bankObj.phone_no = bankModel.phone_no;
            bankObj.acc_no = bankModel.acc_no;
            bankObj.card_no = Convert.ToInt32(bankModel.card_no);
            bankObj.acc_Type = bankModel.acc_Type;
            bankObj.branch_no = bankModel.branch_no;
            bankObj.cvv = bankModel.cvv;
            bankObj.exp_Date = bankModel.exp_Date;
            bankObj.bank_Name = bankModel.bank_Name;

            var json = JsonConvert.SerializeObject(bankObj);

            var content = new StringContent(json, Encoding.UTF8, "application/json");


            HttpClient client = new HttpClient();

            var token = Settings.accessToken;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
               "Bearer", token);

            var result = await client.PutAsync(string.Concat(APIservices.url + "/api/BankDetails/", bankObj.bank_id), content);

            return result.IsSuccessStatusCode;


        }



    }
    
}

       
        
        
        


    

