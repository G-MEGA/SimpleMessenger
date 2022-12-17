using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SimpleMessengerServer.Classes
{
    internal class FileMessage : Message
    {
        byte[] fileData;
        string fileName;

        public FileMessage(User sender, byte[] initialFileData, string initialFileName):base(sender)
        {
            fileData = initialFileData;
            fileName = initialFileName;
        }

        public byte[] GetFileData()
        {
            return fileData;
        }

        public override string GetMessageTypeCode()
        {
            return "File";
        }
        public override string GetTextToDisplayToUser()
        {
            return fileName;
        }
    }
}
