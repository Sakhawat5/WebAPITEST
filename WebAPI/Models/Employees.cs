using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Employees
    {
        public int ID { get; set; } = 0;
        public string Email { get; set; } = "";
        public string Emp_Name { get; set; } = "";
        public string Designation { get; set; } = "";
        public string type { get; set; } = "";
    }
}
