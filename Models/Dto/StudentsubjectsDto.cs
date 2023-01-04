using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementAPI.Models.Dto
{
    public class StudentsubjectsDto
    {
        public int ID { get; set; }
        public int SpanishLanguage { get; set; }
        public int Math { get; set; }
        public int HistoryScience { get; set; }
        public int NaturalSciences { get; set; }
        public int StudentId { get; set; }
    }
}
