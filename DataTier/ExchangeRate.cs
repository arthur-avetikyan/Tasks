using System;

namespace Entities
{
    public class ExchangeRate : IEntityBase
    {
        public Guid Id { get; set; }

        public Currency SourceCurrency { get; set; }

        public Currency DestinationCurrency { get; set; }

        public double Rate { get; set; }
    }
}
