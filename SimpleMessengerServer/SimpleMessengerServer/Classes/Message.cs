using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessengerServer.Classes
{
    internal abstract class Message
    {
        private long time;
        private User user;

        public Message(User sender)
        {
            time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            user = sender;
        }

        public long GetTime() { return time; }
        public User GetUser() { return user; }

        public abstract string GetTextToDisplayToUser();
        public abstract string GetMessageTypeCode();
    }
}
