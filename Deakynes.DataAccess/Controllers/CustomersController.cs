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

        //POST api/customers
        [HttpPost]
        public ActionResult<CustomerReadDto> CreateCustomer(CustomerCreateDto customer)
        {
            var customerModel = _mapper.Map<Customer>(customer);

            _repository.Create(customerModel);
            _repository.SaveChanges();

            var customerReadDto = _mapper.Map<CustomerReadDto>(customerModel);

            return CreatedAtRoute(nameof(customerModel), new { Id = customerReadDto.CustomerId }, customerReadDto);
        }

        //PUT api/customer/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, CustomerUpdateDto customer)
        {
            var customerModelFromRepository = _repository.GetCustomer(id);
            if (customerModelFromRepository == null)
            {
                return NotFound();
            }

            _mapper.Map(customer, customerModelFromRepository);

            _repository.Update(customerModelFromRepository);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/customer/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCustomerUpdate(int id, JsonPatchDocument<CustomerUpdateDto> patch)
        {
            var customerModelFromRepository = _repository.GetCustomer(id);
            if (customerModelFromRepository == null)
            {
                return NotFound();
            }

            var customerToPatch = _mapper.Map<CustomerUpdateDto>(customerModelFromRepository);
            patch.ApplyTo(customerToPatch, ModelState);
            if (!TryValidateModel(customerToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(customerToPatch, customerModelFromRepository);
            _repository.Update(customerModelFromRepository);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/customer/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customer = _repository.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }

            _repository.Delete(customer);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
