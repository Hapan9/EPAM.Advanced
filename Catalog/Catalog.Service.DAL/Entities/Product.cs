using Catalog.Service.DAL.Enteties;

namespace Catalog.Service.DAL.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public Uri? PhotoUrl { get; set; }

        public double Price { get; set; }

        public uint Amount { get; set; }


        public Guid CategoryId { get; set; }
        public required Category Category { get; set; }
    }
}
