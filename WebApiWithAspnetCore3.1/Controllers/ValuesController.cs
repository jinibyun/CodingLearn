﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWithAspnetCore31.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("claimtype")]
        public string GetClaimType()
        {
            return "You are king"; // User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        [AllowAnonymous]
        // GET api/values/5   == api/values?id=5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return id.ToString() + " value";
        }

        // POST api/values
        [HttpPost]
        public void sdfsdgfdg([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void sdfsdfsd(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void fsfgfgfdg(int id)
        {
        }
    }
}
