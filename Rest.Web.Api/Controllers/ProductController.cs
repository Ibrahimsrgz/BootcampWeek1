using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest.Web.Api.Models;
using System;
using System.Collections.Generic;

namespace Rest.Web.Api.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private static List<Product> ProductList = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Category = "Telefon",
                Name = "Iphone",
                Price = 1000,
                IsDeleted = false,
                CreatedAt = new DateTime(2022,05,18),
                UpdateAt = new DateTime(2022,05,18)

            },

            new Product
            {
                Id = 2,
                Category = "Bilgisayar",
                Name = "Monster",
                Price = 4000,
                IsDeleted = false,
                CreatedAt = new DateTime(2022,05,18),
                UpdateAt = new DateTime(2022,05,18)

            },

            new Product
            {
                Id = 1,
                Category = "Televizyon",
                Name = "LG",
                Price = 5000,
                IsDeleted = false,
                CreatedAt = new DateTime(2022,05,18),
                UpdateAt = new DateTime(2022,05,18)

            },


        };


        [HttpGet]
        
        public void Get() { }

    }
}
