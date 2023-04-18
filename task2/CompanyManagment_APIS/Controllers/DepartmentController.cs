using CompanyManagement.BL.Dtos.Department;
using CompanyManagement.BL.Managers.Departments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagment_APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentManager departmentManager;
        public DepartmentController(IDepartmentManager _departmentManager)
        {
            departmentManager= _departmentManager;
        }
        [HttpGet]
        [Route("'{id}")]
        public ActionResult<DepartmentDetailsDto> GetById(int id) 
        {
            DepartmentDetailsDto department = departmentManager.GetByIdWithDetails(id);
            if(department == null)
            {
                return NotFound();
            }
            return department;
        }
    }
}
