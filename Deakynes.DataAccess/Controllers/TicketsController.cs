using AutoMapper;
using Deakynes.DataAccess.Data;
using Deakynes.DataAccess.Dtos;
using Deakynes.DataAccess.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        //PUT api/tickets/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTicket(int id, TicketUpdateDto ticket)
        {
            var ticketModelFromRepository = _repository.GetTicket(id);
            if(ticketModelFromRepository == null)
            {
                return NotFound();
            }

            _mapper.Map(ticket, ticketModelFromRepository);

            _repository.Update(ticketModelFromRepository);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/tickets/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialTicketUpdate(int id, JsonPatchDocument<TicketUpdateDto> patch)
        {
            var ticketModelFromRepository = _repository.GetTicket(id);
            if (ticketModelFromRepository == null)
            {
                return NotFound();
            }

            var ticketToPatch = _mapper.Map<TicketUpdateDto>(ticketModelFromRepository);
            patch.ApplyTo(ticketToPatch, ModelState);
            if(!TryValidateModel(ticketToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(ticketToPatch, ticketModelFromRepository);
            _repository.Update(ticketModelFromRepository);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/tickets/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTicket(int id)
        {
            var ticket = _repository.GetTicket(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _repository.Delete(ticket);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}
