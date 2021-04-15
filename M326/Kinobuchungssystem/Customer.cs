namespace Kinobuchungssystem
{
    public class Customer : ICinemaType
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
