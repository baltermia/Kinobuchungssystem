namespace Kinobuchungssystem
{
    public class Booking : ICinemaType
    {
        public readonly Show Show;

        public readonly Customer Customer;

        public Booking(Show show, Customer customer = null)
        {
            Show = show;
            Customer = customer;
        }

        public override string ToString()
        {
            return Customer?.Firstname + " " + Customer?.Lastname + ": " + Show?.ToString();
        }
    }
}
