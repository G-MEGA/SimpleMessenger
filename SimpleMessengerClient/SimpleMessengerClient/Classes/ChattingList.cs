using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessenger.Classes
{
    internal class ChattingList
    {
        Dictionary<string, Chatting> chattings;

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
            // To do gui와 연결
        }
        public void RemoveChatting(string chatID)
        {
            if (chattings.ContainsKey(chatID))
            {
                chattings[chatID].OnRemovedAtChattingList();
                chattings.Remove(chatID);
            }
            // To do gui와 연결
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

        public void SetMessage(string chatID, int messageIndex, string userID, long time, string typeCode, string text)
        {
            if (chattings.ContainsKey(chatID))
            {
                chattings[chatID].SetMessage(messageIndex, userID, time, typeCode, text);
            }
            // To do gui와 연결
        }
    }
}
