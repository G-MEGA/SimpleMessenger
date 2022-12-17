using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessengerServer.Classes
{
    internal class TextMessage : Message
    {
        string text;

        public TextMessage(User sender, string initialText): base(sender)
        {
            text = initialText;
        }

        public override string GetMessageTypeCode()
        {
            return "Text";
        }
        public override string GetTextToDisplayToUser()
        {
            return text;
        }
    }
}
