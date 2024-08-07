using API_Clean.Application.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Clean.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator mediator;
        public ValuesController(IMediator med)
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
    }
}
