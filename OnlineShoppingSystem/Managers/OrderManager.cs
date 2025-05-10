using OnlineShoppingSystem.DTOs;

public interface OrderManager
{
    Task<bool> ProcessOrder(string orderId);
    Task<int> PlaceOrder(OrderRequestDTO orderRequestDTO);
    Task<OrderResponseDTO> GetOrder(string orderId);
}
