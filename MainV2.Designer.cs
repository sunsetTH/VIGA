using System;
namespace MissionPlanner
{
    partial class MainV2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            Console.WriteLine("mainv2_Dispose");
            if (PluginThreadrunner != null)
                PluginThreadrunner.Dispose();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainV2));
            this.CTX_mainmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autoHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readonlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MenuFlightData = new System.Windows.Forms.ToolStripButton();
            this.MenuInitConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripConnectionControl = new MissionPlanner.Controls.ToolStripConnectionControl();
            this.MenuConfigTune = new System.Windows.Forms.ToolStripButton();
            this.MenuConnect = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.CTX_mainmenu.SuspendLayout();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CTX_mainmenu
            // 
            this.CTX_mainmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoHideToolStripMenuItem,
            this.fullScreenToolStripMenuItem,
            this.readonlyToolStripMenuItem,
            this.connectionOptionsToolStripMenuItem});
            this.CTX_mainmenu.Name = "CTX_mainmenu";
            resources.ApplyResources(this.CTX_mainmenu, "CTX_mainmenu");
            // 
            // autoHideToolStripMenuItem
            // 
            this.autoHideToolStripMenuItem.CheckOnClick = true;
            this.autoHideToolStripMenuItem.Name = "autoHideToolStripMenuItem";
            resources.ApplyResources(this.autoHideToolStripMenuItem, "autoHideToolStripMenuItem");
            this.autoHideToolStripMenuItem.Click += new System.EventHandler(this.autoHideToolStripMenuItem_Click);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.CheckOnClick = true;
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            resources.ApplyResources(this.fullScreenToolStripMenuItem, "fullScreenToolStripMenuItem");
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // readonlyToolStripMenuItem
            // 
            this.readonlyToolStripMenuItem.CheckOnClick = true;
            this.readonlyToolStripMenuItem.Name = "readonlyToolStripMenuItem";
            resources.ApplyResources(this.readonlyToolStripMenuItem, "readonlyToolStripMenuItem");
            this.readonlyToolStripMenuItem.Click += new System.EventHandler(this.readonlyToolStripMenuItem_Click);
            // 
            // connectionOptionsToolStripMenuItem
            // 
            this.connectionOptionsToolStripMenuItem.Name = "connectionOptionsToolStripMenuItem";
            resources.ApplyResources(this.connectionOptionsToolStripMenuItem, "connectionOptionsToolStripMenuItem");
            this.connectionOptionsToolStripMenuItem.Click += new System.EventHandler(this.connectionOptionsToolStripMenuItem_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.Transparent;
            this.MainMenu.ContextMenuStrip = this.CTX_mainmenu;
            resources.ApplyResources(this.MainMenu, "MainMenu");
            this.MainMenu.GripMargin = new System.Windows.Forms.Padding(0);
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(0, 0);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFlightData,
            this.MenuInitConfig,
            this.toolStripConnectionControl,
            this.MenuConfigTune,
            this.MenuConnect});
            this.MainMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.TabStop = true;
            this.MainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MainMenu_ItemClicked);
            this.MainMenu.MouseLeave += new System.EventHandler(this.MainMenu_MouseLeave);
            // 
            // MenuFlightData
            // 
            resources.ApplyResources(this.MenuFlightData, "MenuFlightData");
            this.MenuFlightData.ForeColor = System.Drawing.Color.White;
            this.MenuFlightData.Image = global::MissionPlanner.Properties.Resources.Paper_Plane_48px_1066419_easyicon_net;
            this.MenuFlightData.Margin = new System.Windows.Forms.Padding(0);
            this.MenuFlightData.Name = "MenuFlightData";
            this.MenuFlightData.Click += new System.EventHandler(this.MenuFlightData_Click);
            // 
            // MenuInitConfig
            // 
            resources.ApplyResources(this.MenuInitConfig, "MenuInitConfig");
            this.MenuInitConfig.ForeColor = System.Drawing.Color.White;
            this.MenuInitConfig.Image = global::MissionPlanner.Properties.Resources.configure_2_48px_539568_easyicon_net;
            this.MenuInitConfig.Margin = new System.Windows.Forms.Padding(0);
            this.MenuInitConfig.Name = "MenuInitConfig";
            this.MenuInitConfig.Click += new System.EventHandler(this.MenuSetup_Click);
            // 
            // toolStripConnectionControl
            // 
            this.toolStripConnectionControl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripConnectionControl.BackgroundImage = global::MissionPlanner.Properties.Resources.bg;
            this.toolStripConnectionControl.ForeColor = System.Drawing.Color.ForestGreen;
            this.toolStripConnectionControl.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripConnectionControl.Name = "toolStripConnectionControl";
            resources.ApplyResources(this.toolStripConnectionControl, "toolStripConnectionControl");
            this.toolStripConnectionControl.MouseLeave += new System.EventHandler(this.MainMenu_MouseLeave);
            // 
            // MenuConfigTune
            // 
            resources.ApplyResources(this.MenuConfigTune, "MenuConfigTune");
            this.MenuConfigTune.ForeColor = System.Drawing.Color.White;
            this.MenuConfigTune.Image = global::MissionPlanner.Properties.Resources.set_system_48px_12353_easyicon_net;
            this.MenuConfigTune.Margin = new System.Windows.Forms.Padding(0);
            this.MenuConfigTune.Name = "MenuConfigTune";
            this.MenuConfigTune.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.MenuConfigTune.Click += new System.EventHandler(this.MenuTuning_Click);
            // 
            // MenuConnect
            // 
            this.MenuConnect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.MenuConnect, "MenuConnect");
            this.MenuConnect.ForeColor = System.Drawing.Color.White;
            this.MenuConnect.Margin = new System.Windows.Forms.Padding(0);
            this.MenuConnect.Name = "MenuConnect";
            this.MenuConnect.Click += new System.EventHandler(this.MenuConnect_Click);
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Panel1.Controls.Add(this.MainMenu);
            // 
            // MainV2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainV2";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainV2_KeyDown);
            this.Resize += new System.EventHandler(this.MainV2_Resize);
            this.CTX_mainmenu.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip CTX_mainmenu;
        private System.Windows.Forms.ToolStripMenuItem autoHideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readonlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionOptionsToolStripMenuItem;
        public System.Windows.Forms.MenuStrip MainMenu;
        public System.Windows.Forms.ToolStripButton MenuFlightData;
        public System.Windows.Forms.ToolStripButton MenuInitConfig;
        private Controls.ToolStripConnectionControl toolStripConnectionControl;
        public System.Windows.Forms.ToolStripButton MenuConfigTune;
        public System.Windows.Forms.ToolStripButton MenuConnect;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}