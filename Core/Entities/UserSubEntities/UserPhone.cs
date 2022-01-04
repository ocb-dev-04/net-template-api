using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    /// <summary>
    /// Entity to save users phones
    /// </summary>
    public class UserPhone : BaseEntity
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
        public string PhoneNumber { get; set; }
    }
}
