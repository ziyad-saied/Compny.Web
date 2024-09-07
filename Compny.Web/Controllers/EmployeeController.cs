﻿using Company.Data.Entities;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Employee.EmployeeDto;
using Microsoft.AspNetCore.Mvc;

namespace Compny.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService,IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult Index(string searchInp)
        {
            //ViewBag.Message = "Hello From EmployeeDto Index (ViewBag)";
            //ViewData["TextMessage"] = "Hello From EmployeeDto Index (ViewData)";

            IEnumerable<EmployeeDto> employees = new List<EmployeeDto>(); 
            if (string.IsNullOrEmpty(searchInp))
                employees = _employeeService.GetAll();
            else
                employees = _employeeService.GetEmployeeByName(searchInp);
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _departmentService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.Add(employee);
                    return RedirectToAction(nameof(Index));
                }
                return View(employee);
            }
            catch (Exception)
            {
                return View(employee);
            }
        }
    }
}
