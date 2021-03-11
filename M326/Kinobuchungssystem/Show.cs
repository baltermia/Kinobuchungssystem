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

		public IEnumerable<Booking> Bookings => _bookings.Select(b => b.Value);

		public DateTime Start { get; private set; }

		public DateTime End { get; private set; }

		private readonly Dictionary<int, Booking> _bookings;

		public Show (Room room, Movie movie, DateTime start, DateTime end)
        {
			Room = room;
			Movie = movie;
			Start = start;
			End = end;

			_bookings = new Dictionary<int, Booking>();
        }

		public void AddBooking(Booking booking)
        {
			_bookings.Add(_bookings.Count, booking);
        }
    }
}
