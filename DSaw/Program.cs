﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSaw
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new FormTest());
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //System.Threading.ThreadPool.SetMaxThreads(2000, 800);
            ////Application.Run(new /*PLCSetUp*//*OrdersManagement*/ /*PrintForm*/ /*OrdersProduced*/ LoginForm() );

            //LoginForm Login = new LoginForm();

            //Login.ShowDialog();//显示登陆窗体
            //if (Login.DialogResult == DialogResult.OK)
            //{
            //    var mainForm = new MainForm();
            //    mainForm.LogInUser = Login.LogInUser;
            //    Application.Run(mainForm);//判断登陆成功时主进程显示主窗口
            //}
            //else return;
        }
    }
}
