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

        private const string DATA = @"C:\Users\clopathba\Documents\GitHub\M326\M326\Kinobuchungssystem\Data.json";

        public MainWindow()
        {
            InitializeComponent();

            controller = new Controller(DATA);

            cbxCinemas.ItemsSource = controller.Cinemas;
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
            // .ToList() is necessary as otherwise the list wouldn't be updated correctly (because of IEnumerable)
            grdRoom.ItemsSource = (cinema ?? GetSelectedCinema()).Rooms.ToList();
            grdMovie.ItemsSource = (cinema ?? GetSelectedCinema()).Movies.ToList();
            grdCustomer.ItemsSource = (cinema ?? GetSelectedCinema()).Customers.ToList();
            grdShow.ItemsSource = (cinema ?? GetSelectedCinema()).Shows.ToList();
            grdBooking.ItemsSource = (cinema ?? GetSelectedCinema()).Bookings.ToList();
        }

        private void cbxCinemas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadDataGrids();
        }

        #region Room Grid
        private void btnNewRoom_Click(object sender, RoutedEventArgs e)
        {
            // Todo: Send Room to CreateObjectWindow
            //LoadDataGrids();
        }

        private void btnEditRoom_Click(object sender, RoutedEventArgs e)
        {
            // Open EditWindow
            //Room item = (Room)((Button)e.Source).DataContext;
        }

        private void btnDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            GetSelectedCinema().Rooms.Remove((Room)((Button)e.Source).DataContext);
            LoadDataGrids();
        }
        #endregion

        #region Movie Grid
        private void btnNewMovie_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditMovie_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteMovie_Click(object sender, RoutedEventArgs e)
        {
            GetSelectedCinema().Movies.Remove((Movie)((Button)e.Source).DataContext);
            LoadDataGrids();
        }
        #endregion

        #region Customer Grid
        private void btnNewCustomer_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnEditCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            GetSelectedCinema().Customers.Remove((Customer)((Button)e.Source).DataContext);
            LoadDataGrids();
        }
        #endregion

        #region Show Grid
        private void btnNewShow_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnEditShow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteShow_Click(object sender, RoutedEventArgs e)
        {
            GetSelectedCinema().Shows.Remove((Show)((Button)e.Source).DataContext);
            LoadDataGrids();
        }
        #endregion

        #region Booking Grid
        private void btnEditBooking_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNewBooking_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteBooking_Click(object sender, RoutedEventArgs e)
        {
            GetSelectedCinema().Bookings.Remove((Booking)((Button)e.Source).DataContext);
            LoadDataGrids();
        }
        #endregion
    }
}
