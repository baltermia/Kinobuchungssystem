using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinobuchungssystem
{
    class Controller
    {
        public IEnumerable<Cinema> Cinemas => _cinemas.Select(c => c.Value);

        public IEnumerable<Customer> Customers => _customers.Select(c => c.Value);

        public IEnumerable<Movie> Movies => _movies.Select(m => m.Value);

        public IEnumerable<Booking> Bookings => _bookings.Select(b => b.Value);

        private readonly Dictionary<int, Cinema> _cinemas;

        private readonly Dictionary<int, Customer> _customers;

        private readonly Dictionary<int, Movie> _movies;

        private readonly Dictionary<int, Booking> _bookings;

        public Controller()
        {
            _cinemas = new Dictionary<int, Cinema>();
            _customers = new Dictionary<int, Customer>();
            _movies = new Dictionary<int, Movie>();
            _bookings = new Dictionary<int, Booking>();
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
    }
}
