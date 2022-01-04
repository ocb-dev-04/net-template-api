using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    /// <summary>
    /// Base class to set Id, Create, Modified date and more
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Primary Key in data base
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Created date, is just set one time
        /// </summary>
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;

        /// <summary>
        /// Modified date, will set every time when entity is changed
        /// </summary>
        [Required]
        public DateTimeOffset ModifiedDate { get; set; }

        /// <summary>
        /// Prop to know if register is deleted or not
        /// </summary>
        public bool Deleted { get; set; } = false;
    }
}
