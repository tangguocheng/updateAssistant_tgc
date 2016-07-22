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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbFrameLast = new System.Windows.Forms.TextBox();
            this.tbSectorSum = new System.Windows.Forms.TextBox();
            this.tbFrameNow = new System.Windows.Forms.TextBox();
            this.tbFrameSum = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pgbUpdate = new System.Windows.Forms.ProgressBar();
            this.btnUpdateStart = new System.Windows.Forms.Button();
            this.btnUpdateStop = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tbInformation = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPortPrity = new System.Windows.Forms.ComboBox();
            this.cmbPortStopBits = new System.Windows.Forms.ComboBox();
            this.cmbPortDateBits = new System.Windows.Forms.ComboBox();
            this.cmbPortBAUD = new System.Windows.Forms.ComboBox();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.btnOnOff = new System.Windows.Forms.Button();
            this.btnRefreshPort = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbShakeHand = new System.Windows.Forms.TextBox();
            this.cmbInitBaud = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnAddrEnter = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.tbStart1 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tbEnd1 = new System.Windows.Forms.TextBox();
            this.tbStart2 = new System.Windows.Forms.TextBox();
            this.tbEnd3 = new System.Windows.Forms.TextBox();
            this.tbEnd2 = new System.Windows.Forms.TextBox();
            this.tbStart3 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(510, 316);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.tbInformation);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(502, 290);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "升级助手";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbFrameLast);
            this.groupBox3.Controls.Add(this.tbSectorSum);
            this.groupBox3.Controls.Add(this.tbFrameNow);
            this.groupBox3.Controls.Add(this.tbFrameSum);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.pgbUpdate);
            this.groupBox3.Controls.Add(this.btnUpdateStart);
            this.groupBox3.Controls.Add(this.btnUpdateStop);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(94, 186);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 101);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "升级";
            // 
            // tbFrameLast
            // 
            this.tbFrameLast.Location = new System.Drawing.Point(226, 48);
            this.tbFrameLast.Name = "tbFrameLast";
            this.tbFrameLast.ReadOnly = true;
            this.tbFrameLast.Size = new System.Drawing.Size(67, 21);
            this.tbFrameLast.TabIndex = 13;
            // 
            // tbSectorSum
            // 
            this.tbSectorSum.Location = new System.Drawing.Point(69, 48);
            this.tbSectorSum.Name = "tbSectorSum";
            this.tbSectorSum.ReadOnly = true;
            this.tbSectorSum.Size = new System.Drawing.Size(67, 21);
            this.tbSectorSum.TabIndex = 12;
            // 
            // tbFrameNow
            // 
            this.tbFrameNow.Location = new System.Drawing.Point(226, 20);
            this.tbFrameNow.Name = "tbFrameNow";
            this.tbFrameNow.ReadOnly = true;
            this.tbFrameNow.Size = new System.Drawing.Size(67, 21);
            this.tbFrameNow.TabIndex = 11;
            // 
            // tbFrameSum
            // 
            this.tbFrameSum.Location = new System.Drawing.Point(69, 17);
            this.tbFrameSum.Name = "tbFrameSum";
            this.tbFrameSum.ReadOnly = true;
            this.tbFrameSum.Size = new System.Drawing.Size(67, 21);
            this.tbFrameSum.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(149, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "剩余帧数";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "总扇区数:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(149, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "总帧数:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "总帧数:";
            // 
            // pgbUpdate
            // 
            this.pgbUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgbUpdate.Location = new System.Drawing.Point(3, 75);
            this.pgbUpdate.Name = "pgbUpdate";
            this.pgbUpdate.Size = new System.Drawing.Size(399, 23);
            this.pgbUpdate.Step = 1;
            this.pgbUpdate.TabIndex = 1;
            // 
            // btnUpdateStart
            // 
            this.btnUpdateStart.Enabled = false;
            this.btnUpdateStart.Location = new System.Drawing.Point(324, 20);
            this.btnUpdateStart.Name = "btnUpdateStart";
            this.btnUpdateStart.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateStart.TabIndex = 4;
            this.btnUpdateStart.Text = "开始升级";
            this.btnUpdateStart.UseVisualStyleBackColor = true;
            this.btnUpdateStart.Click += new System.EventHandler(this.btnUpdateStart_Click);
            // 
            // btnUpdateStop
            // 
            this.btnUpdateStop.Location = new System.Drawing.Point(324, 46);
            this.btnUpdateStop.Name = "btnUpdateStop";
            this.btnUpdateStop.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateStop.TabIndex = 2;
            this.btnUpdateStop.Text = "停止升级";
            this.btnUpdateStop.UseVisualStyleBackColor = true;
            this.btnUpdateStop.Click += new System.EventHandler(this.btnUpdateStop_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbFilePath);
            this.groupBox2.Controls.Add(this.btnOpenFile);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(94, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 47);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文件";
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(0, 14);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.ReadOnly = true;
            this.tbFilePath.Size = new System.Drawing.Size(318, 21);
            this.tbFilePath.TabIndex = 2;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(324, 12);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 3;
            this.btnOpenFile.Text = "打开文件";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tbInformation
            // 
            this.tbInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbInformation.Location = new System.Drawing.Point(94, 3);
            this.tbInformation.Multiline = true;
            this.tbInformation.Name = "tbInformation";
            this.tbInformation.ReadOnly = true;
            this.tbInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInformation.Size = new System.Drawing.Size(405, 136);
            this.tbInformation.TabIndex = 1;
            this.tbInformation.DoubleClick += new System.EventHandler(this.tbInformation_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbPortPrity);
            this.groupBox1.Controls.Add(this.cmbPortStopBits);
            this.groupBox1.Controls.Add(this.cmbPortDateBits);
            this.groupBox1.Controls.Add(this.cmbPortBAUD);
            this.groupBox1.Controls.Add(this.cmbPortName);
            this.groupBox1.Controls.Add(this.btnOnOff);
            this.groupBox1.Controls.Add(this.btnRefreshPort);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(91, 284);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "serialPort";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "校验位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "停止位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "数据位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "波特率";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口号";
            // 
            // cmbPortPrity
            // 
            this.cmbPortPrity.FormattingEnabled = true;
            this.cmbPortPrity.Location = new System.Drawing.Point(6, 186);
            this.cmbPortPrity.Name = "cmbPortPrity";
            this.cmbPortPrity.Size = new System.Drawing.Size(75, 20);
            this.cmbPortPrity.TabIndex = 6;
            // 
            // cmbPortStopBits
            // 
            this.cmbPortStopBits.FormattingEnabled = true;
            this.cmbPortStopBits.Location = new System.Drawing.Point(6, 148);
            this.cmbPortStopBits.Name = "cmbPortStopBits";
            this.cmbPortStopBits.Size = new System.Drawing.Size(75, 20);
            this.cmbPortStopBits.TabIndex = 5;
            // 
            // cmbPortDateBits
            // 
            this.cmbPortDateBits.FormattingEnabled = true;
            this.cmbPortDateBits.Location = new System.Drawing.Point(6, 110);
            this.cmbPortDateBits.Name = "cmbPortDateBits";
            this.cmbPortDateBits.Size = new System.Drawing.Size(75, 20);
            this.cmbPortDateBits.TabIndex = 4;
            // 
            // cmbPortBAUD
            // 
            this.cmbPortBAUD.FormattingEnabled = true;
            this.cmbPortBAUD.Location = new System.Drawing.Point(6, 72);
            this.cmbPortBAUD.Name = "cmbPortBAUD";
            this.cmbPortBAUD.Size = new System.Drawing.Size(75, 20);
            this.cmbPortBAUD.TabIndex = 3;
            // 
            // cmbPortName
            // 
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Location = new System.Drawing.Point(6, 34);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(75, 20);
            this.cmbPortName.TabIndex = 2;
            // 
            // btnOnOff
            // 
            this.btnOnOff.Location = new System.Drawing.Point(6, 229);
            this.btnOnOff.Name = "btnOnOff";
            this.btnOnOff.Size = new System.Drawing.Size(75, 23);
            this.btnOnOff.TabIndex = 1;
            this.btnOnOff.Text = "打开";
            this.btnOnOff.UseVisualStyleBackColor = true;
            this.btnOnOff.Click += new System.EventHandler(this.btnOnOff_Click);
            // 
            // btnRefreshPort
            // 
            this.btnRefreshPort.Location = new System.Drawing.Point(6, 258);
            this.btnRefreshPort.Name = "btnRefreshPort";
            this.btnRefreshPort.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshPort.TabIndex = 0;
            this.btnRefreshPort.Text = "刷新";
            this.btnRefreshPort.UseVisualStyleBackColor = true;
            this.btnRefreshPort.Click += new System.EventHandler(this.btnRefreshPort_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(502, 290);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置选项";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.tbShakeHand);
            this.groupBox5.Controls.Add(this.cmbInitBaud);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(496, 44);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "通讯握手";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(148, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 7;
            this.label14.Text = "握手帧格式";
            // 
            // tbShakeHand
            // 
            this.tbShakeHand.Location = new System.Drawing.Point(219, 17);
            this.tbShakeHand.Name = "tbShakeHand";
            this.tbShakeHand.Size = new System.Drawing.Size(274, 21);
            this.tbShakeHand.TabIndex = 6;
            this.tbShakeHand.Text = "AT#U\\r\\n";
            // 
            // cmbInitBaud
            // 
            this.cmbInitBaud.FormattingEnabled = true;
            this.cmbInitBaud.Location = new System.Drawing.Point(71, 17);
            this.cmbInitBaud.Name = "cmbInitBaud";
            this.cmbInitBaud.Size = new System.Drawing.Size(61, 20);
            this.cmbInitBaud.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(0, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "初始波特率";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.btnAddrEnter);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Controls.Add(this.checkBox3);
            this.groupBox4.Controls.Add(this.tbStart1);
            this.groupBox4.Controls.Add(this.checkBox2);
            this.groupBox4.Controls.Add(this.tbEnd1);
            this.groupBox4.Controls.Add(this.tbStart2);
            this.groupBox4.Controls.Add(this.tbEnd3);
            this.groupBox4.Controls.Add(this.tbEnd2);
            this.groupBox4.Controls.Add(this.tbStart3);
            this.groupBox4.Location = new System.Drawing.Point(3, 48);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(211, 242);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "用户代码段";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 148);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(215, 48);
            this.label13.TabIndex = 16;
            this.label13.Text = "备注：\r\n1.地址范围0x0000-0xFFFF;\r\n2.地址必须是16的倍数;\r\n3.每行的地址范围必须是递增且不重叠;";
            // 
            // btnAddrEnter
            // 
            this.btnAddrEnter.Location = new System.Drawing.Point(78, 122);
            this.btnAddrEnter.Name = "btnAddrEnter";
            this.btnAddrEnter.Size = new System.Drawing.Size(75, 23);
            this.btnAddrEnter.TabIndex = 15;
            this.btnAddrEnter.Text = "确认";
            this.btnAddrEnter.UseVisualStyleBackColor = true;
            this.btnAddrEnter.Click += new System.EventHandler(this.btnAddrEnter_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(124, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 14;
            this.label12.Text = "结束";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(59, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 13;
            this.label11.Text = "开始";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(7, 41);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "No.1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(7, 96);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox3.Size = new System.Drawing.Size(48, 16);
            this.checkBox3.TabIndex = 10;
            this.checkBox3.Text = "No.3";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // tbStart1
            // 
            this.tbStart1.Location = new System.Drawing.Point(61, 37);
            this.tbStart1.Name = "tbStart1";
            this.tbStart1.Size = new System.Drawing.Size(59, 21);
            this.tbStart1.TabIndex = 2;
            this.tbStart1.Text = "0x0600";
            this.tbStart1.TextChanged += new System.EventHandler(this.tbAddr_textChange);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(7, 69);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox2.Size = new System.Drawing.Size(48, 16);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "No.2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // tbEnd1
            // 
            this.tbEnd1.Location = new System.Drawing.Point(126, 36);
            this.tbEnd1.Name = "tbEnd1";
            this.tbEnd1.Size = new System.Drawing.Size(59, 21);
            this.tbEnd1.TabIndex = 3;
            this.tbEnd1.Text = "0xD7f0";
            this.tbEnd1.TextChanged += new System.EventHandler(this.tbAddr_textChange);
            // 
            // tbStart2
            // 
            this.tbStart2.Location = new System.Drawing.Point(61, 64);
            this.tbStart2.Name = "tbStart2";
            this.tbStart2.Size = new System.Drawing.Size(59, 21);
            this.tbStart2.TabIndex = 4;
            this.tbStart2.Text = "0x";
            this.tbStart2.TextChanged += new System.EventHandler(this.tbAddr_textChange);
            // 
            // tbEnd3
            // 
            this.tbEnd3.Location = new System.Drawing.Point(126, 91);
            this.tbEnd3.Name = "tbEnd3";
            this.tbEnd3.Size = new System.Drawing.Size(59, 21);
            this.tbEnd3.TabIndex = 7;
            this.tbEnd3.Text = "0x";
            this.tbEnd3.TextChanged += new System.EventHandler(this.tbAddr_textChange);
            // 
            // tbEnd2
            // 
            this.tbEnd2.Location = new System.Drawing.Point(126, 64);
            this.tbEnd2.Name = "tbEnd2";
            this.tbEnd2.Size = new System.Drawing.Size(59, 21);
            this.tbEnd2.TabIndex = 5;
            this.tbEnd2.Text = "0x";
            this.tbEnd2.TextChanged += new System.EventHandler(this.tbAddr_textChange);
            // 
            // tbStart3
            // 
            this.tbStart3.Location = new System.Drawing.Point(61, 91);
            this.tbStart3.Name = "tbStart3";
            this.tbStart3.Size = new System.Drawing.Size(59, 21);
            this.tbStart3.TabIndex = 6;
            this.tbStart3.Text = "0x";
            this.tbStart3.TextChanged += new System.EventHandler(this.tbAddr_textChange);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(510, 316);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "升级助手";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPortPrity;
        private System.Windows.Forms.ComboBox cmbPortStopBits;
        private System.Windows.Forms.ComboBox cmbPortDateBits;
        private System.Windows.Forms.ComboBox cmbPortBAUD;
        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.Button btnOnOff;
        private System.Windows.Forms.Button btnRefreshPort;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnUpdateStart;
        private System.Windows.Forms.Button btnUpdateStop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox tbInformation;
        private System.Windows.Forms.ProgressBar pgbUpdate;
        private System.Windows.Forms.TextBox tbFrameLast;
        private System.Windows.Forms.TextBox tbSectorSum;
        private System.Windows.Forms.TextBox tbFrameNow;
        private System.Windows.Forms.TextBox tbFrameSum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbInitBaud;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox tbEnd3;
        private System.Windows.Forms.TextBox tbStart3;
        private System.Windows.Forms.TextBox tbEnd2;
        private System.Windows.Forms.TextBox tbStart2;
        private System.Windows.Forms.TextBox tbEnd1;
        private System.Windows.Forms.TextBox tbStart1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAddrEnter;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbShakeHand;
    }
}

