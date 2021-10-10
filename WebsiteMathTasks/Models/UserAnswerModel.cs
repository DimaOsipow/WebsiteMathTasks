using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteMathTasks.Models
{
    public class UserAnswerModel
    {
        public int Id { get; set; }
        public string UserTask { get; set; }
        public string DefendantName { get; set; }
        public string UserAnswer { get; set; }
        public bool isRightAnswer { get; set; }
        //public IEnumerable<Task> tasks { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
        public List<IndexViewModel> IndexViewModels { get; set; } = new List<IndexViewModel>();
    }
}
