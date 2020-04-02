namespace LedClient
{
    partial class ConfigDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbNControllType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnitLength = new System.Windows.Forms.TextBox();
            this.txtScreenHeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtScreenWidth = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IP地址 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.rchMessage = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbNControllType
            // 
            this.cmbNControllType.FormattingEnabled = true;
            this.cmbNControllType.Location = new System.Drawing.Point(91, 171);
            this.cmbNControllType.Name = "cmbNControllType";
            this.cmbNControllType.Size = new System.Drawing.Size(179, 20);
            this.cmbNControllType.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "单元字符数：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "控制卡：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(125, 210);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(167, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "如：宽30字符，单元15，行2列";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(145, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "16的整数倍；最小16；";
            // 
            // txtUnitLength
            // 
            this.txtUnitLength.Location = new System.Drawing.Point(92, 206);
            this.txtUnitLength.Name = "txtUnitLength";
            this.txtUnitLength.Size = new System.Drawing.Size(29, 21);
            this.txtUnitLength.TabIndex = 17;
            this.txtUnitLength.Text = "15";
            // 
            // txtScreenHeight
            // 
            this.txtScreenHeight.Location = new System.Drawing.Point(91, 131);
            this.txtScreenHeight.Name = "txtScreenHeight";
            this.txtScreenHeight.Size = new System.Drawing.Size(48, 21);
            this.txtScreenHeight.TabIndex = 17;
            this.txtScreenHeight.Text = "64";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "16的整数倍；最小64；";
            // 
            // txtScreenWidth
            // 
            this.txtScreenWidth.Location = new System.Drawing.Point(91, 97);
            this.txtScreenWidth.Name = "txtScreenWidth";
            this.txtScreenWidth.Size = new System.Drawing.Size(48, 21);
            this.txtScreenWidth.TabIndex = 15;
            this.txtScreenWidth.Text = "256";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(91, 63);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(48, 21);
            this.txtPort.TabIndex = 14;
            this.txtPort.Text = "5005";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(91, 25);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(130, 21);
            this.txtIP.TabIndex = 13;
            this.txtIP.Text = "192.168.1.49";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 256);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存配置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "屏高：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "屏宽：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "端口号：";
            // 
            // IP地址
            // 
            this.IP地址.AutoSize = true;
            this.IP地址.Location = new System.Drawing.Point(45, 28);
            this.IP地址.Name = "IP地址";
            this.IP地址.Size = new System.Drawing.Size(53, 12);
            this.IP地址.TabIndex = 11;
            this.IP地址.Text = "IP地址：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbNControllType);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtUnitLength);
            this.groupBox1.Controls.Add(this.txtScreenHeight);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtScreenWidth);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.IP地址);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(711, 238);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LED屏相关参数";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(113, 256);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(120, 23);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "发送测试数据";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // rchMessage
            // 
            this.rchMessage.Location = new System.Drawing.Point(12, 299);
            this.rchMessage.Multiline = true;
            this.rchMessage.Name = "rchMessage";
            this.rchMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.rchMessage.Size = new System.Drawing.Size(711, 303);
            this.rchMessage.TabIndex = 13;
            // 
            // ConfigDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 614);
            this.Controls.Add(this.rchMessage);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConfigDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfigDialog";
            this.Load += new System.EventHandler(this.ConfigDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbNControllType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUnitLength;
        private System.Windows.Forms.TextBox txtScreenHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtScreenWidth;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label IP地址;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox rchMessage;
    }
}