
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table(name: "CourseMaster")]
    public class CourseModel
    {
        [Key]
        public int CourseId { get; set; }
        [Required, Display(Name = "Course Name"), StringLength(50)]
        public string CourseName { get; set; }
        [StringLength(200), Display(Name = "Course Description")]
        public string CourseDescription { get; set; } = string.Empty;
        public DateTime SysDate { get; set; } = DateTime.Now;
    }
}
