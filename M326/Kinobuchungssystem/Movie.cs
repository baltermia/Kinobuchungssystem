namespace Kinobuchungssystem
{
    public class Movie
    {
		public readonly string Title;
		
		public readonly string Genre;
		
		public readonly int Length;
		
		public Movie(string title, string genre, int length)
        {
			Title = title;
			Genre = genre;
			Length = length;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
