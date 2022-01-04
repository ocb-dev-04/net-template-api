using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class DeviceToken : BaseEntity
    {
        /// <summary>
        /// Foreign key to user
        /// </summary>
        [Required]
        public User User { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [Required]
        [MinLength(5)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [Required]
        [MinLength(5)]
        public string Token { get; set; }
    }
}
