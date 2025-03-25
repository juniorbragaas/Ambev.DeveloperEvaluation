using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Vendas.CreateVenda;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas;

/// <summary>
/// Controller for managing Venda operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class VendasController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of VendasController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public VendasController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new Venda
    /// </summary>
    /// <param name="request">The Venda creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Venda details</returns>
    [HttpPost]
    //[ProducesResponseType(typeof(ApiResponseWithData<CreateVendaResponse>), StatusCodes.Status201Created)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateVenda([FromBody] CreateVendaRequest request, CancellationToken cancellationToken)
    {
        return Ok("Precisa Implementar o Codigo");
    }

    /// <summary>
    /// Retrieves a Venda by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the Venda</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Venda details if found</returns>
    [HttpGet("{id}")]
    //[ProducesResponseType(typeof(ApiResponseWithData<GetVendaResponse>), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetVenda([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return Ok("Precisa Implementar o Codigo");
    }

    /// <summary>
    /// Deletes a Venda by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the Venda to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the Venda was deleted</returns>
    [HttpDelete("{id}")]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteVenda([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return Ok("Precisa Implementar o Codigo");
    }
}
