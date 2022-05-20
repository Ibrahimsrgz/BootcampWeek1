using System.ComponentModel.DataAnnotations;

namespace Rest.Web.Api.Models
{
    public class Customer
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "ID cannot be negative")]
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }


        [Required]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Mail { get; set; }


        public string Telephone { get; set; }


    }
}
