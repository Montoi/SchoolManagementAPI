using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.Models.Dto
{
    public class StudentsubjectsCreateDto
    {
       
        public int SpanishLanguage { get; set; }
        public int Math { get; set; }
        public int HistoryScience { get; set; }
        public int NaturalSciences { get; set; }
        public int StudentId { get; set; }
    }
}
