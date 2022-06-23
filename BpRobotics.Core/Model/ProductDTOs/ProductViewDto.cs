namespace BpRobotics.Core.Model.ProductDTOs
{
    public class ProductViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageFileName { get; set; }
        public int ServiceInterval { get; set; }
        public int Warranty { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}
