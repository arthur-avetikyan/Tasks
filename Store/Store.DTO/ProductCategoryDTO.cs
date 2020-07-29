using System;
using System.Collections.Generic;

namespace Store.DTO
{
    public class ProductCategoryDTO : IDTOBase
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryTag { get; set; }
        public virtual IEnumerable<ProductDTO> Product { get; set; }
    }
}