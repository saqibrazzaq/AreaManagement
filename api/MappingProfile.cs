using api.Dtos;
using api.Entities;
using AutoMapper;

namespace api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Country
            CreateMap<Country, CountryRes>();
            CreateMap<CountryReqEdit, Country>();

            // State
            CreateMap<State, StateRes>();
            CreateMap<StateReqEdit, State>();

            // City
            CreateMap<City, CityRes>();
            CreateMap<CityReqEdit, City>();

            // Area
            CreateMap<Area, AreaRes>();
            CreateMap<AreaReqEdit, Area>();

            // City, State, Country import
            CreateMap<CityImport, City>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.name));
            CreateMap<StateImport, State>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dst => dst.Code, opt => opt.MapFrom(src => src.state_code))
                .ForMember(dst => dst.Cities, opt => opt.MapFrom(src => src.cities));
            CreateMap<CountryImport, Country>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dst => dst.Code, opt => opt.MapFrom(src => src.iso3))
                .ForMember(dst => dst.States, opt => opt.MapFrom(src => src.states));
        }
    }
}
