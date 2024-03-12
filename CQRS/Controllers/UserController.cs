using CQRS.Application.Use_Cases.CQRSUser.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            await _mediator.Send(command);

            return Ok("Malumot Yaratildi!");
        }
    }
}
