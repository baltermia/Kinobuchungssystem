using System.Windows;
using System.Windows.Controls;

namespace Kinobuchungssystem
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow(StackPanel panel)
        {
            InitializeComponent();

            brdFields.Child = panel;

            ChangeToSize();
        }

        public StackPanel ShowWindow()
        {
            if (ShowDialog() != true)
            {
                return null;
            }

            return brdFields.Child as StackPanel;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ChangeToSize();
        }

        private void ChangeToSize()
        {
            Height = lblTitle.ActualHeight + btnCreate.ActualHeight + brdFields.ActualHeight + 70;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
