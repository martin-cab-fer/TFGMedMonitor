using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HealthDao
{
    public interface IChatMessageDao : IGenericDao<ChatMessage,Int64>
    {
        List<ChatMessage> FindMessagesByUser(long userId, int startIndex, int count);
    }
}
