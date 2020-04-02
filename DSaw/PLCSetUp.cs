using HslCommunication;
using HslCommunication.ModBus;
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
using System.Configuration;
using System.Xml.Linq;
using System.IO;

namespace DSaw
{
    public partial class PLCSetUp : Form
    {
        public PLCSetUp()
        {
            InitializeComponent();
        }

        private void PLCSetUp_Load(object sender, EventArgs e)
        {
            if (File.Exists("PLCConfig.xml"))
            {
                XElement MyEle = XElement.Load("PLCConfig.xml", LoadOptions.SetLineInfo);
                 textBox1.Text=MyEle.Element("PLCIP").Value;
                 textBox2.Text=MyEle.Element("PLCPort").Value ;
            }
            else
            { MessageBox.Show("Config配置文件丢失", "提示"); }

        }
        public ModbusTcpNet MyModbus;
        private void button1_Click(object sender, EventArgs e)
        {//打开连接
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("IP地址为空");
                return;
            }
            if (MyModbus == null)
            {
                MyModbus = new ModbusTcpNet(textBox1.Text, 502, 1);
                MyModbus.DataFormat = HslCommunication.Core.DataFormat.CDAB;
                MyModbus.ConnectTimeOut = 2000;
                MyModbus.IsStringReverse = true;
                OperateResult MyResult = MyModbus.ConnectServer();
                if (MyResult.IsSuccess)
                {                   
                    MessageBox.Show("连接成功", "提示");
                }
                else
                {
                    MessageBox.Show("连接失败", "提示");
                }
            }
            else
            {
                MessageBox.Show("PLC已连接");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {//关闭连接
            if (MyModbus != null)
            {
                OperateResult Result2 = MyModbus.ConnectClose();
                MyModbus = null;
                if (Result2.IsSuccess)
                {
                    MessageBox.Show("关闭成功", "提示");
                }
                else
                { MessageBox.Show("关闭失败", "提示"); }
            }
            else
            { MessageBox.Show("PLC未连接", "提示"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //XElement MyEle = XElement.Load("PLCConfig.xml", LoadOptions.SetLineInfo);
            //MessageBox.Show(MyEle.Element("PLCIP").Value.ToString());
            if (textBox1.Text == "" | textBox2.Text == "")
            {
                MessageBox.Show("端口号或者IP地址为空！", "提示");
                return;
            }
            if (File.Exists("PLCConfig.xml"))
            {
                XElement MyEle = XElement.Load("PLCConfig.xml", LoadOptions.SetLineInfo);
                MyEle.Element("PLCIP").Value = textBox1.Text;
                MyEle.Element("PLCPort").Value = textBox2.Text;
                
                MyEle.Save("PLCConfig.xml");
                //ConfigurationManager.RefreshSection("configuration");
            }
            else
            { MessageBox.Show("Config配置文件丢失", "提示"); }


        }

    }
}
