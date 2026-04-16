namespace OrderManagement.Application.DTOs.Product
{
    public class UpdateProductDTO
    {

        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }

    }
}
