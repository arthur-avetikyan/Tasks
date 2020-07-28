using System;

namespace Store.IServices
{
    public interface IPriceService
    {
        void DropPrice(Guid id, double amount);
    }
}
