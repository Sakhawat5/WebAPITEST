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
    public class DesignationController : ControllerBase
    {
        //private readonly IDesignationService _designationService;
        private readonly ManagementContext _context;
        public DesignationController(ManagementContext context)
        {
            _context = context;
        }

        // GET: api/<DesignationController>
        [HttpGet]
        public ActionResult<IEnumerable<Designation>> Get()
        {
            var designation = _context.Designation.ToList();
            if (designation.Count == 0)
            {
                return NotFound("No List Found");
            }
            return Ok(designation);

            //List<Designation> designations = _designationService.GetAll().ToList();
            //return designations;
        }

        // GET api/<DesignationController>/5
        [HttpGet("{id}")]
        public Designation Get(int id)
        {

            return _context.Designation.SingleOrDefault(x=>x.Id == id);
        }

        // POST api/<DesignationController>
        [HttpPost]
        public void Post([FromBody] Designation designation)
        {
            _context.Designation.Add(designation);
            _context.SaveChanges();
        }

        // PUT api/<DesignationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Designation designation)
        {
            var  designations = _context.Designation.SingleOrDefault(x => x.Id == id);

        }

        // DELETE api/<DesignationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
