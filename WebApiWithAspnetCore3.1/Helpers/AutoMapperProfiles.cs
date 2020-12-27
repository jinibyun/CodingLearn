using System.Linq;
using AutoMapper;
using WebApiWithAspnetCore31.Dtos;
using WebApiWithAspnetCore31.Models;

namespace WebApiWithAspnetCore31.Helpers
{
    // AutoMapper is convention based solution
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // setting specific member mapping: ForMember
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.Age, opt => {
                    opt.MapFrom(d => d.DateOfBirth.CalculateAge());
                });

            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.Age, opt => {
                    opt.MapFrom(d => d.DateOfBirth.CalculateAge());
                });
           
            
            CreateMap<UserForRegisterDto, User>();
            
        }
    }
}