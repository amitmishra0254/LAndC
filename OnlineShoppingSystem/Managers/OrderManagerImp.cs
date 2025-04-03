using OnlineShoppingSystem.DTOs;
using OnlineShoppingSystem.Exceptions;
using OnlineShoppingSystem.Managers;
using Microsoft.Extensions.Logging;

public class OrderManagerImp : OrderManager
{
    private readonly OrderRepository orderRepository;
    private readonly ProductRepository productRepository;
    private readonly CustomerRepository customerRepository;
    private readonly NotificationSender notificationSender;
    private readonly EmailSender emailSender;
    private readonly ILogger<OrderManagerImp> logger;
    private readonly ProductManager productManager;

    public OrderManagerImp(OrderRepository orderRepository,
                        ProductRepository productRepository,
                        CustomerRepository customerRepository,
                        NotificationSender notificationSender,
                        EmailSender emailSender,
                        ILogger<OrderManagerImp> logger,
                        ProductManager productManager)
    {
        this.orderRepository = orderRepository;
        this.productRepository = productRepository;
        this.customerRepository = customerRepository;
        this.notificationSender = notificationSender;
        this.emailSender = emailSender;
        this.logger = logger;
        this.productManager = productManager;
    }

    public async Task<int> PlaceOrder(OrderRequestDTO orderRequestDTO)
    {
        this.logger.LogInformation($"Placing order");
        if (this.productManager.IsProductIsInStock(orderRequestDTO.items))
        {
            var order = new Order()
            {
                CustomerId = orderRequestDTO.customerId.ToString(),
                Items = orderRequestDTO.items,
                Status = OrderStatus.Pending,
                CreatedAt = DateTime.UtcNow,
                TotalAmount = orderRequestDTO.items.Sum(x => x.Price)
            };
            return this.orderRepository.CreateOrder(order);
        }
        else
        {
            return 0;
        }
    }

    public async Task<bool> ProcessOrder(string orderId)
    {
        try
        {
            this.logger.LogInformation($"Processing order: {orderId}");
            var order = this.orderRepository.GetOrder(orderId);

            if (order.Status == OrderStatus.Pending)
            {
                this.logger.LogInformation($"Order with {orderId} is not {OrderStatus.Pending.ToString()}.");
                return false;
            }

            var customer = this.customerRepository.GetCustomer(order.CustomerId);

            foreach (var item in order.Items)
            {
                this.productRepository.GetProduct(item.ProductId).Stock -= item.Quantity;
            }

            double discount = DiscountFactory.GetDiscount(customer.MembershipLevel);

            if (order.TotalAmount > 1000)
            {
                discount += 0.05;
            }

            order.Status = OrderStatus.Processing;
            order.DiscountApplied = order.TotalAmount * discount;
            order.FinalAmount = order.TotalAmount - order.DiscountApplied;
            order.UpdatedAt = DateTime.Now;

            GlobalData.ActiveOrders.Add(order);
            GlobalData.ProcessingQueue.Add(orderId);

            this.orderRepository.SaveChanges();

            this.emailSender.SendEmail(customer.Email, $"Order {orderId} is being processed");
            this.notificationSender.SendNotification($"New order processing: {orderId}", Role.Admin);
            return true;
        }
        catch (CustomerNotFoundException ex)
        {
            this.logger.LogError(ex, ex.Message);
            return false;
        }
        catch (OrderNotFoundException ex)
        {
            this.logger.LogError(ex, ex.Message);
            return false;
        }
        catch (ProductNotFoundException ex)
        {
            this.logger.LogError(ex, ex.Message);
            return false;
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, ex.Message);
            return false;
        }
    }

    public async Task<OrderResponseDTO> GetOrder(string orderId)
    {
        var order = this.orderRepository.GetOrder(orderId);
        // map here with DTO
        return new OrderResponseDTO();
    }
}
