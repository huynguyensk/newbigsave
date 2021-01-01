using AutoMapper;
using BigSave.Core.Entities;
using BigSave.Web.Models.DataModel;

namespace BigSave.Web.Helper
{
    public class ObjectMapper : Profile
    {
        public ObjectMapper()
        {
            CreateMap<Cart, CartViewModel>().ReverseMap();
            CreateMap<CartItem, CartItemViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Merchant, MerchantViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Wishlist, WishlistViewModel>().ReverseMap();
            CreateMap<Menu, MenuViewModel>().ReverseMap();
            CreateMap<Cart, CartViewModel>().ReverseMap();
            CreateMap<CartItem, CartItemViewModel>().ReverseMap();
            CreateMap<Flyer, FlyerViewModel>().ReverseMap();
            CreateMap<FlyerCategory, FlyerCategoryViewModel>().ReverseMap();
        }
    }
}