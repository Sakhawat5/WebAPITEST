using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Interface;
using WebAPI.Data.Models;

namespace WebAPI.Data.Service
{
    public class DesignationService : IDesignationService
    {
        private readonly IDesignationService _DesignationService;
        private readonly ManagementContext _context;
        public DesignationService(ManagementContext context, IDesignationService DesignationService)
        {
            _context = context;
            _DesignationService = DesignationService;
        }

        public bool CreateDesignation(Designation Designation)
        {
            _context.Designation.Add(Designation);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteDesignation(Designation Designation)
        {
            var getDesignation = GetDesignationById(Designation.Id);
            _context.Remove(getDesignation);
            _context.SaveChanges();
            return true;
        }

        public List<Designation> GetAll()
        {
            return _context.Designation.ToList();

        }

        public Designation GetDesignationById(int id)
        {
            return _context.Designation.FirstOrDefault(x => x.Id == id);

        }

        public bool UpdateDesignation(Designation Designation)
        {
            var getDesignation = GetDesignationById(Designation.Id);
            _context.Designation.Update(Designation);
            return true;
        }

    }
}
