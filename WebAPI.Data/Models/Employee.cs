using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Data.Models
{
    public class Employee
    {
        public int EmpCode { get; set; }
        public string EmpName { get; set; }
        public string Gender { get; set; }
        public int Mobile { get; set; }
        public int DesignationId { get; set; }
        public int SalaryId { get; set; }
    }
}
