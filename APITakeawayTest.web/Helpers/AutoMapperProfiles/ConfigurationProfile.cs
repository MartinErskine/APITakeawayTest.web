using APITakeawayTest.Data.Domain;
using APITakeawayTest.Services.Models;
using AutoMapper;

namespace APITakeawayTest.web.Helpers.AutoMapperProfiles
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<Laptop, LaptopModel>().ReverseMap();

            CreateMap<ConfiguredLaptop, ConfiguredLaptopModel>()
                .ForPath(dest => dest.ConfigurationItems, opt => opt.MapFrom(src => src.ConfigurationItems))
                .ReverseMap();
        }
    }
}
