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
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;
        private readonly ManagementContext _context;
        public SalaryController(ManagementContext context, ISalaryService salaryService)
        {
            _context = context;
            _salaryService = salaryService;
        }
        // GET: api/<SalaryController>
        [HttpGet]
        public IEnumerable<Salary> Get()
        {
            List<Salary> salaries = _salaryService.GetAll().ToList();
            return salaries;
        }

        // GET api/<SalaryController>/5
        [HttpGet("{id}")]
        public Salary Get(int id)
        {
            return _salaryService.GetSalaryById(id);
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
