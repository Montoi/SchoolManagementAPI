using SchoolManagementAPI.Data;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Repository.IRepository;

namespace SchoolManagementAPI.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly AplicationDbContext _db;

        public StudentRepository(AplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Student> UpdateAsync(Student entity)
        {
            entity.LastModifiedDate = DateTime.Now;
            _db.Students.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
