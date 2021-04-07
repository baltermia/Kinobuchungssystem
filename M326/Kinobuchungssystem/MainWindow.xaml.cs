using System;
using System.Collections.Generic;
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

            controller.Save(DATA);

            cbxCinemas.ItemsSource = controller.Cinemas;
        }
    }
}
