namespace OrderManagement.Application.DTOs.Pagination
{
    public class PaginatedResult<T>(IEnumerable<T> items, int totalItems, int pageSize)
    {
        public int TotalPages { get; set; } = (int)Math.Ceiling(totalItems / (double)pageSize);
        public int TotalItems { get; set; } = totalItems;
        public IEnumerable<T> Items { get; set; } = items;
    }
}
