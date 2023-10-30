using AutoMapper;
using Kevin.API.Utils;

namespace Kevin.API.Configuration
{
    public static class MapperConfiguration
    {
        public static void AddMapper(this IServiceCollection services)
        {
            var mapperConfig = new AutoMapper.MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
