using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace WindowsUI
{
    public partial class AboutControl : UserControl
    {
        #region properties

        private string AssemblyTitle
        {
            get
            {
                string _title = "";
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                    _title = ((AssemblyTitleAttribute)attributes[0]).Title;

                return _title;
            }
        }

        private string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        private string AssemblyDescription
        {
            get
            {
                string _desc = "";
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length > 0)
                    _desc = ((AssemblyDescriptionAttribute)attributes[0]).Description;

                return _desc;
            }
        }

        private string AssemblyCopyright
        {
            get
            {
                string _cpw = "";
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length > 0)
                    _cpw = ((AssemblyCopyrightAttribute)attributes[0]).Copyright;

                return _cpw;
            }
        }

        #endregion

        public AboutControl()
        {
            InitializeComponent();
        }

        private void AboutControl_Load(object sender, EventArgs e)
        {
            assemblyLabel.Text = AssemblyTitle;
            versionLabel.Text = AssemblyVersion;
            descLabel.Text = AssemblyDescription;
            copyrighLtabel.Text = AssemblyCopyright;
        }

        private void descLabel_Click(object sender, EventArgs e)
        {

        }

        private void versionLabel_Click(object sender, EventArgs e)
        {

        }

        private void copyrighLtabel_Click(object sender, EventArgs e)
        {

        }

        private void assemblyLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
