using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Repository;

namespace RestaurantReservation.API.Controllers;
[Authorize]
[ApiController]
[Route("api/reservations")]
public class ReservationController : ControllerBase
{
    private readonly ReservationRepository _reservationRepository;
    private readonly CustomerRepository _customerRepository;
    private readonly OrderItemRepository _orderItemRepository;
    
    private readonly IMapper _mapper;

    public ReservationController(ReservationRepository reservationRepository, IMapper mapper, CustomerRepository customerRepository, OrderItemRepository orderItemRepository)
    {
        _reservationRepository = reservationRepository;
        _mapper = mapper;
        _customerRepository = customerRepository;
        _orderItemRepository = orderItemRepository;
    }

    /// <summary>
    /// Retrieves all reservations for a specific customer.
    /// </summary>
    /// <param name="customerId">The ID of the customer.</param>
    /// <returns>A list of the customer's reservations.</returns>
    /// <response code="200">Returns the list of reservations for the customer</response>
    /// <response code="404">If the customer is not found</response>
    [HttpGet("customer{customerId}")]
    [ProducesResponseType(typeof(IEnumerable<ReservationDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetReservationsForCustomer(int customerId)
    {
        try
        {
            await _customerRepository.GetById(customerId);
            var reservations = await _reservationRepository.GetReservationsByCustomer(customerId);
            var reservationDtos = _mapper.Map<List<ReservationDto>>(reservations);
            return Ok(reservationDtos);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return NotFound();
        }

    }

    /// <summary>
    /// Retrieves all orders and their associated menu items for a specific reservation.
    /// </summary>
    /// <param name="id">The ID of the reservation.</param>
    /// <returns>A list of orders, each with its corresponding menu items.</returns>
    /// <response code="200">Returns the list of orders with their menu items.</response>
    /// <response code="404">If no orders are found for the specified reservation ID.</response>

    [HttpGet("{id}/orders")]
    [ProducesResponseType(typeof(IEnumerable<OrderWithMenuItemsDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetOrdersReservation(int id)
    {
        var ordersDict = await _orderItemRepository.ListOrdersAndMenuItems(id);

        if (ordersDict == null || !ordersDict.Any())
            return NotFound(new { Message = "No orders found for the specified reservation." });

        var result = ordersDict.Select(kvp => new OrderWithMenuItemsDto
        {
            OrderId = kvp.Key,
            MenuItems = _mapper.Map<List<MenuItemDto>>(kvp.Value)
        }).ToList();

        return Ok(result);
    }

    /// <summary>
    /// Retrieves all menu items ordered for a specific reservation.
    /// </summary>
    /// <param name="id">The ID of the reservation.</param>
    /// <returns>A list of menu items associated with the reservation's orders.</returns>
    /// <response code="200">Returns the list of ordered menu items.</response>
    /// <response code="404">If no menu items are found for the specified reservation ID.</response>

    [HttpGet("{id}/menu-items")]
    [ProducesResponseType(typeof(IEnumerable<MenuItemDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetOrderedMenuItemsForReservation(int id)
    {
        var menuItems = await _orderItemRepository.ListOrderedMenuItems(id);

        if (menuItems == null || !menuItems.Any()) 
                return NotFound(new { Message = "No menu items found for the specified order." });

        return Ok(_mapper.Map<IEnumerable<MenuItemDto>>(menuItems));
    }

}

