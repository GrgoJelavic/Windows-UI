using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsUI
{
    public static class Util
    {
        public static ToolTip toolTip = new ToolTip();

        public static void Control_MouseHover(object sender, EventArgs e)
        {
            Control ctl = sender as Control;

            toolTip.SetToolTip(ctl, ctl.Name);
        }
    }
}
