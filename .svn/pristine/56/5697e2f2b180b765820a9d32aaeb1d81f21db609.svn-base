using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IIWS.Window.Call;

namespace DSaw
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LogInUser = "";
        }

        public string LogInUser;
        private void MainForm_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext MyContext = new DataClasses1DataContext();
            var UserQuery = from InputUser in MyContext.Users where InputUser.UserName == LogInUser select InputUser;
            if (UserQuery.Count() > 0)
            {                
                btnOrdersProduced.Enabled = true;//订单生产
                if (UserQuery.First().Role == "管理员")
                {
                    btnOrdersManagement.Enabled = true;
                    btnUserManagement.Enabled = true;
                    btnPLCSetUp.Enabled = true;
                }
                else
                {
                    btnOrdersManagement.Enabled = false;
                    btnUserManagement.Enabled = false;
                    btnPLCSetUp.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("用户权限不足，拒绝使用", "提示");
            }
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            UsersManagement MyUsers = new UsersManagement();
            MyUsers.LoginUser = LogInUser;
            MyUsers.ShowDialog();
        }

        private void btnOrdersManagement_Click(object sender, EventArgs e)
        {
            OrdersManagement MyOrders = new OrdersManagement();
            MyOrders.LoginUser = LogInUser;
            MyOrders.ShowDialog();
        }

        private void btnOrdersProduced_Click(object sender, EventArgs e)
        {
            OrdersProduced MyProduced = new OrdersProduced();
            MyProduced.LoginUser = LogInUser;
            MyProduced.PLCIP = "";
            MyProduced.ShowDialog();
        }

        private void btnPLCSetUp_Click(object sender, EventArgs e)
        {
            PLCSetUp MyPLCSet = new PLCSetUp();
            MyPLCSet.ShowDialog();
        }

        //private void btnLedSetup_Click(object sender, EventArgs e)
        //{
        //    ConfigDialog ledSet = new ConfigDialog();
        //    ledSet.ShowDialog();
        //}

        private void btnSoundSetup_Click(object sender, EventArgs e)
        {
            ConfigForm soundSet = new ConfigForm();
            soundSet.ShowDialog();
        }
    }
}
