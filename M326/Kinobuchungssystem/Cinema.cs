using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinobuchungssystem
{
    public class Cinema
    {
		public readonly string Name;

        public readonly SimpleCollection<Room> Rooms;

		public Cinema(string name, IEnumerable<Room> rooms = null)
        {
            Name = name;
            Rooms = new SimpleCollection<Room>(rooms);
        }
    }
}
