using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Entities.Models
{
    public partial class ExchangeRate
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(25)]
        public string SourceCurrency { get; set; }
        [Required]
        [StringLength(25)]
        public string DestinationCurrency { get; set; }
        [Column(TypeName = "decimal(10, 5)")]
        public decimal Rate { get; set; }
    }
}
