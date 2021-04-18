using System;
using System.Windows;
using System.Windows.Controls;

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

        public static StackPanel GetPanel()
        {
            StackPanel panel = new StackPanel();

            TextBlock tbkFirstname = new TextBlock()
            {
                Text = "Name",
                FontWeight = FontWeights.Bold
            };
            TextBox tbxFirstname = new TextBox();

            TextBlock tbkLastname = new TextBlock()
            {
                Text = "Sitzplätze",
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 10, 0, 0)
            };
            TextBox tbxLastname = new TextBox();

            panel.Children.Add(tbkFirstname);
            panel.Children.Add(tbxFirstname);
            panel.Children.Add(tbkLastname);
            panel.Children.Add(tbxLastname);

            return panel;
        }

        public static Customer GetNewFromGrid(Panel panel)
        {
            string firstname = ((TextBox)panel.Children[1]).Text;
            string lastname = ((TextBox)panel.Children[3]).Text;

            return new Customer(firstname, lastname);
        }
    }
}
