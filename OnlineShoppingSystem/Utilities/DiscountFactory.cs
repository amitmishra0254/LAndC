public class DiscountFactory
{
    public static double GetDiscount(string discount)
    {
        return discount switch
        {
            "gold" => 0.1,
            "platinum" => 0.15,
            "diamond" => 0.2,
            _ => 0
        };
    }
}