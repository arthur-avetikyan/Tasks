using System;

namespace Store.DTO
{
    public class StockDTO : IDTOBase
    {
        public Guid Id { get; set; }
        public int? InStock { get; set; }
        public virtual ProductDTO Product { get; set; }
    }
}