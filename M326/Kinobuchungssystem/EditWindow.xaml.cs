using System.Windows;
using System.Windows.Controls;

namespace Kinobuchungssystem
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private readonly IEditObject Obj;

        private readonly Cinema Cinema;

        /// <summary>
        /// Creates a new instance of EditWindow
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="cinema"></param>
        public EditWindow(IEditObject obj, Cinema cinema = null)
        {
            InitializeComponent();

            Obj = obj;
            Cinema = cinema;

            brdFields.Child = Obj.GetPanel(Cinema);

            ChangeToSize();
        }

        /// <summary>
        /// Calls ChangeToSize() if the windows size got changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ChangeToSize();
        }

        /// <summary>
        /// Changes the windows size to fit the content
        /// </summary>
        private void ChangeToSize()
        {
            Height = lblTitle.ActualHeight + btnSave.ActualHeight + brdFields.ActualHeight + 70;
        }

        /// <summary>
        /// Close the Dialog with by settings its result to true and sending the object the stackpanel to save the changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

            Obj.EditFromPanel((StackPanel)brdFields.Child);
        }
    }
}
