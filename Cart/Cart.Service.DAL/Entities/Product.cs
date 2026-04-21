namespace Cart.Service.DAL.Entities
{
    public class Product
    {
        public uint Id { get; set; }

        public required string Name { get; set; }

        public Image? Image { get; set; }

        public double Price { get; set; }

        public uint Quanity { get; set; }
    }
}
