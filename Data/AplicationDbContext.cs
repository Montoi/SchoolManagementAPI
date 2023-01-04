using Microsoft.EntityFrameworkCore;
using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) :base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Studentsubjects> StudentSubjects { get; set; }
    }
}
