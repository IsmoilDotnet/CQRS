﻿using CQRS.Application.Use_Cases.CQRSUser.Commands;
using CQRS.Application.Use_Cases.CQRSUser.Queries;
using CQRS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            await _mediator.Send(command);

            return Ok("Malumot Yaratildi!");
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var result = await _mediator.Send(new GetAllUsersCommandQuery());

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUserById(Guid Id)
        {
            var result = await _mediator.Send(new GetByUserIdCommandQuery()
            {
                Id = Id
            });

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid Id)
        {
            await _mediator.Send(new DeleteUserCommand()
            {
                Id = Id
            });

            return Ok("Deleted");
        }

        //[HttpPut]
        //public async Task<ActionResult<User>> UpdateUser(UpdateUserCommand command)
        //{
        //    var result = await _mediator.Send(command);

        //    return Ok(result);
        //}
    }
}
