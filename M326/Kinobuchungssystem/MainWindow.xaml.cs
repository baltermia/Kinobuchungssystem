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
        /// <summary>
        /// Controller object
        /// </summary>
        private readonly Controller controller;

        /// <summary>
        /// Path to the Data.json file. The file includes all objects stored in the controller object
        /// </summary>
        private const string DATA = @"..\..\Data.json";

        /// <summary>
        /// Creates a new instance of MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            //Get controller with the objects from the Data.json file
            controller = new Controller(DATA);

            //Reload comboboxes
            LoadCombobox();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            //When the window closes again, save the data in the json file again
            controller.Save(DATA);
        }

        /// <summary>
        /// Returns the Cinema which is currently selected in the cbxCinemas combobox
        /// </summary>
        /// <returns></returns>
        private Cinema GetSelectedCinema()
        {
            return (Cinema)cbxCinemas.SelectedItem;
        }

        /// <summary>
        /// Loads all the data into the datagrids (basically a reload)
        /// </summary>
        /// <param name="cinema"></param>
        private void LoadDataGrids(Cinema cinema = null)
        {
            //If the given cinema is null, get the selected cinema
            cinema = cinema ?? GetSelectedCinema();

            // .ToList() is necessary as otherwise the list wouldn't be updated correctly (because of IEnumerable)
            grdRoom.ItemsSource = cinema?.Rooms.ToList();
            grdMovie.ItemsSource = cinema?.Movies.ToList();
            grdCustomer.ItemsSource = cinema?.Customers.ToList();
            grdShow.ItemsSource = cinema?.Shows.ToList();
            grdBooking.ItemsSource = cinema?.Bookings.ToList();
        }

        /// <summary>
        /// Loads all the cinemas into the combobox (basically a reload)
        /// </summary>
        private void LoadCombobox()
        {
            //Clear the source and set it to the Cinemas list again. (.ToList() is neccessary)
            cbxCinemas.ItemsSource = null;
            cbxCinemas.ItemsSource = controller.Cinemas.ToList();

            //If the selected item is null and there is at least one cinema in the combobox, select the first one in the list
            if (cbxCinemas.SelectedItem == null && cbxCinemas.Items.Count >= 1)
            {
                cbxCinemas.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Shows the Editwindow with the given IEditObject
        /// </summary>
        /// <param name="obj"></param>
        private void ShowEditWindow(IEditObject obj)
        {
            bool? result = new EditWindow(obj, GetSelectedCinema()).ShowDialog();

            //If the result is true (meaning the user clicked on 'save') reload the datagrids to show the changes
            if (result == true)
            {
                LoadDataGrids();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxCinemas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Get the current cinema and reload the datagrids
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
            //Open the AddWindow with the Panel and get the edited one back
            StackPanel panel = new AddWindow(Room.GetEmptyPanel()).ShowWindow();

            //If no panel was returned (meaning it's value is null) return immediately
            if (panel == null)
            {
                return;
            }

            //Get the new room object from the grid
            Room room = Room.GetNewFromGrid(panel);

            //Add the new room to the list and reload the datagrids
            GetSelectedCinema().Rooms.Add(room);
            LoadDataGrids();
        }

        private void btnEditRoom_Click(object sender, RoutedEventArgs e)
        {
            //Show the EditWindow with the object
            ShowEditWindow((Room)((Button)e.Source).DataContext);
        }

        private void btnDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            //Delete the 
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
            StackPanel panel = new AddWindow(Cinema.GetEmptyPanel()).ShowWindow();

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
