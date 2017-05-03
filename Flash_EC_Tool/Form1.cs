using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;

namespace Flash_EC_Tool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region ImportDll&參數定義
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "PostMessage")]
        private static extern int PostMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, StringBuilder lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, StringBuilder lParam);
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        private extern static IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClassName, string lpWindowName);
        //wMsg常量定義
        const int BM_CLICK = 0xF5;
        //创建一个窗口   
        const int WM_CREATE = 0x01;
        //当一个窗口被破坏时发送   
        const int WM_DESTROY = 0x02;
        //移动一个窗口   
        const int WM_MOVE = 0x03;
        //改变一个窗口的大小   
        const int WM_SIZE = 0x05;
        //一个窗口被激活或失去激活状态   
        const int WM_ACTIVATE = 0x06;
        //一个窗口获得焦点   
        const int WM_SETFOCUS = 0x07;
        //一个窗口失去焦点   
        const int WM_KILLFOCUS = 0x08;
        //一个窗口改变成Enable状态   
        const int WM_ENABLE = 0x0A;
        //设置窗口是否能重画   
        const int WM_SETREDRAW = 0x0B;
        //应用程序发送此消息来设置一个窗口的文本   
        const int WM_SETTEXT = 0x0C;
        //应用程序发送此消息来复制对应窗口的文本到缓冲区   
        const int WM_GETTEXT = 0x0D;
        //得到与一个窗口有关的文本的长度（不包含空字符）   
        const int WM_GETTEXTLENGTH = 0x0E;
        //要求一个窗口重画自己   
        const int WM_PAINT = 0x0F;
        //当一个窗口或应用程序要关闭时发送一个信号   
        const int WM_CLOSE = 0x10;
        //当用户选择结束对话框或程序自己调用ExitWindows函数   
        const int WM_QUERYENDSESSION = 0x11;
        //用来结束程序运行   
        const int WM_QUIT = 0x12;
        //当用户窗口恢复以前的大小位置时，把此消息发送给某个图标   
        const int WM_QUERYOPEN = 0x13;
        //当窗口背景必须被擦除时（例在窗口改变大小时）   
        const int WM_ERASEBKGND = 0x14;
        //当系统颜色改变时，发送此消息给所有顶级窗口   
        const int WM_SYSCOLORCHANGE = 0x15;
        //当系统进程发出WM_QUERYENDSESSION消息后，此消息发送给应用程序，通知它对话是否结束   
        const int WM_ENDSESSION = 0x16;
        //当隐藏或显示窗口是发送此消息给这个窗口   
        const int WM_SHOWWINDOW = 0x18;
        //发此消息给应用程序哪个窗口是激活的，哪个是非激活的   
        const int WM_ACTIVATEAPP = 0x1C;
        //当系统的字体资源库变化时发送此消息给所有顶级窗口   
        const int WM_FONTCHANGE = 0x1D;
        //当系统的时间变化时发送此消息给所有顶级窗口   
        const int WM_TIMECHANGE = 0x1E;
        //发送此消息来取消某种正在进行的摸态（操作）   
        const int WM_CANCELMODE = 0x1F;
        //如果鼠标引起光标在某个窗口中移动且鼠标输入没有被捕获时，就发消息给某个窗口   
        const int WM_SETCURSOR = 0x20;
        //当光标在某个非激活的窗口中而用户正按着鼠标的某个键发送此消息给//当前窗口   
        const int WM_MOUSEACTIVATE = 0x21;
        //发送此消息给MDI子窗口//当用户点击此窗口的标题栏，或//当窗口被激活，移动，改变大小   
        const int WM_CHILDACTIVATE = 0x22;
        //此消息由基于计算机的训练程序发送，通过WH_JOURNALPALYBACK的hook程序分离出用户输入消息   
        const int WM_QUEUESYNC = 0x23;
        //此消息发送给窗口当它将要改变大小或位置   
        const int WM_GETMINMAXINFO = 0x24;
        //发送给最小化窗口当它图标将要被重画   
        const int WM_PAINTICON = 0x26;
        //此消息发送给某个最小化窗口，仅//当它在画图标前它的背景必须被重画   
        const int WM_ICONERASEBKGND = 0x27;
        //发送此消息给一个对话框程序去更改焦点位置   
        const int WM_NEXTDLGCTL = 0x28;
        //每当打印管理列队增加或减少一条作业时发出此消息    
        const int WM_SPOOLERSTATUS = 0x2A;
        //当button，combobox，listbox，menu的可视外观改变时发送   
        const int WM_DRAWITEM = 0x2B;
        //当button, combo box, list box, list view control, or menu item 被创建时   
        const int WM_MEASUREITEM = 0x2C;
        //此消息有一个LBS_WANTKEYBOARDINPUT风格的发出给它的所有者来响应WM_KEYDOWN消息    
        const int WM_VKEYTOITEM = 0x2E;
        //此消息由一个LBS_WANTKEYBOARDINPUT风格的列表框发送给他的所有者来响应WM_CHAR消息    
        const int WM_CHARTOITEM = 0x2F;
        //当绘制文本时程序发送此消息得到控件要用的颜色   
        const int WM_SETFONT = 0x30;
        //应用程序发送此消息得到当前控件绘制文本的字体   
        const int WM_GETFONT = 0x31;
        //应用程序发送此消息让一个窗口与一个热键相关连    
        const int WM_SETHOTKEY = 0x32;
        //应用程序发送此消息来判断热键与某个窗口是否有关联   
        const int WM_GETHOTKEY = 0x33;
        //此消息发送给最小化窗口，当此窗口将要被拖放而它的类中没有定义图标，应用程序能返回一个图标或光标的句柄，当用户拖放图标时系统显示这个图标或光标   
        const int WM_QUERYDRAGICON = 0x37;
        //发送此消息来判定combobox或listbox新增加的项的相对位置   
        const int WM_COMPAREITEM = 0x39;
        //显示内存已经很少了   
        const int WM_COMPACTING = 0x41;
        //发送此消息给那个窗口的大小和位置将要被改变时，来调用setwindowpos函数或其它窗口管理函数   
        const int WM_WINDOWPOSCHANGING = 0x46;
        //发送此消息给那个窗口的大小和位置已经被改变时，来调用setwindowpos函数或其它窗口管理函数   
        const int WM_WINDOWPOSCHANGED = 0x47;
        //当系统将要进入暂停状态时发送此消息   
        const int WM_POWER = 0x48;
        //当一个应用程序传递数据给另一个应用程序时发送此消息   
        const int WM_COPYDATA = 0x4A;
        //当某个用户取消程序日志激活状态，提交此消息给程序   
        const int WM_CANCELJOURNA = 0x4B;
        //当某个控件的某个事件已经发生或这个控件需要得到一些信息时，发送此消息给它的父窗口    
        const int WM_NOTIFY = 0x4E;
        //当用户选择某种输入语言，或输入语言的热键改变   
        const int WM_INPUTLANGCHANGEREQUEST = 0x50;
        //当平台现场已经被改变后发送此消息给受影响的最顶级窗口   
        const int WM_INPUTLANGCHANGE = 0x51;
        //当程序已经初始化windows帮助例程时发送此消息给应用程序   
        const int WM_TCARD = 0x52;
        //此消息显示用户按下了F1，如果某个菜单是激活的，就发送此消息个此窗口关联的菜单，否则就发送给有焦点的窗口，如果//当前都没有焦点，就把此消息发送给//当前激活的窗口   
        const int WM_HELP = 0x53;
        //当用户已经登入或退出后发送此消息给所有的窗口，//当用户登入或退出时系统更新用户的具体设置信息，在用户更新设置时系统马上发送此消息   
        const int WM_USERCHANGED = 0x54;
        //公用控件，自定义控件和他们的父窗口通过此消息来判断控件是使用ANSI还是UNICODE结构   
        const int WM_NOTIFYFORMAT = 0x55;
        //当用户某个窗口中点击了一下右键就发送此消息给这个窗口   
        //const int WM_CONTEXTMENU = ??;   
        //当调用SETWINDOWLONG函数将要改变一个或多个 窗口的风格时发送此消息给那个窗口   
        const int WM_STYLECHANGING = 0x7C;
        //当调用SETWINDOWLONG函数一个或多个 窗口的风格后发送此消息给那个窗口   
        const int WM_STYLECHANGED = 0x7D;
        //当显示器的分辨率改变后发送此消息给所有的窗口   
        const int WM_DISPLAYCHANGE = 0x7E;
        //此消息发送给某个窗口来返回与某个窗口有关连的大图标或小图标的句柄   
        const int WM_GETICON = 0x7F;
        //程序发送此消息让一个新的大图标或小图标与某个窗口关联   
        const int WM_SETICON = 0x80;
        //当某个窗口第一次被创建时，此消息在WM_CREATE消息发送前发送   
        const int WM_NCCREATE = 0x81;
        //此消息通知某个窗口，非客户区正在销毁    
        const int WM_NCDESTROY = 0x82;
        //当某个窗口的客户区域必须被核算时发送此消息   
        const int WM_NCCALCSIZE = 0x83;
        //移动鼠标，按住或释放鼠标时发生   
        const int WM_NCHITTEST = 0x84;
        //程序发送此消息给某个窗口当它（窗口）的框架必须被绘制时   
        const int WM_NCPAINT = 0x85;
        //此消息发送给某个窗口仅当它的非客户区需要被改变来显示是激活还是非激活状态   
        const int WM_NCACTIVATE = 0x86;
        //发送此消息给某个与对话框程序关联的控件，widdows控制方位键和TAB键使输入进入此控件通过应   
        const int WM_GETDLGCODE = 0x87;
        //当光标在一个窗口的非客户区内移动时发送此消息给这个窗口 非客户区为：窗体的标题栏及窗 的边框体   
        const int WM_NCMOUSEMOVE = 0xA0;
        //当光标在一个窗口的非客户区同时按下鼠标左键时提交此消息   
        const int WM_NCLBUTTONDOWN = 0xA1;
        //当用户释放鼠标左键同时光标某个窗口在非客户区十发送此消息    
        const int WM_NCLBUTTONUP = 0xA2;
        //当用户双击鼠标左键同时光标某个窗口在非客户区十发送此消息   
        const int WM_NCLBUTTONDBLCLK = 0xA3;
        //当用户按下鼠标右键同时光标又在窗口的非客户区时发送此消息   
        const int WM_NCRBUTTONDOWN = 0xA4;
        //当用户释放鼠标右键同时光标又在窗口的非客户区时发送此消息   
        const int WM_NCRBUTTONUP = 0xA5;
        //当用户双击鼠标右键同时光标某个窗口在非客户区十发送此消息   
        const int WM_NCRBUTTONDBLCLK = 0xA6;
        //当用户按下鼠标中键同时光标又在窗口的非客户区时发送此消息   
        const int WM_NCMBUTTONDOWN = 0xA7;
        //当用户释放鼠标中键同时光标又在窗口的非客户区时发送此消息   
        const int WM_NCMBUTTONUP = 0xA8;
        //当用户双击鼠标中键同时光标又在窗口的非客户区时发送此消息   
        const int WM_NCMBUTTONDBLCLK = 0xA9;
        //WM_KEYDOWN 按下一个键   
        const int WM_KEYDOWN = 0x0100;
        //释放一个键   
        const int WM_KEYUP = 0x0101;
        //按下某键，并已发出WM_KEYDOWN， WM_KEYUP消息   
        const int WM_CHAR = 0x102;
        //当用translatemessage函数翻译WM_KEYUP消息时发送此消息给拥有焦点的窗口   
        const int WM_DEADCHAR = 0x103;
        //当用户按住ALT键同时按下其它键时提交此消息给拥有焦点的窗口   
        const int WM_SYSKEYDOWN = 0x104;
        //当用户释放一个键同时ALT 键还按着时提交此消息给拥有焦点的窗口   
        const int WM_SYSKEYUP = 0x105;
        //当WM_SYSKEYDOWN消息被TRANSLATEMESSAGE函数翻译后提交此消息给拥有焦点的窗口   
        const int WM_SYSCHAR = 0x106;
        //当WM_SYSKEYDOWN消息被TRANSLATEMESSAGE函数翻译后发送此消息给拥有焦点的窗口   
        const int WM_SYSDEADCHAR = 0x107;
        //在一个对话框程序被显示前发送此消息给它，通常用此消息初始化控件和执行其它任务   
        const int WM_INITDIALOG = 0x110;
        //当用户选择一条菜单命令项或当某个控件发送一条消息给它的父窗口，一个快捷键被翻译   
        const int WM_COMMAND = 0x111;
        //当用户选择窗口菜单的一条命令或//当用户选择最大化或最小化时那个窗口会收到此消息   
        const int WM_SYSCOMMAND = 0x112;
        //发生了定时器事件   
        const int WM_TIMER = 0x113;
        //当一个窗口标准水平滚动条产生一个滚动事件时发送此消息给那个窗口，也发送给拥有它的控件   
        const int WM_HSCROLL = 0x114;
        //当一个窗口标准垂直滚动条产生一个滚动事件时发送此消息给那个窗口也，发送给拥有它的控件   
        const int WM_VSCROLL = 0x115;
        //当一个菜单将要被激活时发送此消息，它发生在用户菜单条中的某项或按下某个菜单键，它允许程序在显示前更改菜单   
        const int WM_INITMENU = 0x116;
        //当一个下拉菜单或子菜单将要被激活时发送此消息，它允许程序在它显示前更改菜单，而不要改变全部   
        const int WM_INITMENUPOPUP = 0x117;
        //当用户选择一条菜单项时发送此消息给菜单的所有者（一般是窗口）   
        const int WM_MENUSELECT = 0x11F;
        //当菜单已被激活用户按下了某个键（不同于加速键），发送此消息给菜单的所有者   
        const int WM_MENUCHAR = 0x120;
        //当一个模态对话框或菜单进入空载状态时发送此消息给它的所有者，一个模态对话框或菜单进入空载状态就是在处理完一条或几条先前的消息后没有消息它的列队中等待   
        const int WM_ENTERIDLE = 0x121;
        //在windows绘制消息框前发送此消息给消息框的所有者窗口，通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置消息框的文本和背景颜色   
        const int WM_CTLCOLORMSGBOX = 0x132;
        //当一个编辑型控件将要被绘制时发送此消息给它的父窗口通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置编辑框的文本和背景颜色   
        const int WM_CTLCOLOREDIT = 0x133;

        //当一个列表框控件将要被绘制前发送此消息给它的父窗口通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置列表框的文本和背景颜色   
        const int WM_CTLCOLORLISTBOX = 0x134;
        //当一个按钮控件将要被绘制时发送此消息给它的父窗口通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置按纽的文本和背景颜色   
        const int WM_CTLCOLORBTN = 0x135;
        //当一个对话框控件将要被绘制前发送此消息给它的父窗口通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置对话框的文本背景颜色   
        const int WM_CTLCOLORDLG = 0x136;
        //当一个滚动条控件将要被绘制时发送此消息给它的父窗口通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置滚动条的背景颜色   
        const int WM_CTLCOLORSCROLLBAR = 0x137;
        //当一个静态控件将要被绘制时发送此消息给它的父窗口通过响应这条消息，所有者窗口可以 通过使用给定的相关显示设备的句柄来设置静态控件的文本和背景颜色   
        const int WM_CTLCOLORSTATIC = 0x138;
        //当鼠标轮子转动时发送此消息个当前有焦点的控件   
        const int WM_MOUSEWHEEL = 0x20A;
        //双击鼠标中键   
        const int WM_MBUTTONDBLCLK = 0x209;
        //释放鼠标中键   
        const int WM_MBUTTONUP = 0x208;
        //移动鼠标时发生，同WM_MOUSEFIRST   
        const int WM_MOUSEMOVE = 0x200;
        //按下鼠标左键   
        const int WM_LBUTTONDOWN = 0x201;
        //释放鼠标左键   
        const int WM_LBUTTONUP = 0x202;
        //双击鼠标左键   
        const int WM_LBUTTONDBLCLK = 0x203;
        //按下鼠标右键   
        const int WM_RBUTTONDOWN = 0x204;
        //释放鼠标右键   
        const int WM_RBUTTONUP = 0x205;
        //双击鼠标右键   
        const int WM_RBUTTONDBLCLK = 0x206;
        //按下鼠标中键   
        const int WM_MBUTTONDOWN = 0x207;
        const int WM_USER = 0x0400;
        const int MK_LBUTTON = 0x0001;
        const int MK_RBUTTON = 0x0002;
        const int MK_SHIFT = 0x0004;
        const int MK_CONTROL = 0x0008;
        const int MK_MBUTTON = 0x0010;
        const int MK_XBUTTON1 = 0x0020;
        const int MK_XBUTTON2 = 0x0040;
        const int LB_GETCOUNT = 0x018B;
        const int LB_GETTEXT = 0x0189;
        const int LB_RESETCONTENT = 0x184;

        const int BM_GETCHECK = 0x00F0;

        public string portName = string.Empty;
        public int PLC_Read = -1;
        public int PLC_Write = -1;
        public int PLC_Last_Read = -1;
        public string PLC_Read_Device = "D100";
        public string PLC_Write_Device = "D200";
        public int MaxTry = 3;
        public int iTotal = 0;
        public int iPASS = 0;

        #endregion


        delegate void displaymessage();

       
        private void displaymessageinlabel()
        {
            this.lblResult.ForeColor = Color.Yellow;
            this. lblResult.Text = "WAIT";
        }

        //static Program()
        //{
        //    LoadResourceDll.RegistDLL();
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Flash EC Tool, Ver:" + Application.ProductVersion + ", Author:Edward Song";
            this.toolScripVersion.Text = "Application Product Version(程式版本):" + Application.ProductVersion;
            this.toolScriptAuther.Text = ", Author:Edward Song,edward_song@yeah.net";
            this.txtPASS.Text = iPASS.ToString();
            this.txtTotal.Text = iTotal.ToString();
            //check inifile
            if (!Directory.Exists(Param.sysFolder))
                Directory.CreateDirectory(Param.sysFolder);
            if (!Directory.Exists(Param.logFolder))
                Directory.CreateDirectory(Param.logFolder);
            if (!File.Exists(Param.IniFilePath))
                SubFunction.CreateIni(Param.IniFilePath);
            //read value form ini file 
            portName = IniFile.IniReadValue("COM_Set", "PLC_COM", Param.IniFilePath);
            if (string.IsNullOrEmpty(portName))
            {
                //加載串口 
                getSerialPort(comboPLC);
            }
            else
            {
                getSerialPort(comboPLC);
                this.comboPLC.Text = portName;
            }
         }

        private void ShadowCharactors(Label lbl)
        {
            Font var_font = lbl.Font;
            string var_char = lbl.Text;
            Graphics g = this.CreateGraphics();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolScripTime.Text = ", Local Time(當前時間):" + DateTime.Now;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getSerialPort(this.comboPLC);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        #region 串口相關操作

        /// <summary>
        /// 獲取串口 
        /// </summary>
        /// <param name="combox"></param>
        private void getSerialPort(ComboBox combox)
        {
            combox.Items.Clear();
            foreach (string sp in System.IO.Ports.SerialPort.GetPortNames())
            {
                combox.Items.Add(sp);
            }

            if (combox.Items.Count > 0)
            {
                combox.SelectedIndex = 0;
            }

            if (combox.Items.Count == 1)
            {
                //結果存入ini
                IniFile.IniWriteValue("COM_Set", "PLC_COM", combox.SelectedItem.ToString(), Param.IniFilePath);
                portName = combox.SelectedItem.ToString();
            }
        }

        /// <summary>
        /// 打開串口
        /// </summary>
        /// <param name="sp">控件</param>
        /// <param name="portname">串口名稱</param>
        /// <returns>OK=true,NG=false</returns>
        private bool openSerialPort(SerialPort sp, string portname)
        {
            // bool result = true;
            sp.PortName = portname;
            if (!sp.IsOpen)
            {
                try
                {
                    sp.Open();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Can't open SerialPort=" + portname + ",Message:" + e.Message);
                    SubFunction.saveLog("Can't open SerialPort=" + portname + ",Message:" + e.Message +"\r\n");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// close serial port
        /// </summary>
        /// <param name="sp">OK=true,NG=false</param>
        /// <returns></returns>
        private bool closeSerialPort(SerialPort sp)
        {
            if (sp.IsOpen)
            {
                try
                {
                    sp.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Can't close SerialPort=" + sp.PortName.ToString() + ",Message:" + e.Message);
                    SubFunction.saveLog("Can't close SerialPort=" + sp.PortName.ToString() + ",Message:" + e.Message + "\r\n");
                }
            }
            return true;
        }

        /// <summary>
        /// 將串口名字更改為串口數字
        /// </summary>
        /// <param name="portname">串口名字,入COM1</param>
        /// <returns>返回int，如COM1返回1</returns>
        private int changePortNumber(string portname)
        {
            int port = -1;


            //debug
           // MessageBox.Show(portname.Substring(3, 1));


            try
            {
                port = Convert.ToInt16(portname.Replace ("COM",""));
            }
            catch (Exception e)
            {
                MessageBox.Show("Change Serial Port to Nunmber Error,Message:" +
                    e.Message);
                SubFunction.saveLog("Change Serial Port to Nunmber Error,Message:" +
                    e.Message +"\r\n");
            }

            return port;
        }

        #endregion

        /// <summary>
        /// 設置PLC
        /// </summary>
        private void settingPLC(int portNumber)
        {
            actPLC.ActPortNumber = portNumber;
            actPLC.ActUnitType = 0x000F;
            actPLC.ActProtocolType = 0x0004;
            actPLC.ActCpuType = 0x0206;
            actPLC.ActBaudRate = 9600;
            //actPLC.ActDataBits = 0x0007;
        }


        /// <summary>
        /// 從PLC中讀取值
        /// </summary>
        /// <param name="plcdevice">PLC地址</param>
        /// <param name="plcread">PLC讀取的值</param>
        /// <returns>讀取成功為true,失敗為false</returns>
        private bool readPLCValue(string plcdevice, ref int plcread)
        {
            int iReturn = actPLC.GetDevice(plcdevice, out plcread);
            if (iReturn != 0)
            {
                MessageBox.Show("Can't Read PLC Value,Error Code = " + iReturn);
                SubFunction.saveLog("Can't Read PLC Value,Error Code = " + iReturn +"\r\n");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 給PLC寫值
        /// </summary>
        /// <param name="plcdevice">PLC地址</param>
        /// <param name="plcwrite">PLC寫入的值</param>
        /// <returns>成功true,失敗false</returns>
        private bool writePLCValue(string plcdevice, int plcwrite)
        {
            int iReturn = -1;
            iReturn = actPLC.SetDevice(plcdevice, plcwrite);
            if (iReturn != 0)
            {
                MessageBox.Show("Can't write PLC,Error Code = " + iReturn);
                SubFunction.saveLog("Can't write PLC,Error Code = " + iReturn +"\r\n");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 獲取listbox中的內容 
        /// </summary>
        /// <param name="listBoxHwnd">listbox句柄</param>
        /// <returns></returns>
        private List<string> GetListBoxContents(IntPtr listBoxHwnd)
        {
            int cnt = (int)SendMessage(listBoxHwnd, LB_GETCOUNT, IntPtr.Zero, null);
            List<string> listBoxContent = new List<string>();
            for (int i = 0; i < cnt; i++)
            {
                StringBuilder sb = new StringBuilder(256);
                IntPtr getText = SendMessage  (listBoxHwnd, LB_GETTEXT, (IntPtr)i, sb);
                //MessageBox.Show(sb.ToString());
                listBoxContent.Add(sb.ToString());
                //  richTextBox1.AppendText(sb.ToString());
                //  richTextBox1.AppendText(Environment.NewLine);
            }
            return listBoxContent;
        }

        /// <summary>
        /// find listbox hwnd
        /// </summary>
        private void FindListbox()
        {
            IntPtr hwndOfMain = FindWindow(null, "SFPU (MEC5075 - Digilent-2.9)");
            if (hwndOfMain == IntPtr.Zero)
            {
                hwndOfMain = FindWindow(null, "SFPU (MEC5085 - Digilent-2.9)");
            }

            IntPtr hwndOfDiag = FindWindowEx(hwndOfMain, IntPtr.Zero, null, "Flash Update");
            if (hwndOfDiag != IntPtr.Zero)
            {
                IntPtr hwndOfListbox = FindWindowEx(hwndOfDiag, IntPtr.Zero, "Listbox", null);

                if (hwndOfListbox != IntPtr.Zero)
                    MessageBox.Show("Find the listbox");
            }
        }




        private bool checkFlashMassEra()
        {
            IntPtr hwndOfMain = FindWindow(null, "SFPU (MEC5075 - Digilent-2.9)");
            if (hwndOfMain == IntPtr.Zero)
            {
                hwndOfMain = FindWindow(null, "SFPU (MEC5085 - Digilent-2.9)");
            }

            IntPtr hwndOfDiag = FindWindowEx(hwndOfMain, IntPtr.Zero, null, "Flash Update");
            if (hwndOfDiag != IntPtr.Zero)
            {
                IntPtr hwndOfListbox = FindWindowEx(hwndOfDiag, IntPtr.Zero, null, "Flash emergency mass erase");
                //IntPtr hwndOfListbox = FindWindowEx(hwndOfDiag, IntPtr.Zero, null, "Save flash image:");
                if (hwndOfListbox != IntPtr.Zero)
                {

                    int result = SendMessage(hwndOfListbox, BM_GETCHECK, 0, 0); // result == 0,not checked,result == 1,checked

                    if (result == 0)
                        return false;
                    if (result  == 1)
                       return true ;
                }

                
            }


            return false;

        }




        /// <summary>
        /// 清除listbox中的值
        /// </summary>
        private void clearListbox()
        {
            richTestMessage.Text = "";
            IntPtr hwndOfMain = FindWindow(null, "SFPU (MEC5075 - Digilent-2.9)");
            if (hwndOfMain == IntPtr.Zero)
            {
                hwndOfMain = FindWindow(null, "SFPU (MEC5085 - Digilent-2.9)");
            }

            IntPtr hwndOfDiag = FindWindowEx(hwndOfMain, IntPtr.Zero, null, "Flash Update");
            if (hwndOfDiag != IntPtr.Zero)
            {
                IntPtr hwndOfListbox = FindWindowEx(hwndOfDiag, IntPtr.Zero, "Listbox", null);

                if (hwndOfListbox != IntPtr.Zero)
                    SendMessage(hwndOfListbox, LB_RESETCONTENT, 0, 0);
            }
        }

        /// <summary>
        /// press update button
        /// </summary>
        private void PressUpdateButton()
        {
            
            IntPtr hwndOfMain = FindWindow(null , "SFPU (MEC5085 - Digilent-2.9)");
            if (hwndOfMain == IntPtr.Zero)
            {
                hwndOfMain = FindWindow(null , "SFPU (MEC5075 - Digilent-2.9)");
            }
            IntPtr hwndOfDiag = FindWindowEx(hwndOfMain, IntPtr.Zero, null, "Flash Update");
            if (hwndOfDiag != IntPtr.Zero)
            {
                IntPtr hwndOfUpdate = FindWindowEx(hwndOfDiag, IntPtr.Zero, "Button", "Update");
                Stopwatch sw = new Stopwatch();
                sw.Start();
                SendMessage(hwndOfUpdate, BM_CLICK, 0, 0);
                sw.Stop();
                TimeSpan timespan = sw.Elapsed;
                if (timespan.TotalMilliseconds  < 1000)
                    SendMessage(hwndOfUpdate, BM_CLICK, 0, 0);              
            }
        }
       





        private void bnStop_Click(object sender, EventArgs e)
        {
            this.timerScanPLC.Stop();
            try
            {
                if (actPLC.Close() != 0)
                {
                    MessageBox.Show("Can't Close PLC");
                }
             this.btnAutoTest.Enabled = true;
             this.bnStop.Enabled = true;
             this.btnRefresh.Enabled = true;
             this.comboPLC.Enabled = true;
            
                PLC_Last_Read = -1;
                PLC_Read = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Close PLC Error,Message:" + ex.Message);
            }
        }

        private void timerScanPLC_Tick(object sender, EventArgs e)
        {
            this.timerScanPLC.Stop();
            readPLCValue(PLC_Read_Device, ref PLC_Read);
            if (PLC_Read == 65)
            {
                if (PLC_Last_Read != 65)
                {                   
                    this.Invoke((EventHandler)(delegate
{
    this.lblResult.ForeColor = Color.Yellow;
    this.lblResult.Text = "WAIT";
}));
                    iTotal += 1;
                    this.txtTotal.Text = iTotal.ToString();
                    updateTestHistory(lstHistory, "WAIT");
                    SubFunction.saveLog("Read PLC D100=65.\r\n");
                    clearListbox();
                    PressUpdateButton();
                    foreach (string st in GetListBoxContents(getListBoxHwnd(getTagHwnd())))
                    {
                        richTestMessage.AppendText(st);
                        richTestMessage.AppendText(Environment.NewLine);
                        //===============PASS======================
                        if (st.Contains("Verify flash successful"))
                        {
                            iPASS += 1;
                            //寫PLC 
                            if (writePLCValue(PLC_Write_Device, 80))
                            {
                                this.txtPASS.Text = iPASS.ToString();
                                this.lblResult.Text = "PASS";
                                this.lblResult.ForeColor = Color.Green;
                                updateTestHistory(lstHistory, "PASS");
                                SubFunction.saveLog("Auto->PASS.\r\n");
                                SubFunction.saveLog("Write PLC D200=80.\r\n");
                            }
                            else
                            {
                                SubFunction.saveLog("Write PLC D200=80 fail.\r\n");
                            }
                            //================FAIL=====================
                            if (st.Contains("Time"))
                            {
                                double testTime = -1;
                                getTestingTime(st, ref testTime);
                                if (testTime < 18)
                                {
                                    this.Invoke((EventHandler)(delegate
                                    {
                                        this.lblResult.ForeColor = Color.Red;
                                        this.lblResult.Text = "FAIL";
                                    }));
                                    updateTestHistory(lstHistory, "FAIL");
                                    writePLCValue(PLC_Write_Device, 70);
                                    SubFunction.saveLog("auto->fail,time=" + testTime + ".\r\n");
                                    SubFunction.saveLog("write plc d200=70.\r\n");
                                }
                            }

                        }
                    }
                }               
            }
            PLC_Last_Read = PLC_Read;
           this. timerScanPLC.Start();
   

        }

        /// <summary>
        /// 獲取tag的句柄
        /// </summary>
        /// <returns></returns>
        private IntPtr getTagHwnd()
        {
            IntPtr result = IntPtr.Zero;
            IntPtr hwndOfMain = FindWindow(null, "SFPU (MEC5085 - Digilent-2.9)");
            if (hwndOfMain == IntPtr.Zero)
                hwndOfMain = FindWindow(null, "SFPU (MEC5075 - Digilent-2.9)");
            if (hwndOfMain != IntPtr.Zero)
            {
                IntPtr hwndOfDiag = FindWindowEx(hwndOfMain, IntPtr.Zero, null, "Flash Update");
                if (hwndOfDiag != IntPtr.Zero)
                {
                    result = hwndOfDiag;
                }
                else
                {
                   // MessageBox.Show("Get Hwnd of Flash Update Fail", "Get Tag Hwnd");
                }
            }
            else
            {
                //MessageBox.Show("Get Hwnd of SFPU (MEC5085 - Digilent-2.9) Fail", "Get Main Hwnd");
            }
            return result;
        }

        /// <summary>
        /// 獲取listbox的句柄
        /// </summary>
        /// <param name="taghwnd"></param>
        /// <returns></returns>
        private IntPtr getListBoxHwnd(IntPtr taghwnd)
        {
            IntPtr result = IntPtr.Zero;

            IntPtr hwndOfListbox = FindWindowEx(taghwnd, IntPtr.Zero, "Listbox", null);
            if (hwndOfListbox != IntPtr.Zero)
            {
                result = hwndOfListbox;
            }
            else
            {
                //MessageBox.Show("Get Hwnd of Listbox Fail", "Get Listbox Hwnd");
            }

            return result;
        }

        private void btnAutoTest_Click(object sender, EventArgs e)
        {
            if (checkFlashMassEra())
            {
                MessageBox.Show("选择打开的SFPU刷EC工具版本有误,可能导致MB异常，请联系PE检查... ", "Version Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                SubFunction.saveLog("选择打开的SFPU刷EC工具版本有误,可能导致MB异常，请联系PE检查...\r\n");
                return;
            }

            //set plc
            settingPLC(changePortNumber(portName));
            if (actPLC.Open() != 0)
            {
                //連接不成功
                MessageBox.Show("Can't Auto Connect PLC");
                SubFunction.saveLog("Auto Test,Can't Auto Connect PLC.\r\n");
                this.btnAutoTest.Enabled = true;
            }
            else
            {
                //連接成功
                this.btnAutoTest.Enabled = false;
                this.btnRefresh.Enabled = false;
                this.comboPLC.Enabled = false;
                //開始掃描
                timerScanPLC.Enabled = true;
                timerScanPLC.Start();
            }
        }

        private void btnManual_Click(object sender, EventArgs e)
        {

           if ( checkFlashMassEra())
           {
               MessageBox.Show("选择打开的SFPU刷EC工具版本有误,可能导致MB异常，请联系PE检查... ", "Version Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               SubFunction.saveLog("选择打开的SFPU刷EC工具版本有误,可能导致MB异常，请联系PE检查...\r\n");
               return;
           }

            //return;
            clearListbox();
            SubFunction.saveLog("Manual->clearListbox.\r\n");
            PressUpdateButton();
            SubFunction.saveLog("Manual->PressUpdateButton.\r\n");

            foreach (string st in GetListBoxContents(getListBoxHwnd(getTagHwnd())))
            {
                richTestMessage.AppendText(st);
                richTestMessage.AppendText(Environment.NewLine);

                if (st.Contains("Verify flash successful"))
                {
                    this.Invoke((EventHandler)(delegate
                    {
                        this.lblResult.ForeColor = Color.Green;
                        this.lblResult.Text = "PASS";
                    }));
                    this.lblResult.ForeColor = Color.Green;
                    updateTestHistory(lstHistory, "PASS");
                    SubFunction.saveLog("Manual->PASS.\r\n");
                }

                if (st.Contains("Time"))
                {
                    //
                    double testTime = -1;
                    getTestingTime(st, ref testTime);
                    if (testTime < 18)
                    {
                        this.Invoke((EventHandler)(delegate
                        {
                            this.lblResult.ForeColor = Color.Red;
                            this.lblResult.Text = "FAIL";
                        }));
                        SubFunction.saveLog("Manual->FAIL,Time=" + testTime +".\r\n");
                        updateTestHistory(lstHistory, "FAIL");
                    }
                }

            }
        }


        /// <summary>
        /// 從字符串中分離出測試時間
        /// </summary>
        /// <param name="testmessage">測試信息的字符串</param>
        /// <param name="testtime">測試時間</param>
        /// <returns>返回一個double類型的測時間</returns>
        private double getTestingTime(string testmessage, ref  double testtime)
        {
            testtime = -1;
            testmessage = testmessage.Replace("Time:", string.Empty);
            testmessage = testmessage.Replace("seconds", string.Empty).Trim();
            testtime = Convert.ToDouble(testmessage);
            return testtime;
        }



        /// <summary>
        /// 添加信息到測試歷史listbox中
        /// </summary>
        /// <param name="listbox">listbox的名字</param>
        /// <param name="contents">內容</param>
        private void updateTestHistory(ListBox listbox,string contents)
        {
            if (listbox.Items.Count > 100)
                listbox.Items.Clear();

            listbox.Items.Add (DateTime.Now.ToString ("HH:mm:ss" + "->" + contents ));

            if (listbox.Items.Count > 1)
            {
                listbox.TopIndex = listbox.Items.Count - 1;
                listbox.SetSelected(listbox.Items.Count - 1, true);
            }


        }

        private void comboPLC_SelectedIndexChanged(object sender, EventArgs e)
        {
            IniFile.IniWriteValue("COM_Set", "PLC_COM", this.comboPLC.Text.Trim(), Param.IniFilePath);
        }
    }
    
}
