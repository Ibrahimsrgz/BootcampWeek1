using System;
using System.ComponentModel.DataAnnotations;

namespace Rest.Web.Api.Models
{
    public class Product
    {

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "ID cannot be negative")]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Price cannot be negative")]
        public float Price { get; set; }

        [Required]
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }


        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative")]
        public int Stock { get; set; }

        public bool IsDeleted { get; set; }


    }


    public class ProductUpdateDto
    {
        public float Price { get; set; }

    }
}
