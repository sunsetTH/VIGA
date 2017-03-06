namespace MissionPlanner.GCSViews.ConfigurationView
{
    partial class ConfigMotorTest
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigMotorTest));
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lab2 = new System.Windows.Forms.Label();
            this.lab1 = new System.Windows.Forms.Label();
            this.thr_percent = new System.Windows.Forms.NumericUpDown();
            this.duration = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thr_percent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.duration)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // lab2
            // 
            resources.ApplyResources(this.lab2, "lab2");
            this.lab2.Name = "lab2";
            // 
            // lab1
            // 
            resources.ApplyResources(this.lab1, "lab1");
            this.lab1.Name = "lab1";
            // 
            // thr_percent
            // 
            resources.ApplyResources(this.thr_percent, "thr_percent");
            this.thr_percent.Name = "thr_percent";
            this.thr_percent.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // duration
            // 
            resources.ApplyResources(this.duration, "duration");
            this.duration.Name = "duration";
            this.duration.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // ConfigMotorTest
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.duration);
            this.Controls.Add(this.thr_percent);
            this.Controls.Add(this.lab1);
            this.Controls.Add(this.lab2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Name = "ConfigMotorTest";
            this.Load += new System.EventHandler(this.ConfigMotorTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thr_percent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.duration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lab2;
        private System.Windows.Forms.Label lab1;
        private System.Windows.Forms.NumericUpDown thr_percent;
        private System.Windows.Forms.NumericUpDown duration;
    }
}
