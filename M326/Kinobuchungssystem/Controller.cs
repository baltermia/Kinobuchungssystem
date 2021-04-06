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

        public IEnumerable<Booking> Bookings => _bookings.Select(m => m.Value);

        private Dictionary<int, Cinema> _cinemas;

        private Dictionary<int, Customer> _customers;

        private Dictionary<int, Movie> _movies;

        private Dictionary<int, Booking> _bookings;

        private XmlToObject xmlReader;

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

        public void SetObjectsFromXml(string path)
        {
            xmlReader = new XmlToObject(path);

            _movies = xmlReader.GetObject();

            //Todo: do some XmlToObject stuff
        }
    }
}
