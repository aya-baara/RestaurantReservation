using AutoMapper;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.API.Profiles;

public class MenuItemProfile : Profile
{
    public MenuItemProfile()
    {
        CreateMap<MenuItem, MenuItemDto>();
    }
}

