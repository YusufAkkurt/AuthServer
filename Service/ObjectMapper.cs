using AutoMapper;
using System;

namespace AuthServer.Service
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazyMapper = new(() =>
        {
            var config = new MapperConfiguration(config => { config.AddProfile<DtoMapper>(); });
            return config.CreateMapper();
        });

        public static IMapper Mapper => lazyMapper.Value;
    }
}
