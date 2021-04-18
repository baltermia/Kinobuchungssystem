using System.Windows;
using System.Windows.Controls;

namespace Kinobuchungssystem
{
    public class Booking
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

        public static StackPanel GetPanel(Cinema cinema)
        {
            StackPanel panel = new StackPanel();

            TextBlock tbkShow = new TextBlock()
            {
                Text = "Vorführung",
                FontWeight = FontWeights.Bold
            };
            ComboBox cbxShow = new ComboBox()
            {
                ItemsSource = cinema.Shows
            };

            TextBlock tbkCustomer = new TextBlock()
            {
                Text = "Kunde",
                FontWeight = FontWeights.Bold
            };
            ComboBox cbxCustomer = new ComboBox()
            {
                ItemsSource = cinema.Customers
            };

            panel.Children.Add(tbkShow);
            panel.Children.Add(cbxShow);
            panel.Children.Add(tbkCustomer);
            panel.Children.Add(cbxCustomer);

            return panel;
        }

        public static Booking GetNewFromPanel(StackPanel panel)
        {
            Show show = (Show)((ComboBox)panel.Children[1]).SelectedItem;
            Customer customer = (Customer)((ComboBox)panel.Children[3]).SelectedItem;

            return new Booking(show, customer);
        }
    }
}
