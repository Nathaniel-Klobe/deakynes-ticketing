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
            CreateMap<Ticket, TicketReadDto>();

            CreateMap<TicketCreateDto, Ticket>();

            CreateMap<TicketUpdateDto, Ticket>();

            CreateMap<Ticket, TicketUpdateDto>();
        }
    }
}
