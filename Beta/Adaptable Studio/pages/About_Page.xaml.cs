﻿using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Adaptable_Studio
{
    /// <summary> About_Page.xaml 的交互逻辑 </summary>
    public partial class About_Page : Page
    {
        #region ini配置文件
        [DllImport("kernel32")]
        static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        //定义写入函数
        //用途：若存在给定路径下的ini文件，就在其中写入给定节和键的值（若已存在此键就覆盖之前的值），若不存在ini文件，就创建该ini文件并写入。

        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        //定义读入函数

        string iniPath = Environment.CurrentDirectory + @"\config.ini";//ini文件路径
        StringBuilder StrName = new StringBuilder(255);//定义字符串  
        #endregion

        #region ini文件读写
        /// <summary> 读取配置文件(字符串, "节名", "键名", 文件路径) </summary>
        public static void IniRead(ref StringBuilder StrName, string configureNode, string key, string path)
        {
            //获取节中 键的值，存在字符串中
            //格式：GetPrivateProfileString("节名", "键名", "", 字符串, 255, 文件路径)
            GetPrivateProfileString(configureNode, key, "", StrName, 255, path);
        }
        /// <summary> 写入配置文件("节名", "键名", 键值, 文件路径) </summary>
        public static void IniWrite(string configureNode, string key, string keyValue, string path)
        {
            WritePrivateProfileString(configureNode, key, keyValue, path);
        }
        #endregion

        public About_Page()
        {
            InitializeComponent();
        }

        void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        void Feedback_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://www.mcbbs.net/thread-580119-1-1.html");
        }

        void Donate_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://afdian.net/@MsYqgzt");
        }


    }
}
