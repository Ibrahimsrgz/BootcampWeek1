using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest.Web.Api.Models;
using System.Collections.Generic;

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




    }
}
