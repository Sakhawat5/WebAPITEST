using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<IEnumerable<Employee>> Get(int id)
        {
            Employee employee = new Employee();
            employee.EmpCode = id;
            employee.Type = "getId";
            DataSet dataSet = dbop.GetEmployee(employee, out msg);
            List<Employee> employees = new List<Employee>();
            foreach (DataRow dr in dataSet.Tables[0].Rows)
            {
                employees.Add(new Employee
                {
                    EmpCode = Convert.ToInt32(dr["EmpCode"]),
                    EmpName = dr["EmpName"].ToString(),
                    Gender = dr["Gender"].ToString(),
                    Mobile = Convert.ToInt32(dr["Mobile"]),
                    DesignationId = Convert.ToInt32(dr["DesignationId"]),
                    SalaryId = Convert.ToInt32(dr["SalaryId"])
                });
            }
            //var emp = _employeeService.GetEmployeeById(id);
            return employees;
        }

        // POST api/<EmployeeApiController>
        [HttpPost]
        public string Post([FromBody] Employee employee)
        {
            string msg = string.Empty;
            try
            {
                msg = dbop.EmployeeOpt(employee);
            }
            catch (Exception ex)
            {

                msg = ex.Message;
            }
            return msg;
        }

        // PUT api/<EmployeeApiController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Employee employee)
        {
            try
            {
                employee.EmpCode = id;
                msg = dbop.EmployeeOpt(employee);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // DELETE api/<EmployeeApiController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            Employee employee = new Employee();
            try
            {
                employee.EmpCode = id;
                employee.Type = "delete";
                msg = dbop.EmployeeOpt(employee);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
