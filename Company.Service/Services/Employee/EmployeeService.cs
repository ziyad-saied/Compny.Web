using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Employee.EmployeeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(EmployeeDto employeeDto)
        {
            Employee employee = new Employee()
            {
                Address = employeeDto.Address,
                Age = employeeDto.Age,
                DepartmentId = employeeDto.DepartmentId,
                Email = employeeDto.Email,
                HiringDate = employeeDto.HiringDate,
                ImageUrl = employeeDto.ImageUrl,
                Name = employeeDto.Name,
                PhoneNumber = employeeDto.PhoneNumber,
                Salary = employeeDto.Salary
            };
            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.complete();
        }

        public void Delete(EmployeeDto employeeDto)
        {
            Employee employee = new Employee()
            {
                Address = employeeDto.Address,
                Age = employeeDto.Age,
                DepartmentId = employeeDto.DepartmentId,
                Email = employeeDto.Email,
                HiringDate = employeeDto.HiringDate,
                ImageUrl = employeeDto.ImageUrl,
                Name = employeeDto.Name,
                PhoneNumber = employeeDto.PhoneNumber,
                Salary = employeeDto.Salary
            };
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.complete();
        }

        public ICollection<EmployeeDto> GetAll()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            var mappedEmployees = employees.Select(x => new EmployeeDto
            {
                DepartmentId = x.DepartmentId,
                Email = x.Email,
                HiringDate = x.HiringDate,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                Salary = x.Salary
                ,Id = x.Id,
                Address = x.Address,
                Age = x.Age,
            });
            return (ICollection<EmployeeDto>)mappedEmployees;
        }

        public EmployeeDto GetById(int? id)
        {
            if (id is null)
                return null;
            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);
            if (employee is null)
                return null;
            EmployeeDto employeeDto = new EmployeeDto()
            {
                Address = employee.Address,
                Age = employee.Age,
                DepartmentId = employee.DepartmentId,
                Email = employee.Email,
                HiringDate = employee.HiringDate,
                ImageUrl = employee.ImageUrl,
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                Id = employee.Id
            };
            return employeeDto;
        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
            var employees=_unitOfWork.EmployeeRepository.GetEmployeeByName(name);
            var mappedEmployees = employees.Select(x => new EmployeeDto
            {
                DepartmentId = x.DepartmentId,
                Email = x.Email,
                HiringDate = x.HiringDate,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                Salary = x.Salary
                ,
                Id = x.Id,
                Address = x.Address,
                Age = x.Age,
            });
            return (ICollection<EmployeeDto>)mappedEmployees;

        }

        public void Update(EmployeeDto employee)
        {
//            _unitOfWork.EmployeeRepository.Update(employee);
            _unitOfWork.complete();
        }
    }
}
