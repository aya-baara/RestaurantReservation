using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Repository;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeeController : Controller
{
    private readonly EmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeController(EmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get a specific employee by ID.
    /// </summary>
    /// <param name="id">The ID of the employee to retrieve.</param>
    /// <returns>A single EmployeeDto object.</returns>
    /// <response code="200">Returns the requested employee</response>
    /// <response code="404">If the employee is not found</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CustomerDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult>GetEmployeeById(int id)
    {
        try
        {
            var employee = await _employeeRepository.GetById(id);
            return Ok(_mapper.Map<EmployeeDto>(employee));
        }
        catch
        {
            return NotFound();
        }
    }
}

