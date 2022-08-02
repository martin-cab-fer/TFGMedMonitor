using System;
using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System.Collections.Generic;

namespace Model.UserProfileDao
{
    public interface IUserProfileDao {/*: IGenericDao<UserProfile, Int64>
    {
        
        /// <summary>
        /// Finds a UserProfile by loginName
        /// </summary>
        /// <param name="loginName">loginName</param>
        /// <returns>The UserProfile</returns>
        /// <exception cref="InstanceNotFoundException"/>
        UserProfile FindByLoginName(String loginName);

        bool IsFollowing(string userFollowerName, string userFollowedName);

        void AddFollow(long userFollowerId, string userFollowedName);

        void Unfollow(long userFollowerId, string userFollowedName);

        List<UserProfile> SearchFollowers(string userName, int startIndex, int count);

        List<UserProfile> SearchFollowed(string userName, int startIndex, int count);
        */
    }
}
