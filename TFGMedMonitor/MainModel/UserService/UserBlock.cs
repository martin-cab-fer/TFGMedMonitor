using System;
using System.Collections.Generic;

namespace Model.UserService
{
    public class UserBlock
    {
        public List<UserProfile> Users { get; private set; }

        public bool ExistsMoreUsers { get; private set; }

        public int UserType { get; private set; }

        public UserBlock(List<UserProfile> users, bool existsMoreUsers, int userType)
        {
            Users = users;
            ExistsMoreUsers = existsMoreUsers;
            UserType = userType;
        }

    }
}
