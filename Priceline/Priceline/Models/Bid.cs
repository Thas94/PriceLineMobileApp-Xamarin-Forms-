
using System;
using System.Collections.Generic;
using System.Text;

namespace Priceline.Models
{
    public class Bid
    {
        public int bid_id { get; set; }
        public string user_id { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public Nullable<int> numRooms { get; set; }
        public Nullable<double> room_Price { get; set; }
        public string room_Type { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Hotel_Name { get; set; }
        public string Province { get; set; }
        public Nullable<int> phone_no { get; set; }
        public string street_Address { get; set; }
        public Nullable<int> zip_code { get; set; }
        public string website { get; set; }
    }
}