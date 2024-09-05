using Company.Data.Entities;

namespace Company.Service.Interfaces
{
    public interface IDepartmentService
    {
        Department GetById(int id);
        ICollection<Department> GetAll();
        void Add(Department department);
        void Update(Department department);
        void Delete(Department department);
    }
}
