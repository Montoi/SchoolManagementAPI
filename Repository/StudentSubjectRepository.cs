using SchoolManagementAPI.Data;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Repository.IRepository;

namespace SchoolManagementAPI.Repository
{
    public class StudentSubjectRepository : Repository<Studentsubjects>, IStudentSubjectRepository
    {
        private readonly AplicationDbContext _db;

        public StudentSubjectRepository(AplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Studentsubjects> UpdateAsync(Studentsubjects entity)
        {
            entity.LastModifiedDate  = DateTime.Now;
            _db.StudentSubjects.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
