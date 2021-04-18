using System;
using System.Windows;
using System.Windows.Controls;

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

        public static StackPanel GetPanel()
        {
            StackPanel panel = new StackPanel();

            TextBlock tbkName = new TextBlock()
            {
                Text = "Name",
                FontWeight = FontWeights.Bold
            };
            TextBox tbxName = new TextBox();

            TextBlock tbkSeats = new TextBlock()
            {
                Text = "Sitzplätze",
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 10, 0, 0)
            };
            TextBox tbxSeats = new TextBox();

            panel.Children.Add(tbkName);
            panel.Children.Add(tbxName);
            panel.Children.Add(tbkSeats);
            panel.Children.Add(tbxSeats);

            return panel;
        }

        public static Room GetNewFromGrid(Panel panel)
        {
            string name = ((TextBox)panel.Children[1]).Text;
            int seats = Convert.ToInt32(((TextBox)panel.Children[3]).Text);

            return new Room(name, seats);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
