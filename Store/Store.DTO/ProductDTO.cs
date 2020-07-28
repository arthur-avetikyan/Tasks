using System;

namespace Store.DTO
{
    public class ProductDTO : IDTOBase
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public PriceDTO Price { get; set; }

        public StockDTO Stock { get; set; }
    }
}
