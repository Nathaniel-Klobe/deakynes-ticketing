using AutoMapper;
using Deakynes.DataAccess.Dtos;
using Deakynes.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deakynes.DataAccess.Profiles
{
    public class TicketsProfile : Profile
    {
        public TicketsProfile()
        {
            //Source -> Target
            CreateMap<Ticket, TicketReadDto>();

            //Target -> Source
            CreateMap<TicketCreateDto, Ticket>();
        }
    }
}
