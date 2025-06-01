using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Repository;

namespace RestaurantReservation.API.Controllers;
[ApiController]
[Route("api/reservations")]
public class ReservationController : Controller
{
    private readonly ReservationRepository _reservationRepository;
    private readonly CustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public ReservationController(ReservationRepository reservationRepository, IMapper mapper, CustomerRepository customerRepository)
    {
        _reservationRepository = reservationRepository;
        _mapper = mapper;
        _customerRepository = customerRepository;
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



}

