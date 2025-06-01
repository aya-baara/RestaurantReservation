using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Repository;

namespace RestaurantReservation.API.Controllers;

public class CustomerController : Controller
{
    private readonly CustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerController (CustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get a specific customer by ID.
    /// </summary>
    /// <param name="id">The ID of the customer to retrieve.</param>
    /// <returns>A single CustomerDto object.</returns>
    /// <response code="200">Returns the requested customer</response>
    /// <response code="404">If the customer is not found</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CustomerDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
    {
        try
        {
            var customer = await _customerRepository.GetById(id);
            return Ok(_mapper.Map<CustomerDto>(customer));
        }
        catch
        {
            return NotFound();
        }

    }

}

