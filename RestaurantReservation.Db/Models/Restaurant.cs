﻿using RestaurantReservation.Db.Interface;

namespace RestaurantReservation.Db.Models;

public class Restaurant : IModel
{
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int PhoneNumber { get; set; }
    public string OpeningHours { get; set; }
    public List<Employee> Employees { get; set; }
    public List<Table> Tables { get; set; }
    public List<Reservation> Reservations { get; set; }
    public List<MenuItem> MenuItems { get; set; }
}

