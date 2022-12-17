using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessengerServer.Classes
{
    internal class ClientInterface
    {
        ClientCommunicationProcessor processor;
        Thread threadToRead;

        UserList userList;
        TcpClient tcpClient;

        bool isDisconnecting;

        public ClientInterface(TcpClient c, UserList ul)
        {
            userList = ul;
            tcpClient = c;

            processor = new(ul, this);
            threadToRead = new Thread(Read);

            isDisconnecting = false;
        }
        public void StartToRead()
        {
            if (!isDisconnecting)
            {
                threadToRead.Start();
            }
        }
        public void Disconnect()
        {
            if (!isDisconnecting)
            {
                isDisconnecting = true;
                processor.OnClientInterfaceDisconnecting();

                threadToRead.Join();

                tcpClient.Close();
            }
        }


        private void Read()
        {
            byte[] headerBuffer = new byte[4];
            byte[] bytesBuffer = new byte[0];// new byte[0]은 의미없음 아래에서 오류 안띄우려고 쓴거임

            int leftBytes = headerBuffer.Length;
            bool isHeader = true;

            while (!isDisconnecting)
            {
                while (tcpClient.GetStream().DataAvailable)
                {
                    if (leftBytes > 0)
                    {
                        int readed;
                        // leftBytes만큼 데이터를 받는데,
                        // isHeader면 헤더버퍼에 받고
                        // 아니면 byteBuffer에 받는다
                        if (isHeader)
                        {
                            readed = tcpClient.GetStream().Read(headerBuffer, headerBuffer.Length - leftBytes, leftBytes);
                        }
                        else
                        {
                            readed = tcpClient.GetStream().Read(bytesBuffer, bytesBuffer.Length - leftBytes, leftBytes);
                        }
                        leftBytes -= readed;
                    }
                    else
                    {
                        throw new Exception("이 시점에서 leftBytes가 양수가 아닐 수 없는데 뭔가 이상하다");
                    }

                    // leftBytes가 0이 될 때마다 isHeader를 토글
                    // isHeader가 켜질때는 leftBytes를 헤더버퍼 사이즈로
                    // isHeader가 꺼질때는 leftBytes를 헤더데이터 사이즈로
                    if (leftBytes == 0)
                    {
                        isHeader = !isHeader;

                        //데이터 수신 완료, 헤더 수신 시작
                        if (isHeader)
                        {
                            OnDataReceived(bytesBuffer);
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
        private void OnDataReceived(byte[] bytes)
        {
            if (!isDisconnecting)
            {
                processor.ProcessClientRequest(bytes);
            }
        }


        public void Write(byte[] bytes)
        {
            if (!isDisconnecting)
            {
                byte[] data_with_header = AttachHeader(bytes);

                try
                {
                    tcpClient.GetStream().Write(data_with_header, 0, data_with_header.Length);
                }
                catch (Exception)
                {
                    Disconnect();
                }
            }
        }
        private byte[] AttachHeader(byte[] data)
        {
            byte[] header = BitConverter.GetBytes(data.Length);
            byte[] data_with_header = new byte[header.Length + data.Length];

            Array.Copy(header, 0, data_with_header, 0, header.Length);
            Array.Copy(data, 0, data_with_header, header.Length, data.Length);

            return data_with_header;
        }
    }
}
