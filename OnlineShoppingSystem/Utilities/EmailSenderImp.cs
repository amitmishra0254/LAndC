public class EmailSenderImp : EmailSender
{
    public void SendEmail(string email, string message)
    {
        Console.WriteLine($"Sending email to {email}: {message}");
    }
}
