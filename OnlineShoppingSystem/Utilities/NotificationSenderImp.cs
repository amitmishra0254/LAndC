public class NotificationSenderImp : NotificationSender
{
    public void SendNotification(string message, Role role)
    {
        Console.WriteLine($"Sending notification to {role.ToString()} with message: {message}");
    }
}
