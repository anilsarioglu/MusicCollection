using System.Collections.Generic;
using AutoMapper;

namespace BLL.utilities.autoMapper
{
    internal class Mapper
    {
        internal static TDestination Map<TSource, TDestination>(TSource objectToMap)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            var mapper = config.CreateMapper();
            return mapper.Map<TDestination>(objectToMap);
        }

        internal static List<TDestination> MapList<TSource, TDestination>(List<TSource> listToMap)
        {
            var items = new List<TDestination>();
            foreach (var item in listToMap)
            {
                items.Add(Map<TSource, TDestination>(item));
            }

            return items;
        }
    }
}
