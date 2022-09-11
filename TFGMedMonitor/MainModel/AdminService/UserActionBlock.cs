using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.AdminService
{
    public class UserActionBlock
    {
        public List<UserAction> Actions { get; private set; }

        public bool ExistsMoreActions { get; private set; }

        public UserActionBlock(List<UserAction> actions, bool existsMoreActions)
        {
            Actions = actions;
            ExistsMoreActions = existsMoreActions;
        }
    }
}