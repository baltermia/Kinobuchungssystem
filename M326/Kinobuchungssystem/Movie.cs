using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace Kinobuchungssystem
{
    public class Movie : IEditObject
    {
		public string Title { get; private set; }
		
		public string Genre { get; private set; }
		
		public int Length { get; private set; }
		
        /// <summary>
        /// Creates a new instance of Movie
        /// </summary>
        /// <param name="title"></param>
        /// <param name="genre"></param>
        /// <param name="length"></param>
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

        /// <summary>
        /// Creates a new StackPanel with the given parameters (if they're set)
        /// </summary>
        /// <param name="title"></param>
        /// <param name="genre"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static StackPanel CreatePanel(string title = null, string genre = null, int? length = null)
        {
            StackPanel panel = new StackPanel();

            TextBlock tbkTitle = new TextBlock()
            {
                Text = "Title",
                FontWeight = FontWeights.Bold
            };
            TextBox tbxTitle = new TextBox()
            {
                Text = title ?? ""
            };

            TextBlock tbkGenre = new TextBlock()
            {
                Text = "Genre",
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 10, 0, 0)
            };
            TextBox tbxGenre = new TextBox()
            {
                Text = genre ?? ""
            };

            TextBlock tbkLength = new TextBlock()
            {
                Text = "Länge",
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 10, 0, 0)
            };
            IntegerUpDown numLength = new IntegerUpDown()
            {
                ParsingNumberStyle = NumberStyles.Integer,
                Text = length?.ToString() ?? ""
            };

            panel.Children.Add(tbkTitle);
            panel.Children.Add(tbxTitle);
            panel.Children.Add(tbkGenre);
            panel.Children.Add(tbxGenre);
            panel.Children.Add(tbkLength);
            panel.Children.Add(numLength);

            return panel;
        }

        /// <summary>
        /// Returns a empty StackPanel to create a new Movie object
        /// </summary>
        /// <returns></returns>
		public static StackPanel GetEmptyPanel()
        {
            return CreatePanel();
        }

        /// <summary>
        /// Create a new Movie object give the StackPanel
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>
        public static Movie GetNewFromPanel(StackPanel panel)
        {
            string title = ((TextBox)panel.Children[1]).Text;
            string genre = ((TextBox)panel.Children[3]).Text;
            int length = ((IntegerUpDown)panel.Children[5]).Value ?? -1;

            return new Movie(title, genre, length);
        }

        public StackPanel GetPanel(Cinema cinemas = null)
        {
            return CreatePanel(Title, Genre, Length);
        }

        public void EditFromPanel(StackPanel panel)
        {
            string title = ((TextBox)panel.Children[1]).Text;
            string genre = ((TextBox)panel.Children[3]).Text;
            int length = ((IntegerUpDown)panel.Children[5]).Value ?? -1;

            Title = title == "" || title == null ? Title: title;
            Genre = genre == "" || genre == null ? Genre: genre;
            Length = length != -1 ? length : Length;
        }
    }
}
