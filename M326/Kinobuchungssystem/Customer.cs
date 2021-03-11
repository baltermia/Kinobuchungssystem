using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinobuchungssystem
{
    class Customer
    {
		public readonly string Firstname;

		public readonly string Lastname;

		public IEnumerable<Booking> Bookings => _bookings.Select(d => d.Value).ToList();

		private readonly Dictionary<int, Booking> _bookings;

		public Customer(string firstname, string lastname)
        {
			Firstname = firstname;

			Lastname = lastname;

			_bookings = new Dictionary<int, Booking>();
        }

		public void AddBooking(Booking booking)
        {
			_bookings.Add(_bookings.Count, booking);
        }
    }
}
