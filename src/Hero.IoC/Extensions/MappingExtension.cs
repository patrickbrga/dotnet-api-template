using AutoMapper;
using Core.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Extensions
{
    public static class MappingExtension
    {
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ResquestProfile());
                mc.AddProfile(new ResponseProfile());
                mc.AddProfile(new ServiceProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
