﻿using AutoMapper;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.API.Profiles;

public class ReservationProfile : Profile
{
    public ReservationProfile()
    {
        CreateMap<Reservation, ReservationDto>();
    }
}

