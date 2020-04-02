using IIWS.Window.Call;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSaw.LedLibrary
{
    public class QYLEDController
    {
        private Configuration _configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public void PlayVoice(string voiceContent)
        {
            //System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //udp语音播放
            int netprotocol = 1;            
            string ip = _configuration.AppSettings.Settings["QYLED_IPaddress"].Value;
            string rsadr = "00";
            //string readPerson = configuration.AppSettings.Settings["ReadPerson"].Value;
            //string yinLiang = configuration.AppSettings.Settings["YinLiang"].Value;
            //string yusu = configuration.AppSettings.Settings["YuSu"].Value;
            //string voiceConfig = "sound217[" + readPerson + "][" + yinLiang + "][" + yusu + "]";

            QYLED_DLL.PlayVoice_Net(voiceContent , ip, rsadr, netprotocol, 2);
        }

        public int SendInternalText_Net(string text, int UID, int width,int height,int style)
        {
            int result = 0;
            int netprotocol = 1;
            
            //System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string ip = _configuration.AppSettings.Settings["QYLED_IPaddress"].Value;
            int ledcolour = 0;        //led颜色
            int speed = 1;
            int stoptime = 1;
            int color = 1;
            int font = 1;
            int size = 1;
            int updatestyle = 2;
            bool save = false;

            //udp下发内码文字内容
            result = 1;
            result = QYLED_DLL.SendInternalText_Net(text, ip, netprotocol, width, height, UID, ledcolour, style, speed, stoptime, color, font, size, updatestyle, save);

            return result;
        }

        public int SendInternalText_Area1(string text)
        {
            int uid = Convert.ToInt32(_configuration.AppSettings.Settings["Area1UID"].Value);
            int width = Convert.ToInt32(_configuration.AppSettings.Settings["Area1Width"].Value);
            int height = Convert.ToInt32(_configuration.AppSettings.Settings["Area1Height"].Value);
            int style = 9; //立即显示

            return SendInternalText_Net(text, uid, width, height, style);
        }

        public int SendInternalText_Area2(string text)
        {
            int uid = Convert.ToInt32(_configuration.AppSettings.Settings["Area2UID"].Value);
            int width = Convert.ToInt32(_configuration.AppSettings.Settings["Area2Width"].Value);
            int height = Convert.ToInt32(_configuration.AppSettings.Settings["Area2Height"].Value);
            int style = 14; //闪烁

            return SendInternalText_Net(text, uid, width, height, style);
        }

        public int SendInternalText_Area3(string text)
        {
            int uid = Convert.ToInt32(_configuration.AppSettings.Settings["Area3UID"].Value);
            int width = Convert.ToInt32(_configuration.AppSettings.Settings["Area3Width"].Value);
            int height = Convert.ToInt32(_configuration.AppSettings.Settings["Area3Height"].Value);
            int style = 0; //1自右向左移动//3从下向上移动//0自适应

            return SendInternalText_Net(text, uid, width, height, style);
        }

        public int SendInternalText_Area4(string text)
        {
            int uid = Convert.ToInt32(_configuration.AppSettings.Settings["Area4UID"].Value);
            int width = Convert.ToInt32(_configuration.AppSettings.Settings["Area4Width"].Value);
            int height = Convert.ToInt32(_configuration.AppSettings.Settings["Area4Height"].Value);
            int style = 9; //立即显示

            return SendInternalText_Net(text, uid, width, height, style);
        }

        public int SendInternalText_Area5(string text)
        {
            int uid = Convert.ToInt32(_configuration.AppSettings.Settings["Area5UID"].Value);
            int width = Convert.ToInt32(_configuration.AppSettings.Settings["Area5Width"].Value);
            int height = Convert.ToInt32(_configuration.AppSettings.Settings["Area5Height"].Value);
            int style = 9; //立即显示

            return SendInternalText_Net(text, uid, width, height, style);
        }
    }
}
