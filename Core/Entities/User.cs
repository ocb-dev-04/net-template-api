using System.ComponentModel.DataAnnotations;

using Core.Enums;

namespace Core.Entities
{
    /// <summary>
    /// <see cref="User"/> table in db
    /// </summary>
    public class User : BaseEntity // remember use the Identity to auth process
    {
        /// <summary>
        /// User name
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// User lastname
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// User status, Active by default
        /// </summary>
        public UserStatus UserStatus { get; set; } = UserStatus.Active;

        /// <summary>
        /// User verification status, unverified by default
        /// </summary>
        public UserVerificationStatus VerificationStatus { get; set; } = UserVerificationStatus.Unverified;
    }
}
