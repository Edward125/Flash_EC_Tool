using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Flash_EC_Tool
{
    public partial class frmSetting : Form
    {

        #region 參數定義
        public IntPtr HwndOfDebugMainForm = IntPtr.Zero;
        public IntPtr HwndOfTabSetting = IntPtr.Zero;
        public IntPtr HwndOfButtonDeviceManager = IntPtr.Zero;
        public IntPtr HwndOfFormDeviceManager = IntPtr.Zero;
        public IntPtr HwndOfListConnectDevice = IntPtr.Zero;
        public IntPtr HwndOfListDeviceTable = IntPtr.Zero;
        public IntPtr HwndOfButtonEnumerate = IntPtr.Zero;
        public IntPtr HwndOfTextboxAlias = IntPtr.Zero;
        public IntPtr HwndOfButtonSave = IntPtr.Zero;
        public IntPtr HwndOfButtonRemoveDevice = IntPtr.Zero;
        #endregion

        #region DllImport
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        //[DllImport("user32.dll", EntryPoint = "SendMessage")]
        //private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, string lParam);
        //[DllImport("user32.dll", EntryPoint = "SendMessage")]
        //private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, ref string lParam);
        //[DllImport("user32.dll",CharSet = CharSet.Auto ,SetLastError = false) ]// EntryPoint = "FindWindow")]
        //private static extern int SendMessage(IntPtr hwnd, uint wMsg, IntPtr wParam, StringBuilder  lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, StringBuilder lParam);
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        private extern static IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClassName, string lpWindowName);
        const int BM_CLICK = 0xF5; //click
        const int WM_LBUTTONDOWN = 0x201;//鼠標左鍵

        //一个窗口被激活或失去激活状态   
        const int WM_ACTIVATE = 0x06;
        //一个窗口获得焦点   
        const int WM_SETFOCUS = 0x07;


        const Int32 TCM_FIRST = 0x1300;
        const Int32 TCM_GETIMAGELIST = (TCM_FIRST + 2);
        const Int32 TCM_SETIMAGELIST = (TCM_FIRST + 3);
        const Int32 TCM_GETITEMCOUNT = (TCM_FIRST + 4);
        const Int32 TCM_GETITEMA = (TCM_FIRST + 5);
        const Int32 TCM_GETITEMW = (TCM_FIRST + 60);
        const Int32 TCM_SETITEMA = (TCM_FIRST + 6);
        const Int32 TCM_SETITEMW = (TCM_FIRST + 61);
        const Int32 TCM_INSERTITEMA = (TCM_FIRST + 7);
        const Int32 TCM_INSERTITEMW = (TCM_FIRST + 62);
        const Int32 TCM_DELETEITEM = (TCM_FIRST + 8);
        const Int32 TCM_DELETEALLITEMS = (TCM_FIRST + 9);
        const Int32 TCM_GETITEMRECT = (TCM_FIRST + 10);
        const Int32 TCM_GETCURSEL = (TCM_FIRST + 11);
        const Int32 TCM_SETCURSEL = (TCM_FIRST + 12);
        const Int32 TCM_HITTEST = (TCM_FIRST + 13);
        const Int32 TCM_SETITEMEXTRA = (TCM_FIRST + 14);
        const Int32 TCM_ADJUSTRECT = (TCM_FIRST + 40);
        const Int32 TCM_SETITEMSIZE = (TCM_FIRST + 41);
        const Int32 TCM_REMOVEIMAGE = (TCM_FIRST + 42);
        const Int32 TCM_SETPADDING = (TCM_FIRST + 43);
        const Int32 TCM_GETROWCOUNT = (TCM_FIRST + 44);
        const Int32 TCM_GETCURFOCUS = (TCM_FIRST + 47);
        const Int32 TCM_SETCURFOCUS = (TCM_FIRST + 48);
        const Int32 TCM_SETMINTABWIDTH = (TCM_FIRST + 49);
        const Int32 TCM_DESELECTALL = (TCM_FIRST + 50);
        const Int32 TCM_HIGHLIGHTITEM = (TCM_FIRST + 51);
        const Int32 TCM_SETEXTENDEDSTYLE = (TCM_FIRST + 52); // optional wParam == mask
        const Int32 TCM_GETEXTENDEDSTYLE = (TCM_FIRST + 53);





        #endregion



        public frmSetting()
        {
            InitializeComponent();
        }

        private void btnAutoSetting_Click(object sender, EventArgs e)
        {
        
            getDebugFormHwnd("Digilent Adept", ref HwndOfDebugMainForm);

            //未找到主窗體,退出   
            if ( HwndOfDebugMainForm == IntPtr.Zero)
                {
                    MessageBox.Show("Can't Find Hwnd Of \"Digilent Adept\" ");
                     return;
               }
            //find setting tab
            HwndOfTabSetting = FindWindowEx(HwndOfDebugMainForm, IntPtr.Zero, "SysTabControl32", null );
            IntPtr HwndOfDiag = FindWindowEx(HwndOfTabSetting, IntPtr.Zero, "#32770 (Dialog)", null);
            MessageBox.Show(HwndOfDiag.ToString());
            //MessageBox.Show(HwndOfTabSetting.ToString());
         // int count =  SendMessage(HwndOfTabSetting, TCM_GETITEMCOUNT, 2, 0);
          
            //SendMessage(HwndOfTabSetting, TCM_SETCURSEL , 1, 0);
            //SendMessage(HwndOfTabSetting, TCM_GETCURSEL, 1, 0);
            //SendMessage(HwndOfTabSetting, WM_SETFOCUS, 1, 0);
            //SendMessage(HwndOfTabSetting, WM_LBUTTONDOWN, 1, 0);
          //MessageBox.Show(count.ToString());
           
        }



        /// <summary>
        /// 獲取窗體的句柄
        /// </summary>
        /// <param name="hwndofdebugform"></param>
        private void  getDebugFormHwnd(string szwindowsname,ref  IntPtr  hwndofdebugform)
        {
            hwndofdebugform = FindWindow(null, szwindowsname);
        }



    }
}
