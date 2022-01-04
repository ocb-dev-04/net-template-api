namespace Core.Validations.QueryParams
{
    /// <summary>
    /// Basic class to paginations query params
    /// </summary>
    public class BasePagination
    {
        /// <summary>
        /// Page number to query =>  1 is by default
        /// </summary>
        public int PageNumber { get; set; } = 1;
    }
}
