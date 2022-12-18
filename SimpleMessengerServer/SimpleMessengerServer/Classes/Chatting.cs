using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace SimpleMessengerServer.Classes
{
    internal class Chatting
    {
        private static int totalCount = 0;

        string title;
        int id;
        bool isOneOnOne;
        Dictionary<string, User> users;
        List<Message> messages;

        public Chatting(string initialTitle, bool initialIsOneOnOne, params User[] initialUsers) { 
            title = initialTitle;
            isOneOnOne = initialIsOneOnOne;
            users = new Dictionary<string, User>();

            messages = new List<Message>();
            id = totalCount++;

            for (int i = 0; i < initialUsers.Length; i++)
            {
                Join(initialUsers[i]);
            }
        }

        public bool Join(User user)
        {
            if (users.ContainsKey(user.GetID()))
            {
                return false;
            }
            else
            {
                users[user.GetID()] = user;
                user.JoinChatting(this);

                foreach (User u in users.Values)
                {
                    u.OnOtherUserJoinChatting(GetID(), user);
                }
                return true;
            }
        }
        public bool Exit(User user)
        {
            if (users.ContainsKey(user.GetID()))
            {
                users.Remove(user.GetID());
                user.ExitChatting(this);

                foreach (User u in users.Values)
                {
                    u.OnOtherUserExitChatting(GetID());
                }

                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddMessage(Message message)
        {
            int messageIndex = messages.Count;

            messages.Add(message);

            foreach (User u in users.Values)
            {
                u.OnChattingAddMessage(GetID(), messageIndex);
            }
        }

        public int GetID()
        {
            return id;
        }
        public bool IsOneOnOne()
        {
            return isOneOnOne;
        }
        public string GetTitle()
        {
            return title;
        }
        public Message GetMessage(int index)
        {
            return messages[index];
        }
        public int GetMessagesCount()
        {
            return messages.Count;
        }
        public Dictionary<string, User> GetAllUsers()
        {
            return users;
        }
    }
}
