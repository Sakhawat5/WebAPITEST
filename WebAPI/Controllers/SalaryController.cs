using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        //private readonly ISalaryService _salaryService;
        private readonly ManagementContext _context;
        public SalaryController(ManagementContext context)
        {
            _context = context;
        }

        // GET: api/<SalaryController>
        [HttpGet]
        public ActionResult<IEnumerable<Salary>> Get()
        {
            var salary = _context.Salary.ToList();
            if (salary.Count == 0)
            {
                return NotFound("No List Found");
            }
            return Ok(salary);
        }

        // GET api/<SalaryController>/5
        [HttpGet("{id}")]
        public ActionResult<Salary> Get(int id)
        {
            var salary = _context.Salary.SingleOrDefault(x => x.Id == id);
            //var emp = _employeeService.GetEmployeeById(id);
            return Ok(salary);
        }

        // POST api/<SalaryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SalaryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SalaryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
