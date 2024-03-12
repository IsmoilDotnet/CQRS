using CQRS.Application.Abstractions;
using CQRS.Application.Use_Cases.CQRSUser.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Use_Cases.CQRSUser.Handlers
{
    public class DeleteUserCommandHandler : AsyncRequestHandler<DeleteUserCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteUserCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

            _dbContext.Users.Remove(user);

            await _dbContext.SaveChangesAsync();
        }
    }
}
