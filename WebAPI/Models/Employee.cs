using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Employee
    {
        public int EmpCode { get; set; } = 0;
        public string EmpName { get; set; } = "";
        public string Gender { get; set; } = "";
        public int Mobile { get; set; } = 0;
        public int DesignationId { get; set; } = 0;
        public int SalaryId { get; set; } = 0;
        public string Type { get; set; } = "";
    }
}
