namespace Kinobuchungssystem
{
    public class Room : ICinemaType
    {
	    public readonly string Name;
		
		public readonly int Seats;

        public Room(string name, int seats)
        {
            Name = name;
            Seats = seats;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
