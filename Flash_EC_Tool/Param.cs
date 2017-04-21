using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Flash_EC_Tool
{
    class Param
    {
        public static string sysFolder = Application.StartupPath + @"\" + Application.ProductName;
        public static string logFolder = Application.StartupPath + @"\" + Application.ProductName + @"\" + "Log";
        public static string IniFilePath = Application.StartupPath + @"\" + Application.ProductName + @"\" + "sysConfig.ini";
        public static string portName = string.Empty;
    }
}
