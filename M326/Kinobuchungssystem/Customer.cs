using System.Windows;
using System.Windows.Controls;

namespace Kinobuchungssystem
{
    public class Customer : IEditObject
    {
		public string Firstname { get; private set; }

		public string Lastname { get; private set; }

        public Customer(string firstname, string lastname)
        {
			Firstname = firstname;

			Lastname = lastname;
        }

        public override string ToString()
        {
            return Firstname + ", " + Lastname;
        }

        /// <summary>
        /// Creates a new StackPanel with the given parameters (if they're set)
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <returns></returns>
        private static StackPanel CreatePanel(string firstname = null, string lastname = null)
        {
            StackPanel panel = new StackPanel();

            TextBlock tbkFirstname = new TextBlock()
            {
                Text = "Vorname",
                FontWeight = FontWeights.Bold
            };
            TextBox tbxFirstname = new TextBox()
            {
                Text = firstname
            };

            TextBlock tbkLastname = new TextBlock()
            {
                Text = "Nachname",
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 10, 0, 0)
            };
            TextBox tbxLastname = new TextBox()
            {
                Text = lastname
            };

            panel.Children.Add(tbkFirstname);
            panel.Children.Add(tbxFirstname);
            panel.Children.Add(tbkLastname);
            panel.Children.Add(tbxLastname);

            return panel;
        }

        /// <summary>
        /// Returns a empty StackPanel to create a new Customer object
        /// </summary>
        /// <returns></returns>
        public static StackPanel GetEmptyPanel()
        {
            return CreatePanel();
        }

        /// <summary>
        /// Create a new Customer object give the StackPanel
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>
        public static Customer GetNewFromGrid(Panel panel)
        {
            string firstname = ((TextBox)panel.Children[1]).Text;
            string lastname = ((TextBox)panel.Children[3]).Text;

            return new Customer(firstname, lastname);
        }

        public StackPanel GetPanel(Cinema cinema = null)
        {
            return CreatePanel(Firstname, Lastname);
        }

        public void EditFromPanel(StackPanel panel)
        {
            string firstname = ((TextBox)panel.Children[1]).Text;
            string lastname = ((TextBox)panel.Children[3]).Text;

            Firstname = firstname == "" || firstname == null ? Firstname : firstname;
            Lastname = lastname == "" || lastname == null ? Lastname : lastname;

        }
    }
}
