using AutoMapper;
using CQRS.Application.Use_Cases.CQRSUser.Commands;
using CQRS.Domain.Entities;
using CQRS.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
        }
    }
}
