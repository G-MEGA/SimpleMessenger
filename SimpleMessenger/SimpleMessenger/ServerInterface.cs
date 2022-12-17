using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleMessenger
{
    delegate void DataReceivedDelegate(string data);

    internal class ServerInterface
    {
        private TcpClient client;
        private NetworkStream networkStream;
        private Thread dataReceiveThread;

        public bool IsConnected()
        {
            return IsConnected(client);
        }
        private bool IsConnected(TcpClient c)
        {
            return c != null && c.Connected;
        }

        public void Connect(string host, int port)
        {
            Console.WriteLine("Connect");

            client = new TcpClient();
            client.Connect(host, port);
            networkStream = client.GetStream();

            Console.WriteLine("Connect/Finish");

            dataReceiveThread = new Thread(Receive);
            dataReceiveThread.Start();
        }
        private void Receive()
        {
            TcpClient currentClient = client;

            byte[] headerBuffer = new byte[4];
            byte[] bytesBuffer = new byte[0];// new byte[0]은 의미없음 아래에서 오류 안띄우려고 쓴거임

            int leftBytes = headerBuffer.Length;
            bool isHeader = true;

            while (true)
            {
                if (!IsConnected(currentClient))
                    break;

                while (networkStream.DataAvailable)
                {
                    if (leftBytes > 0)
                    {
                        int readed;
                        // leftBytes만큼 데이터를 받는데,
                        // isHeader면 헤더버퍼에 받고
                        // 아니면 byteBuffer에 받는다
                        if (isHeader)
                        {
                            readed = networkStream.Read(headerBuffer, headerBuffer.Length - leftBytes, leftBytes);
                        }
                        else
                        {
                            readed = networkStream.Read(bytesBuffer, bytesBuffer.Length - leftBytes, leftBytes);
                        }
                        leftBytes -= readed;
                    }
                    else
                        throw new Exception("이 시점에서 leftBytes가 양수가 아닐 수 없는데 뭔가 이상하다");

                    // leftBytes가 0이 될 때마다 isHeader를 토글
                    // isHeader가 켜질때는 leftBytes를 헤더버퍼 사이즈로
                    // isHeader가 꺼질때는 leftBytes를 헤더데이터 사이즈로
                    if (leftBytes == 0)
                    {
                        isHeader = !isHeader;

                        //데이터 수신 완료, 헤더 수신 시작
                        if (isHeader)
                        {
                            OnDataReceived(Encoding.UTF8.GetString(bytesBuffer), bytesBuffer);
                            leftBytes = headerBuffer.Length;
                        }
                        //헤더 수신 완료, 데이터 수신 시작
                        else
                        {
                            leftBytes = BitConverter.ToInt32(headerBuffer, 0);
                            bytesBuffer = new byte[leftBytes];
                        }
                    }
                }

                Thread.Sleep(100);
            }
        }
        public void Send(string data)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(data);
            networkStream.Write(byteData, 0, byteData.Length);
        }

        private void OnDataReceived(string str, byte[] bytes)
        {
            Console.WriteLine(str);
        }
    }
}