using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class UpdateUserDTO : BaseDTO
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
    }
}
