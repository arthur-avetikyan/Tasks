using System;

namespace Store.Entities
{
    public class Stock : IEntityBase
    {
        public Guid Id { get; set; }

        public int InStock { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }
    }
}
