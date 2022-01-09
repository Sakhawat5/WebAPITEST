using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModel
{
    [Keyless]
    public class EmployeeDetails
    {
        public int EmpCode { get; set; } = 0;
        public string EmpName { get; set; } = "";
        public string Gender { get; set; } = "";
        public int Mobile { get; set; } = 0;
        public string Name { get; set; } = "";
        public Decimal Amount { get; set; } = 0;
        public string Type { get; set; } = "";
    }
}
