using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Data.Core
{
    public static class GM<TSource, TDestination>
    where TSource : class where TDestination : class
    {
        private static IMapper _mapper = new Mapper(new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<TSource, TDestination>().ReverseMap();
                    cfg.AllowNullCollections = true;
                    cfg.AllowNullDestinationValues = true;
                }
            )
        );

        public static IMapper Mapper => _mapper;

        public static TDestination MapObject(TSource source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public static List<TDestination> MapCollection(List<TSource> source)
        {
            var list = new List<TDestination>();

            source.ForEach(x => list.Add(MapObject(x)));
            return list;
        }
    }
}
