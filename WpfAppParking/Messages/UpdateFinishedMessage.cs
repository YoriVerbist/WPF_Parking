using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppParking.Messages
{
    class UpdateFinishedMessage
    {
        public enum MessageType { Updated, Deleted, Inserted };
        public UpdateFinishedMessage(MessageType Actie)
        {
            Type = Actie;
        }

        public MessageType Type { get; set; }
    }
}
