﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSaw.LedLibrary;

namespace DSaw
{
    public class DataPush
    {
        public static void ClearScreen() {
            QYLEDController qy = new QYLEDController();
            qy.SendInternalText_Area1("[上料]");
            qy.SendInternalText_Area2("[复尺]");
            qy.SendInternalText_Area3("[材料名称/颜色]");
            qy.SendInternalText_Area4("切：[规格*数量]");
            qy.SendInternalText_Area5("[角度]");
        }

        public static void PushToLed(OrderItems orderItem,bool resetSaw=false) {
            //BXController bx = new BXController();
            string area1Text = "";
            string area2Text = "<<<<<<";
            string area3Text = "";
            string area4Text = "";
            string area5Text = "";

            if (resetSaw)
            {
                area2Text = "复尺";
            }

            string[] note1Arr = orderItem.Note1.Split(':');
            area1Text = note1Arr[0];
            area3Text += note1Arr[1];
            string[] lengthNoteArr = orderItem.LengthNote.Split('：');
            string[] quantityNoteArr = orderItem.QuantityNote.Split('：');

            if (!string.IsNullOrEmpty(lengthNoteArr[1]))
            {
                area3Text += "(" + lengthNoteArr[1] + "*" + quantityNoteArr[1] + ")";
            }

            area4Text = orderItem.Note3;

            area5Text = orderItem.Note4;
           
            //text += orderItem.Note3;

            //bx.WriteTxt(soundString);
            //bx.SendToScreen();

            QYLEDController qy = new QYLEDController();
            qy.SendInternalText_Area1(area1Text);            
            qy.SendInternalText_Area2(area2Text);   
            qy.SendInternalText_Area3(area3Text);
            qy.SendInternalText_Area4(area4Text);
            qy.SendInternalText_Area5(area5Text);
        }

        //public static void PushToLed(string msg)
        //{
        //    BXController bx = new BXController();

        //    bx.WriteTxt(msg);
        //    bx.SendToScreen();
        //}

        public static void PushToSound(OrderItems orderItem,string resetVoidText="") {

            QYLEDController qy = new QYLEDController();

            string soundString = "[s3][z1]#";

            string[] note1Arr = orderItem.Note1.Split(':');
            string[] lengthNoteArr = orderItem.LengthNote.Split('：');
            string[] quantityNoteArr = orderItem.QuantityNote.Split('：');
            string[] note3Arr = orderItem.Note3.Split('：');

            soundString += note1Arr[0] + "[P1000]请放#";
            soundString += note1Arr[1];

            if (!string.IsNullOrEmpty(lengthNoteArr[1]))
            {
                soundString += "([P1000]" + lengthNoteArr[1] + "*" + quantityNoteArr[1] + ")";
            }

            soundString += "[P1500]即将切割#" + note3Arr[1] ;

            if (!string.IsNullOrEmpty(resetVoidText))
            {
                soundString += "[P2000]"+resetVoidText;
            }

            qy.PlayVoice(soundString);
        }

        public static void PushToSound(string msg)
        {

            QYLEDController qy = new QYLEDController();            

            qy.PlayVoice(msg);
        }

        public static bool ShouldRremind(DateTime? datetime)
        {
            if (!datetime.HasValue)
                return true;
            //上午
            if (DateTime.Now.Hour < 12)
            {
                if (datetime < DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    return true;
                }
            }
            else
            {//下午
                if (datetime < DateTime.Parse(DateTime.Now.ToShortDateString() + " 12:00:00"))
                {
                    return true;
                }
            }

            return false;
        }





    }
}
