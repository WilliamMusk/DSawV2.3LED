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
    public partial class UsersManagement : Form
    {
        public UsersManagement()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //DataClasses1DataContext UserContext = new DataClasses1DataContext();
        private void UsersManagement_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext UserContext = new DataClasses1DataContext();
            dataGridView1.DataSource = UserContext.Users;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "用户名";
            dataGridView1.Columns[2].HeaderText = "用户密码";
            dataGridView1.Columns[3].HeaderText = "权限";
        }
        public string LoginUser;
        private void button1_Click(object sender, EventArgs e)
        {//添加用户
            DataClasses1DataContext UserContext = new DataClasses1DataContext();
            if (textBox1.Text == string.Empty | textBox2.Text == string.Empty | comboBox1.Text == string.Empty)
            {
                MessageBox.Show("用户名、密码、权限不能为空");
                return;
            }       

           foreach (Users SingleUser in UserContext.Users)
            {
                if (textBox1.Text.Trim() == SingleUser.UserName)
                {
                    MessageBox.Show("用户名重复，请重新输入");
                    return;
                }       
            }
            Users InputUser = new Users();
            InputUser.UserName = textBox1.Text.Trim();
            InputUser.PassWord= textBox2.Text.Trim();
            InputUser.Role = comboBox1.Text.Trim();            
            UserContext.Users.InsertOnSubmit(InputUser);        
            UserContext.SubmitChanges();
            //var UserList = from s in UserContext.Users select s;
            //dataGridView1.DataSource = UserList;
            dataGridView1.DataSource = UserContext.Users;
        }

        private void button2_Click(object sender, EventArgs e)
        {//删除用户
            DataClasses1DataContext UserContext = new DataClasses1DataContext();
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("无订单项选中", "提示");
                return;
            }          
            foreach (var SelUser in UserContext.Users)
            {
                if (SelUser.UserID==(int)dataGridView1.CurrentRow.Cells[0].Value)
                {                    
                    UserContext.Users.DeleteOnSubmit(SelUser);
                    UserContext.SubmitChanges(); 
                }                           
            }
            dataGridView1.DataSource = UserContext.Users;
            //dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }
    }
}
