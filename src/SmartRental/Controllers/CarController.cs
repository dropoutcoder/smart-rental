using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartRental.Infrastructure.Database.Entities;
using SmartRental.Operations.Abstraction;
using SmartRental.Operations.Commands;

namespace SmartRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public CarController(ILogger<CarController> logger)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public ILogger<CarController> Logger { get; }

        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCar command, [FromServices] IHandler<CreateCar, CarEntity> handler)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var result = await handler.ExecuteAsync(command);

            return Created($"api/car/{result.Id}", null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id, [FromServices] IQueryable<CarEntity> cars)
        {

            var result = await cars.SingleOrDefaultAsync(c => c.Id == id);

            return Ok(result);
        }

        [HttpGet()]
        public async Task<IActionResult> ListAsync([FromServices] IQueryable<CarEntity> cars)
        {
            var result = await cars.ToListAsync();

            return Ok(result);
        }
    }
}
