using System;
using System.Collections.Generic;

namespace Model.AdminService
{
    public class UserBlock
    {
        public List<UserProfile> Users { get; private set; }

        public bool ExistsMoreUsers { get; private set; }

        public bool AreDoctors { get; private set; }

        public UserBlock(List<UserProfile> users, bool existsMoreUsers, bool areDoctors)
        {
            Users = users;
            ExistsMoreUsers = existsMoreUsers;
            AreDoctors = areDoctors;
        }

    }
}
