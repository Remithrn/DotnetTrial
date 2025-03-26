using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Entities.Products.Models
{
    public class ProductEntity
    {
        [Key]
        public long? ProductId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage ="The price must be greater than 0")]
        public decimal Price { get; set; }

        [Required]
        [Range(0,int.MaxValue,ErrorMessage ="Stock cannot be negative")]
        public int StockQuantity { get; set; }

        public DateTime CreatedAte { get; set; } = DateTime.UtcNow;
    }
}
