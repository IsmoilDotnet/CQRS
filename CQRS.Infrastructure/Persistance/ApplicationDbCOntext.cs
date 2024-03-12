using CQRS.Application.Abstractions;
using CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) 
        {

        }

        public DbSet<User> Users { get; set; }

    }
}
