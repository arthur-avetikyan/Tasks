using System;

namespace Store.DTO
{
    public class ProductDTO : IDTOBase
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal Cost { get; set; }
        public string Currency { get; set; }
        public Guid? StockId { get; set; }
        public Guid? CategoryId { get; set; }
        public virtual ProductCategoryDTO Category { get; set; }
        public virtual StockDTO Stock { get; set; }

    }
}
