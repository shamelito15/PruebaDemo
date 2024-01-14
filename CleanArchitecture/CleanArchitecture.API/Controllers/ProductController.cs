using CleanArchitecture.Application.Features.Products.Commands.CreateProduct;
using CleanArchitecture.Application.Features.Products.Commands.DeleteProduct;
using CleanArchitecture.Application.Features.Products.Commands.UpdateProduct;
using CleanArchitecture.Application.Features.Products.Queries.GetProductList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
       private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{username}", Name = "GetProduct")]
        [ProducesResponseType(typeof(IEnumerable<ProductVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductVm>>> GetProductVmByUsername(string username)
        {
            var query = new GetProductListQuery(username);
            var product = await _mediator.Send(query);
            return Ok(product);
        }
        [HttpPost(Name = "CreateProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateProduct([FromBody] CreateProductCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
