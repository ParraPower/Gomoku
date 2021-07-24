using AutoMapper;
using Gomoku.Data.Entities;
using Gomoku.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gomoku.Logic.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, User>()
                .ReverseMap();
        }
    }
}
