using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessenger.Classes
{
    public class ChattingList
    {
        Dictionary<string, Chatting> chattings;

        public event Updated? ChattingsUpdated;

        public ChattingList() { 
            chattings= new Dictionary<string, Chatting>();
        }

        public void SetChatting(string chatID, bool isOneOnOne, string[] userIDList, string title)
        {
            if (chattings.ContainsKey(chatID))
            {
                chattings[chatID].Update(chatID, title, isOneOnOne, userIDList);
            }
            else
            {
                chattings[chatID] = new(chatID, title, isOneOnOne, userIDList);
            }
            ChattingsUpdated?.Invoke();
        }
        public void RemoveChatting(string chatID)
        {
            if (chattings.ContainsKey(chatID))
            {
                chattings[chatID].OnRemovedAtChattingList();
                chattings.Remove(chatID);
            }
            ChattingsUpdated?.Invoke();
        }
        public Chatting? GetChatting(string chatID)
        {
            if (chattings.ContainsKey(chatID))
            {
                return chattings[chatID];
            }
            else
            {
                return null;
            }
        }
        public Dictionary<string, Chatting> GetAllChattings()
        {
            return chattings;
        }

        public void SetMessage(string chatID, int messageIndex, string userID, long time, string typeCode, string text)
        {
            if (chattings.ContainsKey(chatID))
            {
                chattings[chatID].SetMessage(messageIndex, userID, time, typeCode, text);
            }
        }

        public bool IsThereOneOnOneWith(string userID)
        {
            foreach(var chat in GetAllChattings().Values)
            {
                if (chat.IsOneOnOne())
                {
                    foreach(string id in chat.GetUserIDs())
                    {
                        if (userID.Equals(id))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
