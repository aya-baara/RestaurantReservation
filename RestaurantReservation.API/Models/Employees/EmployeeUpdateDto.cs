﻿using RestaurantReservation.Db.Models.Enums;

namespace RestaurantReservation.API.Models.Employees;

public class EmployeeUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public EmployeePosition Position { get; set; }
    public int RestaurantId { get; set; }
}

