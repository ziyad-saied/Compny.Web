using Company.Data.Entities;
using Company.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Compny.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public IActionResult Index(string searchInp)
        {
            IEnumerable<Employee> employees = new List<Employee>(); 
            if (string.IsNullOrEmpty(searchInp))
                employees = _employeeService.GetAll();
            else
                employees = _employeeService.GetEmployeeByName(searchInp);
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
