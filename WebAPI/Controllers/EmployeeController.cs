using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Data.Interface;
using WebAPI.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ManagementContext _context;
        public EmployeeController(ManagementContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }
        // GET: api/<EmployeeApiController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            List<Employee> employeeList = _employeeService.GetAll().ToList();
            return employeeList;
        }

        // GET api/<EmployeeApiController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            
            return _employeeService.GetEmployeeById(id);
        }

        // POST api/<EmployeeApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeeApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
