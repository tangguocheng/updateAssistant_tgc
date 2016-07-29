using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace updataAssitant
{
    public partial class setup : Form
    {
        public setup()
        {
            InitializeComponent();
            Object[] buadRate = { "300", "600", "1200", "2400", "4800", "9600", "19200", "38400", "115200" };
            cmbInitBaud.Items.AddRange(buadRate);
            cmbComBaud.Items.AddRange(buadRate);
            cmbShakeBaud.Items.AddRange(buadRate);

            string[] protocol = { "userDefine", "IEC62056-21", "DTL645-07" };
            cmbProtocol.Items.AddRange(protocol);
            loadConfigXML();

        }
        private void loadConfigXML()
        {
            XElement rootXml = XElement.Load(Application.StartupPath + "\\configuration.xml");

            int initBaudIndex = cmbInitBaud.Items.IndexOf(rootXml.Element("serialInitBaud").Value.ToString());
            int comBaudIndex = cmbComBaud.Items.IndexOf(rootXml.Element("serialComBaud").Value.ToString());
            int protocolIndex = cmbProtocol.Items.IndexOf(rootXml.Element("serialProtocol").Value.ToString());
            int shakeBaudIndex = cmbShakeBaud.Items.IndexOf(rootXml.Element("serialShakeBaud").Value.ToString());

            cmbInitBaud.SelectedIndex = (initBaudIndex == -1) ? (0) : (initBaudIndex);
            cmbComBaud.SelectedIndex = (comBaudIndex == -1) ? (0) : (comBaudIndex);
            cmbProtocol.SelectedIndex = (protocolIndex == -1) ? (0) : (protocolIndex);
            cmbShakeBaud.SelectedIndex = (shakeBaudIndex == -1) ? (0) : (shakeBaudIndex);
            tbFrame.Text = @rootXml.Element("userFrame").Value;

            tbStart1.Text = rootXml.Element("codeStartAddr1").Value.ToUpper().Replace("0X", " ").Trim();
            tbStart2.Text = rootXml.Element("codeStartAddr2").Value.ToUpper().Replace("0X", " ").Trim();
            tbStart3.Text = rootXml.Element("codeStartAddr3").Value.ToUpper().Replace("0X", " ").Trim();

            tbEnd1.Text = rootXml.Element("codeEndAddr1").Value.ToUpper().Replace("0X", " ").Trim();
            tbEnd2.Text = rootXml.Element("codeEndAddr2").Value.ToUpper().Replace("0X", " ").Trim();
            tbEnd3.Text = rootXml.Element("codeEndAddr3").Value.ToUpper().Replace("0X", " ").Trim();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Application.StartupPath + "\\configuration.xml"))
            {
                System.IO.File.Delete(Application.StartupPath + "\\configuration.xml");
            }
            XDocument myXDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Settings", "setting"));
            myXDoc.Save(Application.StartupPath + "\\test2.xml");
            XElement root = new XElement("Settings",
                new XElement("serialInitBaud", cmbInitBaud.Text),
                new XElement("serialComBaud", cmbComBaud.Text),
                new XElement("serialShakeBaud", cmbShakeBaud.Text),
                new XElement("serialProtocol", cmbProtocol.Text),
                new XElement("userFrame", @tbFrame.Text.ToUpper()),
                new XElement("codeStartAddr1", "0x" + tbStart1.Text),
                new XElement("codeStartAddr2", "0x" + tbStart2.Text),
                new XElement("codeStartAddr3", "0x" + tbStart2.Text),
                new XElement("codeEndAddr1", "0x" + tbEnd1.Text),
                new XElement("codeEndAddr2", "0x" + tbEnd2.Text),
                new XElement("codeEndAddr3", "0x" + tbEnd3.Text)
                );

            root.Save(Application.StartupPath + "\\configuration.xml");
            Form1 parent = (Form1)this.Owner;
            parent.loadConfig();
            this.Close();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textChange(object sender, EventArgs e)
        {
            try
            {
                String numStr = ((TextBox)sender).Text;
                if (string.IsNullOrEmpty(numStr))
                {
                    return;
                }
                numStr = numStr.Replace("0x", " ");
                numStr = numStr.Replace("0X", " ");
                numStr = numStr.Trim();
                UInt32 test = Convert.ToUInt32(numStr, 16);
                if ((test < 0) || test > 0xFFFF)
                {
                     ((TextBox)sender).TextChanged -= textChange;
                    MessageBox.Show("输入内容不是数字或超范围（0000~FFFF）,请重新输入");
                    ((TextBox)sender).Text=null;
                    ((TextBox)sender).TextChanged += textChange;
                }
            }
            catch (Exception)
            {
                ((TextBox)sender).TextChanged -= textChange;
                MessageBox.Show("输入内容不是数字或超范围（0000~FFFF）,请重新输入");
                ((TextBox)sender).Text = null;
                ((TextBox)sender).TextChanged += textChange;
            }
        }
    }
}