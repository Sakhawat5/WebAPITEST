using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DB;
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
        //EmpDb context = new EmpDb();
        string msg = string.Empty;
        private readonly ManagementContext _context;
        public ViweOutputController(ManagementContext context)
        {
            _context = context;
            //_employeeService = employeeService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {

            Employee ed = new Employee();
            ed.Type = "get";
            DataSet ds = dbop.GetEmployee(ed, out msg);
            List<Employee> empDetail = new List<Employee>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                empDetail.Add(new Employee
                {
                    EmpCode = Convert.ToInt32(dr["EmpCode"].ToString()),
                    EmpName = dr["EmpName"].ToString(),
                    Gender = dr["Gender"].ToString(),
                    Mobile = Convert.ToInt32(dr["Mobile"].ToString()),
                    DesignationId = Convert.ToInt32(dr["DesignationId"].ToString()),
                    SalaryId = Convert.ToInt32(dr["SalaryId"].ToString())
                });
            }
            return empDetail;
        }

        // GET: api/<ValuesController>
        //[HttpGet]
        //public ActionResult<IEnumerable<Employees>> Get()
        //{

        //    Employees ed = new Employees();
        //    ed.type = "get";
        //    DataSet ds = context.EmployeeDetailsGet(ed, out msg);
        //    List<Employees> empDetail = new List<Employees>();
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        empDetail.Add(new Employees
        //        {
        //            ID = Convert.ToInt32(dr["ID"].ToString()),
        //            Email = dr["Email"].ToString(),
        //            Emp_Name = dr["Emp_Name"].ToString(),
        //            Designation = dr["Designation"].ToString()
        //        });
        //    }
        //    return empDetail;
        //}

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
