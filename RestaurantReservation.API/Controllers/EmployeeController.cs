using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Models;
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
    public async Task<ActionResult>GetEmployee(int id)
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

    /// <summary>
    /// Creates a new employee.
    /// </summary>
    /// <param name="EmployeeCreationDto">The employee data to create</param>
    /// <returns>The newly created employee.</returns>
    /// <response code="201">Returns the newly created employee</response>
    /// <response code="400">If the input is invalid</response>
    [HttpPost]
    [ProducesResponseType(typeof(CustomerDto), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateEmployee(EmployeeCreationDto creationDto)
    {
        var employee = await _employeeRepository.Create(_mapper.Map<Employee>(creationDto));
        var createdEmployee = _mapper.Map<EmployeeDto>(employee);

        return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId }, createdEmployee);
    }
}

