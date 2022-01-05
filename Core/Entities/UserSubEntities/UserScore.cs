using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class UserScore : BaseEntity
    {
        /// <summary>
        /// Evaluated user foreign key
        /// </summary>
        [Required]
        public Guid User { get; set; }

        /// <summary>
        /// Qualifier user foreign key
        /// </summary>
        [Required]
        public User Qualifier { get; set; }

        /// <summary>
        /// Score
        /// </summary>
        [Range(1, 5)]
        public int Score { get; set; }

        public string Comment { get; set; } = string.Empty;
    }
}
