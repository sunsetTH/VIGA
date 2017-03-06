using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace MissionPlanner
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            AnimateWindow(this.Handle, 1500, 0X00080000);
            string strVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            //TXT_version.Text = "Version: " + Application.ProductVersion; // +" Build " + strVersion;

            //if (Program.Logo != null)
            //{
            //    //pictureBox1.BackgroundImage = MissionPlanner.Properties.Resources.bgdark;
            //    //pictureBox1.Image = Program.Logo;
            //    //pictureBox1.Visible = true;
            //}
        }
        [DllImportAttribute("user32.dll")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
    }
}