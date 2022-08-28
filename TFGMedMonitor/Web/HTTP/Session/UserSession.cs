using System;

namespace Web.HTTP.Session
{
    public class UserSession
    {
        private long userProfileId;
        private String firstName;
        private String loginName;
        private int userType;

        public long UserProfileId
        {
            get { return userProfileId; }
            set { userProfileId = value; }
        }

        public String LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }

        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public int UserType
        {
            get { return userType; }
            set { userType = value; }
        }
    }
}