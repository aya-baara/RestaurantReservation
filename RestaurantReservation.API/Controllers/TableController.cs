using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repository;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Route("api/tables")]
public class TableController : Controller
{
    private readonly TableRepository _tableRepository;
    private readonly IMapper _mapper;

    public TableController(TableRepository tableRepository, IMapper mapper)
    {
        _tableRepository = tableRepository;
        this._mapper = mapper;
    }

    /// <summary>
    /// Get a specific table by ID.
    /// </summary>
    /// <param name="id">The ID of the table to retrieve.</param>
    /// <returns>A single tableDto object.</returns>
    /// <response code="200">Returns the requested customer</response>
    /// <response code="404">If the customer is not found</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TableDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult>GetTable(int id)
    {
        try {
            var table = await _tableRepository.GetById(id);
            return Ok(_mapper.Map<TableDto>(table));
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return NotFound();
        }
    }

    /// <summary>
    /// Creates a new table.
    /// </summary>
    /// <param name="TableCreationDto">The table data to create</param>
    /// <returns>The newly created table.</returns>
    /// <response code="201">Returns the newly created table</response>
    /// <response code="400">If the input is invalid</response>
    [HttpPost]
    [ProducesResponseType(typeof(CustomerDto), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult>CreateTable(TableCreationDto tableCreationDto)
    {
        var table = await _tableRepository.Create(_mapper.Map<Table>(tableCreationDto));
        var createdTable = _mapper.Map<TableDto>(table);

        return CreatedAtAction(nameof(GetTable), new { id = createdTable.TableId }, createdTable);
    }

    /// <summary>
    /// Updates an existing table's information.
    /// </summary>
    /// <param name="id">The ID of the table to update.</param>
    /// <param name="customerUpdateDto">The updated table information.</param>
    /// <returns>No content if the update is successful; NotFound if the table does not exist.</returns>
    /// <response code="204">table updated successfully</response>
    /// <response code="404">table not found</response>
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateEmployee(int id, TableUpdateDto tableUpdateDto)
    {
        try
        {
            var table = await _tableRepository.GetById(id);
            _mapper.Map(tableUpdateDto, table);
            await _tableRepository.Update(table);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return NotFound();
        }

    }
}

