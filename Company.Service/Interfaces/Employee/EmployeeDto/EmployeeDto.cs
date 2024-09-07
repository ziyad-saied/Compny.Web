﻿using Company.Service.Interfaces.Department.DepartmentDto;

namespace Company.Service.Interfaces.Employee.EmployeeDto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public string ImageUrl { get; set; }
        public DepartmentDto Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}
