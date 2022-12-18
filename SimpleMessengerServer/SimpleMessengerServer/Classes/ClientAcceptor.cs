using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessengerServer.Classes
{
    internal class ClientAcceptor
    {
        Thread threadToRead;
        TcpListener listener;

        UserList userList;

        public ClientAcceptor(UserList ul)
        {
            userList = ul;

            threadToRead = new Thread(AcceptClients);
            listener = new(IPAddress.Any, 9999);
        }
        public void StartToAcceptClients()
        {
            threadToRead.Start();
        }
        public void StopToAcceptClients()
        {
            listener.Stop();
        }

        private void AcceptClients()
        {
            listener.Start();

            while (true)
            {
                try
                {
                    TcpClient client = listener.AcceptTcpClient();
                    ClientInterface clientInterface = new(client, userList);
                    clientInterface.StartToRead();
                }
                catch (Exception) { break; }
            }
        }
    }
}
