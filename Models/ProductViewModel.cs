namespace Practical_11.Models
{
    public class ProductViewModel
    {
        public string? viewData { get; set; }
        public List<Product>? Products { get; set; }
        public Product? Product { get; set; }
        public string particalViewName { get; set; } = string.Empty;
    }
}
