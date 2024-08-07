using API_Clean.Application.Product.Command;
using API_Clean.Application.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Clean.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductsController(IMediator med)
        {
            mediator = med;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
               var getprod = new GetAllProducts();
               var res = await mediator.Send(getprod);
               return Ok(res);
        }

        [HttpGet("{Username}")]
        public async Task<IActionResult> GetProductDetailsByUsername(string Username)
        {
            API_Clean.Domain.Entities.Product pro = await mediator.Send(new GetProductByUsername { CreatorUsername = Username });
            if (pro == null)
            {
                return NotFound();
            }
            return Ok(pro);
        }


        [Authorize(Policy = "Valid")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProduct request)
        {
            var user = HttpContext.User;
            var nameClaim = user.Claims.FirstOrDefault(c => c.Type == "Username")?.Value;


            request.CreatorUsername = nameClaim;
            var bookId = await mediator.Send(request);
            return Ok(bookId);
        }

        [Authorize(Policy = "Valid")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateProduct request)
        {
            var user = HttpContext.User;
            var nameClaim = user.Claims.FirstOrDefault(c => c.Type == "Username")?.Value;
            if (nameClaim != null)
            {
                request.CreatorUsername = nameClaim;
                request.Id = id;
                await mediator.Send(request);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(Policy = "Valid")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var user = HttpContext.User;
            var nameClaim = user.Claims.FirstOrDefault(c => c.Type == "Username")?.Value;


            var request = new DeleteProduct { Id = id };
            request.CreatorUsername = nameClaim;
            await mediator.Send(request);
            return Ok();
        }


    }
}
