using Company.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Compny.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentService;

        public DepartmentController(IDepartmentRepository departmentService)
        {
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var departments = _departmentService.GetAll();
            return View(departments);
        }
    }
}
