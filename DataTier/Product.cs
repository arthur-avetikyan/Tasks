using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store
{
    public class Product : IEntityBase
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Price Amount { get; set; }

        public class Price
        {
            public IEnumerable<ExchangeRate> Rates { get; set; }

            public Currency Currency { get; set; }

            public double Cost { get; set; }

            public double PriceModificator { get; set; }

            public double TotalPrice(Currency targetCurrency = Currency.AMD) => Cost * PriceModificator * Rates
                .FirstOrDefault(rate => rate.SourceCurrency == Currency && rate.DestinationCurrency == targetCurrency).Rate;
        }
    }
}
