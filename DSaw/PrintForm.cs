using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;

namespace DSaw
{
    public partial class PrintForm : Form
    {
        public PrintForm()
        {
            InitializeComponent();
        }

        public Bitmap qrCodeImage;
        public string PrintTxt = "";
        public int PrintTimes = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            //StringBuilder mystr = new StringBuilder();
            //string mystr2 = "09-30-012";
            //mystr.AppendLine(mystr2);
            //string mystr3 = "5400";
            //mystr.AppendLine(mystr3);
            //string date = DateTime.Now.ToString();
            //mystr.AppendLine(date);
            //string xuhao = "2";
            //string beizhu = "外单包 单扇 吊脚:10 右锁内开 双钢单透";
            //mystr.AppendLine(beizhu + xuhao);
            if (PrintTxt == "")
                PrintTxt = "09-30-012\r\n" + "5400\r\n" + DateTime.Now.ToString() + "\r\n" + "外单包 单扇 吊脚:10 右锁内开 双钢单透";
            textBox1.Text = PrintTxt;
            textBox1.Font = new Font("宋体", 12, FontStyle.Bold);
            QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(textBox1.Text, QRCodeGenerator.ECCLevel.M);
            QRCode qrcode = new QRCode(qrCodeData);
            //qrCodeImage = qrcode.GetGraphic(2, Color.Black, Color.White, null,15, 6, false);
            qrCodeImage = qrcode.GetGraphic(2);
            pictureBox1.Image = qrCodeImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument1;
            try
            {
                printPreviewDialog.ShowDialog();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap _NewBitmap = new Bitmap(groupBox1.Width, groupBox1.Height);
            groupBox1.DrawToBitmap(_NewBitmap, new Rectangle(0, 0, _NewBitmap.Width, _NewBitmap.Height));
            e.Graphics.DrawImage(_NewBitmap, 0, 0, _NewBitmap.Width, _NewBitmap.Height);
        }
        public void print()
        {
            //textBox1.Select(0,0);
            
           
            if (PrintTxt == "")
                PrintTxt = "09-30-012\r\n" + "5400\r\n" + DateTime.Now.ToString() + "\r\n" + "外单包 单扇 吊脚:10 右锁内开 双钢单透";
            textBox1.Text = PrintTxt;
            textBox1.Font = new Font("宋体", 12, FontStyle.Bold);
            QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(textBox1.Text, QRCodeGenerator.ECCLevel.M);
            QRCode qrcode = new QRCode(qrCodeData);
            //qrCodeImage = qrcode.GetGraphic(2, Color.Black, Color.White, null,15, 6, false);
            qrCodeImage = qrcode.GetGraphic(2);
            pictureBox1.Image = qrCodeImage;
            MessageBox.Show("p");
            button1.Focus();
            for (int i = PrintTimes; i > 0; i--)
            {
                printDocument1.Print();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            print();
            //for( int i=PrintTimes;i==0;i--)
            //{
            //    printDocument1.Print();
            //}
            
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {

        }
    }
    
}
