using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSaw
{
    public partial class OrdersManagement : Form
    {
        public OrdersManagement()
        {
            InitializeComponent();
        }
        public string LoginUser = "";
               
        private void button1_Click(object sender, EventArgs e)
        {
            //导入订单
            DataClasses1DataContext OrdersList = new DataClasses1DataContext();
            openFileDialog1.Filter = "txt 文件(*.txt)|*.txt";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {                
                foreach (var myorder in OrdersList.Orders)
                {
                    if (myorder.OrderName == openFileDialog1.SafeFileName)
                    {
                        MessageBox.Show("订单已存在，不能重复导入！");
                        return;
                    }
                }
                //导入订单表orders
                try
                {
                    int OrderQuantity = 0;
                    Orders NewOrder = new Orders();
                    NewOrder.OrderName = openFileDialog1.SafeFileName;
                    NewOrder.OrderDate = System.DateTime.Now.ToString();
                    NewOrder.OrderState = 0;
                    NewOrder.Importer = LoginUser;
                    OrdersList.Orders.InsertOnSubmit(NewOrder);
                    OrdersList.SubmitChanges();
                    dataGridView1.DataSource = OrdersList.Orders;

                    var NewID = from s in OrdersList.Orders where s.OrderName == openFileDialog1.SafeFileName select s.ID;
                    StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.UTF8);
                    while (sr.Peek() != -1)
                    {
                        string mystr2 = sr.ReadLine();
                        if (mystr2 == "")//判断txt文件末尾是否有空格，如果为空格则略过后面的处理
                            continue;
                        StringBuilder mybuilder = new StringBuilder(mystr2);
                        mybuilder.Replace(';', '|');                       
                        string[] mystr3 = mybuilder.ToString().Split('|');
                        //各列进行赋值 
                        OrderItems MyItem = new OrderItems();
                        MyItem.OrderID = (int)NewID.First();
                        MyItem.OrderName = openFileDialog1.SafeFileName;
                        MyItem.ItemID = Convert.ToInt32(mystr3[0]);
                        MyItem.Length = Convert.ToDouble(mystr3[1]);
                        MyItem.Quantity = Convert.ToInt32(mystr3[2]);
                        MyItem.LeftAngle = Convert.ToInt32(mystr3[3]);
                        MyItem.RightAngle = Convert.ToInt32(mystr3[4]);
                        MyItem.Note1 = mystr3[5];
                        MyItem.LengthNote = mystr3[6];
                        MyItem.QuantityNote = mystr3[7];
                        MyItem.DoorID = mystr3[8];
                        MyItem.Note2 = mystr3[9];
                        MyItem.Note3 = mystr3[10];
                        MyItem.Note4 = mystr3[11];
                        MyItem.ItemState = 0;
                        MyItem.Priority = 0;
                        OrderQuantity = (int)MyItem.Quantity + OrderQuantity;
                        OrdersList.OrderItems.InsertOnSubmit(MyItem);
                    }
                   //查询插入的订单ID号，然后根据订单ID号写入订单数量信息
                    //var query2 = from s2 in OrdersList.Orders where s2.ID==NewID.First() select s2;
                    //query2.First().TotalQuantity = OrderQuantity;
                    OrdersList.SubmitChanges();               
                }
                catch (Exception ex)
                { MessageBox.Show("订单导入失败!" + ex.Message); }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {//删除订单
            DataClasses1DataContext OrdersList = new DataClasses1DataContext();
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("无订单项选中", "提示");
                return;
            }
            try
            {
                foreach (var myitem in OrdersList.OrderItems)
                {
                    if (myitem.OrderID == (int)dataGridView1.SelectedRows[0].Cells[0].Value)
                    {
                        OrdersList.OrderItems.DeleteOnSubmit(myitem);
                    }
                    //OrdersList.SubmitChanges();
                }               
                foreach (var myorder in OrdersList.Orders)
                {
                    if (myorder.ID == (int)dataGridView1.SelectedRows[0].Cells[0].Value)
                    {
                        OrdersList.Orders.DeleteOnSubmit(myorder);
                    }
                    //OrdersList.SubmitChanges();
                }
                OrdersList.SubmitChanges();
                //var OrderList = from s in MyContent.Orders select s;
                dataGridView1.DataSource = OrdersList.Orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除异常！  " + ex.Message);
            }
        }

        private void OrdersManagement_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddDays(-7);
            DataClasses1DataContext OrdersList = new DataClasses1DataContext();
            dataGridView1.DataSource = OrdersList.Orders;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "订单名称";
            dataGridView1.Columns[2].HeaderText = "订单日期";
            dataGridView1.Columns[3].HeaderText = "导入";
            dataGridView1.Columns[4].HeaderText = "订单状态";
            dataGridView1.Columns[5].HeaderText = "订单数量";
            dataGridView1.Columns[6].HeaderText = "等待";
            dataGridView1.Columns[7].HeaderText = "推迟";
            dataGridView1.Columns[8].HeaderText = "缺料";
            dataGridView1.Columns[9].HeaderText = "完成";
            dataGridView1.Columns[10].HeaderText = "完成率";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext mycontext = new DataClasses1DataContext();            
            var query = from s in mycontext.Orders where DateTime.Compare(Convert.ToDateTime(s.OrderDate), dateTimePicker1.Value) > 0 select s;
            //假若查询数量为0个订单，将显示为空
            if (query.Count() == 0)
            {
                dataGridView1.DataSource = null;
                return;
            }
            foreach (var SingleOrder in query)
            {
                //待产0，缺料1，推迟2，完成3 
                int QTotal = 0;
                int QWait = 0;
                int QShort = 0;
                int QDelayed = 0;
                int QCompleted = 0;
                var query3 = from ss in mycontext.OrderItems where ss.OrderID == SingleOrder.ID select ss;
                //query3 是订单条目
                foreach (var query4 in query3)
                {
                    QTotal = (int)query4.Quantity + QTotal;//统计订单总量
                    if (query4.ItemState == 0) //待产
                        QWait = (int)query4.Quantity + QWait;
                    if (query4.ItemState == 1) //缺料
                        QShort = (int)query4.Quantity + QShort;
                    if (query4.ItemState == 2) //推迟
                        QDelayed = (int)query4.Quantity + QDelayed;
                    if (query4.ItemState == 3) //完成
                        QCompleted = (int)query4.Quantity + QCompleted;
                }
                SingleOrder.Wait = QWait;
                SingleOrder.Short = QShort;
                SingleOrder.Delayed = QDelayed;
                SingleOrder.Completed = QCompleted;
                SingleOrder.TotalQuantity = QTotal;
                if (QTotal != 0)
                {
                    SingleOrder.DoneRate = ((double)QCompleted / QTotal).ToString();
                }                
            }
            mycontext.SubmitChanges();
            dataGridView1.DataSource = query;
        }
    }
}
