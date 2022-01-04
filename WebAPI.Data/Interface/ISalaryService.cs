using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Models;

namespace WebAPI.Data.Interface
{
    public interface ISalaryService
    {
        List<Salary> GetAll();
        bool CreateSalary(Salary Salary);
        Salary GetSalaryById(int id);
        bool UpdateSalary(Salary Salary);
        bool DeleteSalary(Salary Salary);
    }
}
