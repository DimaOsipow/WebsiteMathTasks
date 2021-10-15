using System.Collections.Generic;

namespace WebsiteMathTasks.Models
{
    public class UserAnswerModel
    {
        public int Id { get; set; }
        public string UserTask { get; set; }
        public string DefendantName { get; set; }
        public string UserAnswer { get; set; }
        public bool isRightAnswer { get; set; }
        
        public List<Task> Tasks { get; set; } = new List<Task>();
        public List<IndexViewModel> IndexViewModels { get; set; } = new List<IndexViewModel>();
    }
}
