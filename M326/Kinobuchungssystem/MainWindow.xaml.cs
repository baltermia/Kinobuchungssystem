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
            cinema = cinema ?? GetSelectedCinema();

            // .ToList() is necessary as otherwise the list wouldn't be updated correctly (because of IEnumerable)
            grdRoom.ItemsSource = cinema?.Rooms.ToList();
            grdMovie.ItemsSource = cinema?.Movies.ToList();
            grdCustomer.ItemsSource = cinema?.Customers.ToList();
            grdShow.ItemsSource = cinema?.Shows.ToList();
            grdBooking.ItemsSource = cinema?.Bookings.ToList();
        }

        private void ShowAddWindow<T>() where T : ICinemaType
        {
            AddWindow.GetInstance<T>(GetSelectedCinema()).ShowDialog();
            LoadDataGrids();
        }

        private void ShowEditWindow(ICinemaType type)
        {

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
            ShowAddWindow((Room)((Button)e.Source).DataContext);
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
            ShowAddWindow((Movie)((Button)e.Source).DataContext);

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
            ShowAddWindow((Customer)((Button)e.Source).DataContext);

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
            ShowAddWindow((Customer)((Button)e.Source).DataContext);
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
            ShowAddWindow((Booking)((Button)e.Source).DataContext);
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
    }
}
