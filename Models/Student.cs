using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int age { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set;}
    }
}
