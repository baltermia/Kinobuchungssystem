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

        public override string ToString()
        {
            return Firstname + ", " + Lastname;
        }
    }
}
