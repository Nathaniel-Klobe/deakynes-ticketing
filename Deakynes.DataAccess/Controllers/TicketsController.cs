using AutoMapper;
using Deakynes.DataAccess.Data;
using Deakynes.DataAccess.Dtos;
using Deakynes.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deakynes.DataAccess.Controllers
{

    [Route("api/tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _repository;
        private readonly IMapper _mapper;

        public TicketsController(ITicketRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/tickets
        [HttpGet]
        public ActionResult<IEnumerable<TicketReadDto>> GetAll()
        {
            var ticketItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<TicketReadDto>>(ticketItems));
        }

        //GET api/tickets/{id}
        [HttpGet("{id}", Name="GetTicket")]
        public ActionResult<TicketReadDto> GetTicket(int id)
        {
            var ticketItem = _repository.GetTicket(id);
            if(ticketItem != null)
            {
                return Ok(_mapper.Map<TicketReadDto>(ticketItem));
            }
            return NotFound();
        }

        //POST api/tickets
        [HttpPost]
        public ActionResult<TicketReadDto> CreateTicket(TicketCreateDto ticket)
        {
            var ticketModel = _mapper.Map<Ticket>(ticket);

            _repository.Create(ticketModel);
            _repository.SaveChanges();

            var ticketReadDto = _mapper.Map<TicketReadDto>(ticketModel);



            return CreatedAtRoute(nameof(GetTicket), new { Id = ticketReadDto.TicketId }, ticketReadDto);
        }
    }
}
