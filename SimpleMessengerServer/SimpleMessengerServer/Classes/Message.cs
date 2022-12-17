using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessengerServer.Classes
{
    internal abstract class Message
    {
        protected int time;

        public int GetTime() { return time; }

        public abstract string GetTextToDisplayToUser();
        public abstract string GetMessageTypeCode();
    }
}
