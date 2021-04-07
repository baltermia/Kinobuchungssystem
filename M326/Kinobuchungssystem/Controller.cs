using Newtonsoft.Json.Linq;
using System.IO;

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

            Rooms = SimpleCollection<Room>.GetDeserialized(json.SelectToken("Rooms").ToString());
            Shows = SimpleCollection<Show>.GetDeserialized(json.SelectToken("Shows").ToString());
            Movies = SimpleCollection<Movie>.GetDeserialized(json.SelectToken("Movies").ToString());
            Customers = SimpleCollection<Customer>.GetDeserialized(json.SelectToken("Customers").ToString());
            Cinemas = SimpleCollection<Cinema>.GetDeserialized(json.SelectToken("Cinemas").ToString());
            Bookings = SimpleCollection<Booking>.GetDeserialized(json.SelectToken("Bookings").ToString());
        }

        public void Save(string path)
        {
            JObject json = new JObject
            {
                { "Rooms", JToken.Parse(Rooms.GetSerialized()) },
                { "Shows", JToken.Parse(Shows.GetSerialized()) },
                { "Movies", JToken.Parse(Movies.GetSerialized()) },
                { "Customers", JToken.Parse(Customers.GetSerialized()) },
                { "Cinemas", JToken.Parse(Cinemas.GetSerialized()) },
                { "Bookings", JToken.Parse(Bookings.GetSerialized()) }
            };

            File.WriteAllText(path, json.ToString());
        }
    }
}
