using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class CreateUserDTO
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

        // TODO: need make dtos to this props
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
    }
}
