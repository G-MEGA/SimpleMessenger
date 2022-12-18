using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessenger.Classes
{
    internal class Message
    {
        string userID;
        long time;
        string typeCode;
        string text;

        public Message(string initialUserID, long initialTime, string initialTypeCode, string initialText) { 
            userID = initialUserID;
            time = initialTime;
            typeCode = initialTypeCode;
            text = initialText;
        }

        public string GetUserID() { return userID; }
        public long GetTime() { return time; }
        public string GetTypeCode() { return typeCode;}
        public string GetText() { return text;}
    }
}
