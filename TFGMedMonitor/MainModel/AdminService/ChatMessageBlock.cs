using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.AdminService
{
    public class ChatMessageBlock 
    {
        public List<ChatMessage> Messages { get; private set; }

        public bool ExistsMoreMessages { get; private set; }

        public ChatMessageBlock(List<ChatMessage> messages, bool existsMoreMessages)
        {
            Messages = messages;
            ExistsMoreMessages = existsMoreMessages;
        }
    }
}