using System;

namespace Kinobuchungssystem
{
    public class Show : ICinemaType
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
    }
}
