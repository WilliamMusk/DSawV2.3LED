using System.Runtime.InteropServices;

namespace IIWS.Window.Call
{
    class QYLED_DLL
    {
        public delegate void mydelegate(int comMsg);
        
        private const string Ddll = "bin\\QYLED.dll";
        //开启服务（TCP）
        [DllImport(Ddll)]
        public static extern int OpenServer (int TIPPort);
        //关闭服务（TCP）
        [DllImport(Ddll)]
        public static extern int CloseServer();
        //串口通讯回调函数
        [DllImport(Ddll)]
        public static extern int SetComCallBack(mydelegate TComCallBack);
        //添加显示页
        [DllImport(Ddll)]
        public static extern int AddShowPage(string Tstarttime,string Tstoptime,int Tweekday);
        //添加区域
        [DllImport(Ddll)]
        public static extern int AddArea(int Tx,int Ty,int Twidth,int Thigth);
        //添加实时采集素材
        [DllImport(Ddll)]
        public static extern int AddTemplate_CollectData(string TshowContent, int TtypeNo, int TfontColor, int TfontBody, int TfontSize);
        //添加内码文字素材
        [DllImport(Ddll)]
        public static extern int AddTemplate_InternalText(string TshowContent, int Tuid, int TscreenColor, int TshowStyle, int TshowSpeed, int TstopTime, int TfontColor, int TfontBody, int TfontSize, bool TpowerOffSave);
        //添加日期时间素材
        [DllImport(Ddll)]
        public static extern int AddTemplate_DateTime(int Tuid, int TscreenColor, int TnumColor, int TchrColor, int TfontBody, int TfontSize, int TyearLen, int TtimeFormat, int TshowFormat, int TtimeDifSet, int ThourSpan, int TminSpan, int TstopTime, bool TpowerOffSave);
        //添加图片组素材
        [DllImport(Ddll)]
        public static extern int AddTemplate_ImageGroup(string TimageFilePaths, int Tuid, int TscreenColor, int TshowStyle, int TshowSpeed, int TstopTime);
        //添加排队叫号素材
        [DllImport(Ddll)]
        public static extern int AddTemplate_LineUp(string TshowContent, int TstopTime, int TfontColor, int TfontBody, int TfontSize, int TlineUpWinAddrNo, bool TlineUpFlash);
        //发送素材模板到控制卡
        [DllImport(Ddll)]
        public static extern int SendTemplateData_Net(string Tip, int TnetProtocol);
        //发送实时采集（网络）
        [DllImport(Ddll)]
        public static extern int SendCollectionData_Net(string TshowContent, string TIP, int TnetProtocol,int TtypeNo, int TfontColor, int TfontBody, int TfontSize);
        //实时采集批量发送（UDP）
        [DllImport(Ddll)]
        public static extern int SendMulCollectionData_Net(string TshowContent, string TIP, int TnetProtocol, int TtypeNo, int TfontColor, int TfontBody, int TfontSize,int TdataIndex,int TdataCount);
        //发送实时采集（串口）
        [DllImport(Ddll)]
        public static extern int SendCollectionData_Com(string TshowContent, string Trs485Address, int TrsType, int TcomPort, int TbaudRate, int TtypeNo, int TfontColor, int TfontBody, int TfontSize);
        //发送内码文字（网络）
        [DllImport(Ddll)]
        public static extern byte SendInternalText_Net(string TshowContent, string TcardIP, int TnetProtocol, int TareaWidth, int TareaHigth, int Tuid, int TscreenColor, int TshowStyle, int TshowSpeed,int TstopTime,int TfontColor,int TfontBody,int TfontSize,int TupdateStyle,bool TpowerOffSave);
        //内码文字批量发送（UDP）
        [DllImport(Ddll)]
        public static extern int SendMulInternalText_Net(string TshowContent, string TcardIP, int TnetProtocol, int TareaWidth, int TareaHigth, int Tuid, int TscreenColor, int TshowStyle, int TshowSpeed, int TstopTime, int TfontColor, int TfontBody, int TfontSize, int TupdateStyle, int TpowerOffSave,int TtextIndex,int TtextCount);
        //发送内码文字（串口）
        [DllImport(Ddll)]
        public static extern int SendInternalText_Com(string TshowContent, string Trs485Address, int rsType, int TcomPort, int TbaudRate, int TareaWidth, int TareaHigth, int Tuid, int TscreenColor, int TshowStyle, int TshowSpeed, int TstopTime, int TfontColor, int TfontBody, int TfontSize, int TupdateStyle, bool TpowerOffSave);
        //发送排队叫号（UDP）
        [DllImport(Ddll)]
        public static extern int SendLineUp_Net(string TshowContent, string TcardIP, int TnetProtocol, int TstopTime, int TfontColor, int TlineUpWinAddrNo, bool TlineUpFlash);
        //发送排队叫号（RS485）
        [DllImport(Ddll)]
        public static extern int SendLineUp_Com(string TshowContent, string TcardAddress, int TcomPort,int TbaudRate, int TstopTime, int TcycleCount, int TscreenWide, bool TpowerOffSave,bool TlineUpFlash);
        //发送日期时间（网络）
        [DllImport(Ddll)]
        public static extern int SendDateTime_Net(string TcardIP, int TnetProtocol, int Tuid, int TnumColor, int TchrColor, int TfontBody, int TfontSize, int TyearLen, int TtimeFormat, int showFormat, int TtimeDifSet, int ThourSpan, int TminSpan, int TstopTime);
        //发送图片组素材（网络）
        [DllImport(Ddll)]
        public static extern int SendImageGroup_Net(string TimageFilePath, string TcardIP, int TnetProtocol, int TareaWidth, int TareaHigth, int Tuid, int TscreenColor, int TshowStyle, int TshowSpeed, int TstopTime, bool TpowerOffSave, int TimageIndex, int TimageCount);
        //发送点播图片组（UDP）
        //[DllImport(Ddll)]
        //public static extern int PlayImageGroup_Net
        //点播显示页（UDP）
        [DllImport(Ddll)]
        public static extern int PlayShowPage_Net(string TcardIP, int TnetProtocol, int TshowPageNo);
        //点播显示页（串口）
        [DllImport(Ddll)]
        public static extern int PlayShowPage_Com(string Trs485Address, int TrsType, int Tcomport, int TbaudRate, int TshowPageNo);
        //设置控制卡亮度（网络）
        [DllImport(Ddll)]
        public static extern int SetBright_Net(string TcardIP, int TnetProtocol, int Tpriority, int TbrighValue);
        //校正控制卡时间（网络）
        [DllImport(Ddll)]
        public static extern int TimeCheck_Net(string TcardIP, int TnetProtocol);
        //校正控制卡时间（RS485）
        [DllImport(Ddll)]
        public static extern int TimeCheck_Com(string Trs485Address, int TrsType, int TcomPort, int TbaudRate);
        //开始播放控制（TCP）
        [DllImport(Ddll)]
        public static extern int StartPlay_Net(string TcardIP, int TnetProtocol);
        //停止播放控制（TCP）
        [DllImport(Ddll)]
        public static extern int StopPlay_Net(string TcardIP, int TnetProtocol);
        //语音播放(网络)
        [DllImport(Ddll)]
        public static extern int PlayVoice_Net(string TplayContent, string TcardIP, string Trs485Address,int TnetProtocol,int TrsPort);
        //语音播放(串口)
        [DllImport(Ddll)]
        public static extern int PlayVoice_Com(string TplayContent, string Trs485Address, int TrsType, int TcomPort,int TbaudRate);
        //继电器控制(网络)
        [DllImport(Ddll)]
        public static extern int RelaySwitch_Net(string TCardIP, int TNetProtocol, int TSwitch1, int TSwitch2, int TSwitch3);
    }
}
