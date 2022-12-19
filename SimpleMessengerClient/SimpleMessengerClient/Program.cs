using SimpleMessenger.Classes;
using SimpleMessengerClient.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleMessenger
{
    internal static class Program
    {
        static bool isTerminating = false;
        public static void SetTerminatingFlag()
        {
            isTerminating = true;
        }

        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //Application.Run(new TestForm());

            while (!isTerminating)
            {
                UserList userList = new UserList();
                ChattingList chattingList = new ChattingList();

                ServerInterface serverInterface = new ServerInterface(userList, chattingList);

                bool connected = false;
                try
                {
                    serverInterface.Connect("127.0.0.1", 9999);
                    connected = true;
                }
                catch (Exception ex)
                {
                    connected = false;
                }

                if (connected)
                {
                    Application.Run(new LoginForm(serverInterface.GetProcessor()));

                    if (serverInterface.GetProcessor().IsSuccessedLogin())
                    {
                        // Mainform
                        Application.Run(new MainForm(serverInterface.GetProcessor(), userList, chattingList));
                    }

                    serverInterface.Disconnect();
                }
                else
                {
                    Application.Run(new CantConnectToServerForm());
                }
            }

        }
    }
}
