using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Service.Services;
using Company.Data.Entities;
using Company.Service.Interfaces.Department.DepartmentDto;
using AutoMapper;

namespace Company.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(DepartmentDto departmentDto)
        {
            //var mappedDepartment = new DepartmentDto
            //{
            //    Code = department.Code,
            //    Name = department.Name,
            //    CreateAt = DateTime.Now
            //};
            var mappedDepartment = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Add(mappedDepartment);
            _unitOfWork.complete();
        }

        public void Delete(DepartmentDto departmentDto)
        {
            var mappedDepartment = _mapper.Map<Department>(departmentDto);

            _unitOfWork.DepartmentRepository.Delete(mappedDepartment);
            _unitOfWork.complete();
        }

        public ICollection<DepartmentDto> GetAll()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            var mappedDepartment = _mapper.Map<IEnumerable<DepartmentDto>>(departments);
            return (ICollection<DepartmentDto>)mappedDepartment;
        }

        public DepartmentDto GetById(int? id)
        {
            if (id is null)
                return null;
            var department = _unitOfWork.DepartmentRepository.GetById(id.Value); 
            if (department is null)
                return null;
            var mappedDepartment = _mapper.Map<DepartmentDto>(department);
            return mappedDepartment;
        }

        public void Update(DepartmentDto department)
        {
            //_unitOfWork.DepartmentRepository.Update(department);
            //_unitOfWork.complete();
        }
    }
}
