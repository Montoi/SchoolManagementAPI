using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.Models.Dto
{
    public class StudentCreateDto
    {
       
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public int age { get; set; }
    }
}
