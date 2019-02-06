using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Priceline.Models;

namespace Priceline.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        #region
        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;
        #endregion

        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        public static string accessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("accessToken", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("accessToken", value);
            }
        }

        public static string username
        {
            get
            {
                return AppSettings.GetValueOrDefault("username", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("username", value);
            }
        }

        public static string diffDays
        {
            get
            {
                return AppSettings.GetValueOrDefault("diffDays", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("diffDays", value);
            }
        }

        public static string userId
        {
            get
            {
                return AppSettings.GetValueOrDefault("userId", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("userId", value);
            }
        }


        public static List<string> userDetails
        {
            get
            {
                string value = AppSettings.GetValueOrDefault("userDetails", "");
                List<string> myList;
                if (string.IsNullOrEmpty(value))
                    myList = new List<string>();
                else
                    myList = JsonConvert.DeserializeObject<List<string>>(value);
                return myList;
            }
            set
            {
                string listValue = JsonConvert.SerializeObject(value);
                AppSettings.AddOrUpdateValue("userDetails", listValue);
            }
        }

        public static List<Rooms> roomByID
        {
            get
            {
                string value = AppSettings.GetValueOrDefault("userDetails", "");
                List<Rooms> myList;
                if (string.IsNullOrEmpty(value))
                    myList = new List<Rooms>();
                else
                    myList = JsonConvert.DeserializeObject<List<Rooms>>(value);
                return myList;
            }
            set
            {
                string listValue = JsonConvert.SerializeObject(value);
                AppSettings.AddOrUpdateValue("userDetails", listValue);
            }
        }

        public static string destination
        {
            get
            {
                return AppSettings.GetValueOrDefault("destination", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("destination", value);
            }
        }

        public static string city
        {
            get
            {
                return AppSettings.GetValueOrDefault("city", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("city", value);
            }
        }

        public static string rate
        {
            get
            {
                return AppSettings.GetValueOrDefault("rate", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("rate", value);
            }
        }

        public static string inDate
        {
            get
            {
                return AppSettings.GetValueOrDefault("inDate", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("inDate", value);
            }
        }

        public static string outDate
        {
            get
            {
                return AppSettings.GetValueOrDefault("outDate", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("outDate", value);
            }
        }

        public static string roomSelected
        {
            get
            {
                return AppSettings.GetValueOrDefault("roomSelected", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("roomSelected", value);
            }
        }

        public static string UserRole
        {
            get
            {
                return AppSettings.GetValueOrDefault("role", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("role", value);
            }
        }



        public static string Bidmount
        {
            get
            {
                return AppSettings.GetValueOrDefault("Bidmount", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Bidmount", value);
            }
        }

        public static string FirstName
        {
            get
            {
                return AppSettings.GetValueOrDefault("FirstName", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("FirstName", value);
            }
        }

        public static string LastName
        {
            get
            {
                return AppSettings.GetValueOrDefault("LastName", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("LastName", value);
            }
        }

        public static string Email
        {
            get
            {
                return AppSettings.GetValueOrDefault("Email", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Email", value);
            }
        }

        public static Rooms chosenRoom
        {
            get
            {
                string value = AppSettings.GetValueOrDefault("chosenRoom", "");
                Rooms myList;
                if (string.IsNullOrEmpty(value))
                    myList = new Rooms();
                else
                    myList = JsonConvert.DeserializeObject<Rooms>(value);
                return myList;
            }
            set
            {
                string listValue = JsonConvert.SerializeObject(value);
                AppSettings.AddOrUpdateValue("chosenRoom", listValue);
            }
        }

        public static Hotels chosenHotel
        {
            get
            {
                string value = AppSettings.GetValueOrDefault("chosenHotel", "");
                Hotels myList;
                if (string.IsNullOrEmpty(value))
                    myList = new Hotels();
                else
                    myList = JsonConvert.DeserializeObject<Hotels>(value);
                return myList;
            }
            set
            {
                string listValue = JsonConvert.SerializeObject(value);
                AppSettings.AddOrUpdateValue("chosenHotel", listValue);
            }
        }

        public static Rooms roomLeft
        {
            get
            {
                string value = AppSettings.GetValueOrDefault("roomLeft", "");
                Rooms myList;
                if (string.IsNullOrEmpty(value))
                    myList = new Rooms();
                else
                    myList = JsonConvert.DeserializeObject<Rooms>(value);
                return myList;
            }
            set
            {
                string listValue = JsonConvert.SerializeObject(value);
                AppSettings.AddOrUpdateValue("roomLeft", listValue);
            }
        }

    }
}
