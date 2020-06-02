using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsUI
{
    public partial class Dashboard : Form
    {
        #region properties

        #endregion

        #region variables

        Page1 page1;
        Page2 page2;
        Page3 page3;

        //ribbon panels
        TableLayoutPanel navigationTableLayoutPanel = new TableLayoutPanel();
        TableLayoutPanel pageTableLayoutPanel = new TableLayoutPanel();



        //labels
        Label titleLabel = new Label();

        //buttons
        Button exitButton = new Button();
        Button aboutButton = new Button();
        Button fullScreenButton = new Button();
        Button languageButton = new Button();
        Button backButton = new Button();
        Button step1Button = new Button();

        bool showFullScreen = false;
        string holdFullScreenCode = "";
        string whichControl = GlobalConfig.DASHBOARD;

        #endregion

        #region init & load


        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            GlobalConfig.LANGUAGE = GlobalConfig.ENGLISH;

            this.Icon = MakeIcon();
            this.MouseDown += new MouseEventHandler(form_MouseDown);
            dashboardPanel.MouseDown += new MouseEventHandler(base_MouseDown);
            titleLabel.MouseDown += new MouseEventHandler(base_MouseDown);
            navigationTableLayoutPanel.MouseDown += new MouseEventHandler(base_MouseDown);

            foreach (DashboardTile dt in dashboardPanel.Controls.OfType<DashboardTile>())
            {
                dt.TileClicked += new EventHandler(dashboardTile_TileClicked);
                dt.TileRightClicked += new EventHandler(dashboardTile_TileRightClicked);
                dt.TileMoved += new EventHandler(dashboardTile_TileMoved);

                dt.RunMethodName = string .Format("{0}_Run", dt.Name);
            }

            //dashboardTile1.TileClicked += new EventHandler(dashboardTile_TileClicked);
            //dashboardTile1.TileRightClicked += new EventHandler(dashboardTile_TileRightClicked);
            //dashboardTile1.TileMoved += new EventHandler(dashboardTile_TileMoved);

            //dashboardTile2.TileClicked += new EventHandler(dashboardTile_TileClicked);
            //dashboardTile2.TileRightClicked += new EventHandler(dashboardTile_TileRightClicked);
            //dashboardTile2.TileMoved += new EventHandler(dashboardTile_TileMoved);


            aboutButton.Click += new EventHandler(delegate { ShowAboutBox(); });
            exitButton.Click += new EventHandler(delegate { ExitApplication(); });
            languageButton.Click += new EventHandler(delegate { ChangeLanguage(); });
            fullScreenButton.Click += new EventHandler(delegate { SetScreen(); });
            backButton.Click += new EventHandler(delegate { ShowDashboard(); });
            step1Button.Click += new EventHandler(delegate { step1ButtonClicked(); });

            aboutButton.MouseHover += new EventHandler(Util.Control_MouseHover);
            exitButton.MouseHover += new EventHandler(Util.Control_MouseHover);
            languageButton.MouseHover += new EventHandler(Util.Control_MouseHover);
            fullScreenButton.MouseHover += new EventHandler(Util.Control_MouseHover);
            step1Button.MouseHover += new EventHandler(Util.Control_MouseHover);
            backButton.MouseHover += new EventHandler(Util.Control_MouseHover);

            BuildNavigationRibbonPanels();

            LoadDashboardTiles();

            SetScreen();

            RefreshLabels(new object(), new EventArgs());

            GlobalConfig.LanguageChanged += new EventHandler(RefreshLabels);
        }

        private void RefreshLabels(object sender, EventArgs e)
        {
            titleLabel.Text = Phrases.GetPhrase("DASHBOARD");
            aboutButton.Name = Phrases.GetPhrase("ABOUT");
            exitButton.Name = Phrases.GetPhrase("EXIT");
            backButton.Name = Phrases.GetPhrase("BACK");
            step1Button.Name = Phrases.GetPhrase("STEP1");

            fullScreenButton.Name = Phrases.GetPhrase(holdFullScreenCode);

        }

        #endregion  

        #region load dashboard tiles

        private void LoadDashboardTiles()
        {
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            titleLabel.ForeColor = Color.Silver;
            titleLabel.TextAlign = ContentAlignment.TopLeft;

            dashboardTopPanel.Controls.Clear();
            dashboardTopPanel.Controls.Add(titleLabel);
        }

        #endregion

        #region dashboard tile events

        private void dashboardTile_TileClicked(object sender, EventArgs e)
        {
            DashboardTile tile = sender as DashboardTile;
            
            this.GetType().InvokeMember(tile.RunMethodName,
                System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.InvokeMethod,
                null, this, new string[] { "" });

            dashboardTopPanel.BackColor = Color.White;
            dashboardTopPanel.Controls.Clear();
            dashboardTopPanel.Controls.Add(pageTableLayoutPanel);

        }

        private void dashboardTile_TileRightClicked(object sender, EventArgs e)
        {
            DashboardTile tile = sender as DashboardTile;

            MessageBox.Show(tile.Name + "tile right clicked");
        }

        private void dashboardTile_TileMoved(object sender, EventArgs e)
        {
            this.Refresh();
        }

        public void dashboardTile1_Run(string str)
        {
            if (page1 == null)
            {
                page1 = new Page1();       
                page1.Dock = DockStyle.Fill;
                page1.MouseDown += new MouseEventHandler(form_MouseDown);
            }

            dashboardBottomPanel.Controls.Clear();
            dashboardBottomPanel.Controls.Add(page1);
            page1.RefreshLabels(null, null);
            step1Button.Tag = page1;
            whichControl = GlobalConfig.PAGE;
        }

        public void dashboardTile2_Run(string str)
        {
            if (page2 == null)
            {
                page2 = new Page2();
                page2.Dock = DockStyle.Fill;
                page2.MouseDown += new MouseEventHandler(form_MouseDown);
            }

            dashboardBottomPanel.Controls.Clear();
            dashboardBottomPanel.Controls.Add(page2);
            page2.RefreshLabels(null, null);
            step1Button.Tag = page2;
            whichControl = GlobalConfig.PAGE;
        }


        public void dashboardTile3_Run(string str)
        {
            if (page3 == null)
            {
                page3 = new Page3();
                page3.Dock = DockStyle.Fill;
                page3.MouseDown += new MouseEventHandler(form_MouseDown);
            }

            dashboardBottomPanel.Controls.Clear();
            dashboardBottomPanel.Controls.Add(page3);
            page3.RefreshLabels(null, null);
            step1Button.Tag = page3;
            whichControl = GlobalConfig.PAGE;
        }

        #endregion


        #region build navigation ribbon panel

        private void BuildNavigationRibbonPanels()
        {
            //navigator panel
            aboutButton.BackColor = Color.Transparent;
            aboutButton.BackgroundImage = Properties.Resources.SmallI;
            aboutButton.BackgroundImageLayout = ImageLayout.Center;
            aboutButton.Dock = DockStyle.Fill;
            aboutButton.FlatAppearance.BorderColor = Color.White;
            aboutButton.FlatAppearance.BorderSize = 0;
            aboutButton.FlatAppearance.MouseOverBackColor = Color.SlateGray;
            aboutButton.FlatStyle = FlatStyle.Flat;
            aboutButton.Margin = new Padding(0);
           // aboutButton.Name = Phrases.GetPhrase("ABOUT");
            aboutButton.UseVisualStyleBackColor = false;

            exitButton.BackColor = Color.Transparent;
            exitButton.BackgroundImage = Properties.Resources.SmallX;
            exitButton.BackgroundImageLayout = ImageLayout.Center;
            exitButton.Dock = DockStyle.Fill;
            exitButton.FlatAppearance.BorderColor = Color.White;
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.FlatAppearance.MouseOverBackColor = Color.SlateGray;
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.Margin = new Padding(0);
           // exitButton.Name = Phrases.GetPhrase("EXIT");
            exitButton.UseVisualStyleBackColor = false;

            languageButton.BackColor = Color.Transparent;
            languageButton.BackgroundImage = Properties.Resources.SmallLanguage;
            languageButton.BackgroundImageLayout = ImageLayout.Center;
            languageButton.Dock = DockStyle.Fill;
            languageButton.FlatAppearance.BorderColor = Color.White;
            languageButton.FlatAppearance.BorderSize = 0;
            languageButton.FlatAppearance.MouseOverBackColor = Color.SlateGray;
            languageButton.FlatStyle = FlatStyle.Flat;
            languageButton.Margin = new Padding(0);
            languageButton.Name = Phrases.GetPhrase("CROATIAN"); 
            languageButton.UseVisualStyleBackColor = false;

            fullScreenButton.BackColor = Color.Transparent;
            fullScreenButton.BackgroundImage = Properties.Resources.SmallWindow;
            fullScreenButton.BackgroundImageLayout = ImageLayout.Center;
            fullScreenButton.Dock = DockStyle.Fill;
            fullScreenButton.FlatAppearance.BorderColor = Color.White;
            fullScreenButton.FlatAppearance.BorderSize = 0;
            fullScreenButton.FlatAppearance.MouseOverBackColor = Color.SlateGray;
            fullScreenButton.FlatStyle = FlatStyle.Flat;
            fullScreenButton.Margin = new Padding(0);
          //  fullScreenButton.Name = Phrases.GetPhrase("VIEWWINDOW");
            fullScreenButton.UseVisualStyleBackColor = false;
            holdFullScreenCode = "VIEWWINDOW";

            navigationTableLayoutPanel.ColumnCount = 11;
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));

            navigationTableLayoutPanel.Controls.Add(exitButton, 10, 0);
            navigationTableLayoutPanel.Controls.Add(aboutButton, 9, 0);
            navigationTableLayoutPanel.Controls.Add(fullScreenButton, 8, 0);
            navigationTableLayoutPanel.Controls.Add(languageButton, 7, 0);

            navigationTableLayoutPanel.Margin = new Padding(0);

            navigationTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            navigationTableLayoutPanel.Size = new Size(875, 75);
            navigationTableLayoutPanel.Dock = DockStyle.Fill;
            navigationTableLayoutPanel.BackColor = Color.Transparent;

            //ribbon panel
            backButton.BackColor = Color.Transparent;
            backButton.BackgroundImage = Properties.Resources.SmallArrow;
            backButton.BackgroundImageLayout = ImageLayout.Center;
            backButton.Dock = DockStyle.Fill;
            backButton.FlatAppearance.BorderColor = Color.White;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.FlatAppearance.MouseOverBackColor = Color.SlateGray;
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Margin = new Padding(0);
            // backButton.Name = Phrases.GetPhrase("");
            backButton.UseVisualStyleBackColor = false;

            step1Button.BackColor = Color.Transparent;
            step1Button.BackgroundImage = Properties.Resources.SmallStep1;
            step1Button.BackgroundImageLayout = ImageLayout.Center;
            step1Button.Dock = DockStyle.Fill;
            step1Button.FlatAppearance.BorderColor = Color.White;
            step1Button.FlatAppearance.BorderSize = 0;
            step1Button.FlatAppearance.MouseOverBackColor = Color.SlateGray;
            step1Button.FlatStyle = FlatStyle.Flat;
            step1Button.Margin = new Padding(0);
            // step1Button.Name = Phrases.GetPhrase("");
            step1Button.UseVisualStyleBackColor = false;


            pageTableLayoutPanel.ColumnCount = 11;
            pageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            pageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            pageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            pageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            pageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));

            pageTableLayoutPanel.Controls.Add(step1Button, 5, 0);
            pageTableLayoutPanel.Controls.Add(backButton, 0, 0);

            pageTableLayoutPanel.Margin = new Padding(0);

            pageTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pageTableLayoutPanel.Size = new Size(875, 75);
            pageTableLayoutPanel.Dock = DockStyle.Fill;
            pageTableLayoutPanel.BackColor = Color.Transparent;
        }

        #endregion

        #region back button clicked

        private void ShowDashboard()
        {
            dashboardTopPanel.BackColor = Color.Silver;
            dashboardTopPanel.Controls.Clear();
            dashboardTopPanel.Controls.Add(titleLabel);

            dashboardBottomPanel.Controls.Clear();
            dashboardBottomPanel.Controls.Add(dashboardPanel);
            whichControl = GlobalConfig.DASHBOARD;

        }

        #endregion

        #region step 1 button clicked


        private void step1ButtonClicked()
        {
            object page = step1Button.Tag;

            page.GetType().InvokeMember("Step1ButtonClicked",
                System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.InvokeMethod,
                null, page, new string[] { "" });
        }

        #endregion

        #region show about box

        private void ShowAboutBox()
        {
            PopupMessageBox msgBox = new PopupMessageBox();
            msgBox.Cursor = Cursors.Hand;
            msgBox.BoxType = "About";
            msgBox.FColor = Color.White;
            msgBox.BColor = Color.DeepSkyBlue;
            msgBox.Main_Location = Location;
            msgBox.Show();
            SetRibbonPanel();
            
        }

        #endregion

        #region change language

        private void ChangeLanguage()
        {
            switch (GlobalConfig.LANGUAGE)
            {
                case GlobalConfig.ENGLISH:
                    GlobalConfig.LANGUAGE = GlobalConfig.CROATIAN;
                    languageButton.Name = Phrases.GetPhrase("CROATIAN");
                    break;
                case GlobalConfig.CROATIAN:
                    GlobalConfig.LANGUAGE = GlobalConfig.ENGLISH;
                    languageButton.Name = Phrases.GetPhrase("ENGLISH");
                    break;
                default:
                    break;
            }

            SetRibbonPanel();

            GlobalConfig.LanguageChangedFunction();
        }

        #endregion

        #region set screen size (show full screen)

        private void SetScreen()
        {
            if(showFullScreen)
            {
                showFullScreen = false;
                fullScreenButton.Name = Phrases.GetPhrase("VIEWFULLSCREEN");
                holdFullScreenCode = "VIEWfULLSCREEN";
            }
            else
            {
                showFullScreen = true;
                fullScreenButton.Name = Phrases.GetPhrase("VIEWWINDOW");
                holdFullScreenCode = "VIEWWINDOW";
            }

            Rectangle workingArea = Screen.GetWorkingArea(this);
            //Point pt = new Point(workingArea.Left, workingArea.Bottom -100);

            if (showFullScreen)
            {
                this.WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                fullScreenButton.Image = Properties.Resources.SmallWindow;
                fullScreenButton.Refresh();
            }
            else
            {
                this.ShowIcon = true;
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.Sizable;
                this.Top = 0;
                this.Left = 0;
                this.Height = workingArea.Height - 50;
                this.Width = workingArea.Width;
                fullScreenButton.Image = Properties.Resources.SmallClosedWindow;
                fullScreenButton.Refresh();
            }

            SetRibbonPanel();
        }

        #endregion

        #region exit application

        private void ExitApplication()
        {
            PopupMessageBox msgBox = new PopupMessageBox();
            msgBox.UseButtons = "YN";
            msgBox.FColor = Color.White;
            msgBox.BColor = Color.Orange;
            msgBox.LabelText = Phrases.GetPhrase("YNQUIT");
            if (msgBox.ShowDialog() == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                SetRibbonPanel();
            }
            msgBox.Dispose();
        }

        #endregion

        #region Set Ribbon Panel

        private void SetRibbonPanel()
        {
            if(whichControl == GlobalConfig.DASHBOARD)
            {
                dashboardTopPanel.BackColor = Color.White;
                dashboardTopPanel.Controls.Clear();
                dashboardTopPanel.Controls.Add(titleLabel);
            }
            else
            {
                dashboardTopPanel.BackColor = Color.White;

                dashboardBottomPanel.Controls.Clear();
                dashboardBottomPanel.Controls.Add(pageTableLayoutPanel);
            }
        }

        #endregion

        #region MouseDown

        private void form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dashboardTopPanel.BackColor = Color.Silver;
                dashboardTopPanel.Controls.Clear();
                dashboardTopPanel.Controls.Add(navigationTableLayoutPanel);
            }
            else
            {
                SetRibbonPanel();
            }
        }


        private void base_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        #endregion

        #region make icon

        private Icon MakeIcon()
        {
            Image img = Properties.Resources.BigDashboard;

            Bitmap newImg = new Bitmap(img);

            IntPtr Hicon = newImg.GetHicon();
            Icon myIcon = Icon.FromHandle(Hicon);

            return myIcon;
        }

        #endregion
    }
}
