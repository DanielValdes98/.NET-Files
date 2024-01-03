using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetIdentityRoleBasedTutorial.Data
{

    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]

        public Decimal Price { get; set; }
        [Required]
        public Decimal Cost { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Lot { get; set; } 
        [Required]
        public bool TypeMovement { get; set; } // Entries or exists
        [Required]
        public bool Status { get; set; } // Active or inactive
    }
}
