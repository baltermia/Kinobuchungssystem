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

        /// <summary>
        /// Creates a new instance of Room
        /// </summary>
        /// <param name="name"></param>
        /// <param name="seats"></param>
        public Room(string name, int seats)
        {
            Name = name;
            Seats = seats;
        }

        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Creates a new StackPanel with the given parameters (if they're set)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="seats"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a empty StackPanel to create a new Room
        /// </summary>
        /// <returns></returns>
        public static StackPanel GetEmptyPanel()
        {
            return CreatePanel();
        }

        /// <summary>
        /// Returns a new Room given the StackPanel
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>
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
            int seats = ((IntegerUpDown)panel.Children[3]).Value ?? -1;

            Name = name == "" || name == null ? Name : name;
            Seats = seats != -1 ? seats : Seats;
        }
    }
}
