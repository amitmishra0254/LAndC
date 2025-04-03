using Microsoft.Extensions.Logging;

namespace OnlineShoppingSystem.Managers
{
    public class ProductManagerImp : ProductManager
    {
        private readonly ProductRepository productRepository;
        private readonly ILogger<ProductManagerImp> logger;
        public ProductManagerImp(ProductRepository productRepository, ILogger<ProductManagerImp> logger)
        {
            this.productRepository = productRepository;
            this.logger = logger;
        }
        public bool IsProductIsInStock(List<OrderItem> items)
        {
            foreach (var item in items)
            {
                var product = this.productRepository.GetProduct(item.ProductId);
                if (product.Stock < item.Quantity)
                {
                    logger.LogInformation($"Insufficient stock for product {item.ProductId}");
                    return false;
                }
            }
            return true;
        }
    }
}
