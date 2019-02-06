using System;
using System.Collections.Generic;
using System.Text;

namespace Priceline.Models
{
    public class Rooms
    {
        public int room_id { get; set; }
        public string numRooms { get; set; }
        public string contact_Person { get; set; }
        public string room_Type { get; set; }
        public Nullable<double> room_Price { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string hotelMan_id { get; set; }
    }
}
