using System;

namespace SOLID.SingleResponsibility.Good
{
    public class ProductDisplayer
    {
        public static void DisplayProduct(Product product)
        {
            Console.WriteLine($"{product.Units} {product.Name} is available for {product.Price} dollars.");
        }
    }
}
