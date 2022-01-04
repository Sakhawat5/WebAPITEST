using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Interface;
using WebAPI.Data.Models;

namespace WebAPI.Data.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeService _employeeService;
        private readonly ManagementContext _context;
        public EmployeeService(ManagementContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }
        public bool CreateEmplyee(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteEmplyee(Employee employee)
        {
            var getEmployee = GetEmployeeById(employee.EmpCode);
            _context.Remove(getEmployee);
            _context.SaveChanges();
            return true;
        }

        public List<Employee> GetAll()
        {
            return _context.Employee.ToList();

        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employee.FirstOrDefault(x => x.EmpCode == id);
            
        }

        public bool UpdateEmplyee(Employee employee)
        {
            var getEmployee = GetEmployeeById(employee.EmpCode);
            _context.Employee.Update(employee);
            return true;
        }
    }
}
