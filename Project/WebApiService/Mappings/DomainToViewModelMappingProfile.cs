using AutoMapper;
using DatingApp.Data;
using DatingApp.WebApiService.Dto;
namespace DatingApp.WebApiService.Mappings
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {            
            CreateMap<User, UserForDetailedDto>();
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailedDto>();
        }

    }
}