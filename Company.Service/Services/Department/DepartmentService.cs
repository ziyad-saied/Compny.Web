﻿using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Service.Services;
using Company.Data.Entities;

namespace Company.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void Add(Department department)
        {
            var mappedDepartment = new Department
            {
                Code = department.Code,
                Name = department.Name,
                CreateAt = DateTime.Now
            };
            _departmentRepository.Add(mappedDepartment);
        }

        public void Delete(Department department)
        {
            throw new NotImplementedException();
        }

        public ICollection<Department> GetAll()
        {
            var departments = _departmentRepository.GetAll();
            return departments;
        }

        public Department GetById(int? id)
        {
            if (id is null)
                return null;
            var department = _departmentRepository.GetById(id.Value); 
            if (department is null)
                return null;
            return department;
        }

        public void Update(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
