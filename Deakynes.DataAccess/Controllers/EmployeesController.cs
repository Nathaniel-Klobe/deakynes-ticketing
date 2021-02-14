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
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/employees
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeReadDto>> GetAll()
        {
            var employeeItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<EmployeeReadDto>>(employeeItems));
        }

        //GET api/employees/{id}
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employeeItem = _repository.GetEmployee(id);
            if (employeeItem != null)
            {
                return Ok(_mapper.Map<EmployeeReadDto>(employeeItem));
            }
            return NotFound();
        }

        //POST api/employees
        [HttpPost]
        public ActionResult<EmployeeReadDto> CreateEmployee(EmployeeCreateDto employee)
        {
            var employeeModel = _mapper.Map<Employee>(employee);

            _repository.Create(employeeModel);
            _repository.SaveChanges();

            var employeeReadDto = _mapper.Map<EmployeeReadDto>(employeeModel);

            return CreatedAtRoute(nameof(GetEmployee), new { Id = employeeReadDto.EmployeeId }, employeeReadDto);
        }

        //PUT api/employees/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, EmployeeUpdateDto employee)
        {
            var employeeModelFromRepository = _repository.GetEmployee(id);
            if (employeeModelFromRepository == null)
            {
                return NotFound();
            }

            _mapper.Map(employee, employeeModelFromRepository);

            _repository.Update(employeeModelFromRepository);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/employees/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialEmployeeUpdate(int id, JsonPatchDocument<EmployeeUpdateDto> patch)
        {
            var employeeModelFromRepository = _repository.GetEmployee(id);
            if (employeeModelFromRepository == null)
            {
                return NotFound();
            }

            var employeeToPatch = _mapper.Map<EmployeeUpdateDto>(employeeModelFromRepository);
            patch.ApplyTo(employeeToPatch, ModelState);
            if (!TryValidateModel(employeeToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(employeeToPatch, employeeModelFromRepository);
            _repository.Update(employeeModelFromRepository);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/employees/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = _repository.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            _repository.Delete(employee);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
