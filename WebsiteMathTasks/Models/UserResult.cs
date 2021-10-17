using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteMathTasks.Models
{
    public class UserResult
    {
        public int Id { get; set; }
        public string User { get; set; }
        public int TaskNumber { get; set; }
        public int AnswerCorrectNumber { get; set; }

    }
}
