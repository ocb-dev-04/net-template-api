using Core.Enums;

namespace Core.DTOs
{
    public class FlatUserDTO : BaseDTO
    {
        /// <summary>
        /// User name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User status, unverified by default
        /// </summary>
        public UserStatus Status { get; set; }

        /// <summary>
        /// User verification status
        /// </summary>
        public UserVerificationStatus VerificationStatus { get; set; }
    }
}
