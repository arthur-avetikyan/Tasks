using System;

namespace Entities
{
    public class Product : IEntityBase
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Price Price { get; set; }

        public Stock Stock { get; set; }
    }
}
