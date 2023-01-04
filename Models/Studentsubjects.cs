using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.Models
{
    public class Studentsubjects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int SpanishLanguage{ get; set; }
        public int Math { get; set;}
        public int HistoryScience { get; set; }
        public int NaturalSciences { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

    }
}
