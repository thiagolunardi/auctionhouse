using AutoMapper;

namespace Auctionata.Application.AutoMapper
{
    public class Mapper
    {
        private static IMapper _mapper;
        public static void RegisterMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ModelToViewModelProfile>();
                cfg.AddProfile<ViewModelToModelProfile>();
            });

            config.AssertConfigurationIsValid();

            _mapper = config.CreateMapper();
        }

        public static TDestination Map<TDestination>(object source) =>
            _mapper.Map<TDestination>(source);
    }
}