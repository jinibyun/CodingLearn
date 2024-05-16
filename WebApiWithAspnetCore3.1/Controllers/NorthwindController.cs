using EFCoreConsole.NorthwindModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiWithAspnetCore31.Dtos;
using WebApiWithAspnetCore31.Models;
using WebApiWithAspnetCore31.Services;

namespace WebApiWithAspnetCore31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NorthwindController : ControllerBase
    {
        IRegion repo;
        public NorthwindController(IRegion _repo)
        {
            repo = _repo;
        }
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(GetData());
        }


        [HttpPost]
        public IActionResult Post(RegionDto region) // automatic deserialization
        {
            try
            {
                // DTO: Data Transfer Object: between JSON and Entity Class

                if (repo.AddRegion(region))
                {
                    return Ok(GetData()); // StatusCode(StatusCodes.Status201Created);
                }
                return BadRequest("something went wrong on saving database such as duplication or other constraints");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, RegionDto region)
        {
            try
            {
                if(id < 1)
                {
                    return BadRequest("Id cannot be less than zero");
                }

                if (repo.UpdateRegion(region))
                {
                    return Ok(GetData()); // StatusCode(StatusCodes.Status201Created);
                }
                return BadRequest("something went wrong on saving database such as duplication or other constraints");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest("Id cannot be less than zero");
                }

                if (repo.DeleteRegion(id))
                {
                    return Ok(GetData()); // StatusCode(StatusCodes.Status201Created);
                }
                return BadRequest("something went wrong on saving database such as duplication or other constraints");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private List<Region> GetData()
        {
            return repo.GetRegions().ToList();
        }
    }
}
