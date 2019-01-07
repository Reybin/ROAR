using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BussinessLayer.Services.Contracts;
using DataLayer.Dto_s;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ROAR_API.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees(int page = 1, int quantityPerPage = 10)
        {
            return Ok(Mapper.Map<IEnumerable<EmployeeDto>>(await _employeeService.GetAllEntities(page, quantityPerPage)));          
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(Guid id)
        {
            var employee = await _employeeService.GetById(id);
            if (employee != null)
            {
                return Ok(Mapper.Map<EmployeeDto>(employee));
            }
            return NotFound(id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (await _employeeService.Create(employee)) return Ok(employee);
                return BadRequest(employee);
            }

            return BadRequest(employee);
        }


    }
}