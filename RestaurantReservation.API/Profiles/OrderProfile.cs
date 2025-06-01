using AutoMapper;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.API.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderWithMenuItemsDto>().ForMember(destination => destination.MenuItems, options => options.MapFrom(src => src.OrderItems.Select(i => i.MenuItem)));
    }
}

