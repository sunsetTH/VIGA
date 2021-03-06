﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using MissionPlanner.Controls;
using MissionPlanner.Utilities;

namespace MissionPlanner.GCSViews.ConfigurationView
{
    public partial class ConfigArduplane : UserControl, IActivate
    {
        // from http://stackoverflow.com/questions/2512781/winforms-big-paragraph-tooltip/2512895#2512895
        private const int maximumSingleLineTooltipLength = 50;
        private static readonly Hashtable tooltips = new Hashtable();
        private readonly Hashtable changes = new Hashtable();
        internal bool startup = true;

        public ConfigArduplane()
        {
            InitializeComponent();
        }

        public void Activate()
        {
            if (!MainV2.comPort.BaseStream.IsOpen)
            {
                Enabled = false;
                return;
            }
            if (MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.ArduPlane)
            {
                Enabled = true;
            }
            else
            {
                Enabled = false;
                return;
            }

            startup = true;

            THR_SLEWRATE.setup(0, 0, 1, 0, "THR_SLEWRATE", MainV2.comPort.MAV.param);
            THR_MAX.setup(0, 0, 1, 0, "THR_MAX", MainV2.comPort.MAV.param);
            THR_MIN.setup(0, 0, 1, 0, "THR_MIN", MainV2.comPort.MAV.param);
            TRIM_THROTTLE.setup(0, 0, 1, 0, "TRIM_THROTTLE", MainV2.comPort.MAV.param);

            ARSPD_RATIO.setup(0, 0, 1, 0, "ARSPD_RATIO", MainV2.comPort.MAV.param);
            ARSPD_FBW_MAX.setup(0, 0, 1, 0, "ARSPD_FBW_MAX", MainV2.comPort.MAV.param);
            ARSPD_FBW_MIN.setup(0, 0, 1, 0, "ARSPD_FBW_MIN", MainV2.comPort.MAV.param);
            TRIM_ARSPD_CM.setup(0, 0, 100, 0, "TRIM_ARSPD_CM", MainV2.comPort.MAV.param);

            LIM_PITCH_MIN.setup(0, 0, 100, 0, "LIM_PITCH_MIN", MainV2.comPort.MAV.param);
            LIM_PITCH_MAX.setup(0, 0, 100, 0, "LIM_PITCH_MAX", MainV2.comPort.MAV.param);
            LIM_ROLL_CD.setup(0, 0, 100, 0, "LIM_ROLL_CD", MainV2.comPort.MAV.param);

            KFF_PTCH2THR.setup(0, 0, 1, 0, "KFF_PTCH2THR", MainV2.comPort.MAV.param);
            KFF_RDDRMIX.setup(0, 0, 1, 0, "KFF_RDDRMIX", MainV2.comPort.MAV.param);

            ENRGY2THR_IMAX.setup(0, 0, 100, 0, "ENRGY2THR_IMAX", MainV2.comPort.MAV.param);
            ENRGY2THR_D.setup(0, 0, 1, 0, "ENRGY2THR_D", MainV2.comPort.MAV.param);
            ENRGY2THR_I.setup(0, 0, 1, 0, "ENRGY2THR_I", MainV2.comPort.MAV.param);
            ENRGY2THR_P.setup(0, 0, 1, 0, "ENRGY2THR_P", MainV2.comPort.MAV.param);

            ALT2PTCH_IMAX.setup(0, 0, 100, 0, "ALT2PTCH_IMAX", MainV2.comPort.MAV.param);
            ALT2PTCH_D.setup(0, 0, 1, 0, "ALT2PTCH_D", MainV2.comPort.MAV.param);
            ALT2PTCH_I.setup(0, 0, 1, 0, "ALT2PTCH_I", MainV2.comPort.MAV.param);
            ALT2PTCH_P.setup(0, 0, 1, 0, "ALT2PTCH_P", MainV2.comPort.MAV.param);

            ARSP2PTCH_IMAX.setup(0, 0, 100, 0, "ARSP2PTCH_IMAX", MainV2.comPort.MAV.param);
            ARSP2PTCH_D.setup(0, 0, 1, 0, "ARSP2PTCH_D", MainV2.comPort.MAV.param);
            ARSP2PTCH_I.setup(0, 0, 1, 0, "ARSP2PTCH_I", MainV2.comPort.MAV.param);
            ARSP2PTCH_P.setup(0, 0, 1, 0, "ARSP2PTCH_P", MainV2.comPort.MAV.param);

            YAW2SRV_IMAX.setup(0, 0, 100, 0, "YAW2SRV_IMAX", MainV2.comPort.MAV.param);
            YAW2SRV_DAMP.setup(0, 0, 1, 0, "YAW2SRV_DAMP", MainV2.comPort.MAV.param);
            YAW2SRV_INT.setup(0, 0, 1, 0, "YAW2SRV_INT", MainV2.comPort.MAV.param);
            YAW2SRV_RLL.setup(0, 0, 1, 0, "YAW2SRV_RLL", MainV2.comPort.MAV.param);

            PTCH2SRV_IMAX.setup(0, 0, 100, 0, "PTCH2SRV_IMAX", MainV2.comPort.MAV.param);
            PTCH2SRV_D.setup(0, 0, 1, 0, "PTCH2SRV_D", MainV2.comPort.MAV.param);
            PTCH2SRV_I.setup(0, 0, 1, 0, "PTCH2SRV_I", MainV2.comPort.MAV.param);
            PTCH2SRV_P.setup(0, 0, 1, 0, "PTCH2SRV_P", MainV2.comPort.MAV.param);

            RLL2SRV_IMAX.setup(0, 0, 100, 0, "RLL2SRV_IMAX", MainV2.comPort.MAV.param);
            RLL2SRV_D.setup(0, 0, 1, 0, "RLL2SRV_D", MainV2.comPort.MAV.param);
            RLL2SRV_I.setup(0, 0, 1, 0, "RLL2SRV_I", MainV2.comPort.MAV.param);
            RLL2SRV_P.setup(0, 0, 1, 0, "RLL2SRV_P", MainV2.comPort.MAV.param);

            NAVL1_DAMPING.setup(0, 0, 1, 0, "NAVL1_DAMPING", MainV2.comPort.MAV.param);
            NAVL1_PERIOD.setup(0, 0, 1, 0, "NAVL1_PERIOD", MainV2.comPort.MAV.param);

            TECS_SINK_MAX.setup(0, 0, 1, 0, "TECS_SINK_MAX", MainV2.comPort.MAV.param);
            TECS_TIME_CONST.setup(0, 0, 1, 0, "TECS_TIME_CONST", MainV2.comPort.MAV.param);
            TECS_PTCH_DAMP.setup(0, 0, 1, 0, "TECS_PTCH_DAMP", MainV2.comPort.MAV.param);
            TECS_SINK_MIN.setup(0, 0, 1, 0, "TECS_SINK_MIN", MainV2.comPort.MAV.param);
            TECS_CLMB_MAX.setup(0, 0, 1, 0, "TECS_CLMB_MAX", MainV2.comPort.MAV.param);

            changes.Clear();

            processToScreen();

            startup = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                BUT_writePIDS_Click(null, null);
                return true;
            }

            return false;
        }

        private static string AddNewLinesForTooltip(string text)
        {
            if (text.Length < maximumSingleLineTooltipLength)
                return text;
            var lineLength = (int) Math.Sqrt(text.Length)*2;
            var sb = new StringBuilder();
            var currentLinePosition = 0;
            for (var textIndex = 0; textIndex < text.Length; textIndex++)
            {
                // If we have reached the target line length and the next      
                // character is whitespace then begin a new line.   
                if (currentLinePosition >= lineLength &&
                    char.IsWhiteSpace(text[textIndex]))
                {
                    sb.Append(Environment.NewLine);
                    currentLinePosition = 0;
                }
                // If we have just started a new line, skip all the whitespace.    
                if (currentLinePosition == 0)
                    while (textIndex < text.Length && char.IsWhiteSpace(text[textIndex]))
                        textIndex++;
                // Append the next character.     
                if (textIndex < text.Length) sb.Append(text[textIndex]);
                currentLinePosition++;
            }
            return sb.ToString();
        }

        private void disableNumericUpDownControls(Control inctl)
        {
            foreach (Control ctl in inctl.Controls)
            {
                if (ctl.Controls.Count > 0)
                {
                    disableNumericUpDownControls(ctl);
                }
                if (ctl.GetType() == typeof (NumericUpDown))
                {
                    ctl.Enabled = false;
                }
            }
        }

        internal void processToScreen()
        {
            toolTip1.RemoveAll();

            disableNumericUpDownControls(this);

            // process hashdefines and update display
            foreach (string value in MainV2.comPort.MAV.param.Keys)
            {
                if (value == null || value == "")
                    continue;

                var name = value;
                var text = Controls.Find(name, true);
                foreach (var ctl in text)
                {
                    try
                    {
                        if (ctl.GetType() == typeof (NumericUpDown))
                        {
                            var numbervalue = (float) MainV2.comPort.MAV.param[value];

                            MAVLinkInterface.modifyParamForDisplay(true, value, ref numbervalue);

                            var thisctl = ((NumericUpDown) ctl);
                            thisctl.Maximum = 9000;
                            thisctl.Minimum = -9000;
                            thisctl.Value = (decimal) numbervalue;
                            thisctl.Increment = (decimal) 0.001;
                            if (thisctl.Name.EndsWith("_P") || thisctl.Name.EndsWith("_I") ||
                                thisctl.Name.EndsWith("_D")
                                || thisctl.Name.EndsWith("_LOW") || thisctl.Name.EndsWith("_HIGH") || thisctl.Value == 0
                                || thisctl.Value.ToString("0.###", new CultureInfo("en-US")).Contains("."))
                            {
                                thisctl.DecimalPlaces = 3;
                            }
                            else
                            {
                                thisctl.Increment = 1;
                                thisctl.DecimalPlaces = 1;
                            }

                            if (thisctl.Name.EndsWith("_IMAX"))
                            {
                                thisctl.Maximum = 180;
                                thisctl.Minimum = -180;
                            }

                            thisctl.Enabled = true;
                            try
                            {
                                thisctl.Parent.Visible = true;
                            }
                            catch
                            {
                            }

                            ThemeManager.ApplyThemeTo(thisctl);

                            thisctl.Validated += EEPROM_View_float_TextChanged;
                        }
                        else if (ctl.GetType() == typeof (ComboBox))
                        {
                            var thisctl = ((ComboBox) ctl);

                            thisctl.SelectedIndex = (int) (float) MainV2.comPort.MAV.param[value];

                            thisctl.Validated += ComboBox_Validated;

                            ThemeManager.ApplyThemeTo(thisctl);
                        }
                    }
                    catch
                    {
                    }
                }
                if (text.Length == 0)
                {
                    //Console.WriteLine(name + " not found");
                }
            }
        }

        private void ComboBox_Validated(object sender, EventArgs e)
        {
            EEPROM_View_float_TextChanged(sender, e);
        }

        private void Configuration_Validating(object sender, CancelEventArgs e)
        {
            EEPROM_View_float_TextChanged(sender, e);
        }

        internal void EEPROM_View_float_TextChanged(object sender, EventArgs e)
        {
            float value = 0;
            var name = ((Control)sender).Name;

            // do domainupdown state check
            try
            {
                if (sender.GetType() == typeof(MavlinkNumericUpDown))
                {
                    value = ((MAVLinkParamChanged)e).value;
                    changes[name] = value;
                }
                else if (sender.GetType() == typeof(MavlinkComboBox))
                {
                    value = ((MAVLinkParamChanged)e).value;
                    changes[name] = value;
                }
                ((Control)sender).BackColor = Color.Green;
            }
            catch (Exception)
            {
                ((Control)sender).BackColor = Color.Red;
            }
        }

        private void BUT_writePIDS_Click(object sender, EventArgs e)
        {
            var temp = (Hashtable) changes.Clone();

            foreach (string value in temp.Keys)
            {
                try
                {
                    if ((float)changes[value] > (float)MainV2.comPort.MAV.param[value] * 2.0f)
                        if (
                            CustomMessageBox.Show(value + " has more than doubled the last input. Are you sure?",
                                "Large Value", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            try
                            {
                                // set control as well
                                var textControls = Controls.Find(value, true);
                                if (textControls.Length > 0)
                                {
                                    // restore old value
                                    textControls[0].Text = MainV2.comPort.MAV.param[value].Value.ToString();
                                    textControls[0].BackColor = Color.FromArgb(0x43, 0x44, 0x45);
                                }
                            }
                            catch
                            {
                            }
                            return;
                        }

                    MainV2.comPort.setParam(value, (float)changes[value]);

                    changes.Remove(value);

                    try
                    {
                        // set control as well
                        var textControls = Controls.Find(value, true);
                        if (textControls.Length > 0)
                        {
                            textControls[0].BackColor = Color.FromArgb(0x43, 0x44, 0x45);
                        }
                    }
                    catch
                    {
                    }
                }
                catch
                {
                    CustomMessageBox.Show(string.Format(Strings.ErrorSetValueFailed, value), Strings.ERROR);
                }
            }
        }

        /// <summary>
        ///     Handles the Click event of the BUT_rerequestparams control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected void BUT_rerequestparams_Click(object sender, EventArgs e)
        {
            if (!MainV2.comPort.BaseStream.IsOpen)
                return;

            ((Control) sender).Enabled = false;

            try
            {
                MainV2.comPort.getParamList();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Error: getting param list " + ex, Strings.ERROR);
            }


            ((Control) sender).Enabled = true;

            Activate();
        }

        private void BUT_refreshpart_Click(object sender, EventArgs e)
        {
            if (!MainV2.comPort.BaseStream.IsOpen)
                return;

            ((Control) sender).Enabled = false;


            updateparam(this);

            ((Control) sender).Enabled = true;


            Activate();
        }

        private void updateparam(Control parentctl)
        {
            foreach (Control ctl in parentctl.Controls)
            {
                if (typeof (NumericUpDown) == ctl.GetType() || typeof (ComboBox) == ctl.GetType())
                {
                    try
                    {
                        MainV2.comPort.GetParam(ctl.Name);
                    }
                    catch
                    {
                    }
                }

                if (ctl.Controls.Count > 0)
                {
                    updateparam(ctl);
                }
            }
        }

        private void numeric_ValueUpdated(object sender, EventArgs e)
        {
            EEPROM_View_float_TextChanged(sender, e);
        }
    }
}