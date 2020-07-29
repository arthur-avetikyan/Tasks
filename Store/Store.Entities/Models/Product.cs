using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Entities.Models
{
    public partial class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(255)]
        public string ProductName { get; set; }
        [Column(TypeName = "decimal(15, 5)")]
        public decimal Cost { get; set; }
        [StringLength(25)]
        public string Currency { get; set; }
        public Guid? StockId { get; set; }
        public Guid? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(ProductCategory.Product))]
        public virtual ProductCategory Category { get; set; }
        [ForeignKey(nameof(StockId))]
        [InverseProperty("Product")]
        public virtual Stock Stock { get; set; }
    }
}
