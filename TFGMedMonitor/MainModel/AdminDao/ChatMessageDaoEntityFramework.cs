using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Linq;

namespace Model.AdminDao
{
    public class ChatMessageDaoEntityFramework :
        GenericDaoEntityFramework<ChatMessage, Int64>, IChatMessageDao
    {
        public ChatMessageDaoEntityFramework()
        {
        }

        public List<ChatMessage> FindMessagesByUser(long userId, int startIndex, int count)
        {
            DbSet<ChatMessage> messages = Context.Set<ChatMessage>();

            var result =
                 (from a in messages
                  where (a.addressee == userId || a.sender == userId)
                  orderby a.title
                  select a).Skip(startIndex).Take(count).ToList();

            return result;
        }
    }
}
