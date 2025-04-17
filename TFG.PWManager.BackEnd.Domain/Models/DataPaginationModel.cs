namespace TFG.PWManager.BackEnd.Domain.Models
{
    public class DataPaginationModel<T> 
    {
        public IEnumerable<T>? Data { get; set; }

        public int? PageNumber { get; set; } = 0;

        public int? PageSize { get; set; } = 0;

        public int? TotalSize { get; set; } = 0;
    }
}
