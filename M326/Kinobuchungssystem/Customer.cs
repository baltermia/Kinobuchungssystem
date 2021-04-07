using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinobuchungssystem
{
    public class Customer
    {
		public readonly string Firstname;

		public readonly string Lastname;

		public Customer(string firstname, string lastname)
        {
			Firstname = firstname;

			Lastname = lastname;
        }
    }
}
