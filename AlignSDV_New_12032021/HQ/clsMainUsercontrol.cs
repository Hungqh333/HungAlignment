using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HQ
{
    class clsMainUsercontrol
    {
        public static void showControl(Control control, Control content)
        {
            // Clear data in control
            content.Controls.Clear();
            // Property for control
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            control.Focus();
            // Add data
            content.Controls.Add(control);
        }

        public static void hideControl(Control control, Control content)
        {
            // Clear data in control
            content.Controls.Clear();
            // Property for control
            
        }
    }
}
