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
            grdRoom.ItemsSource = null;
            grdRoom.ItemsSource = (cinema ?? GetSelectedCinema()).Rooms;

            Cinema temp = GetSelectedCinema();
        }

        private void cbxCinemas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadDataGrids();
        }

        private void btnNewRoom_Click(object sender, RoutedEventArgs e)
        {
            GetSelectedCinema().Rooms.Add(new Room("Temp-Room", 2));
            LoadDataGrids();
        }

        private void btnEditRoom_Click(object sender, RoutedEventArgs e)
        {
            // Open EditWindow
            // Room item = (Room)((Button)e.Source).DataContext;
        }

        private void btnDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            GetSelectedCinema().Rooms.Remove((Room)((Button)e.Source).DataContext);
            LoadDataGrids();
        }

        private void btnDeleteMovie_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditMovie_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditShow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteShow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditBooking_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteBooking_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
