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
                Stock =2,
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
                Stock =4,
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
                Stock =5,
                IsDeleted = false,
                CreatedAt = new DateTime(2022,05,18),
                UpdateAt = new DateTime(2022,05,18)

            },


        };

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(ProductList);

        }

       
       [HttpGet("list")]
       public IActionResult GetProductsFromQueryList([FromQuery] string category="" , 
                                                   [FromQuery] float price=0 )
       {
           return Ok(ProductList.Where(x => x.Category.ToLower().Contains(category)).Where(x => x.Price >= price));
       }



        [HttpGet("sort")]
        public IActionResult GetEmployeesFromQuerySort([FromQuery] bool id = false,
                                                   [FromQuery] bool category = false,
                                                   [FromQuery] bool name = false,
                                                   [FromQuery] bool price = false,
                                                   [FromQuery] bool stock = false)
        {
            if (id)
            {
                return Ok(ProductList.OrderBy(x => x.Id));
            }
            else if (category)
            {
                return Ok(ProductList.OrderBy(x => x.Category));
            }
            else if (name)
            {
                return Ok(ProductList.OrderBy(x => x.Name));
            }
            else if (price)
            {
                return Ok(ProductList.OrderBy(x => x.Price));
            }
            else if (stock)
            {
                return Ok(ProductList.OrderBy(x => x.Stock));
            }
            else
            {
                return BadRequest("Sorting type is not valid");
            }

        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            var product = ProductList.Where(product => product.Id == id).SingleOrDefault();

            if (product is null)
                return BadRequest("Invalid id value");

            return Ok(product);

        }


        [HttpPost]

        public IActionResult AddProduct([FromBody] Product newProduct)
        {
            var maxId = ProductList.Max(p => p.Id);

            var findProduct= ProductList.SingleOrDefault(x => x.Id == newProduct.Id);

            if (findProduct is not null)
            {
                for (int i = 0; i < ProductList.Count; i++)
                {
                    if (ProductList[i].Id.Equals(newProduct.Id)){
                        ProductList[i].Stock++;
                            return Ok(ProductList[i]);
                    }
                }
            }

            ProductList.Add(new Product()
            {
                Id = maxId+1,
                Category = newProduct.Category,
                Name = newProduct.Name,
                Price = newProduct.Price,
                Stock = newProduct.Stock,
                IsDeleted = newProduct.IsDeleted   

            });

            return Created("", ProductList.Last());


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
