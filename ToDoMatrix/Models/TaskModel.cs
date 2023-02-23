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
        [Required]
        public int TaskId { get; set; }

        [Required]
        public string Task { get; set; }

        [Required]
        public string Urgent { get; set; }

        public bool Completed { get; set; }
        public DateTime Date { get; set; }


        // Build foreign key relationship

        [Required]

        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
