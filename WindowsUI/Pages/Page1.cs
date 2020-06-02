using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsUI
{
    public partial class Page1 : UserControl
    {
        #region properties

        #endregion

        #region variables

        int cnt = 0;

        #endregion

        #region init and load

        public Page1()
        {
            InitializeComponent();
        }

        private void Page1_Load(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                ctl.MouseDown += new MouseEventHandler(base_MouseDown);
            }


            RefreshLabels(new object(), new EventArgs());

            GlobalConfig.LanguageChanged += new EventHandler(RefreshLabels);
        }

        public void RefreshLabels(object sender, EventArgs e)
        {
            label1.Text = String.Format("{0} {1}", Phrases.GetPhrase("PAGE1"), cnt);
            cnt++;
        }

        private void base_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        #endregion

        #region button clicks

        public void Step1ButtonClicked(string str)
        {
            SendMessageBox(Phrases.GetPhrase("PAGE1"));
        }

        #endregion

        #region message Box

        private void SendMessageBox(string txt)
        {
            PopupMessageBox msgBox = new PopupMessageBox();
            //msgBox.UseButtons = "YN";
            msgBox.FColor = Color.White;
            msgBox.BColor = Color.Orange;
            msgBox.LabelText = Phrases.GetPhrase("PAGE1");
            if (msgBox.ShowDialog() == DialogResult.Yes)
            {
            }
            else
            {
            }
            msgBox.Dispose();

        }

        #endregion
    }
}
