using CQRS.Domain.Entities;
using CQRS.Domain.Entities.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Use_Cases.CQRSUser.Commands
{
    public class UpdateUserCommand : UserDTO, IRequest<User>
    {
        public Guid Id { get; set; }
    }
}
