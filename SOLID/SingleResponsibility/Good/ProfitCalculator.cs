namespace SOLID.SingleResponsibility.Good
{
    public class ProfitCalculator
    {
        public ProfitCalculator(double tax, double cost)
        {
            Tax = tax;
            Cost = cost;
        }

        public double Tax { get; set; }

        public double Cost { get; set; }


        public double CalculateProfit(double price)
        {
            return price - (price * Tax) - Cost;
        }
    }
}
