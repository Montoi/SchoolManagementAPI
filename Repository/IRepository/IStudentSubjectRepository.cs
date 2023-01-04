using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Repository.IRepository
{
    public interface IStudentSubjectRepository : IRepository<Studentsubjects>
    {
        Task<Studentsubjects> UpdateAsync(Studentsubjects entity);

    }
}
