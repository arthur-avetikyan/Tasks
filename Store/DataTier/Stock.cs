using System;

namespace Entities
{
    public class Stock : IEntityBase
    {
        public Guid Id { get; set; }

        public int InStock { get; set; }
    }
}
