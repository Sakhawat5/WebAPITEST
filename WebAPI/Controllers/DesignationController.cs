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
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationService _designationService;
        private readonly ManagementContext _context;
        public DesignationController(ManagementContext context, IDesignationService designationService)
        {
            _context = context;
            _designationService = designationService;
        }
        // GET: api/<DesignationController>
        [HttpGet]
        public IEnumerable<Designation> Get()
        {
            List<Designation> designations = _designationService.GetAll().ToList();
            return designations;
        }

        // GET api/<DesignationController>/5
        [HttpGet("{id}")]
        public Designation Get(int id)
        {

            return _designationService.GetDesignationById(id);
        }

        // POST api/<DesignationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DesignationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DesignationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
