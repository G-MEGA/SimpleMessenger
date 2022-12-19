using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Devices;
using SimpleMessengerClient.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SimpleMessenger.Classes
{
    public class ServerCommunicationProcessor
    {
        UserList userList;
        ChattingList chattingList;
        ServerInterface serverInterface;

        string myID;
        string myPassword;
        bool isTryingLogin;
        bool isSuccessedLogin;

        LoginForm? loginForm;
        RegisterForm? registerForm;
        MainForm? mainForm;

        public event SearchedUsers? SearchedUsers;

        public ServerCommunicationProcessor(UserList ul, ChattingList cl, ServerInterface si) 
        {
            userList = ul;
            chattingList = cl;
            serverInterface = si;

            myID = "";
            myPassword = "";
            isTryingLogin = false;
            isSuccessedLogin = false;
        }

        public bool IsSuccessedLogin()
        {
            return isSuccessedLogin;
        }
        public void SetLoginForm(LoginForm? form)
        {
            loginForm = form;
        }
        public void SetRegisterForm(RegisterForm? form)
        {
            registerForm = form;
        }
        public void SetMainForm(MainForm? form)
        {
            mainForm = form;
        }

        public void OnServerInterfaceDisconnecting()
        {
            SendLogout();
        }
        public void ProcessDataFromServer(byte[] bytes)
        {
            string requestHeadStr = BytesToString(bytes, 0, 1024);
            string requestType = requestHeadStr.Split('/', StringSplitOptions.None)[0];

            string[] request;

            switch (requestType)
            {
                // registerFail/idAlreadyExists/
                case "registerFail":
                    request = BytesToRequestForm(bytes);

                    RegisterFail(request[1]);
                    break;
                // loginFail/
                case "loginFail":
                    //request = BytesToRequestForm(bytes);

                    LoginFail();
                    break;
                // loginSuccess/
                case "loginSuccess":
                    //request = BytesToRequestForm(bytes);

                    LoginSuccess();
                    break;
                // userProfile/(id)/(nickname)/(selfIntroduction)
                case "userProfile":
                    request = BytesToRequestForm(bytes, 4);

                    UserProfile(request[1], request[2], request[3]);
                    break;
                // addToContactList/(id)
                case "addToContactList":
                    request = BytesToRequestForm(bytes);

                    AddToContactList(request[1]);
                    break;
                // removeInContactList/(id)
                case "removeInContactList":
                    request = BytesToRequestForm(bytes);

                    RemoveInContactList(request[1]);
                    break;
                // chatting/(id)/(1대1여부)/(참가자들 id목록 쉼표,로 구분)/(타이틀)
                case "chatting":
                    request = BytesToRequestForm(bytes, 5);

                    Chatting(request[1], request[2], request[3], request[4]);
                    break;
                // removeChatting/(id)
                case "removeChatting":
                    request = BytesToRequestForm(bytes);

                    RemoveChatting(request[1]);
                    break;
                // chattingMessage/(채팅 id)/(메시지 index)/userID/(time int가 아니라 Long임)/(typeCode)/(text)
                case "chattingMessage":
                    request = BytesToRequestForm(bytes, 7);

                    chattingMessage(request[1], request[2], request[3], request[4], request[5], request[6]);
                    break;
                // searchResult/(id),(nickname)/.../(id),(nickname)
                case "searchResult":
                    request = BytesToRequestForm(bytes, 2);

                    if(request.Length > 1)
                    {
                        SearchResult(request[1]);
                    }
                    else
                    {
                        SearchResult("");
                    }
                    break;
                // fileDownload/(fileName)/(fileData)
                case "fileDownload":
                    request = requestHeadStr.Split("/", 3, StringSplitOptions.None);

                    string requestStrWithoutFileData = request[0] + "/";
                    requestStrWithoutFileData += request[1] + "/";

                    int byteLength = StringToBytes(requestStrWithoutFileData).Length;

                    FileDownload(request[1], bytes[byteLength..]);
                    break;
                // fileDownloadFail/
                case "fileDownloadFail":
                    //request = BytesToRequestForm(bytes, 2);

                    FileDownloadFail();
                    break;
            }
        }
        

        private void RegisterFail(string reason)
        {
            isTryingLogin = false;
            isSuccessedLogin = false;

            registerForm?.Invoke(registerForm.OnRegisterFail, reason);
        }
        private void LoginFail()
        {
            isTryingLogin = false;
            isSuccessedLogin = false;

            loginForm?.Invoke(loginForm.OnLoginFail);
        }
        private void LoginSuccess()
        {
            isTryingLogin = false;
            isSuccessedLogin = true;
            userList.SetMyID(myID);

            registerForm?.Invoke(registerForm.Close);
            loginForm?.Invoke(loginForm.Close);
        }
        private void UserProfile(string id, string nickname, string selfIntroduction)
        {
            userList.SetUserProfile(id, nickname, selfIntroduction);
        }
        private void AddToContactList(string id)
        {
            userList.AddToContactList(id);
        }
        private void RemoveInContactList(string id)
        {
            userList.RemoveInContactList(id);
        }
        private void Chatting(string chatID, string isOneOnOneStr, string userIDListStr, string title)
        {
            string[] userIDList = userIDListStr.Split(',', StringSplitOptions.RemoveEmptyEntries);
            chattingList.SetChatting(chatID, isOneOnOneStr.Equals("true") ? true : false, userIDList, title);
        }
        private void RemoveChatting(string chatID)
        {
            chattingList.RemoveChatting(chatID);
        }
        private void chattingMessage(string chatID, string messageIndexStr, string userID, string timeStr, string typeCode, string text)
        {
            long time = Convert.ToInt64(timeStr);
            chattingList.SetMessage(chatID, Convert.ToInt32(messageIndexStr), userID, time, typeCode, text);
        }
        private void SearchResult(string idNicknamePairStr)
        {
            string[] idNicknamePairs = idNicknamePairStr.Split('/', StringSplitOptions.RemoveEmptyEntries);
            
            Dictionary<string, string> idNickname = new Dictionary<string, string>();
            foreach(string str in idNicknamePairs)
            {
                string[] splited = str.Split(',', StringSplitOptions.None);
                idNickname[splited[0]] = splited[1];
            }
            SearchedUsers?.Invoke(idNickname);
        }
        private void FileDownload(string fileName, byte[] fileData)
        {
            mainForm?.Invoke(() =>
            {
                SaveFileDialog save = new();
                save.FileName = fileName;
                save.Title = "저장 경로 지정";
                save.OverwritePrompt = true;
                save.DefaultExt = fileName.Split('.', StringSplitOptions.TrimEntries).Last();

                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(save.FileName, fileData);

                    //FileStream fileStream = (FileStream)save.OpenFile();

                    //fileStream.Write(fileData, 0, fileData.Length);

                    //fileStream.Close();
                }
            });
        }
        private void FileDownloadFail()
        {
            mainForm?.OnFileDownloadFail();
        }

        // register/(id)/(password)/(nickname)
        public void SendRegister(string id, string password, string nickname)
        {
            if (!isTryingLogin && !isSuccessedLogin)
            {
                isTryingLogin = true;
                isSuccessedLogin = false;

                myID = id;
                myPassword = password;

                string str = "register/" + id + "/" + password + "/" + nickname;
                serverInterface.Write(StringToBytes(str));
            }
        }
        // login/(id)/(password)
        public void SendLogin(string id, string password)
        {
            if (!isTryingLogin && !isSuccessedLogin)
            {
                isTryingLogin = true;
                isSuccessedLogin = false;

                myID = id;
                myPassword = password;

                string str = "login/" + id + "/" + password;
                serverInterface.Write(StringToBytes(str));
            }
        }
        // logout/
        private void SendLogout()
        {
            if (isSuccessedLogin)
            {
                isSuccessedLogin = false;

                string str = "logout/";
                serverInterface.Write(StringToBytes(str));
            }
        }
        // modifyProfile/(nickname)/(selfIntroduction)
        public void SendModifyProfile(string nickname, string selfIntroduction)
        {
            if (isSuccessedLogin)
            {
                string str = "modifyProfile/" + nickname + "/" + selfIntroduction;
                serverInterface.Write(StringToBytes(str));
            }
        }
        // addUserToContactList/(id)
        public void SendAddUserToContactList(string id)
        {
            if (isSuccessedLogin)
            {
                string str = "addUserToContactList/" + id;
                serverInterface.Write(StringToBytes(str));
            }
        }
        // removeUserInContactList/(id)
        public void SendRemoveUserInContactList(string id)
        {
            if (isSuccessedLogin)
            {
                string str = "removeUserInContactList/" + id;
                serverInterface.Write(StringToBytes(str));
            }
        }
        // startChatting/(1대1여부)/(참가자들 id목록 쉼표,로 구분)/(타이틀)
        public void SendStartChatting(bool isOneOnOne, List<User> users, string title)
        {
            if (isSuccessedLogin)
            {
                string str = "startChatting/" + (isOneOnOne ? "true":"false") + "/";
                foreach(User u in users)
                {
                    str += u.GetID() + ",";
                }
                str += "/" + title;
                serverInterface.Write(StringToBytes(str));
            }
        }
        // inviteChatting/(userID)/(chattingID)
        public void SendInviteChatting(string userID, string chattingID)
        {
            if (isSuccessedLogin)
            {
                string str = "inviteChatting/" + userID + "/" + chattingID;
                serverInterface.Write(StringToBytes(str));
            }
        }
        // makeTextMessage/(chattingID)/(text)
        public void SendMakeTextMessage(string chattingID, string text)
        {
            if (isSuccessedLogin)
            {
                string str = "makeTextMessage/" + chattingID + "/" + text;
                serverInterface.Write(StringToBytes(str));
            }
        }
        // makeFileMessage/(chattingID)/(fileName)/(fileData)
        public void SendMakeFileMessage(string chattingID, string fileName, byte[] fileData)
        {
            if (isSuccessedLogin)
            {
                string str = "makeFileMessage/" + chattingID + "/" + fileName + "/";
                serverInterface.Write(StringToBytes(str).Concat(fileData).ToArray());
            }
        }
        // exitFromChatting/(chattingID)
        public void SendExitFromChatting(string chattingID)
        {
            if (isSuccessedLogin)
            {
                string str = "exitFromChatting/" + chattingID;
                serverInterface.Write(StringToBytes(str));
            }
        }
        // searchUser/(keyword)
        public void SendSearchUser(string keyword)
        {
            if (isSuccessedLogin)
            {
                string str = "searchUser/" + keyword;
                serverInterface.Write(StringToBytes(str));
            }
        }
        // fileMessageDownload/(chattingID)/(messageIndex)
        public void SendFileMessageDownload(string chattingID, int messageIndex)
        {
            if (isSuccessedLogin)
            {
                string str = "fileMessageDownload/" + chattingID + "/" + messageIndex.ToString();
                serverInterface.Write(StringToBytes(str));
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
    }

    public delegate void SearchedUsers(Dictionary<string, string> id_nickname);
}
