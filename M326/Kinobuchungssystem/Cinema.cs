using System.Collections.Generic;

namespace Kinobuchungssystem
{
    public class Cinema : ICinemaType
    {
		public readonly string Name;

        public readonly SimpleCollection<Room> Rooms;

        public readonly SimpleCollection<Show> Shows;

        public readonly SimpleCollection<Movie> Movies;

        public readonly SimpleCollection<Customer> Customers;

        public readonly SimpleCollection<Booking> Bookings;

        public Cinema(string name, IEnumerable<Room> rooms = null, IEnumerable<Movie> movies = null, IEnumerable<Customer> customers = null, IEnumerable<Booking> bookings= null, IEnumerable<Show> shows = null)
        {
            Name = name;
            Rooms = new SimpleCollection<Room>(rooms);
            Shows = new SimpleCollection<Show>(shows);
            Movies = new SimpleCollection<Movie>(movies);
            Customers = new SimpleCollection<Customer>(customers);
            Bookings = new SimpleCollection<Booking>(bookings);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
