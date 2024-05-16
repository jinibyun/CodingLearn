using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiWithAspnetCore31.Dtos
{
    public class RegionDto
    {
        [Required(ErrorMessage ="Region Id cannot be empty")]
        public int RegionId { get; set; }

        
        [Required(ErrorMessage = "Region description cannot be empty")]
        public string RegionDescription { get; set; }
    }
}