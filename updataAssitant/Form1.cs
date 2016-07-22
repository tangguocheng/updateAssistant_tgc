using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Ports;
using System.Timers;
using Microsoft.WindowsAPICodePack.Taskbar;
namespace updataAssitant
{
    public partial class Form1 : Form
    {
        private SerialPort myPort = new SerialPort();
        private System.Timers.Timer myTimer = new System.Timers.Timer();
        private TaskbarManager myTaskManager = TaskbarManager.Instance;
        public Form1()
        {
            InitializeComponent();
            myTaskManager.ApplicationId = "Taskbar";
            foreach (string name in SerialPort.GetPortNames())
            {
                cmbPortName.Items.Add(name);
            }
            cmbPortName.SelectedIndex = 0;
            myPort.DataReceived += MyPort_DataReceived;
            
            Object[] buadRate = { "300", "600", "1200", "2400", "4800", "9600", "19200", "38400", "115200"};
            cmbPortBAUD.Items.AddRange(buadRate);
            cmbInitBaud.Items.AddRange(buadRate);
            cmbInitBaud.SelectedIndex = 0;
            cmbPortBAUD.SelectedIndex = 5;
            Object[] dateBits = { "7", "8", "9" };
            cmbPortDateBits.Items.AddRange(dateBits);
            cmbPortDateBits.SelectedIndex = 1;
            Object[] stopBits = { "0","1","1.5","2"};
            cmbPortStopBits.Items.AddRange(stopBits);
            cmbPortStopBits.SelectedIndex = 1;
            Object[] parity = { "无","奇校验", "偶校验" };
            cmbPortPrity.Items.AddRange(parity);
            cmbPortPrity.SelectedIndex = 0;
            pgbUpdate.Minimum = 0;
            pgbUpdate.Maximum = 100;
            pgbUpdate.Value = 0;
            myTimer.Stop();
            myTimer.Elapsed += MyTimer_Elapsed;

            checkBox1.Checked = true;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            tbStart1.Enabled = checkBox1.Checked;
            tbEnd1.Enabled = checkBox1.Checked;
            tbStart2.Enabled = checkBox2.Checked;
            tbEnd2.Enabled = checkBox2.Checked;
            tbStart3.Enabled = checkBox3.Checked;
            tbEnd3.Enabled = checkBox3.Checked;
            if (TaskbarManager.IsPlatformSupported)
            {
                myTaskManager.SetProgressState(TaskbarProgressBarState.Paused, this.Handle);
                myTaskManager.SetProgressValue(29, 100, this.Handle);
            }
        }
        private Int64 currentLines = 0;

        /// <summary>
        /// 定时溢出处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private const int FrameLen = 22;
        private Int64 sendFrameCount = 0;
        private void MyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            myTimer.Stop();
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
                for (int i = 1; i < FrameLen - 2; i++)
                {
                    sendDate[i] = 0;
                }
                sendDate[0] = 0x23;
                sendDate[3] = 0x02;
                sendDate[FrameLen - 2] = 0x02;
                sendDate[FrameLen - 1] = 0x23;
                myPort.Write(sendDate, 0, FrameLen);
                return;
            }

            string[] update_split = updateFile[currentLines].Trim().Split(' ');
            for (int i = 1,j=4; i < update_split.Length; i++)
            {
                sendDate[j] = (byte)(Convert.ToByte(update_split[i], 16)); 
                chkTemp += sendDate[j];
                j++;            
            }
            
            sendDate[0] = 0x23;
            sendDate[1] = (byte)(Convert.ToUInt32(update_split[0], 16) / 512);           // 扇区号
            sendDate[2] = (byte)((Convert.ToUInt32(update_split[0], 16) % 512 ) / 16);   // 行号
            sendDate[3] = 0x00;
            sendDate[FrameLen-2] = (byte)(chkTemp + sendDate[1] + sendDate[2] + sendDate[3]);
            sendDate[FrameLen-1] = 0x23;

            myPort.Write(sendDate,0, FrameLen);
            sendFrameCount++;
            currentLines++;

            Action act = () => tbInformation.AppendText(System.DateTime.Now.ToString()+":  " + "第 "+Convert.ToString(sendFrameCount) +" 帧-->发送完成" + "\r\n");
            tbInformation.Invoke(act);
            
            act = () => tbFrameNow.Text = Convert.ToString(sendFrameCount);
            tbFrameNow.Invoke(act);

            act = () => tbFrameLast.Text = Convert.ToString(frameSum-sendFrameCount);
            tbFrameNow.Invoke(act);

            act = () => pgbUpdate.Value = (int)(sendFrameCount * 100 / frameSum);
            pgbUpdate.Invoke(act);

            myTaskManager.SetProgressValue((int)(sendFrameCount * 100 / frameSum), 100, this.Handle);
            
        }

        /// <summary>
        /// 串口接收处理
        /// </summary>
        private List<byte> myBuffer = new List<byte>(4096);
        private void MyPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int num = myPort.BytesToRead;
            byte[] byteTemp= new byte[num];
            myPort.Read(byteTemp, 0, num);
            myBuffer.AddRange(byteTemp);
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
                            break;
                        case 0x01:
                            information = "开始升级,发送第一帧数据";
                            sendSwitch = true;
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
                            information = "升级完成";
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
                            break;
                        default:
                            information = "undefined instruct";
                            break;
                    }
                    //information += Convert.ToSingle(type);
                    myBuffer.Clear();

                    Action act = () => tbInformation.AppendText(System.DateTime.Now.ToString() + ":  " + information + "\r\n");
                    tbInformation.Invoke(act);

                    if (sendSwitch && fileIsOpened)
                    {
                        myTimer.Interval = 800;     // 300ms后发送数据
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

        /// <summary>
        /// 打开/关闭串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOnOff_Click(object sender, EventArgs e)
        {
            if (myPort.IsOpen == false)
            {
                
                myPort.PortName = cmbPortName.Text;
                myPort.BaudRate = Convert.ToInt32(cmbPortBAUD.Text);
                switch (Convert.ToInt16(cmbPortStopBits.Text)*10)
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
                try
                {
                    myPort.Open();
                    btnOnOff.Text = "关闭";
                    cmbPortBAUD.Enabled = false;
                    cmbPortDateBits.Enabled = false;
                    cmbPortName.Enabled = false;
                    cmbPortPrity.Enabled = false;
                    cmbPortStopBits.Enabled = false;
                    tbInformation.AppendText(System.DateTime.Now.ToString()+":  " + cmbPortName.Text + "端口打开"+"\r\n");

                }
                catch (System.IO.IOException)
                {
                    tbInformation.AppendText(System.DateTime.Now.ToString()+":  " + cmbPortName.Text + "端口打开失败"+"\r\n");
                }

            }
            else 
            { 
                myPort.Close();
                btnOnOff.Text = "打开";
                cmbPortBAUD.Enabled = true;
                cmbPortDateBits.Enabled = true;
                cmbPortName.Enabled = true;
                cmbPortPrity.Enabled = true;
                cmbPortStopBits.Enabled = true;
                tbInformation.AppendText(System.DateTime.Now.ToString()+":  " +  cmbPortName.Text + "端口关闭" + "\r\n");

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

        String myFilePath;
        string myDirectoryName=null;
        private string[] updateFile;
        private bool fileIsOpened = false;
        private Int64 frameSum = 0;
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            string ALLFF = " FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF";
            string tempFileName = Application.StartupPath+"\\tempHexFile.txt";

            string[] content =new string[8192];
            for (UInt32 j=0,i = 0; i < 0x1FFFF; i += 16,j++)
            {
                content[j] = Convert.ToString(i,16).ToUpper()+ALLFF; 
            }
            System.IO.File.WriteAllLines(tempFileName, content);       

            OpenFileDialog myFileDialog = new OpenFileDialog();
            if (myDirectoryName==null)
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
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        private bool handleHexFile(string filePath)
        {
            string[] Hex=System.IO.File.ReadAllLines(filePath);
            string[] formatHex= System.IO.File.ReadAllLines(Application.StartupPath + "\\tempHexFile.txt");
            uint dateAddr = 0;
            uint dateLen = 0;
            foreach (string hexLine in Hex)
            {
                if (!string.IsNullOrEmpty(hexLine))
                {
                    if (hexLine.Substring(0, 1) == ":")          // hex-80文件以冒号":"开头
                    {
                        dateLen = Convert.ToUInt32(hexLine.Substring(1,2).Trim(),16);
                        dateAddr = Convert.ToUInt32(hexLine.Substring(3, 4).Trim(),16);
                        if (dateLen == 0)
                        {
                            continue;
                        }
                        uint modLine = dateAddr / 16;
                        uint modByte = dateAddr % 16 + 1;
                        uint modLen = dateLen;
                        string[] tempStr=null;
                        tempStr = formatHex[modLine].Trim().Split(' ');
                        
                        for (int i = 0; i < modLen*2; i+=2)
                        {
                            tempStr[modByte] = hexLine.Substring(9 + i, 2).Trim();
                            if (modByte>=16)
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
        /// 开始升级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateStart_Click(object sender, EventArgs e)
        {

            if ((myPort.IsOpen == false) || fileIsOpened == false)
            {
                if (myPort.IsOpen == false) tbInformation.AppendText(System.DateTime.Now.ToString()+":  " + "端口未打开\r\n");
                if (fileIsOpened == false) tbInformation.AppendText(System.DateTime.Now.ToString()+":  " + "升级文件未打开\r\n");
            }
            else
            {
                if (cmbPortBAUD.Text != cmbInitBaud.Text)
                {
                    myPort.Close();
                    myPort.BaudRate = Convert.ToInt32(cmbInitBaud.Text);
                    myPort.Open();

                }
                String start = @tbShakeHand.Text.ToUpper().Trim();//"AT#U\r";
                while (start.Contains(@"\R\N"))
                {
                    start = start.Replace(@"\R\N"," ");
                    start = start.Trim();
                }
                start += "\r";
                myPort.DiscardInBuffer();
                myPort.WriteLine(start);
                currentLines = 0;
                sendFrameCount = 0;
                tbInformation.AppendText(System.DateTime.Now.ToString() + ":  " + "开始升级\r\n");

                myPort.Close();
                myPort.BaudRate = Convert.ToInt32(cmbPortBAUD.Text);
                myPort.Open();
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbInformation_DoubleClick(object sender, EventArgs e)
        {
            tbInformation.Clear();
        }

        /// <summary>
        /// 停止升级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateStop_Click(object sender, EventArgs e)
        {
            myTimer.Stop();
            myPort.Close();
            currentLines = 0;
            sendFrameCount = 0;
            btnOnOff.Text = "打开";
            cmbPortBAUD.Enabled = true;
            cmbPortDateBits.Enabled = true;
            cmbPortName.Enabled = true;
            cmbPortPrity.Enabled = true;
            cmbPortStopBits.Enabled = true;
            tbInformation.AppendText(System.DateTime.Now.ToString()+":  "  + "停止升级" + "\r\n");
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            bool enable = ((CheckBox)sender).Checked;
            switch (((CheckBox)sender).Name)
            {
                case "checkBox1":
                    tbStart1.Enabled = enable;
                    tbEnd1.Enabled = enable;
                    break;
                case "checkBox2":
                    tbStart2.Enabled = enable;
                    tbEnd2.Enabled = enable;
                    break;
                case "checkBox3":
                    tbStart3.Enabled = enable;
                    tbEnd3.Enabled = enable;
                    break;
                default:
                    break;
            }
            
        }



        private void btnAddrEnter_Click(object sender, EventArgs e)
        {
            bool wrongRangeFlag = false;
            bool reverseFlag = false;
            bool not16xFlag = false;

            string wrongRange = "请输入代码段范围（0x0000~0xFFFF）";
            string reverse = "开始地址大于结束地址";
            string not16x = "代码地址不是16的倍数";

            if (checkBox1.Checked)
            {
                wrongRangeFlag = ((startAddr1 == 0) && (endAddr1 == 0));
                reverseFlag = (startAddr1 >= endAddr1);
                not16xFlag = ((startAddr1 % 16 != 0) || (endAddr1 % 16 != 0));
            }
            if (checkBox2.Checked)
            {
                wrongRangeFlag = ((startAddr2 == 0) && (endAddr2 == 0));
                reverseFlag = (startAddr2 >= endAddr2);
                not16xFlag = ((startAddr2 % 16 != 0) || (endAddr2 % 16 != 0));
            }
            if (checkBox3.Checked)
            {
                wrongRangeFlag = ((startAddr3 == 0) && (endAddr3 == 0));
                reverseFlag = (startAddr3 >= endAddr3);
                not16xFlag = ((startAddr3 % 16 != 0) || (endAddr3 % 16 != 0));
            }
            if (wrongRangeFlag)
            {
               MessageBox.Show(wrongRange);
            }
            if (reverseFlag)
            {
                MessageBox.Show(reverse);
            }
            if (not16xFlag)
            {
                MessageBox.Show(not16x);
            }

            if ((!wrongRangeFlag) && (!reverseFlag) &&(!not16xFlag))
            {
                MessageBox.Show("OK!");
            }
        }
        private UInt32 startAddr1 = 0x0600, startAddr2 = 0, startAddr3 = 0;

        private UInt32 endAddr1 = 0x0D7F0, endAddr2 = 0, endAddr3 = 0;
        private void tbAddr_textChange(object sender, EventArgs e)
        {
            try
            {            
                String numStr = ((TextBox)sender).Text;
                if ((numStr == "0x") || (numStr == "0X"))
                {
                    return;
                }

                numStr = numStr.Replace("0x"," ");
                numStr = numStr.Replace("0X", " ");
                numStr = numStr.Trim();
                UInt32 test = Convert.ToUInt32(numStr, 16);
                if ((test < 0) || test > 0xFFFF)
                {
                    ((TextBox)sender).TextChanged -= tbAddr_textChange;
                    MessageBox.Show("输入内容不是数字或超范围（0x0000~0xFFFF）,请重新输入");
                    ((TextBox)sender).Text = "0x";
                    ((TextBox)sender).TextChanged += tbAddr_textChange;
                }
                else
                {
                    switch (((TextBox)sender).Name)
                    {
                        case "tbStart1":
                            startAddr1 = test;
                            break;
                        case "tbStart2":
                            startAddr2 = test;
                            break;
                        case "tbStart3":
                            startAddr3 = test;
                            break;
                        case "tbEnd1":
                            endAddr1 = test;
                            break;
                        case "tbEnd2":
                            endAddr2 = test;
                            break;
                        case "tbEnd3":
                            endAddr3 = test;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {
                ((TextBox)sender).TextChanged -= tbAddr_textChange;
                MessageBox.Show("输入内容不是数字或超范围（0x0000~0xFFFF）,请重新输入");
                ((TextBox)sender).Text = "0x";
                ((TextBox)sender).TextChanged += tbAddr_textChange;
            }
        }
    }
}
