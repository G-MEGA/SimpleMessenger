using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SimpleMessengerServer.Classes
{
    internal class ClientCommunicationProcessor
    {
        ClientInterface clientInterface;
        UserList userList;

        User? user;

        public ClientCommunicationProcessor(UserList ul, ClientInterface ci) {
            userList = ul;
            clientInterface = ci;
        }

        public bool IsLogin()
        {
            return user != null;
        }
        public void OnClientInterfaceDisconnecting()
        {
            if (IsLogin())
            {
                user?.RemoveClient(this);
                user = null;
            }
        }

        public void ProcessClientRequest(byte[] bytes)
        {
            string requestHeadStr = BytesToString(bytes, 0, 1024);
            string requestType = requestHeadStr.Split('/', StringSplitOptions.None)[0];

            string[] request;

            switch (requestType)
            {
                // register/(id)/(password)/(nickname)
                case "register":
                    request = BytesToRequestForm(bytes);
                    StringArrayWriteConsole(request);

                    Register(request[1], request[2], request[3]);
                    break;
                // login/(id)/(password)
                case "login":
                    request = BytesToRequestForm(bytes);
                    StringArrayWriteConsole(request);

                    Login(request[1], request[2]);
                    break;
                // logout/
                case "logout":
                    StringArrayWriteConsole(new string[] { "logout" });

                    Logout();
                    break;
                // modifyProfile/(nickname)/(selfIntroduction)
                case "modifyProfile":
                    request = BytesToRequestForm(bytes, 3);
                    StringArrayWriteConsole(request);

                    ModifyProfile(request[1], request[2]);
                    break;
                // addUserToContactList/(id)
                case "addUserToContactList":
                    request = BytesToRequestForm(bytes);
                    StringArrayWriteConsole(request);

                    AddUserToContactList(request[1]);
                    break;
                // removeUserInContactList/(id)
                case "removeUserInContactList":
                    request = BytesToRequestForm(bytes);
                    StringArrayWriteConsole(request);

                    RemoveUserInContactList(request[1]);
                    break;
                // startChatting/(1대1여부)/(참가자들 id목록 쉼표,로 구분)/(타이틀)
                case "startChatting":
                    request = BytesToRequestForm(bytes, 4);
                    StringArrayWriteConsole(request);

                    StartChatting(request[1], request[2], request[3]);
                    break;
                // inviteChatting/(userID)/(chattingID)
                case "inviteChatting":
                    request = BytesToRequestForm(bytes);
                    StringArrayWriteConsole(request);

                    InviteChatting(request[1], request[2]);
                    break;
                // makeTextMessage/(chattingID)/(text)
                case "makeTextMessage":
                    request = BytesToRequestForm(bytes, 3);
                    StringArrayWriteConsole(request);

                    MakeTextMessage(request[1], request[2]);
                    break;
                // makeFileMessage/(chattingID)/(fileName)/(fileData)
                case "makeFileMessage":
                    request = requestHeadStr.Split("/", 4, StringSplitOptions.None);
                    StringArrayWriteConsole(request, 3);

                    string requestStrWithoutFileData = request[0] + "/";
                    requestStrWithoutFileData += request[1] + "/";
                    requestStrWithoutFileData += request[2] + "/";

                    int byteLength = StringToBytes(requestStrWithoutFileData).Length;

                    MakeFileMessage(request[1], request[2], bytes[byteLength..]);
                    break;
                // exitFromChatting/(chattingID)
                case "exitFromChatting":
                    request = BytesToRequestForm(bytes);
                    StringArrayWriteConsole(request);

                    ExitFromChatting(request[1]);
                    break;
                // searchUser/(keyword)
                case "searchUser":
                    request = BytesToRequestForm(bytes);
                    StringArrayWriteConsole(request);

                    SearchUser(request[1]);
                    break;
                // fileMessageDownload/(chattingID)/(messageIndex)
                case "fileMessageDownload":
                    request = BytesToRequestForm(bytes);
                    StringArrayWriteConsole(request);

                    FileMessageDownload(request[1], request[2]);
                    break;
                default:
                    break;
            }
        }


        private void Register(string id, string password, string nickname)
        {
            if (!IsLogin())
            {
                if (userList.RegisterUser(id, password, nickname))
                {
                    user = userList.GetUser(id);
                    user?.AddClient(this);

                    StartClient();
                }
                else
                {
                    if (userList.HasID(id))
                    {
                        clientInterface.Write(StringToBytes("registerFail/idAlreadyExists/"));
                        Console.WriteLine("Output   " + "registerFail/idAlreadyExists/");
                    }
                }
            }
        }
        private void Login(string id, string password)
        {
            if (!IsLogin())
            {
                User? tryLogin = userList.GetUser(id, password);
                if (tryLogin != null)
                {
                    user = tryLogin;
                    user.AddClient(this);

                    StartClient();
                }
                else
                {
                    clientInterface.Write(StringToBytes("loginFail/"));
                    Console.WriteLine("Output   " + "loginFail/");
                }
            }
        }
        private void Logout()
        {
            if (IsLogin())
            {
                clientInterface.Disconnect();
            }
        }
        private void ModifyProfile(string nickname, string selfIntroduction)
        {
            if (IsLogin())
            { 
                user.ModifyProfile(nickname, selfIntroduction);
            }
        }
        private void AddUserToContactList(string id)
        {
            if (IsLogin())
            {
                user.AddToContactList(userList.GetUser(id));
            }
        }
        private void RemoveUserInContactList(string id)
        {
            if (IsLogin())
            {
                user.RemoveInContactList(userList.GetUser(id));
            }
        }
        private void StartChatting(string isOneOnOneStr, string userIDListStr, string title)
        {
            if (IsLogin())
            {
                string[] userIDList = userIDListStr.Split(',', StringSplitOptions.RemoveEmptyEntries);
                User[] users = new User[userIDList.Length];
                for (int i = 0; i < userIDList.Length; i++)
                {
                    users[i] = userList.GetUser(userIDList[i]);
                }

                Chatting chatting = new(title, isOneOnOneStr.Equals("true") ? true : false, users);
            }
        }
        private void InviteChatting(string userID, string chattingIDStr)
        {
            if (IsLogin())
            {
                User targetUser = userList.GetUser(userID);
                Chatting chatting = user.GetChattings()[Convert.ToInt32(chattingIDStr)];
                chatting.Join(targetUser);
            }
        }
        private void MakeTextMessage(string chattingIDStr, string text)
        {
            if (IsLogin())
            {
                TextMessage message = new(user, text);
                user.GetChattings()[Convert.ToInt32(chattingIDStr)].AddMessage(message);
            }
        }
        private void MakeFileMessage(string chattingIDStr, string fileName, byte[] fileData)
        {
            if (IsLogin())
            {
                FileMessage message = new(user, fileData, fileName);
                user.GetChattings()[Convert.ToInt32(chattingIDStr)].AddMessage(message);
            }
        }
        private void ExitFromChatting(string chattingIDStr)
        {
            if (IsLogin())
            {
                user.GetChattings()[Convert.ToInt32(chattingIDStr)].Exit(user);
            }
        }
        private void SearchUser(string keyword)
        {
            List<User> searchResult = userList.SearchUser(keyword);
            SendSearchResult(searchResult);
        }
        private void FileMessageDownload(string chattingIDStr, string messageIndexStr)
        {
            if (IsLogin())
            {
                int chattingID = Convert.ToInt32(chattingIDStr);
                int messageIndex = Convert.ToInt32(messageIndexStr);

                Message msg = user.GetChattings()[chattingID].GetMessage(messageIndex);
                if(msg is FileMessage)
                {
                    SendFileDownload((msg as FileMessage).GetFileName(), (msg as FileMessage).GetFileData());
                }
                else
                {
                    clientInterface.Write(StringToBytes("fileDownloadFail/"));
                    Console.WriteLine("Output   " + "fileDownloadFail/");
                }
            }
        }

        // userProfile/(id)/(nickname)/(selfIntroduction)
        public void SendUserProfile(string id)
        {
            User? targetUser= userList.GetUser(id);

            if (targetUser != null)
            {
                string str = "userProfile/" + id + "/" + targetUser.GetNickname() + "/" + targetUser.GetSelfIntroduction();
                clientInterface.Write(StringToBytes(str));
                Console.WriteLine("Output   " + str);
            }
        }
        // addToContactList/(id)
        public void SendAddToContactList(string id)
        {
            string str = "addToContactList/" + id;
            clientInterface.Write(StringToBytes(str));
            Console.WriteLine("Output   " + str);
        }
        // removeInContactList/(id)
        public void SendRemoveInContactList(string id)
        {
            string str = "removeInContactList/" + id;
            clientInterface.Write(StringToBytes(str));
            Console.WriteLine("Output   " + str);
        }
        // chatting/(id)/(1대1여부)/(참가자들 id목록 쉼표,로 구분)/(타이틀)
        public void SendChatting(int id)
        {
            Chatting chatting = user.GetChattings()[id];

            string str = "chatting/" + id.ToString() + "/";
            str += chatting.IsOneOnOne() ? "true" : "false" + "/";
            foreach(string userID in chatting.GetAllUsers().Keys)
            {
                str += userID + ",";
            }
            str += "/" + chatting.GetTitle();
            clientInterface.Write(StringToBytes(str));
            Console.WriteLine("Output   " + str);
        }
        // removeChatting/(id)
        public void SendRemoveChatting(int id)
        {
            string str = "removeChatting/" + id.ToString();
            clientInterface.Write(StringToBytes(str));
            Console.WriteLine("Output   " + str);
        }
        // chattingMessage/(채팅 id)/(메시지 index)/userID/(time int가 아니라 Long임)/(typeCode)/(text)
        public void SendChattingMessage(int id, int index)
        {
            Chatting chatting = user.GetChattings()[id];
            Message message = chatting.GetMessage(index);

            string str = "chattingMessage/" + id.ToString() + "/";
            str += index.ToString() + "/";
            str += message.GetUser().GetID() + "/";
            str += message.GetTime().ToString() + "/";
            str += message.GetMessageTypeCode() + "/";
            str += message.GetTextToDisplayToUser();
            clientInterface.Write(StringToBytes(str));
            Console.WriteLine("Output   " + str);
        }
        // searchResult/(id),(nickname)/.../(id),(nickname)
        private void SendSearchResult(List<User> searchResult)
        {
            string str = "searchResult";
            foreach (User u in searchResult)
            {
                str += "/" + u.GetID() + "," + u.GetNickname();
            }
            clientInterface.Write(StringToBytes(str));
            Console.WriteLine("Output   " + str);
        }
        // fileDownload/(fileName)/(fileData)
        private void SendFileDownload(string fileName, byte[] filedata)
        {
            string str = "fileDownload/" + fileName + "/";
            clientInterface.Write(StringToBytes(str).Concat(filedata).ToArray());
            Console.WriteLine("Output   " + str);
        }

        private void StartClient()
        {
            if (IsLogin())
            {
                // 본인/ 연락처/ 채팅으로 연결된 사람들 프로필
                foreach (string id in user.GetUsersWhoISee().Keys)
                {
                    SendUserProfile(id);
                }
                // 연락처 id목록
                foreach (string id in user.GetContactList().Keys)
                {
                    SendAddToContactList(id);
                }
                // 채팅
                foreach (int id in user.GetChattings().Keys)
                {
                    SendChatting(id);
                }
                // 각 채팅별 메시지들
                foreach (Chatting chatting in user.GetChattings().Values)
                {
                    int id = chatting.GetID();
                    int messagesCount = chatting.GetMessagesCount();
                    for (int i = 0; i < messagesCount; i++)
                    {
                        SendChattingMessage(id, i);
                    }
                }

                clientInterface.Write(StringToBytes("loginSuccess/"));
                Console.WriteLine("Output   " + "loginSuccess/");
            }
        }


        private byte[] StringToBytes(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
        private string BytesToString(byte[] bytes, int index = 0, int count = -1)
        {
            if (count < 0 || (bytes.Length - index) < count)
            {
                return Encoding.UTF8.GetString(bytes, index, bytes.Length - index);
            }
            else
            {
                return Encoding.UTF8.GetString(bytes, index, count);
            }
        }
        private string[] BytesToRequestForm(byte[] bytes)
        {
            return BytesToString(bytes).Split("/", StringSplitOptions.None);
        }
        private string[] BytesToRequestForm(byte[] bytes, int count)
        {
            return BytesToString(bytes).Split("/", count, StringSplitOptions.None);
        }

        private void StringArrayWriteConsole(string[] strArr, int count = -1)
        {
            if (count < 0)
            {
                foreach(string str in strArr)
                {
                    Console.Write(str + "/");
                }
                Console.WriteLine();
            }
            else
            {
                for(int i = 0; i < count; i++)
                {
                    Console.Write(strArr[i] + "/");
                }
                Console.WriteLine();
            }
        }
    }
}
