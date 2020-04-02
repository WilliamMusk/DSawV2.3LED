using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSaw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LogInUser = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
        public string LogInUser;

        private void Form1_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext MyContext = new DataClasses1DataContext();
            var LogInUserList = from s in MyContext.Users select s.UserName;          
            comboBox1.DataSource = LogInUserList;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext MyContext = new DataClasses1DataContext();
            var UserQuery = from InputUser in MyContext.Users where InputUser.UserName == comboBox1.Text.Trim() && InputUser.PassWord == textBox1.Text.Trim() select InputUser;           
            if (UserQuery.Count()>0)
            {
                LogInUser = comboBox1.Text.Trim();//传递其他窗口登陆用户名
                comboBox1.Enabled = false;//用户名选择下拉
                textBox1.Enabled = false;//密码输入框
                button1.Enabled = false;//登陆按钮
                button4.Enabled = true;//订单生产
                if (UserQuery.First().Role == "管理员")
                {
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button5.Enabled = true;
                }
                else
                {
                    button2.Enabled = false;
                    button3.Enabled = false;                  
                }        
            }
            else
            {
                MessageBox.Show("密码错误，请重新输入", "提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UsersManagement MyUsers = new UsersManagement();
            MyUsers.LoginUser = LogInUser;
            MyUsers.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OrdersManagement MyOrders = new OrdersManagement();
            MyOrders.LoginUser = LogInUser;
            MyOrders.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OrdersProduced MyProduced = new OrdersProduced();
            MyProduced.LoginUser = LogInUser;
            MyProduced.PLCIP ="";
            MyProduced.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PLCSetUp MyPLCSet = new PLCSetUp();
            MyPLCSet.ShowDialog();
        }
    }
}
