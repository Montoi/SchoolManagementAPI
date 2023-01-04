using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Repository.IRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> UpdateAsync(Student entity);
    }
}
