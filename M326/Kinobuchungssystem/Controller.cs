using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinobuchungssystem
{
    class Controller
    {
        public readonly SimpleCollection<Room> Rooms;

        public readonly SimpleCollection<Show> Shows;

        public readonly SimpleCollection<Movie> Movies;

        public readonly SimpleCollection<Customer> Customers;

        public readonly SimpleCollection<Cinema> Cinemas;

        public readonly SimpleCollection<Booking> Bookings;

        public Controller()
        {
            Rooms = new SimpleCollection<Room>();
            Shows = new SimpleCollection<Show>();
            Movies = new SimpleCollection<Movie>();
            Customers = new SimpleCollection<Customer>();
            Cinemas = new SimpleCollection<Cinema>();
            Bookings = new SimpleCollection<Booking>();
        }

        public Controller(string path)
        {
            JObject json = JObject.Parse(File.ReadAllText(path));

            string rooms = json.SelectToken("Rooms").ToString();
            Rooms = SimpleCollection<Room>.GetDeserialized(rooms);

            string shows = json.SelectToken("Shows").ToString();
            Shows = SimpleCollection<Show>.GetDeserialized(shows);

            string movies = json.SelectToken("Movies").ToString();
            Movies = SimpleCollection<Movie>.GetDeserialized(movies);

            string customers = json.SelectToken("Customers").ToString();
            Customers = SimpleCollection<Customer>.GetDeserialized(customers);

            string cinemas = json.SelectToken("Cinemas").ToString();
            Cinemas = SimpleCollection<Cinema>.GetDeserialized(cinemas);

            string bookings = json.SelectToken("Bookings").ToString();
            Bookings = SimpleCollection<Booking>.GetDeserialized(bookings);
        }

        public void Save(string path)
        {
            path.ToString();
        }
    }
}
