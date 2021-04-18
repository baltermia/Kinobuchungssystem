using System.Windows;
using System.Windows.Controls;

namespace Kinobuchungssystem
{
    public class Booking : IEditObject
    {
        public Show Show { get; private set; }

        public Customer Customer { get; private set; }

        public Booking(Show show, Customer customer = null)
        {
            Show = show;
            Customer = customer;
        }

        public override string ToString()
        {
            return Customer?.Firstname + " " + Customer?.Lastname + ": " + Show?.ToString();
        }

        private static StackPanel CreatePanel(Cinema cinema, Show show = null, Customer customer = null)
        {
            StackPanel panel = new StackPanel();

            TextBlock tbkShow = new TextBlock()
            {
                Text = "Vorführung",
                FontWeight = FontWeights.Bold
            };
            ComboBox cbxShow = new ComboBox()
            {
                ItemsSource = cinema.Shows,
                SelectedItem = show
            };

            TextBlock tbkCustomer = new TextBlock()
            {
                Text = "Kunde",
                FontWeight = FontWeights.Bold
            };
            ComboBox cbxCustomer = new ComboBox()
            {
                ItemsSource = cinema.Customers,
                SelectedItem = customer
            };

            panel.Children.Add(tbkShow);
            panel.Children.Add(cbxShow);
            panel.Children.Add(tbkCustomer);
            panel.Children.Add(cbxCustomer);

            return panel;
        }
        public static StackPanel GetEmptyPanel(Cinema cinema)
        {
            return CreatePanel(cinema);
        }

        public static Booking GetNewFromPanel(StackPanel panel)
        {
            Show show = (Show)((ComboBox)panel.Children[1]).SelectedItem;
            Customer customer = (Customer)((ComboBox)panel.Children[3]).SelectedItem;

            return new Booking(show, customer);
        }

        public StackPanel GetPanel(Cinema cinema)
        {
            return CreatePanel(cinema, Show, Customer);
        }

        public void EditFromPanel(StackPanel panel)
        {
            Show show = (Show)((ComboBox)panel.Children[1]).SelectedItem;
            Customer customer = (Customer)((ComboBox)panel.Children[3]).SelectedItem;

            Show = show ?? Show;
            Customer = customer ?? Customer;
        }
    }
}
