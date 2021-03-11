using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinobuchungssystem
{
    class Movie
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
    }
}
