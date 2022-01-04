using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Interface;
using WebAPI.Data.Models;

namespace WebAPI.Data.Service
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryService _SalaryService;
        private readonly ManagementContext _context;
        public SalaryService(ManagementContext context, ISalaryService SalaryService)
        {
            _context = context;
            _SalaryService = SalaryService;
        }

        public bool CreateSalary(Salary Salary)
        {
            _context.Salary.Add(Salary);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteSalary(Salary Salary)
        {
            var getSalary = GetSalaryById(Salary.Id);
            _context.Remove(getSalary);
            _context.SaveChanges();
            return true;
        }

        public List<Salary> GetAll()
        {
            return _context.Salary.ToList();

        }

        public Salary GetSalaryById(int id)
        {
            return _context.Salary.FirstOrDefault(x => x.Id == id);

        }

        public bool UpdateSalary(Salary Salary)
        {
            var getSalary = GetSalaryById(Salary.Id);
            _context.Salary.Update(Salary);
            return true;
        }

    }
}
