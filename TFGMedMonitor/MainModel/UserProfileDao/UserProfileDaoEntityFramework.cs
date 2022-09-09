using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;

namespace Model.UserProfileDao
{
    public class UserProfileDaoEntityFramework
        : GenericDaoEntityFramework<UserProfile, Int64>, IUserProfileDao
    {

        public UserProfileDaoEntityFramework()
        {
        }

        /// <summary>
        /// Finds a UserProfile by his loginName
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        /// <exception cref="InstanceNotFoundException"></exception>
        public UserProfile FindByLoginName(string loginName)
        {
            UserProfile userProfile = null;

            DbSet<UserProfile> userProfiles = Context.Set<UserProfile>();

            var result =
                (from u in userProfiles
                 where u.loginName == loginName
                 select u);

            userProfile = result.FirstOrDefault();

            if (userProfile == null)
                throw new InstanceNotFoundException(loginName,
                    typeof(UserProfile).FullName);

            return userProfile;
        }

        public List<UserProfile> FindByUserType(int userType, int startIndex, int count)
        {
            DbSet<UserProfile> userProfiles = Context.Set<UserProfile>();

            if (userType > 3 || userType < 1)
            {
                var result =
                (from u in userProfiles
                 orderby u.loginName
                 select u).Skip(startIndex).Take(count).ToList();

                return result;
            } else
            {
                var result =
                (from u in userProfiles
                 where u.userType == userType
                 orderby u.loginName
                 select u).Skip(startIndex).Take(count).ToList();

                return result;
            }
        }
    }
}