﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.ModBus;
using System.Timers;
using QRCoder;
using System.Threading;
using System.Reflection;
using System.Xml.Linq;
using System.IO;

namespace DSaw
{
    public partial class OrdersProduced : Form
    {
        public OrdersProduced()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public int FilterState = 0;
        //public string FilterFileName = "";
        public int SelectedOrderID = 0;
        public string PrintTxt1 = "";
        public string PrintTxt2 = "";
        public int PrintTimes = 1;
        //public System.Timers.Timer MyNewTimer = new System.Timers.Timer();
        public System.Threading.Timer MyThreadTimer;

        public string PLCIP = "";
        public string PLCPort = "502";
        public ModbusTcpNet modbus;
        public string LoginUser = "";

        private void OrdersProduced_Load(object sender, EventArgs e)
        {
            try
            {
                DataClasses1DataContext ItemsList = new DataClasses1DataContext();
                //var query2 = from s2 in ItemsList.Orders where s2.OrderState == 0 select s2.OrderName;
                //comboBox1.DataSource = query2;
                //var query2 = from s2 in ItemsList.Orders where s2.OrderState == 0 select new { s2.OrderName, s2.ID };
                //comboBox1.DataSource = query2.AsEnumerable().Select(s=>s.OrderName).ToList();
                var query2 = from s2 in ItemsList.Orders where s2.OrderState == 0 select s2;
                comboBox1.DisplayMember = "OrderName";
                comboBox1.ValueMember = "ID";
                comboBox1.DataSource = query2.ToList();

                comboBox1.Text = "";
                dataGridView1.DataSource = "";

                Type type = dataGridView1.GetType();
                PropertyInfo pi = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(dataGridView1, true, null);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {//查看待产0
            FilterState = 0;
            GetFilteredData(FilterState);
        }

        private void button2_Click(object sender, EventArgs e)
        {//查看缺料1
            FilterState = 1;
            GetFilteredData(FilterState);
        }

        private void button3_Click(object sender, EventArgs e)
        {//查看推迟2
            FilterState = 2;
            GetFilteredData(FilterState);
        }

        private void button4_Click(object sender, EventArgs e)
        {//查看完成3
            FilterState = 3;
            GetFilteredData(FilterState);
            //printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {//缺料按钮
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("无订单项选中", "提示");
                return;
            }
            if (FilterState != 1)
            {
                ChangeItemState(1);
            }
            else
            {
                MessageBox.Show("已经是缺料状态");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {//推迟按钮
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("无订单项选中", "提示");
                return;
            }
            if (FilterState != 2)
            {
                ChangeItemState(2);
            }
            else
            {
                MessageBox.Show("已经是推迟状态");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {//待产按钮
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("无订单项选中", "提示");
                return;
            }
            if (FilterState != 0)
            {
                ChangeItemState(0);
            }
            else
            {
                MessageBox.Show("已经是待产状态");
            }
        }

        public void GetFilteredData(int MyInt)
        {
            if (SelectedOrderID == 0 || comboBox1.Text == "")
            {
                MessageBox.Show("请选择订单");
                return;
            }
            DataClasses1DataContext ItemsList = new DataClasses1DataContext();

            var query = from s in ItemsList.OrderItems where s.ItemState == MyInt & s.OrderID == SelectedOrderID & s.Length>450.0 select s;//20191110增加长度的筛选

            dataGridView1.DataSource = query;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "订单号";
            dataGridView1.Columns[2].HeaderText = "订单名称";
            dataGridView1.Columns[3].HeaderText = "订单序号";
            dataGridView1.Columns[4].HeaderText = "长度";
            dataGridView1.Columns[5].HeaderText = "数量";
            dataGridView1.Columns[6].HeaderText = "左角度";
            dataGridView1.Columns[7].HeaderText = "右角度";
            dataGridView1.Columns[8].HeaderText = "材料";
            //dataGridView1.Columns[8].Width = 200;
            dataGridView1.Columns[9].HeaderText = "备注长度";
            dataGridView1.Columns[10].HeaderText = "数量";
            dataGridView1.Columns[11].HeaderText = "门编号";
            dataGridView1.Columns[12].HeaderText = "备注1";
            dataGridView1.Columns[13].HeaderText = "备注2";
            dataGridView1.Columns[14].HeaderText = "备注3";
            dataGridView1.Columns[15].HeaderText = "订单状态";
            dataGridView1.Columns[16].HeaderText = "优先级";
            dataGridView1.Columns[17].HeaderText = "合格品数量";
            dataGridView1.Columns[18].HeaderText = "废品数量";
            dataGridView1.Columns[19].HeaderText = "单刀切数";
            dataGridView1.Columns[20].HeaderText = "切割时间";
            dataGridView1.Columns[21].HeaderText = "操作者";
        }

        public void ChangeItemState(int MyInt)
        {
            DataClasses1DataContext ItemsList = new DataClasses1DataContext();
            var query = from s in ItemsList.OrderItems where s.ID == (int)dataGridView1.CurrentRow.Cells[0].Value select s;
            foreach (var ss in query)
            {
                ss.ItemState = MyInt;
            }
            ItemsList.SubmitChanges();
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FilterFileName = comboBox1.Text.Trim();
            SelectedOrderID = Convert.ToInt32(comboBox1.SelectedValue);
            //MessageBox.Show(SelectedOrderID.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {//开始生产

            if (dataGridView1.ColumnCount == 0 || comboBox1.Text == string.Empty)
            {
                MessageBox.Show("请选择订单或者切换至待产状态");
                return;
            }
            if (File.Exists("DSaw.exe.config"))
            {
                XElement MyEle = XElement.Load("PLCConfig.xml", LoadOptions.SetLineInfo);
                //PLCIP = MyEle.Element("userSettings").Element("DSaw.Properties.Settings").Elements("setting").First().Value;
                PLCIP = MyEle.Element("PLCIP").Value;
            }
            else
            { MessageBox.Show("Config配置文件丢失", "提示"); return; }

            modbus = new ModbusTcpNet(PLCIP, 502, 1);
            modbus.AddressStartWithZero = true;
            modbus.DataFormat = HslCommunication.Core.DataFormat.CDAB;
            modbus.IsStringReverse = true;
            modbus.ConnectTimeOut = 5000;
            OperateResult connect = modbus.ConnectServer();
            if (!connect.IsSuccess)
            {
                MessageBox.Show("上位机与PLC通信失败，请检查连接！");
            }
            else
            {
                button8.Text = "已连接";
                button8.Enabled = false;
                timer1.Start();

                //清屏
                DataPush.ClearScreen();
            }
            MyThreadTimer = new System.Threading.Timer(new TimerCallback(MyThreadTimer_Tick));
            //MyThreadTimer.Change(0,1500);               
        }
        private Object syncObj = new object();
        private void MyThreadTimer_Tick(object sender)
        {
            //textBox7.Invoke(new Action(()=> { textBox7.Text = DateTime.Now.ToString(); }));//测试用语句           
            try
            {
                OperateResult OR = modbus.Write("6112", 0); //6112对应喂狗寄存器
                if (OR.IsSuccess == false)
                {
                    MessageBox.Show("PC-PLC定时置位失败，网络中断");
                }
                //45568自动模式，45569下一单，45570缺料
                OperateResult<bool> OR2 = modbus.ReadCoil("45569");
                if (OR2.Content == true)
                {//自动模式，读取下一单/缺料是否被按下    
                    lock (syncObj)
                    {
                        TransferData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "通信异常");
            }
        }
        private void Mytimer_Tick(object sender, EventArgs e)//未被使用
        {  ////6112对应喂狗寄存器
            //OperateResult OR = modbus.Write("6112", 0);
            //if (OR.IsSuccess == false)
            //{
            //    MessageBox.Show("网络中断");
            //}
            ////45568自动模式，45569下一单，45570缺料
            //OperateResult<bool> OR2 = modbus.ReadCoil("45569");
            //if (OR2.Content == true)
            //{//自动模式，读取下一单/缺料是否被按下
            //    TransferData();
            //}
        }


        #region 测试
        private void buttonTest_Click(object sender, EventArgs e)
        {
            DataPush.ClearScreen();

            for (int i = 188; i < 200; i++)
            {
                TransferDataTest(i);
                Thread.Sleep(30000);
            }
        }



        public void TransferDataTest(int id)
        {


            DataClasses1DataContext MyContext = new DataClasses1DataContext();
            var MyItem = MyContext.OrderItems.FirstOrDefault(x => x.ID == id);

            if (MyItem != null)
            {
                #region 发送数据到Led屏，语音卡

                bool resetSaw = false;
                string resetVoidText = "";

                var angleChangeState = MyContext.AngleChangeStates.FirstOrDefault(x => x.LeftAngle == MyItem.LeftAngle && x.RightAngle == MyItem.RightAngle);
                if (angleChangeState.ChangeDate == null || angleChangeState.ChangeDate.Value < DateTime.Parse(DateTime.Now.ToShortDateString() + " 12:00:00"))
                {
                    resetSaw = true;

                    angleChangeState.ChangeDate = DateTime.Now;
                    MyContext.SubmitChanges();

                    string M = DateTime.Now.Hour < 12 ? "上午" : "下午";

                    resetVoidText = "这是今天" + M + "第一次切割" + angleChangeState.AngleName + "，#请记得复尺";
                    //DataPush.PushToLed("这是今天" + M + "第一次切割" + angleChangeState.AngleName + "，#记得复尺");
                    //DataPush.PushToSound("这是今天" + M + "第一次切割" + angleChangeState.AngleName + "，#记得复尺");
                    //Thread.Sleep(15000);
                }

                DataPush.PushToLed(MyItem, resetSaw);
                DataPush.PushToSound(MyItem, resetVoidText);

                #endregion
            }


        }

        #endregion

        public void TransferData()//未被使用
        {//数据传输     
            //读取ID
            OperateResult<int> IDNumber = modbus.ReadInt32("06114");//读取正在加工ID            
            OperateResult<Int32> myresult7 = modbus.ReadInt32("06106");//合格数量                    
            OperateResult<Int32> myresult8 = modbus.ReadInt32("06108");//单刀切数
            OperateResult<Int32> myresult9 = modbus.ReadInt32("06110");//次品数量
            DataClasses1DataContext MyContext = new DataClasses1DataContext();

            var query = from s in MyContext.OrderItems where s.ID == IDNumber.Content select s;
            if (query.Count<OrderItems>() != 0)
            {//可以根据登记号查到加工数据
                query.First<OrderItems>().GoodQuantity = query.First<OrderItems>().Quantity;
                query.First<OrderItems>().BadQuantity = myresult8.Content - query.First<OrderItems>().Quantity;
                query.First<OrderItems>().CutTimes = myresult8.Content;
                query.First<OrderItems>().ItemState = 3;//订单标记完成
                query.First<OrderItems>().CutDateTime = DateTime.Now.ToString();//加工时间
                query.First<OrderItems>().User = LoginUser;
                modbus.Write("06106", 0);//合格数量清零
                modbus.Write("06108", 0);//单刀切数清零
                modbus.Write("06110", 0);//次品数量清零
                MyContext.SubmitChanges();
            }
            if (dataGridView1.Rows.Count != 0)//判断是否是最后一条数据
            {//若不是最后一条数据     
                OrderItems MyItem = (OrderItems)dataGridView1.Rows[0].DataBoundItem;

                OperateResult myresult0 = modbus.Write("06114", (int)MyItem.ID);//写登记号
                OperateResult myresult1 = modbus.Write("06096", (int)MyItem.ItemID);//写登记号                
                OperateResult myresult2 = modbus.Write("06098", (float)MyItem.Length);//写切割长度
                OperateResult myresult3 = modbus.Write("06100", (int)MyItem.LeftAngle);//写左角度
                OperateResult myresult4 = modbus.Write("06102", (int)MyItem.RightAngle);//写右角度
                OperateResult myresult6 = modbus.Write("06104", (int)MyItem.Quantity);//写订单数量  
                OperateResult myresult10 = modbus.WriteCoil("45569", false);
                PrintTimes = (int)MyItem.Quantity;
                IntPtr i = this.Handle;//判断窗体句柄是否创建完毕以便更改控件数据
                textBox2.Invoke(new Action(() => { textBox2.Text = MyItem.Length.ToString(); }));
                textBox3.Invoke(new Action(() => { textBox3.Text = MyItem.LeftAngle.ToString(); }));
                textBox4.Invoke(new Action(() => { textBox4.Text = MyItem.RightAngle.ToString(); }));
                textBox5.Invoke(new Action(() => { textBox5.Text = MyItem.Quantity.ToString(); }));
                textBox6.Invoke(new Action(() => { textBox6.Text = MyItem.Note1.ToString(); }));
                textBox7.Invoke(new Action(() => { textBox7.Text = MyItem.Note2.ToString(); }));
                textBox8.Invoke(new Action(() => { textBox8.Text = MyItem.DoorID.ToString(); }));
                textBox1.Invoke(new Action(() => { textBox1.Text = MyItem.ItemID.ToString(); }));
                textBox9.Invoke(new Action(() => { textBox9.Text = MyItem.LengthNote.ToString(); }));

                this.dataGridView1.Invoke(new Action(() => { dataGridView1.Rows.Remove(dataGridView1.Rows[0]); }));
            }
            else
            {//写最后一条数据
                modbus.WriteCoil("45569", false);//下一单按钮复位
                DataClasses1DataContext MyContext2 = new DataClasses1DataContext();
                var query2 = from s in MyContext2.Orders where s.ID == SelectedOrderID select s;
                if (query2.Count() != 0)
                {
                    query2.First().OrderState = 1;
                    MyContext2.SubmitChanges();
                    MessageBox.Show("该订单全部完工，请选择下一订单！", "提示");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            PrintTxt1 = "序号" + textBox1.Text + "长度" + textBox2.Text + "\r\n" + "左" + textBox3.Text + "右" + textBox4.Text
              + "数量" + textBox5.Text + "\r\n" + textBox8.Text + "\r\n" + DateTime.Now.ToString();//textbox8为门编号
            PrintTxt2 = textBox6.Text;
            try
            {
                for (int i = PrintTimes; i > 0; i--)
                {
                    //printDocument1.Print();//打印功能屏蔽
                }

                OperateResult<int> IDNumber = modbus.ReadInt32("06114");


                Task t1 = Task.Factory.StartNew(() =>
                {
                    PushDataToController(IDNumber.Content);
                    //PushDataToController(188);
                    //MessageBox.Show("这里是Task线程");
                });

                //MessageBox.Show("这里是UI线程");



                //DataClasses1DataContext MyContext = new DataClasses1DataContext();    

                //var query = from s in MyContext.OrderItems where s.ID == IDNumber.Content select s;
                //OrderItems MyItem = (OrderItems)dataGridView1.Rows[0].DataBoundItem;
                //#region 发送数据到Led屏，语音卡
                //bool resetSaw = false;
                //string resetVoidText = "";

                //var angleChangeState = MyContext.AngleChangeStates.FirstOrDefault(x => x.LeftAngle == MyItem.LeftAngle && x.RightAngle == MyItem.RightAngle);
                //if (angleChangeState.ChangeDate == null || angleChangeState.ChangeDate.Value < DateTime.Parse(DateTime.Now.ToShortDateString() + " 12:00:00"))
                //{
                //    resetSaw = true;

                //    angleChangeState.ChangeDate = DateTime.Now;
                //    MyContext.SubmitChanges();

                //    string M = DateTime.Now.Hour < 12 ? "上午" : "下午";

                //    resetVoidText = "这是今天" + M + "第一次切割" + angleChangeState.AngleName + "，#请记得复尺";
                //    //DataPush.PushToLed("这是今天" + M + "第一次切割" + angleChangeState.AngleName + "，#记得复尺");
                //    //DataPush.PushToSound("这是今天" + M + "第一次切割" + angleChangeState.AngleName + "，#记得复尺");
                //    //Thread.Sleep(15000);
                //}

                //DataPush.PushToLed(MyItem, resetSaw);
                //DataPush.PushToSound(MyItem, resetVoidText);

                //#endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "无法打印，请检查打印机！");
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string ComStr = PrintTxt1 + PrintTxt2;
            Bitmap qrCodeImage;
            QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(ComStr.ToString(), QRCodeGenerator.ECCLevel.M);
            QRCode qrcode = new QRCode(qrCodeData);
            //qrCodeImage = qrcode.GetGraphic(2, Color.Black, Color.White, null,15, 6, false);
            qrCodeImage = qrcode.GetGraphic(2);
            //Bitmap _NewBitmap = new Bitmap(groupBox1.Width, groupBox1.Height);
            //groupBox1.DrawToBitmap(_NewBitmap, new Rectangle(0, 0, _NewBitmap.Width, _NewBitmap.Height));
            //e.Graphics.DrawImage(_NewBitmap, 0, 0, _NewBitmap.Width, _NewBitmap.Height);
            e.Graphics.DrawImage(qrCodeImage, 0, 10, 70, 70);//二维码图像20191110调整打印大小
            e.Graphics.DrawString(PrintTxt1.ToString(), new Font("宋体", 10, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(80.0F, 0.0F)); //打印订单基本信息
            e.Graphics.DrawString(PrintTxt2.ToString(), new Font("宋体", 10, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(0.0F, 65.0F)); //上料/续切 打印订单基本信息
            if (textBox7.Text.Count() >= 4)
            {
                int StrSplit = (int)(textBox7.Text.Count() * 0.8);
                e.Graphics.DrawString(textBox7.Text.Substring(0, StrSplit), new Font("宋体", 10, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(0.0F, 110.0F));//打印备注
                e.Graphics.DrawString(textBox7.Text.Substring(StrSplit + 1, textBox7.Text.Count() - StrSplit - 1), new Font("宋体", 10, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(0.0F, 130.0F));//打印备注 
            }

        }

        private void OrdersProduced_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modbus != null)
            {
                modbus.ConnectClose();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            try
            {
                OperateResult OR = modbus.Write("6112", 0); //6112对应喂狗寄存器
                if (OR.IsSuccess == false)
                {
                    MessageBox.Show("PC-PLC定时置位失败，网络中断");
                }
                //45568自动模式，45569下一单，45570缺料
                OperateResult<bool> OR2 = modbus.ReadCoil("45569");
                if (OR2.Content == true)
                {//自动模式，读取下一单/缺料是否被按下    
                    lock (syncObj)
                    {
                        TransferData2();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "通信异常");
            }
            timer1.Start();
        }


        public void TransferData2()
        {//数据传输     
            //读取ID
            OperateResult<int> IDNumber = modbus.ReadInt32("06114");//读取正在加工ID            
            OperateResult<Int32> myresult7 = modbus.ReadInt32("06106");//合格数量                    
            OperateResult<Int32> myresult8 = modbus.ReadInt32("06108");//单刀切数
            OperateResult<Int32> myresult9 = modbus.ReadInt32("06110");//次品数量
            DataClasses1DataContext MyContext = new DataClasses1DataContext();
            var query = from s in MyContext.OrderItems where s.ID == IDNumber.Content select s;
            if (query.Count<OrderItems>() != 0)
            {//可以根据登记号查到加工数据
                query.First<OrderItems>().GoodQuantity = query.First<OrderItems>().Quantity;
                query.First<OrderItems>().BadQuantity = myresult8.Content - query.First<OrderItems>().Quantity;
                query.First<OrderItems>().CutTimes = myresult8.Content;
                query.First<OrderItems>().ItemState = 3;//订单标记完成
                query.First<OrderItems>().CutDateTime = DateTime.Now.ToString();//加工时间
                query.First<OrderItems>().User = LoginUser;
                modbus.Write("06106", 0);//合格数量清零
                modbus.Write("06108", 0);//单刀切数清零
                modbus.Write("06110", 0);//次品数量清零
                MyContext.SubmitChanges();
            }
            if (dataGridView1.Rows.Count != 0)//判断是否是最后一条数据
            {//若不是最后一条数据     
                OrderItems MyItem = (OrderItems)dataGridView1.Rows[0].DataBoundItem;

                #region 发送数据到Led屏，语音卡

                //bool resetSaw = false;
                //string resetVoidText = "";

                //var angleChangeState = MyContext.AngleChangeStates.FirstOrDefault(x => x.LeftAngle == MyItem.LeftAngle && x.RightAngle == MyItem.RightAngle);
                //if (angleChangeState.ChangeDate == null || angleChangeState.ChangeDate.Value < DateTime.Parse(DateTime.Now.ToShortDateString() + " 12:00:00"))
                //{
                //    resetSaw = true;

                //    angleChangeState.ChangeDate = DateTime.Now;
                //    MyContext.SubmitChanges();

                //    string M = DateTime.Now.Hour < 12 ? "上午" : "下午";

                //    resetVoidText = "这是今天" + M + "第一次切割" + angleChangeState.AngleName + "，#请记得复尺";
                //    //DataPush.PushToLed("这是今天" + M + "第一次切割" + angleChangeState.AngleName + "，#记得复尺");
                //    //DataPush.PushToSound("这是今天" + M + "第一次切割" + angleChangeState.AngleName + "，#记得复尺");
                //    //Thread.Sleep(15000);
                //}

                //DataPush.PushToLed(MyItem, resetSaw);
                //DataPush.PushToSound(MyItem, resetVoidText);

                #endregion

                OperateResult myresult0 = modbus.Write("06114", (int)MyItem.ID);//写登记号
                OperateResult myresult1 = modbus.Write("06096", (int)MyItem.ItemID);//写登记号                
                OperateResult myresult2 = modbus.Write("06098", (float)MyItem.Length);//写切割长度
                OperateResult myresult3 = modbus.Write("06100", (int)MyItem.LeftAngle);//写左角度
                OperateResult myresult4 = modbus.Write("06102", (int)MyItem.RightAngle);//写右角度
                OperateResult myresult6 = modbus.Write("06104", (int)MyItem.Quantity);//写订单数量  
                OperateResult myresult10 = modbus.WriteCoil("45569", false);
                PrintTimes = (int)MyItem.Quantity;
                IntPtr i = this.Handle;//判断窗体句柄是否创建完毕以便更改控件数据
                textBox2.Text = MyItem.Length.ToString();
                textBox3.Text = MyItem.LeftAngle.ToString();
                textBox4.Text = MyItem.RightAngle.ToString();
                textBox5.Text = MyItem.Quantity.ToString();
                textBox6.Text = MyItem.Note1.ToString();
                textBox7.Text = MyItem.Note2.ToString();
                textBox8.Text = MyItem.DoorID.ToString();
                textBox1.Text = MyItem.ItemID.ToString();
                textBox9.Text = MyItem.LengthNote.ToString(); 

                dataGridView1.Rows.Remove(dataGridView1.Rows[0]);
            }
            else
            {//写最后一条数据
                modbus.WriteCoil("45569", false);//下一单按钮复位
                DataClasses1DataContext MyContext2 = new DataClasses1DataContext();
                var query2 = from s in MyContext2.Orders where s.ID == SelectedOrderID select s;
                if (query2.Count() != 0)
                {
                    query2.First().OrderState = 1;
                    MyContext2.SubmitChanges();
                    MessageBox.Show("该订单全部完工，请选择下一订单！", "提示");
                }
            }
        }

        private void PushDataToController(int IDNumber) {

            DataClasses1DataContext MyContext = new DataClasses1DataContext();
            var MyItem = MyContext.OrderItems.FirstOrDefault(x => x.ID == IDNumber);
            if (MyItem != null)
            {
                #region 发送数据到Led屏，语音卡
                bool resetSaw = false;
                string resetVoidText = "";

                var angleChangeState = MyContext.AngleChangeStates.FirstOrDefault(x => x.LeftAngle == MyItem.LeftAngle && x.RightAngle == MyItem.RightAngle);
                if (angleChangeState.ChangeDate == null || angleChangeState.ChangeDate.Value < DateTime.Parse(DateTime.Now.ToShortDateString() + " 12:00:00"))
                {
                    resetSaw = true;

                    angleChangeState.ChangeDate = DateTime.Now;
                    MyContext.SubmitChanges();

                    string M = DateTime.Now.Hour < 12 ? "上午" : "下午";

                    resetVoidText = "这是今天" + M + "第一次切割" + angleChangeState.AngleName + "，#请记得复尺";
                    //DataPush.PushToLed("这是今天" + M + "第一次切割" + angleChangeState.AngleName + "，#记得复尺");
                    //DataPush.PushToSound("这是今天" + M + "第一次切割" + angleChangeState.AngleName + "，#记得复尺");
                    //Thread.Sleep(15000);
                }

                DataPush.PushToLed(MyItem, resetSaw);
                DataPush.PushToSound(MyItem, resetVoidText);

                #endregion
            }

        }

    }
}