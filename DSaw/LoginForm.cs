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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            LogInUser = "";
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext MyContext = new DataClasses1DataContext();
            var LogInUserList = from s in MyContext.Users select s.UserName;
            comboBoxUser.DataSource = LogInUserList;
        }

        public string LogInUser;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataClasses1DataContext MyContext = new DataClasses1DataContext();
                var UserQuery = from InputUser in MyContext.Users where InputUser.UserName == comboBoxUser.Text.Trim() && InputUser.PassWord == txtPassword.Text.Trim() select InputUser;
                if (UserQuery.Count() > 0)
                {
                    //LogInUser = comboBox1.Text.Trim();//传递其他窗口登陆用户名
                    //comboBox1.Enabled = false;//用户名选择下拉
                    //textBox1.Enabled = false;//密码输入框
                    //button1.Enabled = false;//登陆按钮
                    //button4.Enabled = true;//订单生产
                    //if (UserQuery.First().Role == "管理员")
                    //{
                    //    button2.Enabled = true;
                    //    button3.Enabled = true;
                    //    button5.Enabled = true;
                    //}
                    //else
                    //{
                    //    button2.Enabled = false;
                    //    button3.Enabled = false;
                    //}

                    this.DialogResult = DialogResult.OK;//关键:设置登陆成功状态
                    this.LogInUser = comboBoxUser.Text;
                    this.Close();                    
                }
                else
                {
                    MessageBox.Show("密码错误，请重新输入", "提示");
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        
    }
}
