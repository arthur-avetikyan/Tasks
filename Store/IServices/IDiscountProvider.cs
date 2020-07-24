using System;

namespace IServices
{
    public interface IDiscountProvider
    {
        void SetDiscountStrategy(IDiscountStrategy discountStrategy);

        double ApplyDiscount(IDiscountStrategy discountStrategy, Guid productId);
    }
}
