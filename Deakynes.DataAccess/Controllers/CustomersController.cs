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
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/customers
        [HttpGet]
        public ActionResult<IEnumerable<CustomerReadDto>> GetAll()
        {
            var customerItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<CustomerReadDto>>(customerItems));
        }

        //GET api/customers/{id}
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customerItem = _repository.GetCustomer(id);
            if (customerItem != null)
            {
                return Ok(_mapper.Map<CustomerReadDto>(customerItem));
            }
            return NotFound();
        }
    }
}
