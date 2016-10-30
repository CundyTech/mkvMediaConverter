using System.ComponentModel;
using System.Windows.Forms;

namespace mkvMediaConverter
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tpQueue = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvQueue = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.LbConvertedFiles = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LstOutput = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LstFfmpegOutput = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postConverstionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteOldFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RbtnMP4toMKV = new System.Windows.Forms.RadioButton();
            this.RbtnMKVtoMP4 = new System.Windows.Forms.RadioButton();
            this.BtnWatch = new System.Windows.Forms.Button();
            this.BtnSlctCstmFldr = new System.Windows.Forms.Button();
            this.ChkCustomOutput = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnSlctWtchFldr = new System.Windows.Forms.Button();
            this.TxtWtchFldr = new System.Windows.Forms.TextBox();
            this.TxtOutput = new System.Windows.Forms.TextBox();
            this.tpQueue.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tpQueue
            // 
            this.tpQueue.Controls.Add(this.tabPage4);
            this.tpQueue.Controls.Add(this.tabPage3);
            this.tpQueue.Controls.Add(this.tabPage1);
            this.tpQueue.Controls.Add(this.tabPage2);
            this.tpQueue.Location = new System.Drawing.Point(12, 169);
            this.tpQueue.Name = "tpQueue";
            this.tpQueue.SelectedIndex = 0;
            this.tpQueue.Size = new System.Drawing.Size(689, 269);
            this.tpQueue.TabIndex = 53;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvQueue);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(681, 243);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Queue";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvQueue
            // 
            this.dgvQueue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQueue.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQueue.Location = new System.Drawing.Point(3, 3);
            this.dgvQueue.Name = "dgvQueue";
            this.dgvQueue.RowHeadersVisible = false;
            this.dgvQueue.Size = new System.Drawing.Size(675, 237);
            this.dgvQueue.TabIndex = 58;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.LbConvertedFiles);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(681, 243);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Converted Files";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // LbConvertedFiles
            // 
            this.LbConvertedFiles.FormattingEnabled = true;
            this.LbConvertedFiles.Location = new System.Drawing.Point(0, 0);
            this.LbConvertedFiles.Name = "LbConvertedFiles";
            this.LbConvertedFiles.Size = new System.Drawing.Size(707, 212);
            this.LbConvertedFiles.TabIndex = 55;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(600, 214);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 54;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LstOutput);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(681, 243);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Watcher Logs";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // LstOutput
            // 
            this.LstOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LstOutput.FormattingEnabled = true;
            this.LstOutput.Location = new System.Drawing.Point(0, 0);
            this.LstOutput.Name = "LstOutput";
            this.LstOutput.Size = new System.Drawing.Size(694, 212);
            this.LstOutput.TabIndex = 53;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(613, 219);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 51;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.BtnClearOutput_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LstFfmpegOutput);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(681, 243);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Conversion Logs";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LstFfmpegOutput
            // 
            this.LstFfmpegOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LstFfmpegOutput.BackColor = System.Drawing.SystemColors.MenuText;
            this.LstFfmpegOutput.ForeColor = System.Drawing.Color.White;
            this.LstFfmpegOutput.FormattingEnabled = true;
            this.LstFfmpegOutput.Location = new System.Drawing.Point(0, 0);
            this.LstFfmpegOutput.Name = "LstFfmpegOutput";
            this.LstFfmpegOutput.Size = new System.Drawing.Size(694, 212);
            this.LstFfmpegOutput.TabIndex = 55;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(613, 219);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 54;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip.Location = new System.Drawing.Point(0, 451);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(711, 22);
            this.statusStrip.TabIndex = 54;
            this.statusStrip.Text = "StpStatus";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusLabel.Text = "Idle";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(449, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel2.Image = global::mkvMediaConverter.Properties.Resources.Counter_5730;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(221, 17);
            this.toolStripStatusLabel2.Text = "0 Days, 0 Hours, 0 Minutes, 0 Seconds";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "mkv Media Converter";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 27);
            this.panel1.TabIndex = 56;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(711, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.postConverstionToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // postConverstionToolStripMenuItem
            // 
            this.postConverstionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteOldFileToolStripMenuItem});
            this.postConverstionToolStripMenuItem.Name = "postConverstionToolStripMenuItem";
            this.postConverstionToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.postConverstionToolStripMenuItem.Text = "Post-Conversion";
            // 
            // deleteOldFileToolStripMenuItem
            // 
            this.deleteOldFileToolStripMenuItem.Checked = true;
            this.deleteOldFileToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.deleteOldFileToolStripMenuItem.Name = "deleteOldFileToolStripMenuItem";
            this.deleteOldFileToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.deleteOldFileToolStripMenuItem.Text = "Delete Old File";
            this.deleteOldFileToolStripMenuItem.Click += new System.EventHandler(this.deleteOldFileToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::mkvMediaConverter.Properties.Resources.blue_banner;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.BtnWatch);
            this.panel2.Controls.Add(this.BtnSlctCstmFldr);
            this.panel2.Controls.Add(this.ChkCustomOutput);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.BtnSlctWtchFldr);
            this.panel2.Controls.Add(this.TxtWtchFldr);
            this.panel2.Controls.Add(this.TxtOutput);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(711, 136);
            this.panel2.TabIndex = 57;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.RbtnMP4toMKV);
            this.groupBox3.Controls.Add(this.RbtnMKVtoMP4);
            this.groupBox3.Location = new System.Drawing.Point(16, 89);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(603, 28);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            // 
            // RbtnMP4toMKV
            // 
            this.RbtnMP4toMKV.AutoSize = true;
            this.RbtnMP4toMKV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RbtnMP4toMKV.Location = new System.Drawing.Point(94, 8);
            this.RbtnMP4toMKV.Name = "RbtnMP4toMKV";
            this.RbtnMP4toMKV.Size = new System.Drawing.Size(85, 17);
            this.RbtnMP4toMKV.TabIndex = 1;
            this.RbtnMP4toMKV.Text = "MP4 to MKV";
            this.RbtnMP4toMKV.UseVisualStyleBackColor = true;
            this.RbtnMP4toMKV.Visible = false;
            // 
            // RbtnMKVtoMP4
            // 
            this.RbtnMKVtoMP4.AutoSize = true;
            this.RbtnMKVtoMP4.Checked = true;
            this.RbtnMKVtoMP4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RbtnMKVtoMP4.Location = new System.Drawing.Point(6, 8);
            this.RbtnMKVtoMP4.Name = "RbtnMKVtoMP4";
            this.RbtnMKVtoMP4.Size = new System.Drawing.Size(85, 17);
            this.RbtnMKVtoMP4.TabIndex = 0;
            this.RbtnMKVtoMP4.TabStop = true;
            this.RbtnMKVtoMP4.Text = "MKV to MP4";
            this.RbtnMKVtoMP4.UseVisualStyleBackColor = true;
            // 
            // BtnWatch
            // 
            this.BtnWatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnWatch.Image = global::mkvMediaConverter.Properties.Resources.ServiceStart_5723;
            this.BtnWatch.Location = new System.Drawing.Point(626, 94);
            this.BtnWatch.Name = "BtnWatch";
            this.BtnWatch.Size = new System.Drawing.Size(75, 23);
            this.BtnWatch.TabIndex = 50;
            this.BtnWatch.Text = "Start";
            this.BtnWatch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnWatch.UseVisualStyleBackColor = true;
            this.BtnWatch.Click += new System.EventHandler(this.BtnWatch_Click);
            // 
            // BtnSlctCstmFldr
            // 
            this.BtnSlctCstmFldr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSlctCstmFldr.Location = new System.Drawing.Point(626, 61);
            this.BtnSlctCstmFldr.Name = "BtnSlctCstmFldr";
            this.BtnSlctCstmFldr.Size = new System.Drawing.Size(75, 23);
            this.BtnSlctCstmFldr.TabIndex = 49;
            this.BtnSlctCstmFldr.Text = "Select";
            this.BtnSlctCstmFldr.UseVisualStyleBackColor = true;
            this.BtnSlctCstmFldr.Click += new System.EventHandler(this.BtnSlctCstmFldr_Click);
            // 
            // ChkCustomOutput
            // 
            this.ChkCustomOutput.AutoSize = true;
            this.ChkCustomOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkCustomOutput.Location = new System.Drawing.Point(15, 44);
            this.ChkCustomOutput.Name = "ChkCustomOutput";
            this.ChkCustomOutput.Size = new System.Drawing.Size(128, 17);
            this.ChkCustomOutput.TabIndex = 48;
            this.ChkCustomOutput.Text = "Custom Output Folder";
            this.ChkCustomOutput.UseVisualStyleBackColor = true;
            this.ChkCustomOutput.CheckedChanged += new System.EventHandler(this.ChkCustomOutput_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Watch Folder:";
            // 
            // BtnSlctWtchFldr
            // 
            this.BtnSlctWtchFldr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSlctWtchFldr.Location = new System.Drawing.Point(626, 19);
            this.BtnSlctWtchFldr.Name = "BtnSlctWtchFldr";
            this.BtnSlctWtchFldr.Size = new System.Drawing.Size(75, 23);
            this.BtnSlctWtchFldr.TabIndex = 47;
            this.BtnSlctWtchFldr.Text = "Select";
            this.BtnSlctWtchFldr.UseVisualStyleBackColor = true;
            this.BtnSlctWtchFldr.Click += new System.EventHandler(this.BtnSlctWtchFldr_Click);
            // 
            // TxtWtchFldr
            // 
            this.TxtWtchFldr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtWtchFldr.Location = new System.Drawing.Point(15, 20);
            this.TxtWtchFldr.Name = "TxtWtchFldr";
            this.TxtWtchFldr.Size = new System.Drawing.Size(603, 20);
            this.TxtWtchFldr.TabIndex = 45;
            // 
            // TxtOutput
            // 
            this.TxtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtOutput.Enabled = false;
            this.TxtOutput.Location = new System.Drawing.Point(15, 63);
            this.TxtOutput.Name = "TxtOutput";
            this.TxtOutput.Size = new System.Drawing.Size(603, 20);
            this.TxtOutput.TabIndex = 46;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BackgroundImage = global::mkvMediaConverter.Properties.Resources.blue_banner;
            this.ClientSize = new System.Drawing.Size(711, 473);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tpQueue);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "mkv Media Converter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.tpQueue.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Timer timer;
        private TabControl tpQueue;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ListBox LstOutput;
        private Button button2;
        private ListBox LstFfmpegOutput;
        private Button button3;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private TabPage tabPage3;
        private ListBox LbConvertedFiles;
        private Button button4;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private Timer timer1;
        private NotifyIcon notifyIcon;
        private Panel panel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem postConverstionToolStripMenuItem;
        private ToolStripMenuItem deleteOldFileToolStripMenuItem;
        private Panel panel2;
        private GroupBox groupBox3;
        private RadioButton RbtnMP4toMKV;
        private RadioButton RbtnMKVtoMP4;
        private Button BtnWatch;
        private Button BtnSlctCstmFldr;
        private CheckBox ChkCustomOutput;
        private Label label5;
        private Button BtnSlctWtchFldr;
        private TextBox TxtWtchFldr;
        private TextBox TxtOutput;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private TabPage tabPage4;
        private DataGridView dgvQueue;
    }
}

