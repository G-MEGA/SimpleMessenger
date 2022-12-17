using System.Text;
using SimpleMessengerServer.Classes;

namespace SimpleMessengerServer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            UserList userList = new UserList();
            ClientAcceptor clientAcceptor = new ClientAcceptor(userList);
            clientAcceptor.StartToAcceptClients();

            Application.Run(new MainForm());

            clientAcceptor.StopToAcceptClients();
        }
    }
}