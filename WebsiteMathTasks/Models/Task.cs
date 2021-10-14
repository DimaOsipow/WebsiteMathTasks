using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteMathTasks.Models
{
    public class Task 
    {   
        public int Id { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Сondition { get; set; }
        public string theme { get; set; }
        public string tag { get; set; }
        public string img { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Answer { get; set; }
        public string SecondAnswer{ get; set; }
        public string ThirdAnswer { get; set; }
        //public int TaskRating { get; set; }
        //public IEnumerable<UserAnswerModel> userAnswerModels { get; set; }
        public List<UserAnswerModel> UserAnswerModels { get; set; } = new List<UserAnswerModel>();
        public List<IndexViewModel> IndexViewModels { get; set; } = new List<IndexViewModel>();

    }
}
