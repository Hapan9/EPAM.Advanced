namespace Catalog.Service.BLL.Dto
{
    public class ProductDto
    {
        public required string Name { get; set; }

        public string? Description { get; set; }

        public Uri? PhotoUrl { get; set; }

        public double Price { get; set; }

        public uint Amount { get; set; }


        public Guid CategoryId { get; set; }
    }
}
