using IServices;
using System;

namespace Services
{
    public class DiscountProvider : IDiscountProvider
    {
        IDiscountStrategy _discountStrategy;


        public double ApplyDiscount(IDiscountStrategy discountStrategy, Guid productId)
        {
            return _discountStrategy.GetDiscount(productId);
        }

        public void SetDiscountStrategy(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }
    }
}
