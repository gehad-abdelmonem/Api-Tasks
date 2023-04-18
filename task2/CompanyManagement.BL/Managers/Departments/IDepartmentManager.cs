using CompanyManagement.BL.Dtos.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BL.Managers.Departments
{
    public interface IDepartmentManager
    {
        DepartmentDetailsDto GetByIdWithDetails(int id);
    }
}
