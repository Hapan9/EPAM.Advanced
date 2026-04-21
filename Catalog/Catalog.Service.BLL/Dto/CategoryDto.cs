namespace Catalog.Service.BLL.Dto
{
    public class CategoryDto
    {
        public required string Name { get; set; }

        public Uri? PhotoUrl { get; set; }

        public Guid? ParentId { get; set; }
    }
}
