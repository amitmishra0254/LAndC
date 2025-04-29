public class Wallet
{
    private float value;
    public float getBalance()
    {
        return value;
    }

    public void setBalance(float newValue)
    {
        value = newValue;
    }

    public void depositMoney(float deposit)
    {
        value += deposit;
    }

    public void withdrawMoney(float debit)
    {
        value -= debit;
    }
}