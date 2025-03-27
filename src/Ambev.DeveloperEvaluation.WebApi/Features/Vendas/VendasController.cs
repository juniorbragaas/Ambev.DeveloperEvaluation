using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Clientes;

/// <summary>
/// Controller for managing user operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class VendasController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IVendaRepository _VendasRepository;

    /// <summary>
    /// Initializes a new instance of UsersController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public VendasController(IMediator mediator, IMapper mapper, IVendaRepository VendasRepository)
    {
        _mediator = mediator;
        _mapper = mapper;
        _VendasRepository = VendasRepository;
    }

    /// <summary>
    /// Creates a new user
    /// </summary>
    /// <param name="request">The user creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user details</returns>
    [HttpPost]
    //[ProducesResponseType(typeof(ApiResponseWithData<CreateClientesResponse>), StatusCodes.Status201Created)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateVendas([FromBody] Venda request)
    {
        //Verificando se tem algum produto com desconto
        var prod = request.Products;
        foreach (var product in prod)
        {
            if(product.Quantidade <= 0 && product.Quantidade > 20)
            {
                return Ok("Existem produtos na venda com quantidade acima de 20");
            }
            if(product.Quantidade >=4 && product.Quantidade < 10)
            {
                VendaBOValidator.DescontoEntre4e9(request, product.Id);
            }
            if (product.Quantidade >= 10 && product.Quantidade < 20)
            {
                VendaBOValidator.DescontoEntre10e20(request, product.Id);
            }
        }
       VendaBOValidator.CalculoValores(request);
       var VendasCriada = _VendasRepository.CreateAsync(request);
       return Ok(VendasCriada);
    }

    /// <summary>
    /// Retrieves a user by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user details if found</returns>
    [HttpGet("ListarTodos")]
    //[ProducesResponseType(typeof(ApiResponseWithData<GetClientesResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListarVendas()
    {
        var Vendas = _VendasRepository.ListVendas();
        return Ok(Vendas);
    }

    /// <summary>
    /// Retrieves a user by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user details if found</returns>
    [HttpGet("{id}")]
    //[ProducesResponseType(typeof(ApiResponseWithData<GetClientesResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetVendas([FromRoute] string id)
    {

        var resultado = _VendasRepository.GetByIdAsync(id);
        return Ok(resultado);
    }

    /// <summary>
    /// Deletes a user by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the user was deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteVendas([FromRoute] string id, CancellationToken cancellationToken)
    {
        var resultado = _VendasRepository.DeleteAsync(id);
        return Ok(resultado);
    }
}
