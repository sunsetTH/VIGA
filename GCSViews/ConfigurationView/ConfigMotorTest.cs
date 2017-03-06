using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using MissionPlanner.Controls;
using MissionPlanner.HIL;
using MissionPlanner.GCSViews.ConfigurationView;
namespace MissionPlanner.GCSViews.ConfigurationView
{
    public partial class ConfigMotorTest : UserControl, IActivate
    {
        public ConfigMotorTest()
        {
            InitializeComponent();
        }

        public void Activate()
        {
            var x = 500;
            var y = 60;

            var motormax = this.get_motormax();

            MyButton but;
            for (var a = 1; a <= motormax; a++)
            {
                but = new MyButton();
                but.Text = "待测电机 " + (char) ((a - 1) + 'A');
                but.Location = new Point(x, y);
                but.Click += but_Click;
                but.Tag = a;

                Controls.Add(but);

                y += 30;
            }

            but = new MyButton();
            but.Text = "测试所有电机";
            but.Location = new Point(x, y);
            but.Size = new Size(90, 40);
            but.Click += but_TestAll;
            Controls.Add(but);

            y += 40;

            but = new MyButton();
            but.Text = "所有电机停转";
            but.Location = new Point(x, y);
            but.Size = new Size(90, 40);
            but.Click += but_StopAll;
            Controls.Add(but);

            y += 40;

            but = new MyButton();
            but.Text = "依次测试所有电机";
            but.Location = new Point(x, y);
            but.Size = new Size(90, 40);
            but.Click += but_TestAllSeq;
            Controls.Add(but);
                    

            Utilities.ThemeManager.ApplyThemeTo(this);
        }

        private int get_motormax()
        {
            var motormax = 8;

            var enable = MainV2.comPort.MAV.param.ContainsKey("FRAME") || MainV2.comPort.MAV.param.ContainsKey("Q_FRAME_TYPE") || MainV2.comPort.MAV.param.ContainsKey("FRAME_TYPE");

            if (!enable)
            {
                Enabled = false;
                return motormax;
            }

            MAVLink.MAV_TYPE type = MAVLink.MAV_TYPE.QUADROTOR;
            int frame_type = 0; // + frame

            if (MainV2.comPort.MAV.param.ContainsKey("Q_FRAME_CLASS"))
            {
                var value = (int)MainV2.comPort.MAV.param["Q_FRAME_CLASS"].Value;
                switch (value)
                {
                    case 0:
                        type = MAVLink.MAV_TYPE.QUADROTOR;
                        break;
                    case 1:
                        type = MAVLink.MAV_TYPE.HEXAROTOR;
                        break;
                    case 2:
                        type = MAVLink.MAV_TYPE.OCTOROTOR;
                        break;
                    case 3:
                        type = MAVLink.MAV_TYPE.OCTOROTOR;
                        break;
                }

                frame_type = (int)MainV2.comPort.MAV.param["Q_FRAME_TYPE"].Value;

            }
            else if (MainV2.comPort.MAV.param.ContainsKey("FRAME"))
            {
                type = MainV2.comPort.MAV.aptype;
                frame_type = (int)MainV2.comPort.MAV.param["FRAME"].Value;
            }
            else if (MainV2.comPort.MAV.param.ContainsKey("FRAME_TYPE"))
            {
                type = MainV2.comPort.MAV.aptype;
                frame_type = (int)MainV2.comPort.MAV.param["FRAME_TYPE"].Value;
            }

            var motors = new Motor[0];

            if (type == MAVLink.MAV_TYPE.TRICOPTER)
            {
                motormax = 4;

                motors = Motor.build_motors(MAVLink.MAV_TYPE.TRICOPTER, frame_type);
               
            }
            else if (type == MAVLink.MAV_TYPE.QUADROTOR)
            {
                motormax = 4;

                motors = Motor.build_motors(MAVLink.MAV_TYPE.QUADROTOR, frame_type);
                if (frame_type == 0)//+字型机架
                    pictureBox1.BackgroundImage = Properties.Resources._4_;
                else if (frame_type == 1)
                    pictureBox1.BackgroundImage = Properties.Resources._4x;
                else
                    pictureBox1.BackgroundImage = null;
            }
            else if (type == MAVLink.MAV_TYPE.HEXAROTOR)
            {
                motormax = 6;

                motors = Motor.build_motors(MAVLink.MAV_TYPE.HEXAROTOR, frame_type);
                if (frame_type == 0)//+字型机架
                    pictureBox1.BackgroundImage = Properties.Resources._6_;
                else if (frame_type == 1)
                    pictureBox1.BackgroundImage = Properties.Resources._6x;
                else
                    pictureBox1.BackgroundImage = null;
            }
            else if (type == MAVLink.MAV_TYPE.OCTOROTOR)
            {
                motormax = 8;

                motors = Motor.build_motors(MAVLink.MAV_TYPE.OCTOROTOR, frame_type);
                if (frame_type == 0)//+字型机架
                    pictureBox1.BackgroundImage = Properties.Resources._8_;
                else if (frame_type == 1)
                    pictureBox1.BackgroundImage = Properties.Resources._8x;
                else
                    pictureBox1.BackgroundImage = null;
            }
            else if (type == MAVLink.MAV_TYPE.HELICOPTER)
            {
                motormax = 0;
            }

            return motormax;
        }

        private void but_TestAll(object sender, EventArgs e)
        {
            int speed = (int) thr_percent.Value;
            int time = (int) duration.Value;

            int motormax = this.get_motormax();
            for (int i = 1; i <= motormax; i++)
            {
                testMotor(i, speed, time);
            }
        }

        private void but_TestAllSeq(object sender, EventArgs e)
        {
            int motormax = this.get_motormax();
            int speed = (int) thr_percent.Value;
            int time = (int) duration.Value;

            testMotor(1, speed, time, motormax);
        }

        private void but_StopAll(object sender, EventArgs e)
        {
            int motormax = this.get_motormax();
            for (int i = 1; i <= motormax; i++)
            {
                testMotor(i, 0, 0);
            }
        }

        private void but_Click(object sender, EventArgs e)
        {
            int speed = (int) thr_percent.Value;
            int time = (int) duration.Value;
            try
            {
                var motor = (int) ((MyButton) sender).Tag;
                this.testMotor(motor, speed, time);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Failed to test motor\n" + ex);
            }
        }

        private void testMotor(int motor, int speed, int time,int motorcount = 0)
        {
            try
            {
                if (
                    !MainV2.comPort.doMotorTest(motor, MAVLink.MOTOR_TEST_THROTTLE_TYPE.MOTOR_TEST_THROTTLE_PERCENT,
                        speed, time, motorcount))
                {
                    CustomMessageBox.Show("命令被控制系统拒绝，请检查是否解锁或其他设置");
                }
            }
            catch
            {
                CustomMessageBox.Show(Strings.ErrorCommunicating + "\nMotor: " + motor, Strings.ERROR);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("http://copter.ardupilot.com/wiki/connect-escs-and-motors/");
            }
            catch
            {
                CustomMessageBox.Show("Bad default system association", Strings.ERROR);
            }
        }

        private void ConfigMotorTest_Load(object sender, EventArgs e)
        {

        }
    }
}