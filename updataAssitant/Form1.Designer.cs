namespace updataAssitant
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpUpdateAssistant = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pgbUpdate = new System.Windows.Forms.ProgressBar();
            this.btnExitBTL = new System.Windows.Forms.Button();
            this.btnEnterBTL = new System.Windows.Forms.Button();
            this.btnUpdateStop = new System.Windows.Forms.Button();
            this.tbFrameLast = new System.Windows.Forms.TextBox();
            this.btnUpdateStart = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSectorSum = new System.Windows.Forms.TextBox();
            this.tbFrameNow = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbFrameSum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tbInformation = new System.Windows.Forms.TextBox();
            this.tbpSerialAssistant = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rtbReceive = new System.Windows.Forms.RichTextBox();
            this.cmbPortBAUD = new System.Windows.Forms.ComboBox();
            this.cmbPortDateBits = new System.Windows.Forms.ComboBox();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.cmbPortStopBits = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPortPrity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRefreshPort = new System.Windows.Forms.Button();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.pictureBox_Port = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCheckBTL = new System.Windows.Forms.ToolStripMenuItem();
            this.HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.statusLabelCom = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.systemTimer = new System.Windows.Forms.Timer(this.components);
            this.myPort = new System.IO.Ports.SerialPort(this.components);
            this.tabControl1.SuspendLayout();
            this.tbpUpdateAssistant.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tbpSerialAssistant.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Port)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpUpdateAssistant);
            this.tabControl1.Controls.Add(this.tbpSerialAssistant);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl1.Location = new System.Drawing.Point(81, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(469, 329);
            this.tabControl1.TabIndex = 0;
            // 
            // tbpUpdateAssistant
            // 
            this.tbpUpdateAssistant.Controls.Add(this.groupBox5);
            this.tbpUpdateAssistant.Controls.Add(this.groupBox2);
            this.tbpUpdateAssistant.Controls.Add(this.tbInformation);
            this.tbpUpdateAssistant.Location = new System.Drawing.Point(4, 22);
            this.tbpUpdateAssistant.Name = "tbpUpdateAssistant";
            this.tbpUpdateAssistant.Padding = new System.Windows.Forms.Padding(3);
            this.tbpUpdateAssistant.Size = new System.Drawing.Size(461, 303);
            this.tbpUpdateAssistant.TabIndex = 0;
            this.tbpUpdateAssistant.Text = "升级助手";
            this.tbpUpdateAssistant.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pgbUpdate);
            this.groupBox5.Controls.Add(this.btnExitBTL);
            this.groupBox5.Controls.Add(this.btnEnterBTL);
            this.groupBox5.Controls.Add(this.btnUpdateStop);
            this.groupBox5.Controls.Add(this.tbFrameLast);
            this.groupBox5.Controls.Add(this.btnUpdateStart);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.tbSectorSum);
            this.groupBox5.Controls.Add(this.tbFrameNow);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.tbFrameSum);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 179);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(455, 117);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "升级";
            // 
            // pgbUpdate
            // 
            this.pgbUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgbUpdate.Location = new System.Drawing.Point(3, 90);
            this.pgbUpdate.Name = "pgbUpdate";
            this.pgbUpdate.Size = new System.Drawing.Size(449, 24);
            this.pgbUpdate.Step = 1;
            this.pgbUpdate.TabIndex = 15;
            // 
            // btnExitBTL
            // 
            this.btnExitBTL.Location = new System.Drawing.Point(290, 47);
            this.btnExitBTL.Name = "btnExitBTL";
            this.btnExitBTL.Size = new System.Drawing.Size(75, 22);
            this.btnExitBTL.TabIndex = 16;
            this.btnExitBTL.Text = "退出BTL";
            this.btnExitBTL.UseVisualStyleBackColor = true;
            this.btnExitBTL.Click += new System.EventHandler(this.btnExitBTL_Click);
            // 
            // btnEnterBTL
            // 
            this.btnEnterBTL.Location = new System.Drawing.Point(290, 19);
            this.btnEnterBTL.Name = "btnEnterBTL";
            this.btnEnterBTL.Size = new System.Drawing.Size(75, 22);
            this.btnEnterBTL.TabIndex = 15;
            this.btnEnterBTL.Text = "启动BTL";
            this.btnEnterBTL.UseVisualStyleBackColor = true;
            this.btnEnterBTL.Click += new System.EventHandler(this.btnEnterBTL_Click);
            // 
            // btnUpdateStop
            // 
            this.btnUpdateStop.Enabled = false;
            this.btnUpdateStop.Location = new System.Drawing.Point(374, 48);
            this.btnUpdateStop.Name = "btnUpdateStop";
            this.btnUpdateStop.Size = new System.Drawing.Size(75, 22);
            this.btnUpdateStop.TabIndex = 14;
            this.btnUpdateStop.Text = "停止";
            this.btnUpdateStop.UseVisualStyleBackColor = true;
            this.btnUpdateStop.Click += new System.EventHandler(this.btnUpdateStop_Click);
            // 
            // tbFrameLast
            // 
            this.tbFrameLast.Location = new System.Drawing.Point(200, 48);
            this.tbFrameLast.Name = "tbFrameLast";
            this.tbFrameLast.ReadOnly = true;
            this.tbFrameLast.Size = new System.Drawing.Size(67, 21);
            this.tbFrameLast.TabIndex = 13;
            // 
            // btnUpdateStart
            // 
            this.btnUpdateStart.Enabled = false;
            this.btnUpdateStart.Location = new System.Drawing.Point(374, 20);
            this.btnUpdateStart.Name = "btnUpdateStart";
            this.btnUpdateStart.Size = new System.Drawing.Size(75, 22);
            this.btnUpdateStart.TabIndex = 4;
            this.btnUpdateStart.Text = "开始";
            this.btnUpdateStart.UseVisualStyleBackColor = true;
            this.btnUpdateStart.Click += new System.EventHandler(this.btnUpdateStart_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(147, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "剩余帧:";
            // 
            // tbSectorSum
            // 
            this.tbSectorSum.Location = new System.Drawing.Point(71, 49);
            this.tbSectorSum.Name = "tbSectorSum";
            this.tbSectorSum.ReadOnly = true;
            this.tbSectorSum.Size = new System.Drawing.Size(67, 21);
            this.tbSectorSum.TabIndex = 12;
            // 
            // tbFrameNow
            // 
            this.tbFrameNow.Location = new System.Drawing.Point(200, 20);
            this.tbFrameNow.Name = "tbFrameNow";
            this.tbFrameNow.ReadOnly = true;
            this.tbFrameNow.Size = new System.Drawing.Size(67, 21);
            this.tbFrameNow.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "总扇区数:";
            // 
            // tbFrameSum
            // 
            this.tbFrameSum.Location = new System.Drawing.Point(71, 19);
            this.tbFrameSum.Name = "tbFrameSum";
            this.tbFrameSum.ReadOnly = true;
            this.tbFrameSum.Size = new System.Drawing.Size(67, 21);
            this.tbFrameSum.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(147, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "当前帧:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "总帧数:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbFilePath);
            this.groupBox2.Controls.Add(this.btnOpenFile);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(455, 41);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文件";
            // 
            // tbFilePath
            // 
            this.tbFilePath.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbFilePath.Location = new System.Drawing.Point(3, 17);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.ReadOnly = true;
            this.tbFilePath.Size = new System.Drawing.Size(368, 21);
            this.tbFilePath.TabIndex = 2;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOpenFile.Location = new System.Drawing.Point(377, 17);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 21);
            this.btnOpenFile.TabIndex = 3;
            this.btnOpenFile.Text = "打开文件";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tbInformation
            // 
            this.tbInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbInformation.Location = new System.Drawing.Point(3, 3);
            this.tbInformation.Multiline = true;
            this.tbInformation.Name = "tbInformation";
            this.tbInformation.ReadOnly = true;
            this.tbInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInformation.Size = new System.Drawing.Size(455, 135);
            this.tbInformation.TabIndex = 1;
            this.tbInformation.DoubleClick += new System.EventHandler(this.tbInformation_DoubleClick);
            // 
            // tbpSerialAssistant
            // 
            this.tbpSerialAssistant.Controls.Add(this.tableLayoutPanel1);
            this.tbpSerialAssistant.Location = new System.Drawing.Point(4, 22);
            this.tbpSerialAssistant.Name = "tbpSerialAssistant";
            this.tbpSerialAssistant.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSerialAssistant.Size = new System.Drawing.Size(461, 303);
            this.tbpSerialAssistant.TabIndex = 1;
            this.tbpSerialAssistant.Text = "串口助手";
            this.tbpSerialAssistant.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.rtbReceive, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(455, 297);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // rtbReceive
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.rtbReceive, 2);
            this.rtbReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbReceive.Location = new System.Drawing.Point(3, 3);
            this.rtbReceive.Name = "rtbReceive";
            this.rtbReceive.Size = new System.Drawing.Size(449, 142);
            this.rtbReceive.TabIndex = 15;
            this.rtbReceive.Text = "";
            // 
            // cmbPortBAUD
            // 
            this.cmbPortBAUD.FormattingEnabled = true;
            this.cmbPortBAUD.Location = new System.Drawing.Point(6, 53);
            this.cmbPortBAUD.Name = "cmbPortBAUD";
            this.cmbPortBAUD.Size = new System.Drawing.Size(75, 20);
            this.cmbPortBAUD.TabIndex = 3;
            // 
            // cmbPortDateBits
            // 
            this.cmbPortDateBits.FormattingEnabled = true;
            this.cmbPortDateBits.Location = new System.Drawing.Point(6, 91);
            this.cmbPortDateBits.Name = "cmbPortDateBits";
            this.cmbPortDateBits.Size = new System.Drawing.Size(75, 20);
            this.cmbPortDateBits.TabIndex = 4;
            // 
            // cmbPortName
            // 
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Location = new System.Drawing.Point(6, 15);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(75, 20);
            this.cmbPortName.TabIndex = 2;
            // 
            // cmbPortStopBits
            // 
            this.cmbPortStopBits.FormattingEnabled = true;
            this.cmbPortStopBits.Location = new System.Drawing.Point(6, 167);
            this.cmbPortStopBits.Name = "cmbPortStopBits";
            this.cmbPortStopBits.Size = new System.Drawing.Size(75, 20);
            this.cmbPortStopBits.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "波特率";
            // 
            // cmbPortPrity
            // 
            this.cmbPortPrity.FormattingEnabled = true;
            this.cmbPortPrity.Location = new System.Drawing.Point(6, 129);
            this.cmbPortPrity.Name = "cmbPortPrity";
            this.cmbPortPrity.Size = new System.Drawing.Size(75, 20);
            this.cmbPortPrity.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "数据位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "停止位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "校验位";
            // 
            // btnRefreshPort
            // 
            this.btnRefreshPort.Location = new System.Drawing.Point(6, 294);
            this.btnRefreshPort.Name = "btnRefreshPort";
            this.btnRefreshPort.Size = new System.Drawing.Size(75, 21);
            this.btnRefreshPort.TabIndex = 0;
            this.btnRefreshPort.Text = "刷新";
            this.btnRefreshPort.UseVisualStyleBackColor = true;
            this.btnRefreshPort.Click += new System.EventHandler(this.btnRefreshPort_Click);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pictureBox_Port);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.cmbPortBAUD);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnRefreshPort);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.cmbPortDateBits);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tabControl1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label5);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.cmbPortName);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label3);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.cmbPortPrity);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.cmbPortStopBits);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label4);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label2);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(545, 346);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 25);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(545, 346);
            this.toolStripContainer1.TabIndex = 12;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // pictureBox_Port
            // 
            this.pictureBox_Port.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Port.Location = new System.Drawing.Point(12, 220);
            this.pictureBox_Port.Name = "pictureBox_Port";
            this.pictureBox_Port.Size = new System.Drawing.Size(58, 50);
            this.pictureBox_Port.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Port.TabIndex = 11;
            this.pictureBox_Port.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FToolStripMenuItem,
            this.MenuItemSetup,
            this.HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(545, 25);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FToolStripMenuItem
            // 
            this.FToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemOpen,
            this.MenuItemExit});
            this.FToolStripMenuItem.Image = global::updataAssitant.Properties.Resources.folder;
            this.FToolStripMenuItem.Name = "FToolStripMenuItem";
            this.FToolStripMenuItem.ShowShortcutKeys = false;
            this.FToolStripMenuItem.Size = new System.Drawing.Size(74, 21);
            this.FToolStripMenuItem.Text = "文件(&F)";
            // 
            // MenuItemOpen
            // 
            this.MenuItemOpen.Image = global::updataAssitant.Properties.Resources.File;
            this.MenuItemOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuItemOpen.Name = "MenuItemOpen";
            this.MenuItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MenuItemOpen.ShowShortcutKeys = false;
            this.MenuItemOpen.Size = new System.Drawing.Size(110, 22);
            this.MenuItemOpen.Text = "打开(&O)";
            this.MenuItemOpen.Click += new System.EventHandler(this.MenuItemOpen_Click);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Image = global::updataAssitant.Properties.Resources.close;
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.MenuItemExit.ShowShortcutKeys = false;
            this.MenuItemExit.Size = new System.Drawing.Size(110, 22);
            this.MenuItemExit.Text = "退出(&X)";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // MenuItemSetup
            // 
            this.MenuItemSetup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemConfig,
            this.MenuItemCheckBTL});
            this.MenuItemSetup.Image = global::updataAssitant.Properties.Resources.setup;
            this.MenuItemSetup.Name = "MenuItemSetup";
            this.MenuItemSetup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.MenuItemSetup.ShowShortcutKeys = false;
            this.MenuItemSetup.Size = new System.Drawing.Size(75, 21);
            this.MenuItemSetup.Text = "设置(&T)";
            // 
            // MenuItemConfig
            // 
            this.MenuItemConfig.Image = global::updataAssitant.Properties.Resources.speed;
            this.MenuItemConfig.Name = "MenuItemConfig";
            this.MenuItemConfig.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.MenuItemConfig.ShowShortcutKeys = false;
            this.MenuItemConfig.Size = new System.Drawing.Size(153, 22);
            this.MenuItemConfig.Text = "通信及代码&B)";
            this.MenuItemConfig.Click += new System.EventHandler(this.MenuItemBaudRate_Click);
            // 
            // MenuItemCheckBTL
            // 
            this.MenuItemCheckBTL.Image = global::updataAssitant.Properties.Resources.TestBTL;
            this.MenuItemCheckBTL.Name = "MenuItemCheckBTL";
            this.MenuItemCheckBTL.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.MenuItemCheckBTL.ShowShortcutKeys = false;
            this.MenuItemCheckBTL.Size = new System.Drawing.Size(153, 22);
            this.MenuItemCheckBTL.Text = "检查BTL状态(&K)";
            this.MenuItemCheckBTL.Click += new System.EventHandler(this.MenuItemCheckBTL_Click_1);
            // 
            // HToolStripMenuItem
            // 
            this.HToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemHelp,
            this.toolStripSeparator5,
            this.MenuItemAbout});
            this.HToolStripMenuItem.Image = global::updataAssitant.Properties.Resources.help;
            this.HToolStripMenuItem.Name = "HToolStripMenuItem";
            this.HToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
            this.HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // MenuItemHelp
            // 
            this.MenuItemHelp.Image = global::updataAssitant.Properties.Resources.help_class2;
            this.MenuItemHelp.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.MenuItemHelp.Name = "MenuItemHelp";
            this.MenuItemHelp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.MenuItemHelp.ShowShortcutKeys = false;
            this.MenuItemHelp.Size = new System.Drawing.Size(117, 22);
            this.MenuItemHelp.Text = "帮助(&H)";
            this.MenuItemHelp.Click += new System.EventHandler(this.MenuItemHelp_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(114, 6);
            // 
            // MenuItemAbout
            // 
            this.MenuItemAbout.Image = global::updataAssitant.Properties.Resources.about;
            this.MenuItemAbout.Name = "MenuItemAbout";
            this.MenuItemAbout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.MenuItemAbout.ShowShortcutKeys = false;
            this.MenuItemAbout.Size = new System.Drawing.Size(117, 22);
            this.MenuItemAbout.Text = "关于(&A)...";
            this.MenuItemAbout.Click += new System.EventHandler(this.MenuItemAbout_Click);
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelCom,
            this.toolStripStatusLabel2,
            this.statusLabelTime});
            this.statusStrip2.Location = new System.Drawing.Point(0, 349);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(545, 22);
            this.statusStrip2.TabIndex = 14;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // statusLabelCom
            // 
            this.statusLabelCom.Name = "statusLabelCom";
            this.statusLabelCom.Size = new System.Drawing.Size(12, 17);
            this.statusLabelCom.Text = " ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(518, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = " ";
            // 
            // statusLabelTime
            // 
            this.statusLabelTime.Name = "statusLabelTime";
            this.statusLabelTime.Size = new System.Drawing.Size(0, 17);
            // 
            // systemTimer
            // 
            this.systemTimer.Enabled = true;
            this.systemTimer.Interval = 1000;
            this.systemTimer.Tick += new System.EventHandler(this.systemTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(545, 371);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.85D;
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "升级助手";
            this.tabControl1.ResumeLayout(false);
            this.tbpUpdateAssistant.ResumeLayout(false);
            this.tbpUpdateAssistant.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tbpSerialAssistant.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Port)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpUpdateAssistant;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbFrameLast;
        private System.Windows.Forms.Button btnUpdateStart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbSectorSum;
        private System.Windows.Forms.TextBox tbFrameNow;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbFrameSum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TabPage tbpSerialAssistant;
        private System.Windows.Forms.ComboBox cmbPortBAUD;
        private System.Windows.Forms.ComboBox cmbPortDateBits;
        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.ComboBox cmbPortStopBits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPortPrity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRefreshPort;
        private System.Windows.Forms.PictureBox pictureBox_Port;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSetup;
        private System.Windows.Forms.ToolStripMenuItem MenuItemConfig;
        private System.Windows.Forms.TextBox tbInformation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox rtbReceive;
        private System.Windows.Forms.Button btnUpdateStop;
        private System.Windows.Forms.Button btnExitBTL;
        private System.Windows.Forms.Button btnEnterBTL;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCheckBTL;
        private System.Windows.Forms.ProgressBar pgbUpdate;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelCom;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelTime;
        private System.Windows.Forms.Timer systemTimer;
        private System.IO.Ports.SerialPort myPort;
    }
}

