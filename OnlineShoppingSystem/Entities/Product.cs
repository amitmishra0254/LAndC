using OnlineShoppingSystem.Enums;

public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public ProductCategory Category { get; set; }
    public int Stock { get; set; }
    public bool IsActive { get; set; }
}
