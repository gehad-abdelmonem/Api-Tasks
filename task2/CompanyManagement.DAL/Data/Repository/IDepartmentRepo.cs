using CompanyManagement.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DAL.Data.Repository
{
    public interface IDepartmentRepo
    {
        List<Department> GetAll();
        Department GetById(int id);
        void Update(Department department);
        bool Delete(int id);
        Department GetByIdWithTicketsAndDevelopers(int id);
        void SaveChange();
    }
}
