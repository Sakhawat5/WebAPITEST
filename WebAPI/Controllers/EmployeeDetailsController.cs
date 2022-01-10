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
    public class EmployeeDetailsController : ControllerBase
    {
        Db dbop = new Db();
        string msg = string.Empty;
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDetails>> Get()
        {

            EmployeeDetails ed = new EmployeeDetails();
            ed.Type = "getEmployeeDetails";
            DataSet ds = dbop.GetEmployeeDetails(ed, out msg);
            List<EmployeeDetails> empDetail = new List<EmployeeDetails>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                empDetail.Add(new EmployeeDetails
                {
                    EmpCode = Convert.ToInt32(dr["EmpCode"].ToString()),
                    EmpName = dr["EmpName"].ToString(),
                    Gender = dr["Gender"].ToString(),
                    Mobile = Convert.ToInt32(dr["Mobile"].ToString()),
                    Name = dr["Name"].ToString(),
                    Amount = Convert.ToDecimal(dr["Amount"].ToString())
                });
            }
            return empDetail;
        }
    }
}
