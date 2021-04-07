using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinobuchungssystem
{
    class Controller
    {
        [JsonIgnore]
        public IEnumerable<Cinema> Cinemas => _cinemas.Select(c => c.Value);

        [JsonIgnore]
        public IEnumerable<Room> Rooms=> _rooms.Select(r => r.Value);
        [JsonIgnore]
        public IEnumerable<Customer> Customers => _customers.Select(c => c.Value);

        [JsonIgnore]
        public IEnumerable<Movie> Movies => _movies.Select(m => m.Value);

        [JsonIgnore]
        public IEnumerable<Booking> Bookings => _bookings.Select(b => b.Value);

        [JsonIgnore]
        public IEnumerable<Show> Shows => _shows.Select(s => s.Value);

        private readonly Dictionary<int, Show> _shows;

        private readonly Dictionary<int, Room> _rooms;
        
        private readonly Dictionary<int, Cinema> _cinemas;

        private readonly Dictionary<int, Customer> _customers;

        private readonly Dictionary<int, Movie> _movies;

        private readonly Dictionary<int, Booking> _bookings;

        public Controller()
        {
            _shows = new Dictionary<int, Show>();
            _rooms = new Dictionary<int, Room>();
            _cinemas = new Dictionary<int, Cinema>();
            _customers = new Dictionary<int, Customer>();
            _movies = new Dictionary<int, Movie>();
            _bookings = new Dictionary<int, Booking>();
        }

        public void AddShow(Show show)
        {
            _shows.Add(_shows.Count, show);
        }

        public void AddRoom(Room room)
        {
            _rooms.Add(_rooms.Count, room);
        }

        public void AddCinema(Cinema cinema)
        {
            _cinemas.Add(_cinemas.Count, cinema);
        }

        public void AddCustomer(Customer customer)
        {
            _customers.Add(_customers.Count, customer);
        }

        public void AddMovie(Movie movie)
        {
            _movies.Add(_movies.Count, movie);
        }

        public void AddBookings(Booking booking)
        {
            _bookings.Add(_bookings.Count, booking);
        }

        public void GetDataFromFile(string path)
        {

        }

        public void WriteDataIntoFile(string path)
        {

        }
    }
}
