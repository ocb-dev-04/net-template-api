using Core.Enums;

namespace Core.DTOs
{
    public class FullUserDTO : BaseDTO
    {
        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User lastname
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User status
        /// </summary>
        public UserStatus UserStatus { get; set; }

        /// <summary>
        /// User verification status
        /// </summary>
        public UserVerificationStatus VerificationStatus { get; set; }
    }
}
