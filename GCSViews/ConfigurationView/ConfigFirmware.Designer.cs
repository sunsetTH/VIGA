using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO.Ports;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using System.Net;

namespace MissionPlanner.GCSViews.ConfigurationView
{
    partial class ConfigFirmware : MyUserControl
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.ProgressBar progress;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigFirmware));
            this.lbl_status = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.lbl_Custom_firmware_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_status
            // 
            resources.ApplyResources(this.lbl_status, "lbl_status");
            this.lbl_status.Name = "lbl_status";
            // 
            // progress
            // 
            resources.ApplyResources(this.progress, "progress");
            this.progress.Name = "progress";
            this.progress.Step = 1;
            // 
            // lbl_Custom_firmware_label
            // 
            resources.ApplyResources(this.lbl_Custom_firmware_label, "lbl_Custom_firmware_label");
            this.lbl_Custom_firmware_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Custom_firmware_label.Name = "lbl_Custom_firmware_label";
            this.lbl_Custom_firmware_label.Click += new System.EventHandler(this.Custom_firmware_label_Click);
            // 
            // ConfigFirmware
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lbl_Custom_firmware_label);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.progress);
            this.Name = "ConfigFirmware";
            resources.ApplyResources(this, "$this");
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Label lbl_Custom_firmware_label;
    }
}