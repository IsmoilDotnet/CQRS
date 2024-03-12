using AutoMapper;
using CQRS.Application.Abstractions;
using CQRS.Application.Use_Cases.CQRSUser.Commands;
using CQRS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Use_Cases.CQRSUser.Handlers
{
    public class UpdateUserCommandHandler(IApplicationDbContext _dbContext, IMapper _mapper) : IRequestHandler<UpdateUserCommand, User>
    {
        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (user is not null)
            {
                user.ModifiedDate = DateTime.UtcNow;
                user.Name = request.Name;
                user.Email = request.Email;
                user.UserName = request.UserName;
                user.Bio = request.Bio;
                user.PhotoPath = request.PhotoPath;
                user.FollowersCount = request.FollowersCount;
                user.Login = request.Login;
                user.PasswordHash = request.PasswordHash;

                await _dbContext.SaveChangesAsync(cancellationToken);

                return user;
            }

            return null;
        }
    }
}
