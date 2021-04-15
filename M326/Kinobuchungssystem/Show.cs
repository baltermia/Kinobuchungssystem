using System;

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
    }
}
