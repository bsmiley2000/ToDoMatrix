using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoMatrix.Models
{
    public class TaskModel
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string Task { get; set; }
        public string Urgent { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
