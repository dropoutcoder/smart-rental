using Microsoft.AspNetCore.Mvc;
using SmartRental.Infrastructure.Database.Entities;
using SmartRental.Operations.Abstraction;
using SmartRental.Operations.Commands;

namespace SmartRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerController(ILogger<CustomerController> logger)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public ILogger<CustomerController> Logger { get; }

        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCustomer command, [FromServices] IHandler<CreateCustomer, CustomerEntity> handler)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var result = await handler.ExecuteAsync(command);

            return Created($"api/customer/{result.Id}", null);
        }
    }
}
