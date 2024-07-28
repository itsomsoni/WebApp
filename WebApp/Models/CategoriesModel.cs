using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class CategoriesModel
    {
        public int CategoryId { get; set; }

        [Required, Display(Name = "Category Name"), StringLength(100)]
        public string CategoryName { get; set; } = string.Empty;
        [ValidateNever, Display(Name = "Category Description")]
        public string CategoryDescription { get; set; } = string.Empty;
    }
}
