using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IIWS.Window.Call.Models;
using DSaw;
using DSaw.LedLibrary;

namespace IIWS.Window.Call
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
            BindCmbReadPerson();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            txtIp.Text = configuration.AppSettings.Settings["QYLED_IPaddress"].Value;           
            cmbReadPerson.SelectedValue = configuration.AppSettings.Settings["ReadPerson"].Value;
            txtYinLiang.Text = configuration.AppSettings.Settings["YinLiang"].Value;
            txtYuSu.Text = configuration.AppSettings.Settings["YuSu"].Value;

            txtArea1UID.Text = configuration.AppSettings.Settings["Area1UID"].Value;
            txtArea1Width.Text = configuration.AppSettings.Settings["Area1Width"].Value;
            txtArea1Height.Text = configuration.AppSettings.Settings["Area1Height"].Value;
            txtArea2UID.Text = configuration.AppSettings.Settings["Area2UID"].Value;
            txtArea2Width.Text = configuration.AppSettings.Settings["Area2Width"].Value;
            txtArea2Height.Text = configuration.AppSettings.Settings["Area2Height"].Value;
            txtArea3UID.Text = configuration.AppSettings.Settings["Area3UID"].Value;
            txtArea3Width.Text = configuration.AppSettings.Settings["Area3Width"].Value;
            txtArea3Height.Text = configuration.AppSettings.Settings["Area3Height"].Value;
            txtArea4UID.Text = configuration.AppSettings.Settings["Area4UID"].Value;
            txtArea4Width.Text = configuration.AppSettings.Settings["Area4Width"].Value;
            txtArea4Height.Text = configuration.AppSettings.Settings["Area4Height"].Value;
            txtArea5UID.Text = configuration.AppSettings.Settings["Area5UID"].Value;
            txtArea5Width.Text = configuration.AppSettings.Settings["Area5Width"].Value;
            txtArea5Height.Text = configuration.AppSettings.Settings["Area5Height"].Value;



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string ip= this.txtIp.Text.Trim();
            string readPerson = this.cmbReadPerson.SelectedValue.ToString();
            string yinLiang= this.txtYinLiang.Text.Trim(); ;
            string yusu= this.txtYuSu.Text.Trim();

            configuration.AppSettings.Settings["QYLED_IPaddress"].Value = ip;
            configuration.AppSettings.Settings["ReadPerson"].Value = readPerson;
            configuration.AppSettings.Settings["YinLiang"].Value = yinLiang;
            configuration.AppSettings.Settings["YuSu"].Value = yusu;

            configuration.AppSettings.Settings["Area1UID"].Value = txtArea1UID.Text.Trim();
            configuration.AppSettings.Settings["Area1Width"].Value = txtArea1Width.Text.Trim();
            configuration.AppSettings.Settings["Area1Height"].Value = txtArea1Height.Text.Trim();
            configuration.AppSettings.Settings["Area2UID"].Value = txtArea2UID.Text.Trim();
            configuration.AppSettings.Settings["Area2Width"].Value = txtArea2Width.Text.Trim();
            configuration.AppSettings.Settings["Area2Height"].Value = txtArea2Height.Text.Trim();
            configuration.AppSettings.Settings["Area3UID"].Value = txtArea3UID.Text.Trim();
            configuration.AppSettings.Settings["Area3Width"].Value = txtArea3Width.Text.Trim();
            configuration.AppSettings.Settings["Area3Height"].Value = txtArea3Height.Text.Trim();
            configuration.AppSettings.Settings["Area4UID"].Value = txtArea4UID.Text.Trim();
            configuration.AppSettings.Settings["Area4Width"].Value = txtArea4Width.Text.Trim();
            configuration.AppSettings.Settings["Area4Height"].Value = txtArea4Height.Text.Trim();
            configuration.AppSettings.Settings["Area5UID"].Value = txtArea5UID.Text.Trim();
            configuration.AppSettings.Settings["Area5Width"].Value = txtArea5Width.Text.Trim();
            configuration.AppSettings.Settings["Area5Height"].Value = txtArea5Height.Text.Trim();





            //string voiceConfig = "[" + readPerson + "][" + yinLiang + "][" + yusu + "]";


            ////udp语音播放
            //int netprotocol = 1;
            //string voicetext = txtTesttext.Text;
            //string rsadr = "00";
            //QYLED_DLL.PlayVoice_Net(voiceConfig, ip, rsadr, netprotocol, 2);

            configuration.Save();
            MessageBox.Show(@"保存设置成功!");
        }

        private void btnSendTest_Click(object sender, EventArgs e)
        {
            //udp语音播放
            int netprotocol = 1;
            string voicetext = txtTesttext.Text;
            string ip = txtIp.Text;
            string rsadr = "00";
            QYLED_DLL.PlayVoice_Net(voicetext, ip, rsadr, netprotocol, 2);
        }

        private void BindCmbReadPerson()
        {
            List<ReadPerson> list = new List<ReadPerson>();
            list.Add(new ReadPerson() { Name = "小燕(女声)", Value = "m3" });
            list.Add(new ReadPerson() { Name = "小萍(女声)", Value = "m53" });
            list.Add(new ReadPerson() { Name = "许久(男声)", Value = "m51" });
            list.Add(new ReadPerson() { Name = "许多(男声)", Value = "m52" });

            cmbReadPerson.DataSource = list;
            cmbReadPerson.DisplayMember = "Name";
            cmbReadPerson.ValueMember = "Value";
        }

        private void btnArea1Test_Click(object sender, EventArgs e)
        {
            string text = txtArea1Text.Text;
            int uid = Convert.ToInt32(txtArea1UID.Text.Trim());
            int width = Convert.ToInt32(txtArea1Width.Text.Trim());
            int height = Convert.ToInt32(txtArea1Height.Text.Trim());
            int style = 9; //立即显示

            QYLEDController qy = new QYLEDController();

            int result = 1;
            result = qy.SendInternalText_Net(text, uid, width, height, style);

            if (result == 0)
            {
                MessageBox.Show("下发成功！", "udp发送内码文字内容");
            }
            else
            {
                MessageBox.Show("下发失败！", "udp发送内码文字内容");
            }
        }

        private void btnArea2Test_Click(object sender, EventArgs e)
        {
            string text = txtArea2Text.Text;
            int uid = Convert.ToInt32(txtArea2UID.Text.Trim());
            int width = Convert.ToInt32(txtArea2Width.Text.Trim());
            int height = Convert.ToInt32(txtArea2Height.Text.Trim());
            int style = 14; //闪烁

            QYLEDController qy = new QYLEDController();

            int result = 1;
            result = qy.SendInternalText_Net(text, uid, width, height, style);

            if (result == 0)
            {
                MessageBox.Show("下发成功！", "udp发送内码文字内容");
            }
            else
            {
                MessageBox.Show("下发失败！", "udp发送内码文字内容");
            }
        }

        private void btnArea3Test_Click(object sender, EventArgs e)
        {
            string text = txtArea3Text.Text;
            int uid = Convert.ToInt32(txtArea3UID.Text.Trim());
            int width = Convert.ToInt32(txtArea3Width.Text.Trim());
            int height = Convert.ToInt32(txtArea3Height.Text.Trim());
            int style = 0; //1自右向左移动//3从下向上移动//0自适应

            QYLEDController qy = new QYLEDController();

            int result = 1;
            result = qy.SendInternalText_Net(text, uid, width, height, style);

            if (result == 0)
            {
                MessageBox.Show("下发成功！", "udp发送内码文字内容");
            }
            else
            {
                MessageBox.Show("下发失败！", "udp发送内码文字内容");
            }
        }

        private void btnArea4Test_Click(object sender, EventArgs e)
        {
            string text = txtArea4Text.Text;
            int uid = Convert.ToInt32(txtArea4UID.Text.Trim());
            int width = Convert.ToInt32(txtArea4Width.Text.Trim());
            int height = Convert.ToInt32(txtArea4Height.Text.Trim());
            int style = 9; //立即显示

            QYLEDController qy = new QYLEDController();

            int result = 1;
            result = qy.SendInternalText_Net(text, uid, width, height, style);

            if (result == 0)
            {
                MessageBox.Show("下发成功！", "udp发送内码文字内容");
            }
            else
            {
                MessageBox.Show("下发失败！", "udp发送内码文字内容");
            }
        }

        private void btnArea5Test_Click(object sender, EventArgs e)
        {
            string text = txtArea5Text.Text;
            int uid = Convert.ToInt32(txtArea5UID.Text.Trim());
            int width = Convert.ToInt32(txtArea5Width.Text.Trim());
            int height = Convert.ToInt32(txtArea5Height.Text.Trim());
            int style = 9; //立即显示

            QYLEDController qy = new QYLEDController();

            int result = 1;
            result = qy.SendInternalText_Net(text, uid, width, height, style);

            if (result == 0)
            {
                MessageBox.Show("下发成功！", "udp发送内码文字内容");
            }
            else
            {
                MessageBox.Show("下发失败！", "udp发送内码文字内容");
            }
        }
    }
}
