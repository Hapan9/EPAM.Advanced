using Cart.Service.DAL.Entities;

namespace Cart.Service.BLL.Dtos
{
    public class ProductDto
    {
        public uint Id { get; set; }

        public required string Name { get; set; }

        public Image? Image { get; set; }

        public double Price { get; set; }

        public uint Quanity { get; set; }
    }
}
