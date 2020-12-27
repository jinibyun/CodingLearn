using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebApiWithAspnetCore31.Helpers
{
    public static class Extensions
    {
        public static int CalculateAge(this DateTime? theDateTime)
        {
            var datetime = theDateTime.HasValue ? (DateTime)theDateTime : DateTime.Now;
            var age = DateTime.Today.Year - datetime.Year;
            if (datetime.AddYears(age) > DateTime.Today)
                age--;

            return age;
        }
    }
}