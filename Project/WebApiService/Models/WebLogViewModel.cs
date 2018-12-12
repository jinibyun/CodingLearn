using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingApp.WebApiService.Models
{
    public class WebLogViewModel
    {        
        public string Name { get; set; }
        public string Url { get; set; }
        public int Count { get; set; }
        public int Rank { get; set; }
    }
}