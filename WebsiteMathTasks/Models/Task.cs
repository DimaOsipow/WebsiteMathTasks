using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteMathTasks.Models
{
    public class Task 
    {   
        public int Id { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }
        public string Theme { get; set; }
        public string Tag { get; set; }
        public string img { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Answer { get; set; }
        public string SecondAnswer{ get; set; }
        public string ThirdAnswer { get; set; }
        public List<UserAnswerModel> UserAnswerModels { get; set; } = new List<UserAnswerModel>();
        public List<IndexViewModel> IndexViewModels { get; set; } = new List<IndexViewModel>();

    }
}
