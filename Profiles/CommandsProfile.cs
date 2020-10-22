using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Dto;
using Commander.Models;
using AutoMapper;

namespace Commander.Profiles
{
    public class CommandsProfile: Profile
    {
        public CommandsProfile()
        {
            // Source -> Target
            CreateMap<Command, CommandResponseDto>();
            CreateMap<CommandRequestDto, Command>();
            CreateMap<Command, CommandRequestDto>();
        }
    }
}
