using System;

namespace Store.DTO
{
    public class PriceDTO : IDTOBase
    {
        public Guid Id { get; set; }

        public string Currency { get; set; }

        public double Cost { get; set; }
    }
}