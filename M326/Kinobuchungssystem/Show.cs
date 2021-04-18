using System;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace Kinobuchungssystem
{
    public class Show : IEditObject
    {
        public Room Room { get; private set; }

        public Movie Movie { get; private set; }

        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }

        public Show(Room room, Movie movie, DateTime start, DateTime end)
        {
            Room = room;
            Movie = movie;
            Start = start;
            End = end;
        }

        public override string ToString()
        {
            return Movie?.Title + " in " + Room?.Name + " am " + Start.ToString("dd.MM.yyyy") + " von " + Start.ToString("HH:mm") + "-" + End.ToString("HH:mm");
        }

        private static StackPanel CreatePanel(Cinema cinema, Room room = null, Movie movie = null, DateTime? start = null, DateTime? end = null)
        {
            StackPanel panel = new StackPanel();

            TextBlock tbkRoom = new TextBlock()
            {
                Text = "Saal",
                FontWeight = FontWeights.Bold
            };
            ComboBox cbxRoom = new ComboBox()
            {
                ItemsSource = cinema.Rooms,
                SelectedItem = room
            };

            TextBlock tbkMovie= new TextBlock()
            {
                Text = "Film",
                FontWeight = FontWeights.Bold
            };
            ComboBox cbxMovie = new ComboBox()
            {
                ItemsSource = cinema.Movies,
                SelectedItem = movie
            };

            TextBlock tbkStart = new TextBlock()
            {
                Text = "Start",
                FontWeight = FontWeights.Bold
            };
            DateTimePicker dpkStart = new DateTimePicker()
            {
                Value = start
            };

            TextBlock tbkEnd = new TextBlock()
            {
                Text = "Ende",
                FontWeight = FontWeights.Bold
            };
            DateTimePicker dpkEnd = new DateTimePicker()
            {
                Value = end
            };

            panel.Children.Add(tbkRoom);
            panel.Children.Add(cbxRoom);
            panel.Children.Add(tbkMovie);
            panel.Children.Add(cbxMovie);
            panel.Children.Add(tbkStart);
            panel.Children.Add(dpkStart);
            panel.Children.Add(tbkEnd);
            panel.Children.Add(dpkEnd);

            return panel;
        }
        public static StackPanel GetEmptyPanel(Cinema cinema)
        {
            return CreatePanel(cinema);
        }

        public static Show GetNewFromPanel(StackPanel panel)
        {
            Room room = (Room)((ComboBox)panel.Children[1]).SelectedItem;
            Movie movie = (Movie)((ComboBox)panel.Children[3]).SelectedItem;
            DateTime start = ((DateTimePicker)panel.Children[5]).Value ?? DateTime.MinValue;
            DateTime end = ((DateTimePicker)panel.Children[7]).Value ?? DateTime.MaxValue;

            return new Show(room, movie, start, end);
        }

        public StackPanel GetPanel(Cinema cinema)
        {
            return CreatePanel(cinema, Room, Movie, Start, End);
        }

        public void EditFromPanel(StackPanel panel)
        {
            Room room = (Room)((ComboBox)panel.Children[1]).SelectedItem;
            Movie movie = (Movie)((ComboBox)panel.Children[3]).SelectedItem;
            DateTime start = ((DateTimePicker)panel.Children[5]).Value ?? DateTime.MinValue;
            DateTime end = ((DateTimePicker)panel.Children[7]).Value ?? DateTime.MaxValue;

            Room = room ?? Room;
            Movie = movie ?? Movie;
            Start = start == null ? Start : start;
            End = end == null ? End : end;
        }
    }
}
