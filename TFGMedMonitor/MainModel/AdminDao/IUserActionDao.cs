using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.AdminDao
{
    public interface IUserActionDao : IGenericDao<UserAction, Int64>
    {
        List<UserAction> GetUserActions(long user, int startIndex, int count);

        UserAction LogUserAction(UserProfile user, int action, string stV, long intV);

    }
}