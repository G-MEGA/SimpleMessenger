using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessengerServer.Classes
{
    internal class User
    {
        List<ClientCommunicationProcessor> clients;
        Dictionary<int, Chatting> chattings;
        Dictionary<string, User> contactList;
        Dictionary<string, User> followers;

        string id;
        string password;
        string nickname;
        string selfIntroduction;

        public User(string initialID, string initialPassword, string initialNickname) {
            clients = new List<ClientCommunicationProcessor>();
            chattings = new Dictionary<int, Chatting>();
            contactList = new Dictionary<string, User>();
            followers = new Dictionary<string, User>();

            id = initialID;
            password = initialPassword;
            nickname = initialNickname;
            selfIntroduction = "";
        }

        public bool IsID(string value)
        {
            return id.Equals(value);
        }
        public bool IsPassword(string value)
        {
            return password.Equals(value);
        }
        
        public string GetID()
        {
            return id;
        }
        public string GetNickname()
        {
            return nickname;
        }
        public string GetSelfIntroduction()
        {
            return selfIntroduction;
        }
        private Dictionary<string, User> GetUsersWhoViewMyProfile()
        {
            Dictionary<string, User> users = new Dictionary<string, User>();

            users[GetID()] = this;

            foreach (string key in followers.Keys)
            {
                if (!users.ContainsKey(key))
                {
                    users[key] = followers[key];
                }
            }

            foreach (Chatting chatting in chattings.Values)
            {
                Dictionary<string, User> members = chatting.GetAllUsers();
                foreach (string key in members.Keys)
                {
                    if (!users.ContainsKey(key))
                    {
                        users[key] = members[key];
                    }
                }
            }

            return users;
        }
        public Dictionary<string, User> GetUsersWhoISee()
        {
            Dictionary<string, User> users = new Dictionary<string, User>();

            users[GetID()] = this;

            foreach (string key in contactList.Keys)
            {
                if (!users.ContainsKey(key))
                {
                    users[key] = contactList[key];
                }
            }

            foreach (Chatting chatting in chattings.Values)
            {
                Dictionary<string, User> members = chatting.GetAllUsers();
                foreach (string key in members.Keys)
                {
                    if (!users.ContainsKey(key))
                    {
                        users[key] = members[key];
                    }
                }
            }

            return users;
        }
        public Dictionary<string, User> GetContactList()
        {
            return contactList;
        }
        public Dictionary<int, Chatting> GetChattings()
        {
            return chattings;
        }

        public void ModifyProfile(string newNickname, string newSelfIntroduction)
        {
            nickname = newNickname;
            selfIntroduction = newSelfIntroduction;
            // To Do 프로필 변경
            //      해당 유저
            //      해당 유저를 연락처에 넣은 유저 follower
            //      채팅으로 연결된 유저
            Dictionary<string, User> users = GetUsersWhoViewMyProfile();
            foreach (User user in users.Values)
            {
                user.OnUsersWhoISeeProfileUpdated(id);
            }
        }
        public bool AddToContactList(User user)
        {
            if (contactList.ContainsKey(user.GetID()))
            {
                return false;
            }
            else
            {
                contactList[user.GetID()] = user;
                user.AddedToContactListOf(this);
                foreach (ClientCommunicationProcessor client in clients)
                {
                    client.SendAddToContactList(user.GetID());
                }
                return true;
            }
        }
        public bool AddedToContactListOf(User user)
        {
            if (followers.ContainsKey(user.GetID()))
            {
                return false;
            }
            else
            {
                followers[user.GetID()] = user;
                return true;
            }
        }
        public bool RemoveInContactList(User user)
        {
            if (contactList.ContainsKey(user.GetID()))
            {
                contactList.Remove(user.GetID());
                user.RemovedInContactListOf(this);
                foreach (ClientCommunicationProcessor client in clients)
                {
                    client.SendRemoveInContactList(user.GetID());
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemovedInContactListOf(User user)
        {
            if (followers.ContainsKey(user.GetID()))
            {
                followers.Remove(user.GetID());
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool JoinChatting(Chatting chatting)
        {
            if (chattings.ContainsKey(chatting.GetID()))
            {
                return false;
            }
            else
            {
                chattings[chatting.GetID()] = chatting;
                foreach (ClientCommunicationProcessor client in clients)
                {
                    foreach(User user in chatting.GetAllUsers().Values)
                    {
                        client.SendUserProfile(user.GetID());
                    }

                    client.SendChatting(chatting.GetID());
                    
                    int messagesCount = chatting.GetMessagesCount();
                    for(int i=0; i<messagesCount; i++)
                    {
                        client.SendChattingMessage(chatting.GetID(), i);
                    }
                }
                return true;
            }
        }
        public bool ExitChatting(Chatting chatting)
        {
            if (chattings.ContainsKey(chatting.GetID()))
            {
                chattings.Remove(chatting.GetID());
                // To Do 채팅 목록 변경
                return true;
            }
            else
            {
                return false;
            }
        }

        public int AddClient(ClientCommunicationProcessor client)
        {
            if (clients.Contains(client))
            {
                return -1;
            }
            else
            {
                clients.Add(client);
                return clients.Count - 1;
            }
        }
        public bool RemoveClient(ClientCommunicationProcessor client)
        {
            return clients.Remove(client);
        }

        public void OnUsersWhoISeeProfileUpdated(string idOfUsersWhoISee)
        {
            foreach (ClientCommunicationProcessor client in clients)
            {
                client.SendUserProfile(idOfUsersWhoISee);
            }
        }
        public void OnOtherUserJoinChatting(int chattingID, User newUser)
        {
            foreach (ClientCommunicationProcessor client in clients)
            {
                client.SendUserProfile(newUser.GetID());
                client.SendChatting(chattingID);
            }
        }
        public void OnChattingAddMessage(int chattingID, int messageIndex)
        {
            foreach (ClientCommunicationProcessor client in clients)
            {
                client.SendChattingMessage(chattingID, messageIndex);
            }
        }
    }
}
