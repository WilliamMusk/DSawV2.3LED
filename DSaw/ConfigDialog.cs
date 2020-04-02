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
using LedClient.LedLibrary;

namespace LedClient
{
    public partial class ConfigDialog : Form
    {
        public ConfigDialog()
        {
            InitializeComponent();
            BindCmbNControllType();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings["IPaddress"].Value = this.txtIP.Text.Trim();
            configuration.AppSettings.Settings["Socketport"].Value = this.txtPort.Text.Trim();
            configuration.AppSettings.Settings["LEDwidth"].Value = this.txtScreenWidth.Text.Trim();
            configuration.AppSettings.Settings["LEDheight"].Value = this.txtScreenHeight.Text.Trim();
            //configuration.AppSettings.Settings["AutoStart"].Value = this.chkAutoStart.Checked.ToString();
            //configuration.AppSettings.Settings["SleepTime"].Value = this.txtSleepTime.Text.Trim();
            //configuration.AppSettings.Settings["DayStartHour"].Value = this.txtDayStartHour.Text.Trim();
            //configuration.AppSettings.Settings["OnlyAsyncToday"].Value = this.chkOnlyAsyncToday.Checked.ToString();
            configuration.AppSettings.Settings["NControllType"].Value = this.cmbNControllType.SelectedValue.ToString();
            configuration.AppSettings.Settings["UnitLength"].Value = this.txtUnitLength.Text;

            configuration.Save();
            MessageBox.Show("保存成功!");
            //this.Close();
        }

        private void ConfigDialog_Load(object sender, EventArgs e)
        {
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            txtIP.Text = configuration.AppSettings.Settings["IPaddress"].Value;
            txtPort.Text = configuration.AppSettings.Settings["Socketport"].Value;
            txtScreenWidth.Text = configuration.AppSettings.Settings["LEDwidth"].Value;
            txtScreenHeight.Text = configuration.AppSettings.Settings["LEDheight"].Value;
            //chkAutoStart.Checked = Convert.ToBoolean(configuration.AppSettings.Settings["AutoStart"].Value);
            //txtSleepTime.Text = configuration.AppSettings.Settings["SleepTime"].Value;
            //txtDayStartHour.Text = configuration.AppSettings.Settings["DayStartHour"].Value;
            //chkOnlyAsyncToday.Checked = Convert.ToBoolean(configuration.AppSettings.Settings["OnlyAsyncToday"].Value);
            cmbNControllType.SelectedValue = Convert.ToInt32(configuration.AppSettings.Settings["NControllType"].Value);
            txtUnitLength.Text = configuration.AppSettings.Settings["UnitLength"].Value;
        }

        private void BindCmbNControllType()
        {
            List<NControllType> list = new List<NControllType>();
            //list.Add(new NControllType() { Type = "CONTROLLER_TYPE_5M3", Value = 850 });
            //list.Add(new NControllType() { Type = "CONTROLLER_TYPE_5M1", Value = 82 });

            list.AddRange(from int value in Enum.GetValues(typeof (ControllType)) select new NControllType() {Type = Enum.GetName(typeof (ControllType), value), Value = value});

            cmbNControllType.DataSource = list;
            cmbNControllType.DisplayMember = "Type";
            cmbNControllType.ValueMember = "Value";
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            rchMessage.Text += new BXController().SendToScreen();
        }
    }
}
