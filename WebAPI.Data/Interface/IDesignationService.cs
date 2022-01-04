using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Models;

namespace WebAPI.Data.Interface
{
    public interface IDesignationService
    {
        List<Designation> GetAll();
        bool CreateDesignation(Designation designation);
        Designation GetDesignationById(int id);
        bool UpdateDesignation(Designation designation);
        bool DeleteDesignation(Designation designation);
    }
}
