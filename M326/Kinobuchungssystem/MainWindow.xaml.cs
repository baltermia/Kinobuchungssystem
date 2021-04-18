using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kinobuchungssystem
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Controller controller;

        private const string DATA = @"..\..\Data.json";

        public MainWindow()
        {
            InitializeComponent();

            controller = new Controller(DATA);

            LoadCombobox();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            controller.Save(DATA);
        }

        private Cinema GetSelectedCinema()
        {
            return (Cinema)cbxCinemas.SelectedItem;
        }

        private void LoadDataGrids(Cinema cinema = null)
        {
            cinema = cinema ?? GetSelectedCinema();

            // .ToList() is necessary as otherwise the list wouldn't be updated correctly (because of IEnumerable)
            grdRoom.ItemsSource = cinema?.Rooms.ToList();
            grdMovie.ItemsSource = cinema?.Movies.ToList();
            grdCustomer.ItemsSource = cinema?.Customers.ToList();
            grdShow.ItemsSource = cinema?.Shows.ToList();
            grdBooking.ItemsSource = cinema?.Bookings.ToList();
        }

        private void LoadCombobox()
        {
            cbxCinemas.ItemsSource = null;
            cbxCinemas.ItemsSource = controller.Cinemas.ToList();
        }

        private void ShowEditWindow(IEditObject obj)
        {
            bool? result = new EditWindow(obj, GetSelectedCinema()).ShowDialog();

            if (result == true)
            {
                LoadDataGrids();
            }
        }

        private void cbxCinemas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cinema cinema = GetSelectedCinema();
            LoadDataGrids(cinema);

            bool enabled = cinema != null;

            btnNewRoom.IsEnabled = enabled;
            btnNewMovie.IsEnabled = enabled;
            btnNewCustomer.IsEnabled = enabled;
            btnNewShow.IsEnabled = enabled;
            btnNewBooking.IsEnabled = enabled;
        }

        #region Room Grid
        private void btnNewRoom_Click(object sender, RoutedEventArgs e)
        {
            StackPanel panel = new AddWindow(Room.GetEmptyPanel()).ShowWindow();

            if (panel == null)
            {
                return;
            }

            Room room = Room.GetNewFromGrid(panel);

            GetSelectedCinema().Rooms.Add(room);
            LoadDataGrids();
        }

        private void btnEditRoom_Click(object sender, RoutedEventArgs e)
        {
            ShowEditWindow((Room)((Button)e.Source).DataContext);
        }

        private void btnDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            GetSelectedCinema()?.Rooms.Remove((Room)((Button)e.Source).DataContext);
            LoadDataGrids();
        }
        #endregion

        #region Movie Grid
        private void btnNewMovie_Click(object sender, RoutedEventArgs e)
        {
            StackPanel panel = new AddWindow(Movie.GetEmptyPanel()).ShowWindow();

            if (panel == null)
            {
                return;
            }

            Movie movie = Movie.GetNewFromPanel(panel);

            GetSelectedCinema().Movies.Add(movie);
            LoadDataGrids();
        }

        private void btnEditMovie_Click(object sender, RoutedEventArgs e)
        {
            ShowEditWindow((Movie)((Button)e.Source).DataContext);
        }

        private void btnDeleteMovie_Click(object sender, RoutedEventArgs e)
        {
            GetSelectedCinema()?.Movies.Remove((Movie)((Button)e.Source).DataContext);
            LoadDataGrids();
        }
        #endregion

        #region Customer Grid
        private void btnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            StackPanel panel = new AddWindow(Customer.GetEmptyPanel()).ShowWindow();

            if (panel == null)
            {
                return;
            }

            Customer customer = Customer.GetNewFromGrid(panel);

            GetSelectedCinema().Customers.Add(customer);
            LoadDataGrids();
        }
        private void btnEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            ShowEditWindow((Customer)((Button)e.Source).DataContext);
        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            GetSelectedCinema()?.Customers.Remove((Customer)((Button)e.Source).DataContext);
            LoadDataGrids();
        }
        #endregion

        #region Show Grid
        private void btnNewShow_Click(object sender, RoutedEventArgs e)
        {
            StackPanel panel = new AddWindow(Kinobuchungssystem.Show.GetEmptyPanel(GetSelectedCinema())).ShowWindow();

            if (panel == null)
            {
                return;
            }

            Show show = Kinobuchungssystem.Show.GetNewFromPanel(panel);

            GetSelectedCinema().Shows.Add(show);
            LoadDataGrids();
        }
        private void btnEditShow_Click(object sender, RoutedEventArgs e)
        {
            ShowEditWindow((Show)((Button)e.Source).DataContext);
        }

        private void btnDeleteShow_Click(object sender, RoutedEventArgs e)
        {
            GetSelectedCinema()?.Shows.Remove((Show)((Button)e.Source).DataContext);
            LoadDataGrids();
        }
        #endregion

        #region Booking Grid
        private void btnNewBooking_Click(object sender, RoutedEventArgs e)
        {
            StackPanel panel = new AddWindow(Booking.GetEmptyPanel(GetSelectedCinema())).ShowWindow();

            if (panel == null)
            {
                return;
            }

            Booking booking= Booking.GetNewFromPanel(panel);

            GetSelectedCinema().Bookings.Add(booking);
            LoadDataGrids();
        }
        private void btnEditBooking_Click(object sender, RoutedEventArgs e)
        {
            ShowEditWindow((Booking)((Button)e.Source).DataContext);
        }

        private void btnDeleteBooking_Click(object sender, RoutedEventArgs e)
        {
            GetSelectedCinema()?.Bookings.Remove((Booking)((Button)e.Source).DataContext);
            LoadDataGrids();
        }
        #endregion

        #region Cinema
        private void btnNewCinema_Click(object sender, RoutedEventArgs e)
        {
            StackPanel panel = new AddWindow(Cinema.GetPanel()).ShowWindow();

            if (panel == null)
            {
                return;
            }

            Cinema cinema = Cinema.GetNewFromPanel(panel);
            controller.Cinemas.Add(cinema);

            LoadCombobox();

            cbxCinemas.SelectedItem = cbxCinemas.Items[cbxCinemas.Items.Count - 1];
        }

        private void btnDeleteCinema_Click(object sender, RoutedEventArgs e)
        {
            Cinema cinema = GetSelectedCinema();

            MessageBoxResult result = MessageBox.Show("Sind Sie sicher, dass Sie dieses Kino löschen wollen? Kino: " + cinema.ToString(), 
                "Kino löschen", 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                controller.Cinemas.Remove(cinema);
                LoadCombobox();
            }
        }
        #endregion
    }
}
