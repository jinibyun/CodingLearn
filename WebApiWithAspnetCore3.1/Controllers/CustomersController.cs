﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiWithAspnetCore31.Models;

namespace WebApiWithAspnetCore31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        static List<Customer> customers = new List<Customer>()
         {
         new Customer(){Id=1,Name = "Tom Cruise",Email = "tomcruise@gmail.com",Phone =
        "3322"},
         new Customer(){Id=1,Name = "Robert Downy Jr",Email = "robert@gmail.com",Phone
        = "326"},
         new Customer(){Id=1,Name = "Chris patt",Email = "cpatt@hotmail.com",Phone =
        "659"},
         };

        // GET: api/Customers
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return customers;
        }
        // GET: api/Customers/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // POST: api/Customers
        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            // see  "using System.ComponentModel.DataAnnotations" on Customer.cs
            if (ModelState.IsValid)
            {
                customers.Add(customer);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Customers/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

    }
}