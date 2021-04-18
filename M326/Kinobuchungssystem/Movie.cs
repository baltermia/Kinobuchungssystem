using System;
using System.Windows;
using System.Windows.Controls;

namespace Kinobuchungssystem
{
    public class Movie
    {
		public readonly string Title;
		
		public readonly string Genre;
		
		public readonly int Length;
		
		public Movie(string title, string genre, int length)
        {
			Title = title;
			Genre = genre;
			Length = length;
        }

        public override string ToString()
        {
            return Title;
        }

		public static StackPanel GetPanel()
        {
            StackPanel panel = new StackPanel();

            TextBlock tbkTitle = new TextBlock()
            {
                Text = "Title",
                FontWeight = FontWeights.Bold
            };
            TextBox tbxTitle = new TextBox();

            TextBlock tbkGenre = new TextBlock()
            {
                Text = "Genre",
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 10, 0, 0)
            };
            TextBox tbxGenre = new TextBox();

            TextBlock tbkLength = new TextBlock()
            {
                Text = "Länge",
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 10, 0, 0)
            };
            TextBox tbxLength = new TextBox();

            panel.Children.Add(tbkTitle);
            panel.Children.Add(tbxTitle);
            panel.Children.Add(tbkGenre);
            panel.Children.Add(tbxGenre);
            panel.Children.Add(tbkLength);
            panel.Children.Add(tbxLength);

            return panel;
        }

        public static Movie GetNewFromPanel(StackPanel panel)
        {
            string title = ((TextBox)panel.Children[1]).Text;
            string genre = ((TextBox)panel.Children[3]).Text;
            int seats = Convert.ToInt32(((TextBox)panel.Children[5]).Text);

            return new Movie(title, genre, seats);
        }
    }
}
