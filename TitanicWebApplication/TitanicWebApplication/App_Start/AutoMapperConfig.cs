using AutoMapper;
using TitanicWebApplication.Db;

namespace TitanicWebApplication
{
    static class AutoMapperConfig
    {
        public static void CreateMappings()
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<TitanicPassenger, TitanicDbPassenger>()
            //    .ForMember(dest => dest.UniqueId, opt => opt.MapFrom(src => src.UniqueId)));
            Mapper.Initialize(cfg => cfg.CreateMap<TitanicPassenger, TitanicDbPassenger>());
        }
    }
}
