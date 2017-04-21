namespace Flash_EC_Tool
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTestMessage = new System.Windows.Forms.RichTextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAutoTest = new System.Windows.Forms.Button();
            this.btnManual = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bnStop = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.comboPLC = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtPASS = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolScripVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolScripTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolScriptAuther = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.spPLC = new System.IO.Ports.SerialPort(this.components);
            this.actPLC = new AxActProgTypeLib.AxActProgType();
            this.timerScanPLC = new System.Windows.Forms.Timer(this.components);
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // richTestMessage
            // 
            this.richTestMessage.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.richTestMessage.Location = new System.Drawing.Point(9, 23);
            this.richTestMessage.Name = "richTestMessage";
            this.richTestMessage.Size = new System.Drawing.Size(272, 337);
            this.richTestMessage.TabIndex = 0;
            this.richTestMessage.Text = "";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Flash_EC_Tool.Properties.Resources.title;
            this.pictureBox3.Location = new System.Drawing.Point(392, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(543, 94);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Flash_EC_Tool.Properties.Resources.PE;
            this.pictureBox2.Location = new System.Drawing.Point(6, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(166, 477);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Flash_EC_Tool.Properties.Resources.Start;
            this.pictureBox1.Location = new System.Drawing.Point(4, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(356, 478);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstHistory);
            this.groupBox1.Controls.Add(this.richTestMessage);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(593, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 508);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "測試信息";
            // 
            // lstHistory
            // 
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.HorizontalScrollbar = true;
            this.lstHistory.ItemHeight = 19;
            this.lstHistory.Location = new System.Drawing.Point(9, 366);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(272, 137);
            this.lstHistory.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(406, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 508);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "開始提醒";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(36, 102);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(366, 511);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "開始畫面";
            // 
            // btnAutoTest
            // 
            this.btnAutoTest.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAutoTest.Location = new System.Drawing.Point(17, 16);
            this.btnAutoTest.Name = "btnAutoTest";
            this.btnAutoTest.Size = new System.Drawing.Size(180, 45);
            this.btnAutoTest.TabIndex = 8;
            this.btnAutoTest.Text = "Auto Test(自動測試)";
            this.btnAutoTest.UseVisualStyleBackColor = true;
            this.btnAutoTest.Click += new System.EventHandler(this.btnAutoTest_Click);
            // 
            // btnManual
            // 
            this.btnManual.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnManual.Location = new System.Drawing.Point(17, 65);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(180, 48);
            this.btnManual.TabIndex = 9;
            this.btnManual.Text = "Manual(手動測試)";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.Location = new System.Drawing.Point(15, 169);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(180, 43);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit(退出)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.bnStop);
            this.groupBox4.Controls.Add(this.btnAutoTest);
            this.groupBox4.Controls.Add(this.btnExit);
            this.groupBox4.Controls.Add(this.btnManual);
            this.groupBox4.Location = new System.Drawing.Point(886, 387);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(230, 222);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            // 
            // bnStop
            // 
            this.bnStop.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bnStop.Location = new System.Drawing.Point(15, 116);
            this.bnStop.Name = "bnStop";
            this.bnStop.Size = new System.Drawing.Size(180, 48);
            this.bnStop.TabIndex = 12;
            this.bnStop.Text = "Stop(停止測試)";
            this.bnStop.UseVisualStyleBackColor = true;
            this.bnStop.Click += new System.EventHandler(this.bnStop_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblResult);
            this.groupBox5.Location = new System.Drawing.Point(886, 108);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(230, 106);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Yellow;
            this.lblResult.Location = new System.Drawing.Point(29, 18);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(171, 78);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "WAIT";
            // 
            // comboPLC
            // 
            this.comboPLC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPLC.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboPLC.FormattingEnabled = true;
            this.comboPLC.Location = new System.Drawing.Point(88, 16);
            this.comboPLC.Name = "comboPLC";
            this.comboPLC.Size = new System.Drawing.Size(109, 27);
            this.comboPLC.TabIndex = 12;
            this.comboPLC.SelectedIndexChanged += new System.EventHandler(this.comboPLC_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "PLC串口";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRefresh.Location = new System.Drawing.Point(20, 46);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(177, 46);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Refresh(刷新串口)";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.comboPLC);
            this.groupBox6.Controls.Add(this.btnRefresh);
            this.groupBox6.Location = new System.Drawing.Point(886, 289);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(230, 96);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.txtTotal);
            this.groupBox7.Controls.Add(this.txtPASS);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox7.Location = new System.Drawing.Point(886, 215);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(230, 73);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "測試統計信息";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "PASS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(55, 27);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(53, 27);
            this.txtTotal.TabIndex = 1;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPASS
            // 
            this.txtPASS.Location = new System.Drawing.Point(161, 28);
            this.txtPASS.Name = "txtPASS";
            this.txtPASS.ReadOnly = true;
            this.txtPASS.Size = new System.Drawing.Size(54, 27);
            this.txtPASS.TabIndex = 0;
            this.txtPASS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolScripVersion,
            this.toolScripTime,
            this.toolScriptAuther});
            this.statusStrip1.Location = new System.Drawing.Point(0, 627);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1143, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolScripVersion
            // 
            this.toolScripVersion.Name = "toolScripVersion";
            this.toolScripVersion.Size = new System.Drawing.Size(82, 17);
            this.toolScripVersion.Text = "Main Version";
            // 
            // toolScripTime
            // 
            this.toolScripTime.Name = "toolScripTime";
            this.toolScripTime.Size = new System.Drawing.Size(36, 17);
            this.toolScripTime.Text = "Time";
            // 
            // toolScriptAuther
            // 
            this.toolScriptAuther.Name = "toolScriptAuther";
            this.toolScriptAuther.Size = new System.Drawing.Size(45, 17);
            this.toolScriptAuther.Text = "Auther";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // actPLC
            // 
            this.actPLC.Enabled = true;
            this.actPLC.Location = new System.Drawing.Point(36, 39);
            this.actPLC.Name = "actPLC";
            this.actPLC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("actPLC.OcxState")));
            this.actPLC.Size = new System.Drawing.Size(32, 32);
            this.actPLC.TabIndex = 17;
            // 
            // timerScanPLC
            // 
            this.timerScanPLC.Interval = 500;
            this.timerScanPLC.Tick += new System.EventHandler(this.timerScanPLC_Tick);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(135, 23);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(231, 61);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 18;
            this.pictureBox4.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1143, 649);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.actPLC);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTestMessage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAutoTest;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboPLC;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolScripVersion;
        private System.Windows.Forms.ToolStripStatusLabel toolScripTime;
        private System.Windows.Forms.Timer timer1;
        private System.IO.Ports.SerialPort spPLC;
        private AxActProgTypeLib.AxActProgType actPLC;
        private System.Windows.Forms.ToolStripStatusLabel toolScriptAuther;
        private System.Windows.Forms.Timer timerScanPLC;
        private System.Windows.Forms.Button bnStop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtPASS;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}

