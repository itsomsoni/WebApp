using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; } = 0;

        [Required, Display(Name = "Student Name"), StringLength(50)]
        public string StudentName { get; set; } = string.Empty;
        [Required, Display(Name = "Student Email"), EmailAddress]
        public string StudentEmail { get; set; } = string.Empty;
        [Required, Display(Name = "Student Phone"), RegularExpression(pattern: "^[6,7,8,9]{1}[0-9]{9}$", ErrorMessage = "{0} should contain proper Phone no.")]
        public long StudentPhone { get; set; } = 0;
        public string StudentAddress { get; set; } = string.Empty;
    }
}
