﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiWithAspnetCore31.Models;

namespace WebApiWithAspnetCore31.Controllers
{
    // apiVersion : check startup.cs
    // it requires package named "Microsoft.AspNetCore.Mvc.Versioning"
    // 1. querystring versioning: http://localhost:2473/api/movies?api-version=2.0
    // [ApiVersion("2.0")]
    // [Route("api/movies")]

    // 2. url versioning: http://localhost:2473/api/v2/movies
    //[ApiVersion("2.0")]
    //[Route("api/v{version:apiVersion}/movies")]

    // 3. versioning via media type
    // send version information indide header
    // e.g header -->> accept   application/json;v=1.0 (client should send this way)
    // check startup.cs : options.ApiVersionReader = new MediaTypeApiVersionReader();
    [ApiVersion("2.0")]
    [Route("api/movies")]
    [ApiController]
    public class MovieV2Controller : ControllerBase
    {
        static List<MovieV2> movies = new List<MovieV2>()
        {
            new MovieV2()
            {
                Id = 0, MovieName = "movie 1", MovieDescription = "blah..blah", MovieTitle = "title 1"
            },
            new MovieV2()
            {
                Id = 1, MovieName = "movie 2", MovieDescription = "blah..blah....", MovieTitle = "title 2"
            }
        };

        // GET: api/MovieV2
        [HttpGet]
        public IEnumerable<MovieV2> Get()
        {
            return movies;
        }

        // GET: api/MovieV2/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MovieV2
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/MovieV2/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
