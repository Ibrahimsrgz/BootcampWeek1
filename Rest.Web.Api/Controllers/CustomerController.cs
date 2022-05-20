using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest.Web.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rest.Web.Api.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public static List<Customer> customerList = new List<Customer>()
        {
            new Customer
            {
                CustomerId =1,
                Address = "Izmir",
                Name = "Ibrahim",
                Mail ="ibrahim@gmail.com",
                Telephone = "65754643543"
            },
            new Customer
            {
                CustomerId =2,
                Name = "Aylis",
                Address = "Güzelyurt",
                Mail ="aylis@gmail.com",
                Telephone = "5323013145"
            },
            new Customer
            {
                CustomerId =3,
                Name = "Ismail",
                Address = "Ankara",
                Mail ="ismail@gmail.com",
                Telephone = "532306545"
            }
        };


        [HttpGet]
        public IActionResult GetCustomers()
        {
            return Ok(customerList);
        }


         [HttpGet("list")]
        public IActionResult GetCustomerFromQueryList([FromQuery] string name = "", 
                                                    [FromQuery] string address = "")
        {
            return Ok(customerList.Where(x => x.Name.ToLower().Contains(name))
                .Where(x => x.Address.ToLower().Contains(address)));
        }

        
        [HttpGet("sort")]
        public IActionResult GetEmployeesFromQuerySort([FromQuery] bool customerId = false,
                                                    [FromQuery] bool name = false,
                                                    [FromQuery] bool address = false,       
                                                    [FromQuery] bool mail = false,
                                                    [FromQuery] bool telephone = false)
        {
            if (customerId)
            {
                return Ok(customerList.OrderBy(x => x.CustomerId));
            } 
            else if (name)
            {
                return Ok(customerList.OrderBy(x => x.Name));
            }
            else if (address)
            {
                return Ok(customerList.OrderBy(x => x.Address));
            }
            else if (mail)
            {
                return Ok(customerList.OrderBy(x => x.Mail));
            }
            else if (telephone)
            {
                return Ok(customerList.OrderBy(x => x.Telephone));
            }
            else
            {
                return BadRequest("Sorting type is not valid");
            }

        }

        [HttpGet("{id}")] 
        public IActionResult GetCustomerById(int id)
        {

            var customer = customerList.SingleOrDefault(x => x.CustomerId == id);

            if (customer is null)
                return BadRequest("Invalid id value");

            return Ok(customer);
        }


        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {

            var maxId = customerList.Max(p => p.CustomerId);

            var findCustomer = customerList.SingleOrDefault(x => x.Mail == customer.Mail);
            
            if (findCustomer is not null )
            {
                return BadRequest("Mail is used before.");
            }

            customerList.Add(new Customer() { CustomerId = maxId + 1, Name = customer.Name, Address = customer.Address, Mail = customer.Mail, Telephone = customer.Telephone });

            return Created("", customerList.Last());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var customer = customerList.SingleOrDefault(x => x.CustomerId == id);
            if (customer is null)
                return BadRequest("Invalid id value");

            customerList.Remove(customer);
            return Ok(customer);
        }
    }
}
