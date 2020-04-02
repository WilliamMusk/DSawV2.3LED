namespace DSaw
{
    partial class MainForm
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
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.btnOrdersManagement = new System.Windows.Forms.Button();
            this.btnOrdersProduced = new System.Windows.Forms.Button();
            this.btnPLCSetUp = new System.Windows.Forms.Button();
            this.btnSoundSetup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.Location = new System.Drawing.Point(21, 22);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Size = new System.Drawing.Size(124, 111);
            this.btnUserManagement.TabIndex = 0;
            this.btnUserManagement.Text = "用户管理";
            this.btnUserManagement.UseVisualStyleBackColor = true;
            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click);
            // 
            // btnOrdersManagement
            // 
            this.btnOrdersManagement.Location = new System.Drawing.Point(164, 22);
            this.btnOrdersManagement.Name = "btnOrdersManagement";
            this.btnOrdersManagement.Size = new System.Drawing.Size(124, 111);
            this.btnOrdersManagement.TabIndex = 1;
            this.btnOrdersManagement.Text = "订单管理";
            this.btnOrdersManagement.UseVisualStyleBackColor = true;
            this.btnOrdersManagement.Click += new System.EventHandler(this.btnOrdersManagement_Click);
            // 
            // btnOrdersProduced
            // 
            this.btnOrdersProduced.Location = new System.Drawing.Point(306, 22);
            this.btnOrdersProduced.Name = "btnOrdersProduced";
            this.btnOrdersProduced.Size = new System.Drawing.Size(124, 111);
            this.btnOrdersProduced.TabIndex = 3;
            this.btnOrdersProduced.Text = "订单生产";
            this.btnOrdersProduced.UseVisualStyleBackColor = true;
            this.btnOrdersProduced.Click += new System.EventHandler(this.btnOrdersProduced_Click);
            // 
            // btnPLCSetUp
            // 
            this.btnPLCSetUp.Location = new System.Drawing.Point(21, 152);
            this.btnPLCSetUp.Name = "btnPLCSetUp";
            this.btnPLCSetUp.Size = new System.Drawing.Size(124, 111);
            this.btnPLCSetUp.TabIndex = 4;
            this.btnPLCSetUp.Text = "PLC设置";
            this.btnPLCSetUp.UseVisualStyleBackColor = true;
            this.btnPLCSetUp.Click += new System.EventHandler(this.btnPLCSetUp_Click);
            // 
            // btnSoundSetup
            // 
            this.btnSoundSetup.Location = new System.Drawing.Point(164, 152);
            this.btnSoundSetup.Name = "btnSoundSetup";
            this.btnSoundSetup.Size = new System.Drawing.Size(124, 111);
            this.btnSoundSetup.TabIndex = 6;
            this.btnSoundSetup.Text = "控制卡设置";
            this.btnSoundSetup.UseVisualStyleBackColor = true;
            this.btnSoundSetup.Click += new System.EventHandler(this.btnSoundSetup_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 283);
            this.Controls.Add(this.btnSoundSetup);
            this.Controls.Add(this.btnPLCSetUp);
            this.Controls.Add(this.btnOrdersProduced);
            this.Controls.Add(this.btnOrdersManagement);
            this.Controls.Add(this.btnUserManagement);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主面板";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUserManagement;
        private System.Windows.Forms.Button btnOrdersManagement;
        private System.Windows.Forms.Button btnOrdersProduced;
        private System.Windows.Forms.Button btnPLCSetUp;
        private System.Windows.Forms.Button btnSoundSetup;
    }
}