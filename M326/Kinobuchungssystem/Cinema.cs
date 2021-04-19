using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Kinobuchungssystem
{
    public class Cinema
    {
		public readonly string Name;

        public readonly SimpleCollection<Room> Rooms;

        public readonly SimpleCollection<Show> Shows;

        public readonly SimpleCollection<Movie> Movies;

        public readonly SimpleCollection<Customer> Customers;

        public readonly SimpleCollection<Booking> Bookings;

        /// <summary>
        /// Creates a new instance of Cinema
        /// </summary>
        /// <param name="name"></param>
        /// <param name="rooms"></param>
        /// <param name="movies"></param>
        /// <param name="customers"></param>
        /// <param name="bookings"></param>
        /// <param name="shows"></param>
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

        /// <summary>
        /// Returns a empty StackPanel to create a new Cinema object
        /// </summary>
        /// <returns></returns>
        public static StackPanel GetEmptyPanel()
        {
            StackPanel panel = new StackPanel();

            TextBlock tbkName = new TextBlock()
            {
                Text = "Name",
                FontWeight = FontWeights.Bold
            };
            TextBox tbxName = new TextBox();

            panel.Children.Add(tbkName);
            panel.Children.Add(tbxName);

            return panel;
        }

        /// <summary>
        /// Create a new Customer object give the StackPanel
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>
        public static Cinema GetNewFromPanel(StackPanel panel)
        {
            string name = ((TextBox)panel.Children[1]).Text;

            return new Cinema(name);
        }
    }
}
