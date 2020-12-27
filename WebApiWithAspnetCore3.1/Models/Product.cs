using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiWithAspnetCore31.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage ="It is required")]
        public string ProductName { get; set; }


        public decimal ProductPrice { get; set; }
    }
}
