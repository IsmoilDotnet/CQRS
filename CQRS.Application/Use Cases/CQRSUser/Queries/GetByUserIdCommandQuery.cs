using CQRS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Use_Cases.CQRSUser.Queries
{
    public class GetByUserIdCommandQuery : IRequest<User>
    {
        public Guid Id { get; set; }
    }
}
