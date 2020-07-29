using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Entities.Models
{
    public partial class Stock
    {
        [Key]
        public Guid Id { get; set; }
        public int? InStock { get; set; }

        [InverseProperty("Stock")]
        public virtual Product Product { get; set; }
    }
}
