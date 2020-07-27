using System;

namespace Store.Entities
{
    public interface IEntityBase
    {
        Guid Id { get; set; }
    }

    public enum Currency
    {
        AMD = 0,
        EUR = 1,
        USD = 2,
        RUB = 3
    }
}
