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

        public void Read(string path)
        {

        }

        public void Save(string path)
        {

        }
    }
}
