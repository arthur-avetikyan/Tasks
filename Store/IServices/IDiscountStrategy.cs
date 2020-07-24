using System;

namespace IServices
{
    public interface IDiscountStrategy
    {
        double GetDiscount(Guid productId);
    }
}