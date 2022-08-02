using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace Model.UserProfileDao
{
    public class UserProfileDaoEntityFramework {  /*
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

        public bool IsFollowing(string userFollowerName, string userFollowedName)
        {
            UserProfile userFollower =
                FindByLoginName(userFollowerName);

            UserProfile userFollowed =
                FindByLoginName(userFollowedName);

            if (userFollower.Followed.Contains(userFollowed))
                return true;
            else 
                return false;
        }

        public void AddFollow(long userFollowerId, string userFollowedName)
        {
            UserProfile userFollower =
                Find(userFollowerId);

            UserProfile userFollowed =
                FindByLoginName(userFollowedName);

            if (userFollower.Followed.Contains(userFollowed))
                throw new UserService.Exceptions.AlreadyFollowingException(userFollower.loginName, userFollowed.loginName);

            userFollower.Followed.Add(userFollowed);

            Update(userFollower);
        }

        public void Unfollow(long userFollowerId, string userFollowedName)
        {
            UserProfile userFollower =
                Find(userFollowerId);

            UserProfile userFollowed =
                FindByLoginName(userFollowedName);

            if (!userFollower.Followed.Remove(userFollowed))
                throw new UserService.Exceptions.UnfollowNotFollowingException(userFollower.loginName, userFollowed.loginName);

            Update(userFollower);
        }

        public List<UserProfile> SearchFollowers(string userName, int startIndex, int count)
        {
            UserProfile userFollowed =
                FindByLoginName(userName);

            return userFollowed.Followers.Skip(startIndex).Take(count).ToList();
        }
        public List<UserProfile> SearchFollowed(string userName, int startIndex, int count)
        {
            UserProfile userFollower =
                FindByLoginName(userName);

            return userFollower.Followed.Skip(startIndex).Take(count).ToList();
        }
        */
    }
}