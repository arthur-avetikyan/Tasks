using System;

namespace SOLID
{
    public class ProductBad
    {
        public string Name { get; set; }

        public int Units { get; set; }

        public double Price { get; set; }

        public double Tax { get; set; }

        public double Cost { get; set; }


        public void DisplayProduct()
        {
            Console.WriteLine($"{Units} {Name} is available for {Price} dollars.");
        }

        public void SellProduct(int count)
        {
            Units -= count;
        }

        public double CalculateProfitForSales()
        {
            return Price - Price * Tax - Cost;
        }

        public void ApplyDiscount()
        {
            if (CalculateProfitForSales() > 30)
                Price -= 5;
            if (CalculateProfitForSales() < 20)
                Price += 5;
        }
    }
}
