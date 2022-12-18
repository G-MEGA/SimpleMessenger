﻿using SimpleMessenger.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleMessenger
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            UserList userList = new UserList();
            ChattingList chattingList = new ChattingList();

            ServerInterface serverInterface = new ServerInterface(userList, chattingList);
            serverInterface.Connect("127.0.0.1", 9999);

            Application.Run(new LoginForm());
        }
    }
}