namespace PlayWithGithupActions.Services;

public class DiscountCalculator
{
    public decimal CalculateDiscount(decimal totalAmount, bool isVipCustomer)
    {
        if (totalAmount <= 0) 
        {
            return 0;
        }

        if (isVipCustomer)
        {
            // VIPs get 20% off orders over $100, otherwise 10%
            return totalAmount >= 100 ? totalAmount * 0.20m : totalAmount * 0.10m;
        }

        // Regular customers get 5% off orders over $100, otherwise 0%
        return totalAmount >= 100 ? totalAmount * 0.05m : 0;
    }
}