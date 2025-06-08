using System;
using System.ComponentModel.DataAnnotations;

namespace Foody.EntityLayer.Concrete
{
    public class ProductImage
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; } // NEW: for "first"/main image

        // Foreign key
        public int ProductId { get; set; }

        // Navigation property
        public Product Product { get; set; }
    }
}
