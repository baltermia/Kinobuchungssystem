using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinobuchungssystem
{
    class Cinema
    {
		public readonly string Name;

        public IEnumerable<Room> Rooms => _rooms.Select(r => r.Value);
		
		private readonly Dictionary<int, Room> _rooms;

		public Cinema(string name)
        {
            Name = name;

            _rooms = new Dictionary<int, Room>();
        }

        public void AddRoom(Room room)
        {
            _rooms.Add(_rooms.Count, room);
        }
    }
}
