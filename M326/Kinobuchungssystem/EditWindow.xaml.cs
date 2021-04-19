using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Kinobuchungssystem
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private readonly IEditObject Obj;

        private readonly Cinema Cinema;

        public EditWindow(IEditObject obj, Cinema cinema = null)
        {
            InitializeComponent();

            Obj = obj;
            Cinema = cinema;

            brdFields.Child = Obj.GetPanel(Cinema);

            ChangeToSize();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ChangeToSize();
        }

        private void ChangeToSize()
        {
            Height = lblTitle.ActualHeight + btnSave.ActualHeight + brdFields.ActualHeight + 70;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

            Obj.EditFromPanel((StackPanel)brdFields.Child);
        }
    }
}
