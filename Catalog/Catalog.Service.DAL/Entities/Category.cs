using Catalog.Service.DAL.Entities;

namespace Catalog.Service.DAL.Enteties
{
    public sealed class Category
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public Uri? PhotoUrl { get; set; }

        public Guid? ParentId { get; set; }
        public Category? Parent { get; set; }

        public ICollection<Category>? Childrens { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
