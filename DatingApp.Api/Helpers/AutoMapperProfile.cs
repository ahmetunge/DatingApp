using System.Linq;
using AutoMapper;
using DatingApp.Api.Dtos;
using DatingApp.Api.Models;

namespace DatingApp.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserForListDto>()
            .ForMember(dest => dest.PhotoUrl, opt =>
            {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            })
            .ForMember(dest => dest.Age, opt =>
            {
                opt.MapFrom(d => d.DateOfBirth.CalculateAge());
            });

            CreateMap<User, UserForDetailedDto>()
              .ForMember(dest => dest.PhotoUrl, opt =>
              {
                  opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
              })
            .ForMember(dest => dest.Age, opt =>
            {
                opt.MapFrom(d => d.DateOfBirth.CalculateAge());
            });

            CreateMap<Photo, PhotosForDetailedDto>();

            CreateMap<UserForUpdateDto,User>();
        }
    }
}