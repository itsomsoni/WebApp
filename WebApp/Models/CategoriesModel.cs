using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class CategoriesModel
    {
        public int CategoryId { get; set; }

        [Required, Display(Name = "Category Name"), StringLength(100), MinLength(4, ErrorMessage = "{0} Should Be Minimum Of {1} Length."), MaxLength(100)]
        public string CategoryName { get; set; } = string.Empty;
        [Required, Display(Name = "Category Description"), StringLength(500)]
        public string CategoryDescription { get; set; } = string.Empty;
    }
}
