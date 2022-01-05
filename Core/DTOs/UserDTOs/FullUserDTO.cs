using Core.Enums;

namespace Core.DTOs
{
    public class FullUserDTO : BaseDTO
    {
        /// <summary>
        /// User name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }

        // TODO: need to create dtos to this
        ///// <summary>
        ///// Phones numbers of user
        ///// </summary>
        //public virtual HashSet<UserPhone> PhoneNumbers { get; set; } = new HashSet<UserPhone>();

        ///// <summary>
        ///// Devices token of user
        ///// </summary>
        //public virtual HashSet<DeviceToken> DeviceTokens { get; set; } = new HashSet<DeviceToken>();

        ///// <summary>
        ///// Qualifications to user
        ///// </summary>
        //public virtual HashSet<UserScore> UserScores { get; set; } = new HashSet<UserScore>();

        /// <summary>
        /// User status
        /// </summary>
        public UserStatus Status { get; set; }

        /// <summary>
        /// User verification status
        /// </summary>
        public UserVerificationStatus VerificationStatus { get; set; }
    }
}
