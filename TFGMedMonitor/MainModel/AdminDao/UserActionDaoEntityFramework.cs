using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Model.AdminDao
{
    public class UserActionDaoEntityFramework : GenericDaoEntityFramework<UserAction, Int64>, IUserActionDao
    {
        public UserActionDaoEntityFramework()
        {
        }

        public List<UserAction> GetUserActions(long user, int startIndex, int count)
        {
            DbSet<UserAction> userActions = Context.Set<UserAction>();

            if (user >= 0)
            {
                var result =
                (from u in userActions
                 where u.actor == user
                 orderby u.actionTime ascending
                 select u).Skip(startIndex).Take(count).ToList();

                return result;
            }
            else
            {
                var result =
                (from u in userActions
                 orderby u.actionTime ascending
                 select u).Skip(startIndex).Take(count).ToList();

                return result;
            }
        }

        public UserAction LogUserAction(UserProfile user, int action, string strV, long intV)
        {
            string fText;

            switch (action)
            {
                /*Prescription creation */
                case 1:
                    fText = "Prescription creation by " + user.loginName + " for patient " + strV;
                    break;

                /*Prescription removal */
                case 2:
                    fText = "Prescription removal by " + user.loginName + " from patient " + strV;
                    break;

                /*Dose creation */
                case 3:
                    fText = "Dose creation by " + user.loginName + " for prescription of patient " + strV;
                    break;

                /*Analytic creation */
                case 4:
                    fText = "Analytic creation by " + user.loginName + " about patient " + strV;
                    break;

                /*Message creation */
                case 5:
                    fText = "Message sent by " + user.loginName + " to " + strV;
                    break;

                /*Patient creation */
                case 6:
                    fText = "Patient creation by " + user.loginName + " with name " + strV;
                    break;

                /*Medicine creation */
                case 7:
                    fText = "Medicine creation by " + user.loginName + " with name " + strV;
                    break;

                default:
                    return null;
            }

            UserAction uS = new UserAction
            {
                actionTime = DateTime.Now,
                UserProfile = user,
                stringVal = strV,
                intVal = intV,
                actionText = fText
            };

            Create(uS);
            return uS;
        }
    }
}