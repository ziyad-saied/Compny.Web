using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services.Department
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void Add(Data.Entities.Department department)
        {
            throw new NotImplementedException();
        }

        public void Delete(Data.Entities.Department department)
        {
            throw new NotImplementedException();
        }

        public ICollection<Data.Entities.Department> GetAll()
        {
            var departments = _departmentRepository.GetAll();
            return departments;
        }

        public Data.Entities.Department GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Data.Entities.Department department)
        {
            throw new NotImplementedException();
        }
    }
}
