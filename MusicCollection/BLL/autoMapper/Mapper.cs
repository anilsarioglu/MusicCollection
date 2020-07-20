using AutoMapper;

namespace BLL.autoMapper
{
    internal class Mapper
    {
        internal static TDestination Map<TSource, TDestination>(TSource objectToMap)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            var mapper = config.CreateMapper();
            return mapper.Map<TDestination>(objectToMap);
        }
    }
}
