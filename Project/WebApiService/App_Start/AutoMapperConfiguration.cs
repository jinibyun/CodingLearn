using AutoMapper;
using DatingApp.WebApiService.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingApp.WebApiService.App_Start
{
    public class AutoMapperConfiguration
    {
        // ref: https://stackoverflow.com/questions/42812430/automapper-in-webapi-controller
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}