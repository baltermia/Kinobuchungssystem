using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kinobuchungssystem
{
    public interface IEditObject
    {
        /// <summary>
        /// Returns a StackPanel filled with the Show objects properties
        /// </summary>
        /// <param name="cinema"></param>
        /// <returns></returns>
        StackPanel GetPanel(Cinema cinema = null);

        /// <summary>
        /// Write all edited properties in the StackPanel into the object
        /// </summary>
        /// <param name="panel"></param>
        void EditFromPanel(StackPanel panel);
    }
}
