﻿using Microsoft.AspNetCore.Mvc;
using SmartRental.Infrastructure.Database.Entities;
using SmartRental.Operations.Abstraction;
using SmartRental.Operations.Commands;

namespace SmartRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        public RentalController(ILogger<RentalController> logger)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public ILogger<RentalController> Logger { get; }

        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRental command, [FromServices] IHandler<CreateRental, RentalEntity> handler)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var result = await handler.ExecuteAsync(command);

            return Created($"api/customer/{result.Id}", null);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> CreateAsync([FromRoute]int id, [FromServices] IHandler<CancelRental, RentalEntity> handler)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var result = await handler.ExecuteAsync(new CancelRental { RentalId = id });

            return Ok(result);
        }
    }
}