using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Models;

namespace WebAPI.Data.Interface
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        bool CreateEmplyee(Employee employee);
        Employee GetEmployeeById(int id);
        bool UpdateEmplyee(Employee employee);
        bool DeleteEmplyee(Employee employee);
    }
}
