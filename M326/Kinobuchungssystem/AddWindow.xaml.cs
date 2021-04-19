using System.Windows;
using System.Windows.Controls;

namespace Kinobuchungssystem
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        /// <summary>
        /// Creates a new instance of AddWindow
        /// </summary>
        /// <param name="panel">StackPanel which should be shown</param>
        public AddWindow(StackPanel panel)
        {
            InitializeComponent();

            brdFields.Child = panel;

            ChangeToSize();
        }

        /// <summary>
        /// Shows the AddWindow and returns the StackPanel if the user clicks the 'save' button
        /// </summary>
        /// <returns></returns>
        public StackPanel ShowWindow()
        {
            if (ShowDialog() != true)
            {
                return null;
            }

            return brdFields.Child as StackPanel;
        }

        /// <summary>
        /// Call ChangeToSize() if the window size got changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ChangeToSize();
        }

        /// <summary>
        /// Change the window size to fit the content
        /// </summary>
        private void ChangeToSize()
        {
            Height = lblTitle.ActualHeight + btnCreate.ActualHeight + brdFields.ActualHeight + 70;
        }

        /// <summary>
        /// Sets the DialogResult to true which automatically closes the Dialog and return true (see ShowWindow() Method)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
