using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models.Customers;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repository;

namespace RestaurantReservation.API.Controllers;
[Authorize]
[ApiController]
[Route("api/customers")]
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

    /// <summary>
    /// Creates a new customer.
    /// </summary>
    /// <param name="customerCreation">The customer data to create</param>
    /// <returns>The newly created customer.</returns>
    /// <response code="201">Returns the newly created customer</response>
    /// <response code="400">If the input is invalid</response>
    [HttpPost]
    [ProducesResponseType(typeof(CustomerDto), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<CustomerCreationDto>> CreateCustomer(CustomerCreationDto customerCreation)
    {
        var customer = _mapper.Map<Customer>(customerCreation);
        var createdCustomer = await _customerRepository.Create(customer);
        var createdCustomerReturn = _mapper.Map<CustomerDto>(createdCustomer);

        return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomerReturn.CustomerId }, createdCustomerReturn);

    }

    /// <summary>
    /// Updates an existing customer's information.
    /// </summary>
    /// <param name="id">The ID of the customer to update.</param>
    /// <param name="customerUpdateDto">The updated customer information.</param>
    /// <returns>No content if the update is successful; NotFound if the customer does not exist.</returns>
    /// <response code="204">Customer updated successfully</response>
    /// <response code="404">Customer not found</response>
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateCustomer(int id , CustomerUpdateDto customerUpdateDto)
    {
        try
        {
            var customer = await _customerRepository.GetById(id);
            _mapper.Map(customerUpdateDto, customer);
            await _customerRepository.Update(customer);
            return NoContent();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return NotFound();
        }

    }

    /// <summary>
    /// Partially updates an existing customer by ID using a JSON patch document.
    /// </summary>
    /// <param name="id">The ID of the customer to update.</param>
    /// <param name="patchDocument">The JSON patch document containing updates.</param>
    /// <returns>No content if successful; otherwise, a 404 Not Found response.</returns>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PartiallyUpdateCustomer(int id, [FromBody] JsonPatchDocument<CustomerUpdateDto> patchDocument)
    {
        if (patchDocument == null)
            return BadRequest();
        try
        {
            var existingCustomer = await _customerRepository.GetById(id);

            var customerToPatch = _mapper.Map<CustomerUpdateDto>(existingCustomer);

            patchDocument.ApplyTo(customerToPatch, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _mapper.Map(customerToPatch, existingCustomer);
            await _customerRepository.Update(existingCustomer);

            return NoContent();
        }
        catch
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Delete Customer By Id
    /// </summary>
    /// <param name="id">The ID of the customer to delete.</param>
    /// <returns>No content if successful; otherwise, a 404 Not Found response.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteCustomer(int id)
    {
        try
        {
           await _customerRepository.DeleteById(id);
            return NoContent();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return NotFound();
        }

    }

}

