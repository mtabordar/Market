namespace MarketApi
{
    using AutoMapper;
    using MarketApi.Models;
    using MarketApi.ViewModels;

    public class AutoMapperProfileConfig : Profile
    {
        public AutoMapperProfileConfig()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
