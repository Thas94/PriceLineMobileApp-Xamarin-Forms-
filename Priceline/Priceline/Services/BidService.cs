using Priceline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Priceline.Services
{
    public class BidService
    {

        public int randomizeHotel(List<Hotels> hotels)
        {
            Random random = new Random();
            int index = random.Next(hotels.Count);
            return index;
        }

        public List<Rooms> roomsAboveZero(List<Rooms> rooms)
        {
            List<Rooms> rr = new List<Rooms>();
            rr = rooms.FindAll(x => x.numRooms != Convert.ToString(0));
            return rr;
        }

        public List<Rooms> returnRoomsByPrice(List<Rooms> rooms, double amount)
        {
            List<Rooms> rr = new List<Rooms>();
            rr = rooms.FindAll(x => x.room_Price <= amount);
            return rr;
        }

        public List<Rooms> filterRooms(List<Rooms> rooms, string sDate, string eDate, int numRooms)
        {
            List<Rooms> rr = new List<Rooms>();
            rr = rooms.FindAll(x => x.startDate == sDate && x.endDate == eDate && Convert.ToInt32(x.numRooms) >= numRooms);
            return rr;
        }

        public int randomizeRoom(List<Rooms> room)
        {
            Random random = new Random();
            int index = random.Next(room.Count);
            return index;
        }

        public Rooms roomsLeft(Rooms rooms, int numRooms)
        {
            var rr = Convert.ToInt32(rooms.numRooms) - numRooms;
            rooms.numRooms = rr.ToString();

            return rooms;
        }

        public int daysToStay(string d1,string d2)
        {
            var sp = d1.Split('-');

            var sp1 = d2.Split('-');

            var days = Convert.ToInt32(sp1[2]) - Convert.ToInt32(sp[2]);

            return days;
        }
    }
}
