using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinobuchungssystem
{
    public class Booking
    {
        public readonly Show Show;

        public readonly Customer Customer;

        public Booking(Show show, Customer customer = null)
        {
            Show = show;
            Customer = customer;
        }
    }
}
