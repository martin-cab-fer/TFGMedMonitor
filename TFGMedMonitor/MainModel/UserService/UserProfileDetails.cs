using System;

namespace Model.UserService
{
    /// <summary>
    /// VO Class which contains the user details
    /// </summary>
    [Serializable()]
    public class UserProfileDetails
    {
        private string v;
        private string text1;
        private string text2;
        private string text3;
        private string selectedValue1;
        private string selectedValue2;
        #region Properties Region

        public String LoginName { get; private set; }

        public String FirstName { get; private set; }

        public String Lastname { get; private set; }

        public String Email { get; private set; }

        public string Language { get; private set; }

        public string Country { get; private set; }

        public int UserType { get; private set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfileDetails"/>
        /// class.
        /// </summary>
        /// <param name="firstName">The user's first name.</param>
        /// <param name="lastName">The user's last name.</param>
        /// <param name="email">The user's email.</param>
        /// <param name="language">The language.</param>
        /// <param name="country">The country.</param>
        public UserProfileDetails(String loginName, String firstName, String lastName,
            String email, String language, String country, int userType)
        {
            this.LoginName = loginName;
            this.FirstName = firstName;
            this.Lastname = lastName;
            this.Email = email;
            this.Language = language;
            this.Country = country;
            this.UserType = userType;
        }

        public UserProfileDetails(string v, string text1, string text2, string text3, string selectedValue1, string selectedValue2)
        {
            this.v = v;
            this.text1 = text1;
            this.text2 = text2;
            this.text3 = text3;
            this.selectedValue1 = selectedValue1;
            this.selectedValue2 = selectedValue2;
        }

        public override bool Equals(object obj)
        {

            UserProfileDetails target = (UserProfileDetails)obj;

            return (this.LoginName == target.LoginName)
                  && (this.FirstName == target.FirstName)
                  && (this.Lastname == target.Lastname)
                  && (this.Email == target.Email)
                  && (this.Language == target.Language)
                  && (this.Country == target.Country)
                  && (this.UserType == target.UserType);
        }

        // The GetHashCode method is used in hashing algorithms and data 
        // structures such as a hash table. In order to ensure that it works 
        // properly, we suppose that the FirstName does not change.        
        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the 
        /// current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current 
        /// <see cref="T:System.Object"></see>.
        /// </returns>
        public override String ToString()
        {
            String strUserProfileDetails;

            strUserProfileDetails =
                "[ firstName = " + FirstName + " | " +
                "lastName = " + Lastname + " | " +
                "email = " + Email + " | " +
                "language = " + Language + " | " +
                "country = " + Country + " | " +
                "userType = " + UserType + " ]";


            return strUserProfileDetails;
        }
    }
}
