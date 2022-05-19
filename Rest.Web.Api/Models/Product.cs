using System;

namespace Rest.Web.Api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsDeleted { get; set; }


    }


    public class ProductUpdateDto
    {
        public float Price { get; set; }

    }
}
