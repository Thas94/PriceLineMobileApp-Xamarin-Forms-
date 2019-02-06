using System;
using System.Collections.Generic;
using System.Text;

namespace Priceline.Models
{
    public class Hotels
    {
        public int hotel_id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public Nullable<int> zip_code { get; set; }
        public string street_Address { get; set; }
        public string website { get; set; }
        public Nullable<int> rating { get; set; }
        public Nullable<int> phone_no { get; set; }
        public string hotelMan_id { get; set; }
        public string Hotel_Name { get; set; }
    }
}
