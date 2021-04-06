using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinobuchungssystem
{
    class Show
    {
		public Room Room { get; private set; }
		
		public Movie Movie { get; private set; }

		public DateTime Start { get; private set; }

		public DateTime End { get; private set; }

		public Show(Room room, Movie movie, DateTime start, DateTime end, Dictionary<int, Booking> bookings)
		{
			Room = room;
			Movie = movie;
			Start = start;
			End = end;
		}
    }
}
