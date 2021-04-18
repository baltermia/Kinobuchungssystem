using System;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace Kinobuchungssystem
{
    public class Show
    {
        public readonly Room Room;

        public readonly Movie Movie;

        public readonly DateTime Start;

        public readonly DateTime End;

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

        public static StackPanel GetPanel(Cinema cinema)
        {
            StackPanel panel = new StackPanel();

            TextBlock tbkRoom = new TextBlock()
            {
                Text = "Saal",
                FontWeight = FontWeights.Bold
            };
            ComboBox cbxRoom = new ComboBox()
            {
                ItemsSource = cinema.Rooms
            };

            TextBlock tbkMovie= new TextBlock()
            {
                Text = "Film",
                FontWeight = FontWeights.Bold
            };
            ComboBox cbxMovie = new ComboBox()
            {
                ItemsSource = cinema.Movies
            };

            TextBlock tbkStart = new TextBlock()
            {
                Text = "Start",
                FontWeight = FontWeights.Bold
            };
            DateTimePicker dpkStart = new DateTimePicker();

            TextBlock tbkEnd = new TextBlock()
            {
                Text = "Ende",
                FontWeight = FontWeights.Bold
            };
            DateTimePicker dpkEnd = new DateTimePicker();

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

        public static Show GetNewFromPanel(StackPanel panel)
        {
            Room room = (Room)((ComboBox)panel.Children[1]).SelectedItem;
            Movie movie = (Movie)((ComboBox)panel.Children[3]).SelectedItem;
            DateTime start = ((DatePicker)panel.Children[5]).SelectedDate ?? DateTime.MinValue;
            DateTime end = ((DatePicker)panel.Children[7]).SelectedDate ?? DateTime.MaxValue;

            return new Show(room, movie, start, end);
        }
    }
}
