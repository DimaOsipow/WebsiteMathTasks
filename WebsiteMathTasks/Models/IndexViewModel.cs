using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteMathTasks.Models
{
    public class IndexViewModel
    {   
        public int TaskId { get; set; }
        public Task tasks { get; set; }

        public int UserAnswerModelId { get; set; }
        public UserAnswerModel userAnswerModels { get; set; }
    }
}
