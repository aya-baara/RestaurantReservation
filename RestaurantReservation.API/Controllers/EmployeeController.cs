using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models.Customers;
using RestaurantReservation.API.Models.Employees;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repository;

namespace RestaurantReservation.API.Controllers;
[Authorize]
[ApiController]
[Route("api/employees")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeRepository _employeeRepository;
    private readonly OrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public EmployeeController(EmployeeRepository employeeRepository, IMapper mapper, OrderRepository orderRepository)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _orderRepository = orderRepository;
    }

    /// <summary>
    /// Get a specific employee by ID.
    /// </summary>
    /// <param name="id">The ID of the employee to retrieve.</param>
    /// <returns>A single EmployeeDto object.</returns>
    /// <response code="200">Returns the requested employee</response>
    /// <response code="404">If the employee is not found</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
    [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreateEmployee(EmployeeCreationDto creationDto)
    {
        var employee = await _employeeRepository.Create(_mapper.Map<Employee>(creationDto));
        var createdEmployee = _mapper.Map<EmployeeDto>(employee);

        return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId }, createdEmployee);
    }

    /// <summary>
    /// Updates an existing employee's information.
    /// </summary>
    /// <param name="id">The ID of the employee to update.</param>
    /// <param name="employeeUpdateDto">The updated employee information.</param>
    /// <returns>No content if the update is successful; NotFound if the employee does not exist.</returns>
    /// <response code="204">employee updated successfully</response>
    /// <response code="404">employee not found</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateEmployee(int id, EmployeeUpdateDto employeeUpdateDto)
    {
        try
        {
            var employee = await _employeeRepository.GetById(id);
            _mapper.Map(employeeUpdateDto, employee);
            await _employeeRepository.Update(employee);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return NotFound();
        }

    }

    /// <summary>
    /// Partially updates an existing employee by ID using a JSON patch document.
    /// </summary>
    /// <param name="id">The ID of the employee to update.</param>
    /// <param name="patchDocument">The JSON patch document containing updates.</param>
    /// <returns>No content if successful; otherwise, a 404 Not Found response.</returns>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PatchEmployee(int id, [FromBody] JsonPatchDocument<EmployeeUpdateDto> patchDocument)
    {
        if (patchDocument == null)
            return BadRequest();
        try
        {
            var existingEmplyee = await _employeeRepository.GetById(id);

            var employeeToPatch = _mapper.Map<EmployeeUpdateDto>(existingEmplyee);

            patchDocument.ApplyTo(employeeToPatch, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _mapper.Map(employeeToPatch, existingEmplyee);
            await _employeeRepository.Update(existingEmplyee);

            return NoContent();
        }
        catch
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Delete Employee By Id
    /// </summary>
    /// <param name="id">The ID of the Employee to delete.</param>
    /// <returns>No content if successful; otherwise, a 404 Not Found response.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteEmployee(int id)
    {
        try
        {
            await _employeeRepository.DeleteById(id);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return NotFound();
        }

    }

    /// <summary>
    /// Retrieves a list of employees who are managers.
    /// </summary>
    /// <returns>A list of manager employees.</returns>
    /// <response code="200">Returns the list of managers</response>
    /// <response code="500">If there was a server error</response>
    [HttpGet("managers")]
    [ProducesResponseType(typeof(IEnumerable<EmployeeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetManagers()
    {
        return Ok(await _employeeRepository.ListManagers());
    }

    /// <summary>
    /// Calculates the average order amount handled by a specific employee.Add commentMore actions
    /// </summary>
    /// <param name="employeeId">The ID of the employee for whom to calculate the average order amount.</param>
    /// <returns>A 200 OK response with the average order amount; or a 404 Not Found response if no orders exist for the specified employee.</returns>
    [HttpGet("{employeeId}/average-order-amount")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAverageOrderAmount(int employeeId)
    {
        try
        {
            var employee = await _employeeRepository.GetById(employeeId);
            var averageOrderAmount = await _orderRepository.CalculateAverageOrderAmount(employeeId);

            return Ok(new { averageOrderAmount });
        }
        catch
        {
            return NotFound();
        }
       
    }

}

