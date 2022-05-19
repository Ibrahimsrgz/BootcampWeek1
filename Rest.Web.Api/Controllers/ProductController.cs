using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Rest.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
                Id = 3,
                Category = "Televizyon",
                Name = "LG",
                Price = 5000,
                IsDeleted = false,
                CreatedAt = new DateTime(2022,05,18),
                UpdateAt = new DateTime(2022,05,18)

            },


        };


        [HttpGet]
        public List<Product> GetProducts()
        {
            var productList = ProductList;
            return productList;

        }

        [HttpGet("{id}")]
        public Product GetById(int id)
        {

            var product = ProductList.Where(product => product.Id == id).SingleOrDefault();
            return product;

        }
        //[HttpGet]
        //public Product Getter([FromQuery] string id)
        //{

        //    var product = ProductList.Where(product => product.Id == Convert.ToInt32(id)).SingleOrDefault();
        //    return product;

        //}

        [HttpPost]

        public IActionResult AddProduct([FromBody] Product newProduct)
        {

            var product = ProductList.SingleOrDefault(x => x.Id == newProduct.Id);

            if (product is not null)
                return BadRequest();

            ProductList.Add(newProduct);
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = ProductList.SingleOrDefault(x => x.Id == id);

            if (product is null)
                return BadRequest();

            product.Name = updatedProduct.Name != default ? updatedProduct.Name : product.Name;

            product.Price = updatedProduct.Price != default ? updatedProduct.Price : product.Price;

            product.Category = updatedProduct.Category != default ? updatedProduct.Category : product.Category;

            product.IsDeleted = updatedProduct.IsDeleted != default ? updatedProduct.IsDeleted : product.IsDeleted;

            return Ok();

        }


        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] JsonPatchDocument< ProductUpdateDto> product)
        {
            /*var p = ProductList.SingleOrDefault(x => x.Id == id);

            if (p is null)
                return BadRequest();

            product.ApplyTo(p);

            return Ok();*/

            var p = new ProductUpdateDto();

            p.Price = 1;
            product.ApplyTo(p);



        }




        [HttpDelete("{id}")]

        public IActionResult DeleteProduct(int id)
        {
            var product = ProductList.SingleOrDefault(x => x.Id == id);


            if (product is null)
                return BadRequest();

            ProductList.Remove(product);

            return Ok();


        }



    }
}
