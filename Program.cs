public class Program
{
    public static void Main(string[] args)
    {
        Customer deliveryBoy = new Customer("John", "Doe");
        float payment = 2.0f;

        if (deliveryBoy.getWalletBalance() >= payment)
        {
            deliveryBoy.withdrawMoney(payment);
            Console.WriteLine($"Payment of {payment} was successful. Remaining balance: {deliveryBoy.GetWalletBalance()}");
        }
        else
        {
            Console.WriteLine("Not enough balance, come back later and get my money.");
        }
    }
}