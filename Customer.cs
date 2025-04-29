//2.Look at the below classes and the client code given below on how the object are used and methods invoked. Is there a better way to write the Customer class?
public class Customer
{
    private String firstName;
    private String lastName;
    private Wallet myWallet;

    public Customer(string firstName,string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public float getWalletBalance()
    {
        return myWallet.getBalance();
    }

    public void depositMoney(float amount)
    {
        myWallet.depositMoney(amount);
    }

    public void withdrawMoney(float amount)
    {
        myWallet.withdrawMoney(amount);
    }
}