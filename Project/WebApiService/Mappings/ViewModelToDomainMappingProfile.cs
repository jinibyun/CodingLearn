using AutoMapper;
using DatingApp.Data;
using DatingApp.WebApiService.Dto;

namespace DatingApp.WebApiService.Mappings
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserForRegisterDto, User>();
        }
    }
}