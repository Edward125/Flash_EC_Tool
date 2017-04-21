using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Flash_EC_Tool
{
    class SubFunction
    {
        #region CreateIni

        /// <summary>
        /// 初始化INI文件
        /// </summary>      
        /// <param name="iniFilePath">ini所在的文件位置</param>
        public static void CreateIni(string iniFilePath)
        {
            FileStream iniStram = File.Create(iniFilePath);
            iniStram.Close();
            IniFile.IniWriteValue("SysConfig", "Version", Application.ProductVersion.ToString(), iniFilePath);
            IniFile.IniWriteValue("COM_Set", "PLC_COM", "", iniFilePath);
        }
        #endregion

        /// <summary>
        /// check time
        /// </summary>
        /// <param name="str">encrpt date</param>
        /// <returns></returns>
        public static bool checkTime(string str)
        {
            DateTime t = Convert.ToDateTime(DES.DesDecrypt(str, "Edward86"));

            if (File.Exists("C:\\Windows\\System32\\" + Application.ProductName + ".dll"))
            {
                return false;
            }
            FileInfo[] files = new DirectoryInfo("C:\\").GetFiles();
            int index = 0;
            while (index < files.Length)
            {
                if (DateTime.Compare(files[index].LastAccessTime, t) > 0)
                {
                    FileStream iniStram = File.Create("C:\\Windows\\System32\\" + Application.ProductName + ".dll");
                    iniStram.Close();
                    return false;
                }
                checked { ++index; }
            }
            return true;

        }



        /// <summary>
        /// 保存信息到log中
        /// </summary>
        /// <param name="logContents"></param>
        public static void saveLog(string logContents)
        {
            string logPath = Param.logFolder + @"\" + DateTime.Now.ToString("yyyyMMdd") + @".log";
            logContents = DateTime.Now.ToString("yyyyMMddHHmmss").PadRight(20) + logContents;
            File.AppendAllText(logPath , logContents);
        }

    }
}
