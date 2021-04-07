using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinobuchungssystem
{
    public class Room
    {
	    public readonly string Name;
		
		public readonly int Seats;

        public Room(string name, int seats)
        {
            Name = name;
            Seats = seats;
        }
    }
}
