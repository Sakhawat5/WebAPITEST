using Microsoft.AspNetCore.Mvc;
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
    public class EmployeeController : ControllerBase
    {
        Db dbop = new Db();
        string msg = string.Empty;
        // private readonly IEmployeeService _employeeService;
        private readonly ManagementContext _context;
        public EmployeeController(ManagementContext context)
        {
            _context = context;
            //_employeeService = employeeService;
        }
        // GET: api/<EmployeeApiController>

        //List<Employee> employees = new List<Employee>()
        //{
        //    new Employee(){EmpCode=1, EmpName="Nahid", Gender="Male", Mobile=01737068866, DesignationId=1, SalaryId=2},
        //    new Employee(){EmpCode=1, EmpName="Kamal", Gender="Male", Mobile=01737068877, DesignationId=2, SalaryId=2},
        //    new Employee(){EmpCode=1, EmpName="Jamal", Gender="Male", Mobile=01737068888, DesignationId=3, SalaryId=2}

        //};

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            //var employees = new List<Employee>();
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
            //List<Employee> employeeList = _employeeService.GetAll().ToList();
            //return Ok(employeeList);
        }

        //GET api/<EmployeeApiController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            var employee = _context.Employee.SingleOrDefault(x => x.EmpCode == id);
            //var emp = _employeeService.GetEmployeeById(id);
            return Ok(employee);
        }

        // POST api/<EmployeeApiController>
        [HttpPost]
        public ActionResult Post(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
            return Ok(employee);
        }

        // PUT api/<EmployeeApiController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Employee employee)
        {
            try
            {
                var oldEmployee = Get(id);
                if (oldEmployee != null)
                {
                    _context.Employee.Update(employee);
                    _context.SaveChanges();
                }
                return Ok(employee);
            }
            catch (Exception e)
            {
                throw e;                
            }
            
        }

        // DELETE api/<EmployeeApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                var employee = _context.Employee.SingleOrDefault(x => x.EmpCode == id);
                if (employee != null)
                {
                    _context.Employee.Remove(employee);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
