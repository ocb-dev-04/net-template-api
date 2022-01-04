using System.ComponentModel.DataAnnotations;

using Core.Enums;

namespace Core.Entities
{
    public class User : BaseEntity // remember use the Identity to auth process
    {
        /// <summary>
        /// User email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Phones numbers of user
        /// </summary>
        public virtual HashSet<UserPhone> PhoneNumbers { get; set; } = new HashSet<UserPhone>();

        /// <summary>
        /// Devices token of user
        /// </summary>
        public virtual HashSet<DeviceToken> DeviceTokens { get; set; } = new HashSet<DeviceToken>();

        /// <summary>
        /// Qualifications to user
        /// </summary>
        public virtual HashSet<UserScore> UserScores { get; set; } = new HashSet<UserScore>();

        /// <summary>
        /// User status, unverified by default
        /// </summary>
        public UserStatus Status { get; set; } = UserStatus.Unverified;
    }
}
