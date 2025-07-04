﻿using AutoMapper;
using RestaurantReservation.API.Models.Customers;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.API.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerCreationDto, Customer>();
        CreateMap<Customer, CustomerUpdateDto>().ReverseMap();
    }
}

