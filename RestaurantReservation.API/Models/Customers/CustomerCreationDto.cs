﻿namespace RestaurantReservation.API.Models.Customers;

public class CustomerCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int PhoneNumber { get; set; }
    public string Email { get; set; }
}

