using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Ports;
using System.Timers;
using System.Xml.Linq;
using System.Threading;
namespace updataAssitant
{
    public partial class Form1 : Form
    {
        //private System.IO.FileSystemWatcher myFileWatcher = new System.IO.FileSystemWatcher();          // 用来检测文件是否变化
        //private SerialPort myPort = new SerialPort();
        private System.Timers.Timer myTimer = new System.Timers.Timer();
        private string currentProtocol = null;
        private UInt32 startAddr1 = 0, startAddr2 = 0, startAddr3 = 0;              // 用户代码地址范围
        private UInt32 endAddr1 = 0, endAddr2 = 0, endAddr3 = 0;
        private Int32 initBaud = 300;                       // 初始波特率，用于握手通信
        private Int32 comBaud = 19200;                      // bootloader通信波特率，用于升级
        private Int32 shakeBaud = 9600;                     // 仅用于21协议握手
        private string userDefFrame = null;                 // 用户自定义协议帧，用于握手
        private enum step : uint
        {
            shakeHand = 0,
            updateState,
            stop
        }
        step currentStep = step.shakeHand;                  // 用于指示通讯状态的全局变量
        private Int64 currentLines = 0;                     // 当前行，用于文件遍历
        private Int64 sendFrameCount = 0;                   // 已发送数据帧计数

        private const int FrameLen = 22;                    // 帧长度
        // bootloader控制代码
        private const byte CON_update = 0x00;               // 升级数据
        private const byte CON_sectorDone = 0x01;           // 扇区发送完成
        private const byte CON_allUpdateDone = 0x02;        // 全部升级完成
        private const byte CON_stopUpdate = 0x03;           // 停止升级
        private const byte CON_startUpdate = 0x04;          // 开始升级
        private const byte CON_exitBootloader = 0x05;       // 退出bootloader
        private List<byte> myBuffer = new List<byte>(1024); // 全局串口缓存数据
        private int stepCount = 0;                          // 用于21协议握手
        String myFilePath;                                  // 文件路径，包含文件名
        string myDirectoryName = null;                      // 文件目录，不含文件名
        private string[] updateFile;                        // 升级数据文件
        private Int64 frameSum = 0;                         // 计数，需要发送的升级数据帧总数
        private DateTime startTime;                         // 升级开始时间
        private DateTime endTime;                           // 升级结束时间

        private bool fileIsOpened = false;                  // 用于指示升级文件是否打开
        private bool updating = false;                      // 升级状态
        private bool bootLoaderRunning = false;             // bootloader运行状态
        private bool checkBTL = false;                      // 用以测试BTL状态

        public Form1()
        {
            InitializeComponent();

            foreach (string name in SerialPort.GetPortNames())
            {
                cmbPortName.Items.Add(name);
            }

            pictureBox_Port.Image = Properties.Resources.connect_close;
            cmbPortName.SelectedIndex = 0;
            myPort.DataReceived += MyPort_DataReceived;

            Object[] buadRate = { "300", "600", "1200", "2400", "4800", "9600", "19200", "38400", "115200" };
            cmbPortBAUD.Items.AddRange(buadRate);
            cmbPortBAUD.SelectedIndex = 5;
            //cmbPortBAUD.Enabled = false;                    // 使用配置文件配置
            Object[] dateBits = { "7", "8", "9" };
            cmbPortDateBits.Items.AddRange(dateBits);
            cmbPortDateBits.SelectedIndex = 1;
            Object[] stopBits = { "0", "1", "1.5", "2" };
            cmbPortStopBits.Items.AddRange(stopBits);
            cmbPortStopBits.SelectedIndex = 1;
            Object[] parity = { "无", "奇校验", "偶校验" };
            cmbPortPrity.Items.AddRange(parity);
            cmbPortPrity.SelectedIndex = 0;
            pgbUpdate.Minimum = 0;
            pgbUpdate.Maximum = 100;
            pgbUpdate.Value = 0;
            myTimer.Stop();
            myTimer.Elapsed += MyTimer_Elapsed;

            loadConfig();
        }

        /// <summary>
        /// 
        /// </summary>
        private void openMyPort()
        {
            statusLabelCom.Text = "当前串口:" + myPort.PortName + " " + "波特率:" + myPort.BaudRate.ToString() + " 握手协议:" + currentProtocol;
            myPort.Open();
        }

        /// <summary>
        /// 
        /// </summary>
        private void closeMyPort()
        {
            currentLines = 0;
            myBuffer.Clear();
            myPort.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void systemTimer_Tick(object sender, EventArgs e)
        {
            this.statusLabelTime.Text = DateTime.Now.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public void loadConfig()
        {
            if (!System.IO.File.Exists(Application.StartupPath + "\\configuration.xml"))
            {
                XDocument myXDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Settings", "setting"));
                myXDoc.Save(Application.StartupPath + "\\test2.xml");
                XElement root = new XElement("Settings",
                    new XElement("serialInitBaud", "300"),
                    new XElement("serialComBaud", "19200"),
                    new XElement("serialShakeBaud", "9600"),
                    new XElement("serialProtocol", "IEC62056-21"),
                    new XElement("userFrame", @"AT#U\R\N"),
                    new XElement("codeStartAddr1", "0x0600"),
                    new XElement("codeStartAddr3", "0"),
                    new XElement("codeStartAddr2", "0"),
                    new XElement("codeEndAddr1", "0xD7F0"),
                    new XElement("codeEndAddr2", "0"),
                    new XElement("codeEndAddr3", "0")
                    );

                root.Save(Application.StartupPath + "\\configuration.xml");
            }

            XElement rootXml = XElement.Load(Application.StartupPath + "\\configuration.xml");
            initBaud = Convert.ToInt32(rootXml.Element("serialInitBaud").Value);
            comBaud = Convert.ToInt32(rootXml.Element("serialComBaud").Value);
            shakeBaud = Convert.ToInt32(rootXml.Element("serialShakeBaud").Value);
            currentProtocol = rootXml.Element("serialProtocol").Value;
            userDefFrame = rootXml.Element("userFrame").Value;

            startAddr1 = Convert.ToUInt32(rootXml.Element("codeStartAddr1").Value.ToUpper().Replace("0X", " ").Trim(), 16);
            endAddr1 = Convert.ToUInt32(rootXml.Element("codeEndAddr1").Value.ToUpper().Replace("0X", " ").Trim(), 16);

            startAddr2 = Convert.ToUInt32(rootXml.Element("codeStartAddr2").Value.ToUpper().Replace("0X", " ").Trim(), 16);
            endAddr2 = Convert.ToUInt32(rootXml.Element("codeEndAddr2").Value.ToUpper().Replace("0X", " ").Trim(), 16);

            startAddr3 = Convert.ToUInt32(rootXml.Element("codeStartAddr3").Value.ToUpper().Replace("0X", " ").Trim(), 16);
            endAddr3 = Convert.ToUInt32(rootXml.Element("codeEndAddr3").Value.ToUpper().Replace("0X", " ").Trim(), 16);
        }

        /// <summary>
        /// 定时溢出处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            myTimer.Stop();
            if (checkBTL)
            {
                checkBTL = false;
                currentStep = step.shakeHand;
                Action failInfo = () => tbInformation.AppendText(System.DateTime.Now.ToString() + ":  " + "bootLoader未运行，请启动……" + "\r\n");
                tbInformation.Invoke(failInfo);
                return;
            }
            switch (currentStep)
            {
                case step.shakeHand:
                    shackHand();
                    break;
                case step.updateState:
                    sendUpdate();
                    break;
                case step.stop:
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// 将数据装为偶校验数据
        /// </summary>
        /// <param name="dat"></param>
        /// <returns></returns>
        private byte[] ConvertEven(byte[] dat)
        {
            byte[] rtl = dat;
            byte count1Bits = 0;
            for (int i = 0; i < rtl.Length; i++)
            {
                count1Bits = 0;
                byte temp = rtl[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((temp & 0x01) == 0x01)
                    {
                        count1Bits++;
                    }
                    temp = (byte)(temp >> 1);
                }

                if (count1Bits % 2 == 1)
                {
                    rtl[i] = (byte)(rtl[i] | 0x80);
                }
            }
            return rtl;
        }

        /// <summary>
        /// 升级前的握手处理
        /// </summary>
        private void shackHand()
        {
            byte[] temp1 = { 0x7F, 0x7F, 0x7F, 0x06, 0x30, 0x35, 0x31, 0x0D, 0x0A };
            byte[] temp2 = { 0x7F, 0x7F, 0x7F, 0x01, 0x50, 0x31, 0x02, 0x28, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x29, 0x03, 0x61 };
            byte[] temp3 = { 0x7F, 0x7F, 0x7F, 0x01, 0x45, 0x32, 0x02, 0x45, 0x38, 0x30, 0x31, 0x28, 0x29, 0x03, 0x0B };
            byte[] temp4 = { 0x7F, 0x7F, 0x7F, 0x01, 0x42, 0x30, 0x03, 0x71 };

            switch (currentProtocol)
            {
                case "userDefine":
                    currentStep = step.updateState;
                    closeMyPort();
                    myPort.BaudRate = comBaud;      // 自定义握手协议中，不使用中间握手波特率
                    openMyPort();
                    sendInstruct(CON_startUpdate);  // 发送升级指令
                    break;
                case "IEC62056-21":
                    {
                        Thread.Sleep(200);
                        switch (stepCount)
                        {
                            case 1:
                                temp1 = ConvertEven(temp1);
                                myPort.Write(temp1, 0, temp1.Length);
                                closeMyPort();
                                myPort.BaudRate = shakeBaud;
                                openMyPort();
                                break;

                            case 2:
                                temp2 = ConvertEven(temp2);
                                myPort.Write(temp2, 0, temp2.Length);
                                break;

                            case 3:
                                temp3 = ConvertEven(temp3);
                                myPort.Write(temp3, 0, temp3.Length);
                                break;

                            case 4:
                                temp4 = ConvertEven(temp4);
                                myPort.Write(temp4, 0, temp4.Length);
                                break;
                            default:
                                break;
                        }
                        if (stepCount == 4)
                        {
                            currentStep = step.updateState;
                            closeMyPort();
                            myPort.BaudRate = comBaud;
                            openMyPort();
                        }
                    }
                    break;
                case "DTL645-07":
                    break;
                default:
                    break;
            }

        }

        private void sendInstruct(byte type)
        {
            byte[] sendDate = new byte[FrameLen];
            for (int i = 1; i < FrameLen - 2; i++)
            {
                sendDate[i] = 0;
            }
            sendDate[0] = 0x23;
            sendDate[3] = type;
            sendDate[FrameLen - 2] = type;
            sendDate[FrameLen - 1] = 0x23;
            myPort.Write(sendDate, 0, FrameLen);
        }

        /// <summary>
        /// 发送升级数据
        /// </summary>
        private void sendUpdate()
        {
            byte[] sendDate = new byte[FrameLen];
            byte chkTemp = 0;

            UInt32 startLine, endLine;
            startLine = (UInt32)(startAddr1 / 16);
            endLine = (UInt32)(endAddr1 / 16);
            if (currentLines < startLine)
            {
                currentLines = startLine;
            }

            string ALLFF = "FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF";
            while ((currentLines <= endLine) && (updateFile[currentLines].Contains(ALLFF)))
            {
                currentLines++;
            }

            if (currentLines > endLine)
            {
                sendInstruct(CON_allUpdateDone);
                return;
            }

            string[] update_split = updateFile[currentLines].Trim().Split(' ');
            for (int i = 1, j = 4; i < update_split.Length; i++)
            {
                sendDate[j] = (byte)(Convert.ToByte(update_split[i], 16));
                chkTemp += sendDate[j];
                j++;
            }

            sendDate[0] = 0x23;
            sendDate[1] = (byte)(Convert.ToUInt32(update_split[0], 16) / 512);           // 扇区号
            sendDate[2] = (byte)((Convert.ToUInt32(update_split[0], 16) % 512) / 16);    // 行号
            sendDate[3] = 0x00;
            sendDate[FrameLen - 2] = (byte)(chkTemp + sendDate[1] + sendDate[2] + sendDate[3]);
            sendDate[FrameLen - 1] = 0x23;

            myPort.Write(sendDate, 0, FrameLen);
            sendFrameCount++;
            currentLines++;

            Action act = () => tbInformation.AppendText(System.DateTime.Now.ToString() + ":  " + "第 " + Convert.ToString(sendFrameCount) + " 帧 \t======> 发送完成" + "\r\n");
            tbInformation.Invoke(act);

            act = () => tbFrameNow.Text = Convert.ToString(sendFrameCount);
            tbFrameNow.Invoke(act);

            act = () => tbFrameLast.Text = Convert.ToString(frameSum - sendFrameCount);
            tbFrameNow.Invoke(act);

            act = () => pgbUpdate.Value = (int)(sendFrameCount * 100 / frameSum);
            pgbUpdate.Invoke(act);

        }

        /// <summary>
        /// 串口接收处理
        /// </summary>
        private void MyPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int num = myPort.BytesToRead;
            byte[] byteTemp = new byte[num];
            myPort.Read(byteTemp, 0, num);
            myBuffer.AddRange(byteTemp);

            switch (currentStep)
            {
                case step.shakeHand:
                    {
                        switch (currentProtocol)
                        {
                            case "userDefine":
                                if (myBuffer.Contains(0x0A) && (myBuffer[myBuffer.LastIndexOf(0x0A) - 1] == 0x0D))
                                {
                                    myBuffer.Clear();
                                    myTimer.Interval = 1500;
                                    myTimer.Start();
                                }
                                break;
                            case "IEC62056-21":
                                if (myBuffer.Contains(0x0A) || myBuffer.Contains(0x03) || myBuffer.Contains(0x06))
                                {
                                    myBuffer.Clear();
                                    stepCount++;
                                    myTimer.Interval = 300;
                                    myTimer.Start();
                                }
                                break;
                            case "DTL645-07":                       // 保留
                                break;
                            default:
                                break;
                        }

                    }
                    break;
                case step.updateState:
                    {
                        if (myBuffer.Count >= 4)
                        {
                            if ((myBuffer[0] == 0x23) && (myBuffer[3] == 0x23))
                            {
                                int type = (myBuffer[1] - 0x30) * 10 + myBuffer[2] - 0x30;
                                string information = null;
                                bool sendSwitch = false;
                                switch (type)
                                {
                                    case 0x00:
                                        information = "结束升级";
                                        updating = false;
                                        break;
                                    case 0x01:
                                        {
                                            information = "bootloader已运行";
                                            if (checkBTL)
                                            {
                                                checkBTL = false;
                                                myTimer.Stop();     
                                            }
                                            else
                                            {
                                                information += "，准备升级...";
                                                sendSwitch = true;
                                            }
                                            bootLoaderRunning = true;
                                        }
                                        break;
                                    case 0x02:
                                        information = "开始发送下一帧数据";
                                        sendSwitch = true;
                                        break;
                                    case 0x03:
                                        information = "开始发送下一扇区数据";
                                        sendSwitch = true;
                                        break;
                                    case 0x04:
                                        information = "升级完成" + "\n";
                                        endTime = System.DateTime.Now;
                                        TimeSpan ts = endTime.Subtract(startTime).Duration();
                                        information += ("\r\n" + "耗时:" + ts.Hours.ToString() + "小时"
                                                                         + ts.Minutes.ToString() + "分钟"
                                                                         + ts.Seconds.ToString() + "秒" + "\r\n");
                                        information += "跳转至用户代码";
                                        bootLoaderRunning = false;
                                        updating = false;
                                        {
                                            Action actTmp = () => btnUpdateStop.Enabled = false;
                                            btnUpdateStop.Invoke(actTmp);
                                            actTmp = () => btnEnterBTL.Enabled = true;
                                            btnEnterBTL.Invoke(actTmp);
                                            actTmp = () => btnExitBTL.Enabled = true;
                                            btnExitBTL.Invoke(actTmp);
                                        }
                                        break;
                                    case 0x05:
                                        information = "升级失败";
                                        break;
                                    case 0x06:
                                        information = "重发上一帧数据";
                                        if (currentLines != 0)
                                        {
                                            currentLines--;
                                        }
                                        sendSwitch = true;
                                        break;
                                    case 0x07:
                                        information = "undefined instruct";
                                        break;
                                    case 0x08:
                                        information = "bootloader运行中……";
                                        bootLoaderRunning = true;
                                        {
                                            Action actTmp = () => btnUpdateStart.Enabled = true;
                                            btnUpdateStart.Invoke(actTmp);
                                            actTmp = () => btnEnterBTL.Enabled = false;
                                            btnEnterBTL.Invoke(actTmp);
                                        }
                                        break;
                                    case 0x09:
                                        information = "退出bootloader，跳转至用户代码";
                                        bootLoaderRunning = false;
                                        updating = false;
                                        break;
                                    default:
                                        information = "undefined instruct";
                                        break;
                                }
                                myBuffer.Clear();

                                Action act = () => tbInformation.AppendText(System.DateTime.Now.ToString() + ":  " + information + "\r\n");
                                tbInformation.Invoke(act);

                                if (updating && sendSwitch && fileIsOpened && bootLoaderRunning)
                                {
                                    myTimer.Interval = 20;             // 800ms后发送数据
                                    myTimer.Start();
                                }

                            }
                            else
                            {
                                Action act = () => tbInformation.AppendText(System.DateTime.Now.ToString() + ":  " + "undefined instruct  " + Convert.ToString(myBuffer[0])
                                    + Convert.ToString(myBuffer[1])
                                    + Convert.ToString(myBuffer[2])
                                    + Convert.ToString(myBuffer[3]) + "\r\n");
                                tbInformation.Invoke(act);
                                myBuffer.Clear();
                                myPort.DiscardInBuffer();
                            }
                        }
                    }
                    break;
                case step.stop:
                    myBuffer.Clear();
                    break;
            }
        }


        /// <summary>
        /// 刷新串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshPort_Click(object sender, EventArgs e)
        {
            cmbPortName.Items.Clear();
            foreach (string name in SerialPort.GetPortNames())
            {
                cmbPortName.Items.Add(name);
            }
            cmbPortName.SelectedIndex = 0;
        }


        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (updating)
            {
                MessageBox.Show("正在升级，请先停止升级");
                return;
            }

            string ALLFF = " FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF";
            string tempFileName = Application.StartupPath + "\\tempHexFile.txt";

            string[] content = new string[8192];
            for (UInt32 j = 0, i = 0; i < 0x1FFFF; i += 16, j++)
            {
                content[j] = Convert.ToString(i, 16).ToUpper() + ALLFF;
            }
            System.IO.File.WriteAllLines(tempFileName, content);

            OpenFileDialog myFileDialog = new OpenFileDialog();
            if (myDirectoryName == null)
            {
                myFileDialog.InitialDirectory = "C:\\";
            }
            else
            {
                myFileDialog.InitialDirectory = myDirectoryName;
            }

            myFileDialog.Filter = "hex文件|*.hex|文本文件|*.txt";
            myFileDialog.FilterIndex = 0;
            myFileDialog.RestoreDirectory = true;

            if (myFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myFilePath = myFileDialog.FileName) != null)
                    {
                        System.IO.FileInfo fileInfo = new System.IO.FileInfo(myFilePath);
                        tbFilePath.Text = myFilePath;
                        myDirectoryName = fileInfo.DirectoryName;
                        if (fileInfo.Extension.ToUpper() == ".HEX")            // 打开的是HEX文件，将HEX文件转化为16个字节一行的形式存储
                        {
                            if (!handleHexFile(myFilePath))
                            {
                                MessageBox.Show("无法处理该HEX文件，请检查");
                                return;
                            }
                        }
                        else
                        {
                            updateFile = System.IO.File.ReadAllLines(myFilePath);
                        }

                        //string[] tempFile = new string[endAddr1 / 16- endAdd / 16];
                        // 获取需要升级的部分的实际数据长度
                        UInt32 startLine, endLine;
                        startLine = (UInt32)(startAddr1 / 16);
                        endLine = (UInt32)(endAddr1 / 16);
                        frameSum = 0;
                        for (UInt32 i = startLine; i <= endLine; i++)
                        {
                            frameSum++;
                            if ((string.IsNullOrWhiteSpace(updateFile[i])) || (updateFile[i].Contains(ALLFF)))  // 无数据或是全FF行，则不发送
                            {
                                frameSum--;
                            }
                        }
                        tbFrameSum.Text = Convert.ToString(frameSum);
                        int sectorSum = (int)(updateFile.Length * 16 / 512);
                        tbSectorSum.Text = Convert.ToString(sectorSum);
                        fileIsOpened = true;
                        btnUpdateStart.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文件失败，失败原因：\r\n" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 处理hex文件，截取用户代码
        /// </summary>
        /// <param name="filePath"></param>
        private bool handleHexFile(string filePath)
        {
            string[] Hex = System.IO.File.ReadAllLines(filePath);
            string[] formatHex = System.IO.File.ReadAllLines(Application.StartupPath + "\\tempHexFile.txt");
            uint dateAddr = 0;
            uint dateLen = 0;
            foreach (string hexLine in Hex)
            {
                if (!string.IsNullOrEmpty(hexLine))
                {
                    if (hexLine.Substring(0, 1) == ":")          // hex-80文件以冒号":"开头
                    {
                        dateLen = Convert.ToUInt32(hexLine.Substring(1, 2).Trim(), 16);
                        dateAddr = Convert.ToUInt32(hexLine.Substring(3, 4).Trim(), 16);
                        if (dateLen == 0)
                        {
                            continue;
                        }
                        uint modLine = dateAddr / 16;
                        uint modByte = dateAddr % 16 + 1;
                        uint modLen = dateLen;
                        string[] tempStr = null;
                        tempStr = formatHex[modLine].Trim().Split(' ');

                        for (int i = 0; i < modLen * 2; i += 2)
                        {
                            tempStr[modByte] = hexLine.Substring(9 + i, 2).Trim();
                            if (modByte >= 16)
                            {
                                string temp = null;
                                for (int n = 0; n < tempStr.Length; n++)
                                {
                                    temp += (tempStr[n].TrimStart() + ' ');
                                }
                                formatHex[modLine] = temp;

                                modByte = 0;
                                modLine++;
                                tempStr = formatHex[modLine].Trim().Split(' ');
                            }
                            modByte++;
                        }
                        string temp2 = null;
                        for (int n = 0; n < tempStr.Length; n++)
                        {
                            temp2 += (tempStr[n].TrimStart() + ' ');
                        }
                        formatHex[modLine] = temp2;

                    }
                    else
                    {
                        tbInformation.AppendText("empty");
                        return false;
                    }
                }
            }
            updateFile = formatHex;
            System.IO.File.WriteAllLines(Application.StartupPath + "\\HexFile.txt", formatHex);
            return true;
        }

        /// <summary>
        /// 菜单栏，打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemOpen_Click(object sender, EventArgs e)
        {
            this.btnOpenFile_Click(sender, e);
        }

        /// <summary>
        /// 菜单栏，退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            if (updating)
            {
                if (MessageBox.Show("程序正在升级，确定退出？", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// 菜单栏，帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemHelp_Click(object sender, EventArgs e)
        {
            helpAbout HAForm = new helpAbout();
            HAForm.Show();
        }

        /// <summary>
        /// 菜单栏，关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemAbout_Click(object sender, EventArgs e)
        {
            MenuItemHelp_Click(sender, e);
        }

        /// <summary>
        /// 设置波特率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemBaudRate_Click(object sender, EventArgs e)
        {
            setup mySetup = new setup();
            mySetup.Owner = this;
            mySetup.Show();
        }

        /// <summary>
        /// 设置代码范围
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemCodeRange_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 与下位机通信，启动bootloader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnterBTL_Click(object sender, EventArgs e)
        {
            if (bootLoaderRunning)
            {
                return;
            }
            if (myPort.IsOpen)
            {
                closeMyPort();
            }
            try
            {
                SerialPort testPort = new SerialPort(cmbPortName.Text);
                testPort.Close();
                testPort.Open();
                testPort.Close();                   // 用来测试串口是否可用
                myPort.PortName = cmbPortName.Text;
            }
            catch
            {
                tbInformation.AppendText(System.DateTime.Now.ToString() + ":  " + myPort.PortName + "端口不可用" + "\r\n");
                return;
            }

            switch (Convert.ToInt16(cmbPortStopBits.Text) * 10)
            {
                case 0:
                    myPort.StopBits = System.IO.Ports.StopBits.None;
                    break;
                case 10:
                    myPort.StopBits = System.IO.Ports.StopBits.One;
                    break;
                case 15:
                    myPort.StopBits = System.IO.Ports.StopBits.OnePointFive;
                    break;
                case 20:
                    myPort.StopBits = System.IO.Ports.StopBits.Two;
                    break;
                default:
                    myPort.StopBits = System.IO.Ports.StopBits.One;
                    break;
            }

            myPort.DataBits = Convert.ToInt32(cmbPortDateBits.Text);
            switch (cmbPortPrity.SelectedIndex)
            {
                case 0:
                    myPort.Parity = System.IO.Ports.Parity.None;
                    break;
                case 1:
                    myPort.Parity = System.IO.Ports.Parity.Odd;
                    break;
                case 2:
                    myPort.Parity = System.IO.Ports.Parity.Even;
                    break;
                default:
                    myPort.Parity = System.IO.Ports.Parity.None;
                    break;
            }

            myPort.BaudRate = initBaud;
            try
            {
                openMyPort();
                cmbPortBAUD.Enabled = false;
                cmbPortDateBits.Enabled = false;
                cmbPortName.Enabled = false;
                cmbPortPrity.Enabled = false;
                cmbPortStopBits.Enabled = false;
                pictureBox_Port.Image = Properties.Resources.connect_open;
            }
            catch (System.IO.IOException)
            {
                tbInformation.AppendText(System.DateTime.Now.ToString() + ":  " + cmbPortName.Text + "端口打开失败" + "\r\n");
                return;
            }

            currentStep = step.shakeHand;
            switch (currentProtocol)
            {
                case "userDefine":
                    {
                        String start = userDefFrame.ToUpper();
                        while (start.Contains(@"\R\N"))
                        {
                            start = start.Replace(@"\R\N", " ");
                            start = start.Trim();
                        }
                        start += "\r";
                        myPort.DiscardInBuffer();
                        myPort.WriteLine(start);

                    }
                    break;
                case "IEC62056-21":
                    {
                        byte[] startByte = { 0x7F, 0x7F, 0x7F, 0x2F, 0x3F, 0x21, 0x0D, 0x0A };
                        startByte = ConvertEven(startByte);
                        myPort.Write(startByte, 0, startByte.Length);
                        stepCount = 0;
                    }
                    break;
                case "DTL645-07":                       // 保留
                    break;
                default:
                    break;
            }
            currentLines = 0;
            sendFrameCount = 0;
        }

        /// <summary>
        /// 退出bootloader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExitBTL_Click(object sender, EventArgs e)
        {
            closeMyPort();
            myPort.BaudRate = comBaud;
            openMyPort();
            myTimer.Stop();
            sendInstruct(CON_exitBootloader);
            btnEnterBTL.Enabled = true;
            btnUpdateStart.Enabled = false;
            cmbPortBAUD.Enabled = false;
            cmbPortDateBits.Enabled = true;
            cmbPortName.Enabled = true;
            cmbPortPrity.Enabled = true;
            cmbPortStopBits.Enabled = true;
            pictureBox_Port.Image = Properties.Resources.connect_close;
        }

        private void MenuItemCheckBTL_Click_1(object sender, EventArgs e)
        {
            if (bootLoaderRunning)
            {
                tbInformation.AppendText(System.DateTime.Now.ToString() + ":  " + "bootloader已经运行……" + "\r\n");
                return;
            }

            tbInformation.AppendText(System.DateTime.Now.ToString() + ":  " + "测试bootloader是否已经运行……" + "\r\n");
            if (myPort.IsOpen)
            {
                closeMyPort();
            }
            myPort.PortName = cmbPortName.Text;
            myPort.BaudRate = comBaud;
            myPort.Parity = System.IO.Ports.Parity.None;
            myPort.StopBits = System.IO.Ports.StopBits.One;
            myPort.DataBits = Convert.ToInt32(cmbPortDateBits.Text);
            openMyPort();
            checkBTL = true;
            currentStep = step.updateState;
            sendInstruct(CON_startUpdate);
            myTimer.Interval = 2000;
            myTimer.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateStop_Click(object sender, EventArgs e)
        {
            sendInstruct(CON_stopUpdate);

            updating = false;
            myTimer.Stop();
            currentLines = 0;
            sendFrameCount = 0;
            btnUpdateStop.Enabled = false;
            btnEnterBTL.Enabled = false;
            btnExitBTL.Enabled = false;
            btnUpdateStart.Enabled = true;
            tbInformation.AppendText(System.DateTime.Now.ToString() + ":  " + "停止升级" + "\r\n");
        }

        /// <summary>
        /// 开始升级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateStart_Click(object sender, EventArgs e)
        {
            if (bootLoaderRunning && fileIsOpened)          // bootloader和文件均就绪
            {
                tbInformation.AppendText(System.DateTime.Now.ToString() + ":  " + "开始升级\r\n");
                startTime = System.DateTime.Now;            // 记录开始时间
                currentLines = 0;
                sendFrameCount = 0;                         // 重新发送整个数据文件
                updating = true;

                btnUpdateStop.Enabled = true;
                btnEnterBTL.Enabled = false;
                btnExitBTL.Enabled = false;
                btnUpdateStart.Enabled = false;
                sendInstruct(CON_startUpdate);
            }
            else
            {
                tbInformation.AppendText(System.DateTime.Now.ToString() + ":  " + "不符合升级条件:" + "\r\n"
                                        + "bootLoaderRunning:" + bootLoaderRunning.ToString() + "\r\n"
                                        + "fileIsOpened:" + fileIsOpened.ToString() + "\r\n");
            }
        }

        /// <summary>
        /// 清除文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbInformation_DoubleClick(object sender, EventArgs e)
        {
            tbInformation.Clear();
        }
    }
}
       