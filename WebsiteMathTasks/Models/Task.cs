using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteMathTasks.Models
{
    public class Task 
    {   
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Сondition { get; set; }

        public string theme { get; set; }

        public string tag { get; set; }

        public string img { get; set; }

        public string Name2 { get; set; }
    }
}
