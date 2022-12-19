using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessenger.Classes
{
    public class Message
    {
        int index;
        string userID;
        long time;
        string typeCode;
        string text;

        public Message(int initialIndex,  string initialUserID, long initialTime, string initialTypeCode, string initialText) { 
            index = initialIndex;
            userID = initialUserID;
            time = initialTime;
            typeCode = initialTypeCode;
            text = initialText;
        }

        public int GetIndex() { return index; }
        public string GetUserID() { return userID; }
        public long GetTime() { return time; }
        public string GetTypeCode() { return typeCode;}
        public string GetText() { return text;}
    }
}
