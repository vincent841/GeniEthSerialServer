namespace GeniEthSerialServer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxUdp = new System.Windows.Forms.GroupBox();
            this.lblUdp2Status = new System.Windows.Forms.Label();
            this.lblUdp1Status = new System.Windows.Forms.Label();
            this.numUdpPort2 = new System.Windows.Forms.NumericUpDown();
            this.numUdpPort1 = new System.Windows.Forms.NumericUpDown();
            this.chkUdp2 = new System.Windows.Forms.CheckBox();
            this.chkUdp1 = new System.Windows.Forms.CheckBox();
            this.groupBoxSerial = new System.Windows.Forms.GroupBox();
            this.lblSer2Port = new System.Windows.Forms.Label();
            this.lblSer1Port = new System.Windows.Forms.Label();
            this.chkSer2 = new System.Windows.Forms.CheckBox();
            this.chkSer1 = new System.Windows.Forms.CheckBox();
            this.btnRefreshSerial = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBoxUdp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUdpPort2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUdpPort1)).BeginInit();
            this.groupBoxSerial.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUdp
            // 
            this.groupBoxUdp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxUdp.Controls.Add(this.lblUdp2Status);
            this.groupBoxUdp.Controls.Add(this.lblUdp1Status);
            this.groupBoxUdp.Controls.Add(this.numUdpPort2);
            this.groupBoxUdp.Controls.Add(this.numUdpPort1);
            this.groupBoxUdp.Controls.Add(this.chkUdp2);
            this.groupBoxUdp.Controls.Add(this.chkUdp1);
            this.groupBoxUdp.Location = new System.Drawing.Point(12, 12);
            this.groupBoxUdp.Name = "groupBoxUdp";
            this.groupBoxUdp.Size = new System.Drawing.Size(776, 94);
            this.groupBoxUdp.TabIndex = 0;
            this.groupBoxUdp.TabStop = false;
            this.groupBoxUdp.Text = "UDP Echo Servers";
            // 
            // lblUdp2Status
            // 
            this.lblUdp2Status.AutoSize = true;
            this.lblUdp2Status.Location = new System.Drawing.Point(325, 59);
            this.lblUdp2Status.Name = "lblUdp2Status";
            this.lblUdp2Status.Size = new System.Drawing.Size(59, 15);
            this.lblUdp2Status.TabIndex = 5;
            this.lblUdp2Status.Text = "Stopped";
            // 
            // lblUdp1Status
            // 
            this.lblUdp1Status.AutoSize = true;
            this.lblUdp1Status.Location = new System.Drawing.Point(325, 27);
            this.lblUdp1Status.Name = "lblUdp1Status";
            this.lblUdp1Status.Size = new System.Drawing.Size(59, 15);
            this.lblUdp1Status.TabIndex = 4;
            this.lblUdp1Status.Text = "Stopped";
            // 
            // numUdpPort2
            // 
            this.numUdpPort2.Location = new System.Drawing.Point(161, 55);
            this.numUdpPort2.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numUdpPort2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUdpPort2.Name = "numUdpPort2";
            this.numUdpPort2.Size = new System.Drawing.Size(120, 23);
            this.numUdpPort2.TabIndex = 3;
            this.numUdpPort2.Value = new decimal(new int[] {
            35002,
            0,
            0,
            0});
            // 
            // numUdpPort1
            // 
            this.numUdpPort1.Location = new System.Drawing.Point(161, 23);
            this.numUdpPort1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numUdpPort1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUdpPort1.Name = "numUdpPort1";
            this.numUdpPort1.Size = new System.Drawing.Size(120, 23);
            this.numUdpPort1.TabIndex = 2;
            this.numUdpPort1.Value = new decimal(new int[] {
            35001,
            0,
            0,
            0});
            // 
            // chkUdp2
            // 
            this.chkUdp2.AutoSize = true;
            this.chkUdp2.Location = new System.Drawing.Point(17, 56);
            this.chkUdp2.Name = "chkUdp2";
            this.chkUdp2.Size = new System.Drawing.Size(124, 19);
            this.chkUdp2.TabIndex = 1;
            this.chkUdp2.Text = "Enable UDP : Port";
            this.chkUdp2.UseVisualStyleBackColor = true;
            this.chkUdp2.CheckedChanged += new System.EventHandler(this.chkUdp2_CheckedChanged);
            // 
            // chkUdp1
            // 
            this.chkUdp1.AutoSize = true;
            this.chkUdp1.Location = new System.Drawing.Point(17, 24);
            this.chkUdp1.Name = "chkUdp1";
            this.chkUdp1.Size = new System.Drawing.Size(124, 19);
            this.chkUdp1.TabIndex = 0;
            this.chkUdp1.Text = "Enable UDP : Port";
            this.chkUdp1.UseVisualStyleBackColor = true;
            this.chkUdp1.CheckedChanged += new System.EventHandler(this.chkUdp1_CheckedChanged);
            // 
            // groupBoxSerial
            // 
            this.groupBoxSerial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSerial.Controls.Add(this.btnRefreshSerial);
            this.groupBoxSerial.Controls.Add(this.lblSer2Port);
            this.groupBoxSerial.Controls.Add(this.lblSer1Port);
            this.groupBoxSerial.Controls.Add(this.chkSer2);
            this.groupBoxSerial.Controls.Add(this.chkSer1);
            this.groupBoxSerial.Location = new System.Drawing.Point(12, 112);
            this.groupBoxSerial.Name = "groupBoxSerial";
            this.groupBoxSerial.Size = new System.Drawing.Size(776, 94);
            this.groupBoxSerial.TabIndex = 1;
            this.groupBoxSerial.TabStop = false;
            this.groupBoxSerial.Text = "Serial Echo Servers (115200,8N1)";
            // 
            // lblSer2Port
            // 
            this.lblSer2Port.AutoSize = true;
            this.lblSer2Port.Location = new System.Drawing.Point(325, 59);
            this.lblSer2Port.Name = "lblSer2Port";
            this.lblSer2Port.Size = new System.Drawing.Size(83, 15);
            this.lblSer2Port.TabIndex = 3;
            this.lblSer2Port.Text = "Port: (auto)";
            // 
            // lblSer1Port
            // 
            this.lblSer1Port.AutoSize = true;
            this.lblSer1Port.Location = new System.Drawing.Point(325, 27);
            this.lblSer1Port.Name = "lblSer1Port";
            this.lblSer1Port.Size = new System.Drawing.Size(83, 15);
            this.lblSer1Port.TabIndex = 2;
            this.lblSer1Port.Text = "Port: (auto)";
            // 
            // chkSer2
            // 
            this.chkSer2.AutoSize = true;
            this.chkSer2.Location = new System.Drawing.Point(17, 56);
            this.chkSer2.Name = "chkSer2";
            this.chkSer2.Size = new System.Drawing.Size(160, 19);
            this.chkSer2.TabIndex = 1;
            this.chkSer2.Text = "Enable Serial #2 (auto)";
            this.chkSer2.UseVisualStyleBackColor = true;
            this.chkSer2.CheckedChanged += new System.EventHandler(this.chkSer2_CheckedChanged);
            // 
            // chkSer1
            // 
            this.chkSer1.AutoSize = true;
            this.chkSer1.Location = new System.Drawing.Point(17, 24);
            this.chkSer1.Name = "chkSer1";
            this.chkSer1.Size = new System.Drawing.Size(160, 19);
            this.chkSer1.TabIndex = 0;
            this.chkSer1.Text = "Enable Serial #1 (auto)";
            this.chkSer1.UseVisualStyleBackColor = true;
            this.chkSer1.CheckedChanged += new System.EventHandler(this.chkSer1_CheckedChanged);
            // 
            // btnRefreshSerial
            // 
            this.btnRefreshSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshSerial.Location = new System.Drawing.Point(654, 22);
            this.btnRefreshSerial.Name = "btnRefreshSerial";
            this.btnRefreshSerial.Size = new System.Drawing.Size(104, 23);
            this.btnRefreshSerial.TabIndex = 4;
            this.btnRefreshSerial.Text = "Refresh Ports";
            this.btnRefreshSerial.UseVisualStyleBackColor = true;
            this.btnRefreshSerial.Click += new System.EventHandler(this.btnRefreshSerial_Click);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(12, 212);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(776, 226);
            this.txtLog.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.groupBoxSerial);
            this.Controls.Add(this.groupBoxUdp);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Geni Eth & Serial Echo Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxUdp.ResumeLayout(false);
            this.groupBoxUdp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUdpPort2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUdpPort1)).EndInit();
            this.groupBoxSerial.ResumeLayout(false);
            this.groupBoxSerial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxUdp;
        private System.Windows.Forms.CheckBox chkUdp2;
        private System.Windows.Forms.CheckBox chkUdp1;
        private System.Windows.Forms.NumericUpDown numUdpPort2;
        private System.Windows.Forms.NumericUpDown numUdpPort1;
        private System.Windows.Forms.Label lblUdp2Status;
        private System.Windows.Forms.Label lblUdp1Status;
        private System.Windows.Forms.GroupBox groupBoxSerial;
        private System.Windows.Forms.CheckBox chkSer2;
        private System.Windows.Forms.CheckBox chkSer1;
        private System.Windows.Forms.Label lblSer2Port;
        private System.Windows.Forms.Label lblSer1Port;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnRefreshSerial;
    }
}
