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
    }
}
