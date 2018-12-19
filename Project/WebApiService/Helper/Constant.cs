using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DatingApp.WebApiService.Helper
{
    public static class Constant
    {
        public readonly static string Cloudinary_Name = ConfigurationManager.AppSettings["Cloudinary_Name"];
        public readonly static string Cloudinary_ApiKey = ConfigurationManager.AppSettings["Cloudinary_ApiKey"];
        public readonly static string Cloudinary_ApiSecret = ConfigurationManager.AppSettings["Cloudinary_ApiSecret"];
    }
}