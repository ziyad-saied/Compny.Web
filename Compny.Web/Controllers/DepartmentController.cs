using Company.Data.Entities;
using Company.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        [HttpGet]
        public IActionResult Create() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _departmentService.Add(department);
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("DepartmentError", "ValidationErrors");
                return View(department);
            }
            catch (Exception)
            {
                ModelState.AddModelError("DepartmentError", "ValidationErrors");
                return View(department);
            }
        }

        public IActionResult Details(int id,string viewName="Details")
        {
            var department = _departmentService.GetById(id);

            if (department is null)
                return RedirectToAction("NotFound Page",null,"Home");
            return View(viewName,department);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return Details(id,"Update");
        }
        [HttpPost]
        public IActionResult Update(int? id,Department department)
        {
            if(department.Id != id)
                return RedirectToAction("NotFound Page", null, "Home");
            _departmentService.Update(department);

            return RedirectToAction(nameof(Index));

        }
    }
}
