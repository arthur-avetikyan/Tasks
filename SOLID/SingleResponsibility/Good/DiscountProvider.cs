namespace SOLID.SingleResponsibility.Good
{
    public class DiscountProvider
    {
        public double ApplyDiscount(double profitPerItem)
        {
            double lDiscountAmount = 0;
            if (profitPerItem > 40)
                lDiscountAmount += 5;
            if (profitPerItem < 30)
                lDiscountAmount -= 5;
            return lDiscountAmount;
        }
    }
}
