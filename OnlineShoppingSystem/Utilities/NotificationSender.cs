using OnlineShoppingSystem.Enums;

public interface NotificationSender
{
    void SendNotification(string message, Role role);
}
