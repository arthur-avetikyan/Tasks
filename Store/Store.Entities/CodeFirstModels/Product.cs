using System;

namespace Store.Entities
{
    public class Product : IEntityBase
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid PriceId { get; set; }

        public Price Price { get; set; }

        public Guid StockId { get; set; }

        public Stock Stock { get; set; }
    }
}
