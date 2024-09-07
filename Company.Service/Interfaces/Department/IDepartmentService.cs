using Company.Data.Entities;
using Company.Service.Interfaces.Department.DepartmentDto;

namespace Company.Service.Interfaces
{
    public interface IDepartmentService
    {
        DepartmentDto GetById(int? id);
        ICollection<DepartmentDto> GetAll();
        void Add(DepartmentDto department);
        void Update(DepartmentDto department);
        void Delete(DepartmentDto department);
    }
}
