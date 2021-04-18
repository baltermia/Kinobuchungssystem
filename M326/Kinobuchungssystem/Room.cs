using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace Kinobuchungssystem
{
    public class Room : IEditObject
    {
        public string Name { get; private set; }

        public int Seats { get; private set; }

        public Room(string name, int seats)
        {
            Name = name;
            Seats = seats;
        }

        public override string ToString()
        {
            return Name;
        }

        private static StackPanel CreatePanel(string name = null, int? seats = null)
        {
            StackPanel panel = new StackPanel();

            TextBlock tbkName = new TextBlock()
            {
                Text = "Name",
                FontWeight = FontWeights.Bold
            };
            TextBox tbxName = new TextBox()
            {
                Text = name
            };

            TextBlock tbkSeats = new TextBlock()
            {
                Text = "Sitzplätze",
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 10, 0, 0)
            };
            IntegerUpDown numSeats = new IntegerUpDown() 
            { 
                ParsingNumberStyle = NumberStyles.Integer,
                Value = seats
            };

            panel.Children.Add(tbkName);
            panel.Children.Add(tbxName);
            panel.Children.Add(tbkSeats);
            panel.Children.Add(numSeats);

            return panel;
        }
        public static StackPanel GetEmptyPanel()
        {
            return CreatePanel();
        }

        public static Room GetNewFromGrid(Panel panel)
        {
            string name = ((TextBox)panel.Children[1]).Text;
            int seats = ((IntegerUpDown)panel.Children[3]).Value ?? -1;

            return new Room(name, seats);
        }

        public StackPanel GetPanel(Cinema cinemas = null)
        {
            return CreatePanel(Name, Seats);
        }

        public void EditFromPanel(StackPanel panel)
        {
            string name = ((TextBox)panel.Children[1]).Text;
            int seats = ((IntegerUpDown)panel.Children[5]).Value ?? -1;

            Name = name == "" || name == null ? Name : name;
            Seats = seats != -1 ? seats : Seats;
        }
    }
}
