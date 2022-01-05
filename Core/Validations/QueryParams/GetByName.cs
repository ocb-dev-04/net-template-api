using System.ComponentModel.DataAnnotations;

namespace Core.Validations.QueryParams
{
    public class GetByName : BasePagination
    {
        [Required]
        public string Name { get; set; }
    }
}
