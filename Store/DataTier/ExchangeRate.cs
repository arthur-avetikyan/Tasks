using System;

namespace Entities
{
    public class ExchangeRate : IEntityBase
    {
        public Guid Id { get; set; }

        public string SourceCurrency { get; set; }

        public string DestinationCurrency { get; set; }

        public double Rate { get; set; }
    }
}
