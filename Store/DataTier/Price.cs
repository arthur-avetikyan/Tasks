using System;

namespace Entities
{
    public class Price : IEntityBase
    {
        public Guid Id { get; set; }

        public string Currency { get; set; }

        public double Cost { get; set; }
    }
}
