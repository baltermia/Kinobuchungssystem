using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinobuchungssystem
{
    public class Show
    {
        public readonly Room Room;

        public readonly Movie Movie;

        public readonly DateTime Start;

        public readonly DateTime End;

        public readonly SimpleCollection<Booking> Bookings;

        public Show(Room room, Movie movie, DateTime start, DateTime end, IEnumerable<Booking> bookings = null)
        {
            Room = room;
            Movie = movie;
            Start = start;
            End = end;
            Bookings = new SimpleCollection<Booking>(bookings);
        }
    }
}
