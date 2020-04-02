using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DSaw
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }
        System.Threading.Timer ZTimer;

        private void button1_Click(object sender, EventArgs e)
        {
            //PLCSetUp my = new PLCSetUp();
            //my.Show();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            ZTimer = new System.Threading.Timer(new TimerCallback(ZTimer_Tick));
             ZTimer.Change(0,2000);
            i = 0;
        }
        int i;
        private void ZTimer_Tick(object state)
        {
            //throw new NotImplementedException();
            i++;

          
            this.label1.Invoke(new Action(()=>{ label1.Text = i.ToString()+Thread.CurrentContext.ToString()+  Thread.CurrentThread.ToString();; }));
            //MessageBox.Show("定时到" + i.ToString()+"次");

        }
    }
}
