using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViweOutputController : ControllerBase
    {
        Db dbop = new Db();
        string msg = string.Empty;
        private readonly ManagementContext _context;
        public ViweOutputController(ManagementContext context)
        {
            _context = context;
            //_employeeService = employeeService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDetails>> Get()
        {
            
            EmployeeDetails ed = new EmployeeDetails();
            ed.Type = "get";
            DataSet ds = dbop.EmployeeDetailsGet(ed, out msg);
            List<EmployeeDetails> empDetail = new List<EmployeeDetails>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                empDetail.Add(new EmployeeDetails
                {
                    EmpName = dr["EmpName"].ToString(),
                    Gender = dr["Gender"].ToString(),
                    Mobile =Convert.ToInt32(dr["Mobile"].ToString()),
                    Designation = Convert.ToInt32(dr["Designation"].ToString()),
                    Salary = Convert.ToInt32(dr["Salary"].ToString())
                });
            }
            return empDetail;
            //string empName = "Amy";
            //try
            //{
            //    var d = _context.EmployeeDetails.FromSqlRaw($"exec [dbo].[SP_GetEmployeeDescription] @empName={empName}");
            //    return Ok(d);
            //}
            //catch (Exception e)
            //{
            //    throw;
            //}
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
